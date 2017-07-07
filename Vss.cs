using System;
using System.Collections.Generic;
using Alphaleonis.Win32.Vss;
using Alphaleonis.Win32.Filesystem;
using System.Diagnostics;

namespace LGCBackup
{
    public class Vss : IDisposable
    {
        private IVssBackupComponents thisBackup;
        Snapshot thisSnap;
        private static string v_assembly;
        bool ComponentMode = false;

        public Vss()
        {
            Debug.WriteLine("Initializing backup!");
            InitializeBackup();
        }

        public void Setup(string volumeName)
        {
            Debug.WriteLine("Initializing setup!");
            Discovery(volumeName);
            Debug.WriteLine("Working with volume " + volumeName);
            PreBackup();
            Debug.WriteLine("Moving to PreBackup");
        }

        public void Dispose()
        {
            try { Complete(true); } catch { }

            if (thisSnap != null)
            {
                thisSnap.Dispose();
                thisSnap = null;
            }

            if (thisBackup != null)
            {
                thisBackup.Dispose();
                thisBackup = null;
            }
        }

        void InitializeBackup()
        {
            IVssImplementation vss = VssUtils.LoadImplementation();
            Debug.WriteLine("vss interface implementation called - vssutils.loadimplementation() called");
            thisBackup = vss.CreateVssBackupComponents();
            Debug.WriteLine("backup component created");
            //try
            //{
            thisBackup.InitializeForBackup(null);
            thisBackup.GatherWriterMetadata();
            //}
            //catch (Alphaleonis.Win32.Vss.VssUnexpectedErrorException ue)
            //{
            //    Debug.WriteLine("AlphaVss Unexpected Error: " + ue);
            // }


        }

        void Discovery(string fullPath)
        {
            if (ComponentMode)
                ExamineComponents(fullPath);
            else
                thisBackup.FreeWriterMetadata();

            thisSnap = new Snapshot(thisBackup);
            thisSnap.AddVolume(Path.GetPathRoot(fullPath));
        }

        void ExamineComponents(string fullPath)
        {
            IList<IVssExamineWriterMetadata> writer_mds = thisBackup.WriterMetadata;

            foreach (IVssExamineWriterMetadata md in writer_mds)
            {
                Trace.WriteLine("Eaxmining metadata for " + md.WriterName);
                foreach (IVssWMComponent cmp in md.Components)
                {
                    Trace.WriteLine(" Component: " + cmp.ComponentName);
                    Trace.WriteLine(" Component info: " + cmp.Caption);

                    foreach (VssWMFileDescriptor file in cmp.Files)
                    {
                        Trace.WriteLine("     Path: " + file.Path);
                        Trace.WriteLine("        Spec: " + file.FileSpecification);
                    }
                }
            }
        }

        void PreBackup()
        {
            Debug.Assert(thisSnap != null);

            // AF - this is what determines the backup type
            // Options include 'Full', 'Incremental', 'Differential' - 'Full' is likely the most ideal for now
            thisBackup.SetBackupState(ComponentMode, true, VssBackupType.Full, false);

            thisBackup.PrepareForBackup();

            thisSnap.Copy();
        }

        // check loaded assembly - for debugging only

        public static string LoadedAssembly
        {
            get
            {
                v_assembly = VssUtils.GetPlatformSpecificAssemblyName().Name;
                return v_assembly;
            }
        }

        public string GetSnapshotPath(string localPath)
        {
            Console.WriteLine("New volume: " + thisSnap.Root);
            if (Path.IsPathRooted(localPath))
            {
                string root = Path.GetPathRoot(localPath);
                localPath = localPath.Replace(root, String.Empty);
            }
            string slash = Path.DirectorySeparatorChar.ToString();
            if (!thisSnap.Root.EndsWith(slash) && !localPath.StartsWith(slash))
            {
                localPath = localPath.Insert(0, slash);
            }
            localPath = localPath.Insert(0, thisSnap.Root);

            Console.WriteLine("Converted path: " + localPath);

            return localPath;

        }

        public System.IO.Stream GetStream(string localPath)
        {
            // GetSnapshotPath() returns a very funky-looking path.  The
            // System.IO methods can't handle these sorts of paths, so instead
            // we're using AlphaFS, another excellent library by Alpha Leonis.
            // Note that we have no 'using System.IO' at the top of the file.
            // (The Stream it returns, however, is just a System.IO stream.)
            return File.OpenRead(GetSnapshotPath(localPath));
        }

        string FileToPathSpecification(VssWMFileDescriptor file)
        {
            // Environment variables (eg. "%windir%") are common.
            string path = Environment.ExpandEnvironmentVariables(file.Path);

            // Use the alternate location if it's present.
            if (!String.IsNullOrEmpty(file.AlternateLocation))
                path = Environment.ExpandEnvironmentVariables(
                    file.AlternateLocation);

            // Normalize wildcard usage.
            string spec = file.FileSpecification.Replace("*.*", "*");

            // Combine the file specification and the directory name.
            return Path.Combine(path, file.FileSpecification);
        }

        void Complete(bool succeeded)
        {
            if (ComponentMode)
            {
                // As before, we iterate through all of the writers on the system.
                // A more efficient method might only iterate through those writers
                // that were actually involved in this backup.
                IList<IVssExamineWriterMetadata> writers = thisBackup.WriterMetadata;
                foreach (IVssExamineWriterMetadata metadata in writers)
                {
                    foreach (IVssWMComponent component in metadata.Components)
                    {
                        // The BackupSucceeded call should mirror the AddComponent
                        // call that was called during the discovery phase.
                        thisBackup.SetBackupSucceeded(
                            metadata.InstanceId, metadata.WriterId,
                            component.Type, component.LogicalPath,
                            component.ComponentName, succeeded);
                    }
                }

                // Finally, we can dispose of the writer metadata.
                thisBackup.FreeWriterMetadata();
            }

            try
            {
                // The BackupComplete event must be sent to all of the writers.
                thisBackup.BackupComplete();
            }
            // Not sure why, but this throws a VSS_BAD_STATE on XP and W2K3.
            // Per some forum posts about this, I'm just ignoring it.
            catch (VssBadStateException) { }
        }


    }
}
