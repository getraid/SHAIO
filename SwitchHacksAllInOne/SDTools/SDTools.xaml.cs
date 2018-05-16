using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using MahApps.Metro.Controls;

namespace SwitchHacksAllInOne
{
    /// <summary>
    /// Interaction logic for SDTools.xaml
    /// </summary>
    public partial class SDTools : MetroWindow
    {
        private readonly MainWindow _mainWindow;

        public SDTools(MainWindow mainWindow)
        {
            InitializeComponent();
       
            UpdateDrives();


            _mainWindow = mainWindow;
  
        }

        private void UpdateDrives()
        {
            DriveInfo[] drives = GetDrives();
            for (int i = 0; i < drives.Length; i++)
            {
                Combo.ItemsSource = drives;
            }
        }

        private void BackToMainFrm(object sender, System.ComponentModel.CancelEventArgs e)
        {
            _mainWindow.Show();
        }

        private DriveInfo[] GetDrives()
        {
            DriveInfo[] drives = DriveInfo.GetDrives();
            List<DriveInfo> drivesThatCouldBeSDorUSB = new List<DriveInfo>();


            foreach (var drive in drives)
            {
                if (drive.DriveType == DriveType.Removable)
                    drivesThatCouldBeSDorUSB.Add(drive);
            }

            return drivesThatCouldBeSDorUSB.ToArray();

        }

        private void ClickRefresh(object sender, RoutedEventArgs e)
        {
            UpdateDrives();
        }
    }
}
