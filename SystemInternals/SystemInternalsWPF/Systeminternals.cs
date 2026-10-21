using System;
using System.Security.Principal;
using System.Management;
using System.IO;

namespace SystemInternalsWPF
{
    /// <summary>
    /// Hinweis:
    /// So binden Sie diese Befehle in Ihr Programm ein.
    /// Schreiben Sie folgende Zeile in Ihren Code:
    /// Systeminternals.GetUserInfo(); - um an die Benutzerinformationen zu kommen.
    /// usw...
    /// </summary>


    public static class Systeminternals
    {
        public static string GetUserInfo()
        {
            string users = string.Empty;

            SelectQuery query = new SelectQuery("Win32_UserAccount");
            ManagementObjectSearcher searcher = new ManagementObjectSearcher(query);
            foreach (ManagementObject envVar in searcher.Get())
            {
                users += envVar["Name"] + Environment.NewLine;
            }

            return users;
        }

        public static string GetStorageInfo()
        {
            // Warum ist die Klasse eigentlich static? 
            string driveInfo = string.Empty;
            DriveInfo[] driveInformation = DriveInfo.GetDrives();
            foreach (DriveInfo info in driveInformation)
            {
                driveInfo += info.Name + " : ";
                driveInfo += convertToGigabytes(info.TotalFreeSpace) + " GB verfügbar" + Environment.NewLine;
                driveInfo += "Gesamtgröße des Laufwerks: " + convertToGigabytes(info.TotalSize) + " GB";
                break;
            }
            return driveInfo;
        }

        private static double convertToGigabytes(long freeBytesOnDisk)
        {
            return freeBytesOnDisk / 1024 / 1024 / 1024;
        }

        public static string GetUpTime()
        {
            string upTime = string.Empty;
            DateTime lastBootTime = DateTime.MinValue;

            ManagementObjectSearcher mSearcher = new ManagementObjectSearcher("Select * From Win32_OperatingSystem");
            ManagementObjectCollection mObjects = mSearcher.Get();
            foreach (ManagementObject m in mSearcher.Get())
            {
                //No indexing on collection 
                PropertyData pd = m.Properties["LastBootUpTime"];
                string name = pd.Name.ToString();
                lastBootTime = ManagementDateTimeConverter.ToDateTime(pd.Value.ToString());


            }
            TimeSpan diff = (DateTime.Now - lastBootTime);
            return upTime = diff.Days + " days, " + diff.Hours + " hours, " + diff.Minutes + " Minutes, " + diff.Seconds + " Seconds";
        }


        /// <summary>
        /// method for getting the names of all shared folders on local system
        /// </summary>
        /// <returns>Generic list of all share names</returns>
        public static string GetAllShares()
        {
            string shares = string.Empty;

            using (ManagementObjectSearcher query = new ManagementObjectSearcher(new SelectQuery("Win32_Share")))
            {
                foreach (ManagementObject obj in query.Get())
                {
                    string name = obj["Name"].ToString();
                    string path = obj["Path"].ToString();
                    string descr = obj["Description"].ToString();
                    string caption = obj["Caption"].ToString();
                    string status = obj["status"].ToString();
                    shares += name + " -> " + path + " -> " + descr + " -> " + caption + " -> " + status + Environment.NewLine;
                }
            }
            return shares;
        }

        public static string GetSerialnumber()
        {
            string serialnumber = string.Empty;

            ManagementObjectSearcher mSearcher = new ManagementObjectSearcher("Select * From Win32_OperatingSystem");
            ManagementObjectCollection mObjects = mSearcher.Get();
            foreach (ManagementObject m in mSearcher.Get())
            {
                //No indexing on collection 
                PropertyData pd = m.Properties["SerialNumber"];
                string name = pd.Name.ToString();
                serialnumber = pd.Value.ToString();


            }

            return serialnumber;
        }

        public static string GetSystemDirectory()
        {
            string directory = string.Empty;

            ManagementObjectSearcher mSearcher = new ManagementObjectSearcher("Select * From Win32_OperatingSystem");
            ManagementObjectCollection mObjects = mSearcher.Get();
            foreach (ManagementObject m in mSearcher.Get())
            {
                //No indexing on collection 
                PropertyData pd = m.Properties["SystemDirectory"];
                string name = pd.Name.ToString();
                directory = pd.Value.ToString();


            }

            return directory;
        }

    }
}
