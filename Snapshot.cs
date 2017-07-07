using System;
using System.Diagnostics;
using Alphaleonis.Win32.Vss;


namespace LGCBackup
{
    //this class works with Snapshots
    class Snapshot : IDisposable
    {
        IVssBackupComponents thisBackup;
        VssSnapshotProperties thisProps;
        Guid _set_id;
        Guid _snap_id;

        public Snapshot(IVssBackupComponents backup)
        {
            thisBackup = backup;
            _set_id = backup.StartSnapshotSet();
        }

        public void AddVolume(string volumeName)
        {
            Debug.Write("Adding volume");
            if (thisBackup.IsVolumeSupported(volumeName))
                _snap_id = thisBackup.AddToSnapshotSet(volumeName);
            else
                throw new VssVolumeNotSupportedException(volumeName);
        }

        public void Copy()
        {
            thisBackup.DoSnapshotSet();
        }

        // get rid of Snapshots


        public void Delete()
        {
            thisBackup.DeleteSnapshotSet(_set_id, false);
        }

        public string Root
        {
            get
            {
                if (thisProps == null)
                {
                    thisProps = thisBackup.GetSnapshotProperties(_snap_id);
                }
                return thisProps.SnapshotDeviceObject;
            }
        }


        public void Dispose()
        {
            try { Delete(); } catch { }
        }
    }
}
