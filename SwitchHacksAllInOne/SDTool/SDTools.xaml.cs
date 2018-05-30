using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows;
using System.Windows.Documents;
using MahApps.Metro.Controls;
using SHAIO.Model;

namespace SHAIO.SDTool
{
    /// <summary>
    /// Interaction logic for SDTools.xaml
    /// </summary>
    public partial class SDTools : MetroWindow
    {
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
    }
}
