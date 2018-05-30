using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using MahApps.Metro.Controls;
using Microsoft.Win32;
using SHAIO.Model;

namespace SHAIO.SDTool
{
    /// <summary>
    /// Interaction logic for SDTools.xaml
    /// </summary>
    public partial class SDTools : MetroWindow
    {
        private bool? NonRemDrives { get; set; }
        public string HomebrewPath  { get; set; } =  @"SDCard/Homebrew";

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
            ListView.ItemsSource = FileManager.FindHomebrewFiles(HomebrewPath);

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
            Process.Start(Path.Combine(Directory.GetCurrentDirectory(), HomebrewPath));
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
                    if (File.Exists(HomebrewPath + of.SafeFileNames[i]))
                    {
                        continue;
                    }
                    File.Copy(of.FileNames[i], Path.Combine(Directory.GetCurrentDirectory(), HomebrewPath + of.SafeFileNames[i]));

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

            MessageBox.Show("");
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

    }
}
