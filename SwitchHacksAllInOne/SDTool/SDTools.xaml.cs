using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Windows;
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
        //todo make /SDCard/Homebrew and "/Payloads a global var

        private readonly MainWindow _mainWindow;

        public FileManager FileManager { get; }

        public SDTools(MainWindow mainWindow)
        {
            InitializeComponent();
            FileManager = new FileManager();
            UpdateDrives();
            _mainWindow = mainWindow;

        }

        private void UpdateDrives()
        {
            DriveInfo[] drives = FileManager.GetDrives();
            Combo.ItemsSource = drives;
            ListView.ItemsSource = FileManager.FindHomebrewFiles();

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
            Process.Start(Path.Combine(Directory.GetCurrentDirectory(), @"SDCard/Homebrew"));
        }

        /// <summary>
        /// Copies an user-selected zip file into (current directory)/SDCard/Homebrew/
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AddFile(object sender, RoutedEventArgs e)
        {
            OpenFileDialog of = new OpenFileDialog();
            of.Multiselect = true;
            of.Title = "Add ZIP-File to collection";
            of.DefaultExt = ".zip";
            of.Filter = "Zip Files|*.zip";
            of.CheckPathExists = true;

            if (of.ShowDialog() == true)
            {
                for (int i = 0; i < of.FileNames.Length; i++)
                {
                    if (File.Exists(@"SDCard/Homebrew/" + of.SafeFileNames[i]))
                    {
                        continue;
                    }
                    File.Copy(of.FileNames[i], Path.Combine(Directory.GetCurrentDirectory(), @"SDCard/Homebrew/"+of.SafeFileNames[i]));
           
                    ClickRefresh(null,null);
                }
            }
        }

        private void ClearSDBase(object sender, RoutedEventArgs e)
        {
            throw new NotImplementedException();
        }

        private void ClearSDFull(object sender, RoutedEventArgs e)
        {
            throw new NotImplementedException();
        }

        private void ExtractToSDButton(object sender, RoutedEventArgs e)
        {
            throw new NotImplementedException();
        }
    }
}
