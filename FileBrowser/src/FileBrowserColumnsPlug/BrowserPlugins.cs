using System;
using System.Windows.Forms;
using ShellDll;
using System.IO;

namespace Nida.Dfb
{
    public class DefaultColumnPlugin : IColumnPlugin
    {
        private string[] columns = new string[] { "Size", "Date Modified" };

        public string[] ColumnNames
        {
            get { return columns; }
        }

        public string GetFileInfo(IFileInfoProvider provider, string columnName, ShellItem item)
        {
            string retVal = string.Empty;
            ShellAPI.STATSTG info = provider.GetFileInfo();
            
            switch (columnName)
            {
                case "Size":
                    retVal = GetSizeString(info.cbSize);
                    break;

                case "Date Modified":
                    DateTime dateTime = ShellAPI.FileTimeToDateTime(info.mtime);
                    string time = dateTime.ToLongTimeString();
                    retVal = string.Format("{0} {1}", dateTime.ToShortDateString(), time.Remove(time.Length - 3, 3));
                    break;
            }

            return retVal;
        }

        public string GetFolderInfo(IDirInfoProvider provider, string columnName, ShellItem item)
        {
            string retVal = string.Empty;

            if(item.IsDisk)
            {
                DriveInfo di = new DriveInfo(item.Path);
                switch (columnName)
                {
                    case "Size":
                        retVal = GetSizeString(di.TotalSize);
                        break;

                    case "Date Modified":

                        retVal = string.Format("{0} {1}", di.DriveType, di.DriveFormat);
                        break;
                }

            }

            if (columnName != "Size" && !item.IsSystemFolder && !item.IsDisk && item.IsFileSystem)
            {
                ShellAPI.STATSTG info = provider.GetDirInfo();

                switch (columnName)
                {

                    case "Date Modified":
                            DateTime dateTime = ShellAPI.FileTimeToDateTime(info.mtime);
                            string time = dateTime.ToLongTimeString();
                            retVal = string.Format("{0} {1}",
                                dateTime.ToShortDateString(),
                                time.Remove(time.Length - 3, 3));
                        break;
                }
            }

            return retVal;
        }

        public HorizontalAlignment GetAlignment(string columnName)
        {
            if (columnName == "Size")
                return HorizontalAlignment.Right;
            else
                return HorizontalAlignment.Left;
        }

        public string Name
        {
            get { return "Default IColumnPlugin"; }
        }

        public string Info
        {
            get { return "Column plugin for the default columns for all items."; }
        }

        private string GetSizeString(long bytes)
        {
            if (bytes < 1000)
                return string.Format("{0} bytes", bytes);
            else if (bytes < 1000000)
                return string.Format("{0} KB", Math.Round((double)bytes / 1024, 3, MidpointRounding.ToEven));
            else if (bytes < 1000000000)
                return string.Format("{0} MB", Math.Round((double)bytes / (1024*1024), 3, MidpointRounding.ToEven));
            else
                return string.Format("{0} GB", (long)bytes / (1024*1024*1024));
        }
    }
}
