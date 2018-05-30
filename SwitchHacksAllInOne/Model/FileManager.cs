using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Controls;

namespace SHAIO.Model
{
    public class FileManager
    {
    

        /// <summary>
        /// Finds all .zip (homebrew/on sd card) files in (current path)/SDCard/Homebrew/
        /// </summary>
        /// <returns> An array of all .zip (homebrew/on sd card) files</returns>
        public FileInfo[] FindHomebrewFiles(string pHomebrewPath)
        {
            string fileExtenstion = "*.zip";
          
            DirectoryInfo di = new DirectoryInfo(Path.Combine(Directory.GetCurrentDirectory(), pHomebrewPath));
            DirectoryInfo[] directories = di.GetDirectories(fileExtenstion, SearchOption.AllDirectories);
            FileInfo[] files = di.GetFiles(fileExtenstion, SearchOption.AllDirectories);
            return files;

        }

        /// <summary>
        /// Finds all .bin (payload) files in (current path)/SDCard/Homebrew/
        /// </summary>
        /// <returns> An array of all .bin (payload) files</returns>
        public FileInfo[] FindPayloadFiles(string pPayloadPath)
        {
            string fileExtenstion = "*.bin";
         
            DirectoryInfo di = new DirectoryInfo(Path.Combine(Directory.GetCurrentDirectory(), pPayloadPath));
            DirectoryInfo[] directories = di.GetDirectories(fileExtenstion, SearchOption.AllDirectories);
            FileInfo[] files = di.GetFiles(fileExtenstion, SearchOption.AllDirectories);
            return files;

        }
        //^ and yes I know I could merge that into one but I wanted to have it clear and structured.


        /// <summary>
        /// Finds all connected drives that are removable. Returns an array of that.
        /// </summary>
        /// <returns></returns>
        public DriveInfo[] GetDrives(bool nonrem)
        {
            DriveInfo[] drives = DriveInfo.GetDrives();
            List<DriveInfo> drivesThatCouldBeSDorUSB = new List<DriveInfo>();


            foreach (var drive in drives)
            {
                if (drive.DriveType == DriveType.Removable || nonrem)
                    drivesThatCouldBeSDorUSB.Add(drive);
            }

            return drivesThatCouldBeSDorUSB.ToArray();

        }
    }
}