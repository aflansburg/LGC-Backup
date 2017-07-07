using System;
using System.Collections.Generic;
using System.Diagnostics;
using LGCBackup;

namespace LGC_Backup
{
    // Class for working with the AlphaVSS classes - Snapshot & Vss
    class VssHelper
    {
        public static void StartSnapshot(string jobFilePath)
        {

            JobFile job = JobFile.ReadJobFile(jobFilePath);

            string snapshotPath;

            Console.WriteLine("\nJob File Details");
            Console.WriteLine("################");

            Console.WriteLine("\nSources:");
            foreach (string s in job.SourceDirectories)
            {
                Console.WriteLine($"{s}");
            }

            Console.WriteLine("\nDestinations:");
            foreach (string d in job.DestinationDirectories)
            {
                Console.WriteLine($"{d}");
            }
            
            int jobCount = 0;

            foreach (string s in job.SourceDirectories)
            {
                // Debug.WriteLine
                jobCount++;

                Console.WriteLine($"\nStarting operation {jobCount} of {job.SourceDirectories.Count}");

                try
                {
                    Console.WriteLine("\nCreating Vss object.....");

                    using (Vss vss = new Vss())
                    {
                        Console.WriteLine($"\nGetting snapshot path for {s}.....");

                        snapshotPath = vss.GetSnapshotPath(s);

                        Console.WriteLine($"\nSnapshot path = {snapshotPath}");

                        vss.Setup(Alphaleonis.Win32.Filesystem.Path.GetPathRoot(s));

                        Console.Write($"\nPath Root = {Alphaleonis.Win32.Filesystem.Path.GetPathRoot(s)}");

                        Console.WriteLine($"\nSnapshot path is: {snapshotPath}");

                        foreach (string destination in job.DestinationDirectories)
                        {
                            try
                            {
                                Console.WriteLine("\nCopying from snapshot to storage destination.");
                                string rawBackupPath = Alphaleonis.Win32.Filesystem.Path.GetFileName(s);
                                string fullBackupPath =
                                    Alphaleonis.Win32.Filesystem.Path.Combine(destination, rawBackupPath);
                                if (Alphaleonis.Win32.Filesystem.Directory.Exists(fullBackupPath))
                                {
                                    // gets rid of the previous backup if exists ^^ <-- is this redundant to the following block???
                                    Alphaleonis.Win32.Filesystem.Directory.Delete(fullBackupPath, true, true);
                                    Alphaleonis.Win32.Filesystem.Directory.CreateDirectory(fullBackupPath);
                                    Alphaleonis.Win32.Filesystem.Directory.Copy(snapshotPath, fullBackupPath, true);
                                }
                                else
                                {
                                    Alphaleonis.Win32.Filesystem.Directory.CreateDirectory(fullBackupPath);
                                    Alphaleonis.Win32.Filesystem.Directory.Copy(snapshotPath, fullBackupPath, true);
                                }

                                Console.WriteLine("\nBackup completed.");
                            }
                            catch (UnauthorizedAccessException e)
                            {
                                // log event
                                Console.WriteLine($"\nUnauthorized exception: {e}");
                            }
                        }
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine($"\nError: {e}");
                    Debug.WriteLine("\nError when trying to create Vss:" + e);
                }
                
            }
        }


    }
}
