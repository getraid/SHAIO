using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using MahApps.Metro.Controls;
using System.IO.Compression;
using System.IO.Packaging;
using System.Windows.Forms;
using SHAIO.Model;
using MessageBox = System.Windows.MessageBox;
using OpenFileDialog = Microsoft.Win32.OpenFileDialog;

namespace SHAIO.SDTool
{
    /// <summary>
    /// Interaction logic for SDTools.xaml
    /// </summary>
    public partial class SDTools : MetroWindow
    {
        private bool? NonRemDrives { get; set; }


        private readonly MainWindow _mainWindow;

        public FileManager FileManager { get; }

        public SDTools(MainWindow mainWindow)
        {
            InitializeComponent();


            FileManager = new FileManager();
            UpdateDrives();
            _mainWindow = mainWindow;
            ExtractButton.IsEnabled = Combo.SelectedItem != null;
        }

        private void UpdateDrives()
        {
            bool temp = false;
            if (NonRemDrives != null)
            {
                temp = NonRemDrives == true;
            }

            Combo.ItemsSource = null;
            Combo.Items.Clear();
            Combo.UpdateLayout();


            DriveInfo[] drives = FileManager.GetDrives(temp);
            Combo.ItemsSource = drives;
            ListView.ItemsSource = FileManager.FindHomebrewFiles(PathSettings.HomebrewPath, "*.zip");

        }

        private void ClickRefresh(object sender, RoutedEventArgs e)
        {
            UpdateDrives();
        }
        private void BackToMainFrm(object sender, System.ComponentModel.CancelEventArgs e)
        {
            _mainWindow.Show();
        }

        private void OpenFolder(object sender, RoutedEventArgs e)
        {
            Process.Start(Path.Combine(Directory.GetCurrentDirectory(), PathSettings.HomebrewPath));
        }

        /// <summary>
        /// Copies an user-selected zip file into (current directory)/SDCard/Homebrew/
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AddFile(object sender, RoutedEventArgs e)
        {
            OpenFileDialog of = new OpenFileDialog
            {
                Multiselect = true,
                Title = "Add ZIP-File to collection",
                DefaultExt = ".zip",
                Filter = "Zip Files|*.zip",
                CheckPathExists = true
            };

            if (of.ShowDialog() == true)
            {
                for (int i = 0; i < of.FileNames.Length; i++)
                {
                    if (File.Exists(PathSettings.HomebrewPath + of.SafeFileNames[i]))
                    {
                        continue;
                    }
                    File.Copy(of.FileNames[i], Path.Combine(Directory.GetCurrentDirectory(), PathSettings.HomebrewPath + of.SafeFileNames[i]));

                    UpdateDrives();
                }
            }
        }

        /// <summary>
        /// Opens selected drive in explorer
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OpenSdCard(object sender, RoutedEventArgs e)
        {
            DriveInfo temp = (DriveInfo)Combo.SelectedItem;
            if (temp != null)
            {
                Process.Start(temp.Name);
            }

        }

        /// <summary>
        /// This button extracts the selected .zip archives into the root of the SD-Card.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ExtractToSdButton(object sender, RoutedEventArgs e)
        {
            if (ListView.SelectedItem == null)
            {
                MessageBox.Show("You need to select something first.\nYou can also select multiple things, just press CTRL while clicking");
                return;
            }

            foreach (FileInfo file in ListView.SelectedItems)
            {
                DriveInfo temp = (DriveInfo)Combo.SelectedItem;

                //  ZipFile.ExtractToDirectory(file.FullName, temp.Name);
                using (var fs = new StreamReader(file.FullName))
                {
                    new ZipArchive(fs.BaseStream).ExtractToDirectory(temp.Name, true);

                }

            }


        }

        /// <summary>
        /// If CheckBox drive selection is changed, check if drive is fat32 or exfat
        /// Also enable ExtractButton if selection isn't null
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Combo_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            //check if fat32 or exfat / warn if not
            DriveInfo temp = (DriveInfo)Combo.SelectedItem;
            if (temp != null)
            {
                if (!((temp.DriveFormat == "FAT32") || (temp.DriveFormat == "exFAT")))
                {
                    MessageBox.Show("This drive is not formatted with either FAT32 or exFAT. This will likely not work with your Switch.");
                }
            }

            //if the selected Items != null then enable button.
            ExtractButton.IsEnabled = Combo.SelectedItem != null;
        }

        /// <summary>
        /// Necessary for checking if all drives should be shown
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void NonRemovableDrivesCheck(object sender, RoutedEventArgs e)
        {
            NonRemDrives = CheckBox.IsChecked;
            UpdateDrives();
        }

        private void DeleteEntry(object sender, RoutedEventArgs e)
        {
            FileInfo fs = (FileInfo)ListView.SelectedItem;
            if (fs != null)
            {
                MessageBoxResult result = MessageBox.Show("Do you want to delete " + fs.Name + "?", "Delete", MessageBoxButton.YesNo);
                if (result == MessageBoxResult.Yes)
                {
                    File.Delete(fs.FullName);
                    UpdateDrives();
                }
            }

        }
    }

    /// <summary>
    /// Thanks to https://stackoverflow.com/questions/14795197/forcefully-replacing-existing-files-during-extracting-file-using-system-io-compr
    /// </summary>
    public static class ZipArchiveExtensions
    {
        public static void ExtractToDirectory(this ZipArchive archive, string destinationDirectoryName, bool overwrite)
        {
            if (!overwrite)
            {
                archive.ExtractToDirectory(destinationDirectoryName);
                return;
            }
            foreach (ZipArchiveEntry file in archive.Entries)
            {
                string completeFileName = Path.Combine(destinationDirectoryName, file.FullName);
                if (file.Name == "")
                {// Assuming Empty for Directory
                    Directory.CreateDirectory(Path.GetDirectoryName(completeFileName));
                    continue;
                }
                file.ExtractToFile(completeFileName, true);
            }
        }
    }
}