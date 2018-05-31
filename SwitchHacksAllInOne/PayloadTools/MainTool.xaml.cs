using System;
using System.Diagnostics;
using System.IO;
using System.Runtime.InteropServices;
using System.Windows;
using System.Windows.Controls;
using MahApps.Metro.Controls;
using Microsoft.Win32;
using SHAIO.Model;
using SHAIO.Properties;
using SHAIO.SDTool;

namespace SHAIO.PayloadTools
{
    /// <summary>
    /// Interaction logic for PayloadTools.xaml
    /// </summary>
    public partial class MainTool : MetroWindow
    {
        private readonly MainWindow _mainWindow;
        public FileManager FileManager { get; set; }



        public MainTool(MainWindow mainWindow)
        {
            _mainWindow = mainWindow;
            InitializeComponent();

            //Checks if this is the first launch. Asks to install the drivers.
            if (Settings.Default.firstLaunch)
            {
                MessageBox.Show("If this is your first launch, make sure to install the drivers," +
                                " else the switch can't connect.\nClick the button on the bottom left to install the drivers.");
                Settings.Default.firstLaunch = false;
                Settings.Default.Save();
            }

            //Todo: Save last chosen payload
            FileManager = new FileManager();
            FillItemSource();

        }

        private void FillItemSource()
        {
            Combo.ItemsSource = FileManager.FindPayloadFiles(PathSettings.PayloadPath, "*.bin");
        }

        private void BackToMainFrm(object sender, System.ComponentModel.CancelEventArgs e)
        {
            _mainWindow.Show();
        }


        private void ClickWhatShouldIDo(object sender, RoutedEventArgs e)
        {
            Process.Start(@"http://git.getraid.com/SHAIO/#help");
        }


        private void ShowOtherPayloadLaunchers(object sender, RoutedEventArgs e)
        {
            var otherPayloads = new OtherPayloads(this);
            otherPayloads.Show();
            this.Hide();
        }

        private void MainButtonClick(object sender, RoutedEventArgs e)
        {
            string tempPath = Path.Combine(Directory.GetCurrentDirectory(), PathSettings.PathToRcmSmash);
            FileInfo temp = (FileInfo)Combo.SelectedItem;
            Process.Start(tempPath, '"' + temp.FullName + '"' + " -w");
        }

        private void RefreshButton(object sender, RoutedEventArgs e)
        {
            FillItemSource();
        }

        private void Combo_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            LaunchButton.IsEnabled = Combo.SelectedItem != null;

        }

        private void InstallDrivers(object sender, RoutedEventArgs e)
        {
            try
            {
                Process.Start( Path.Combine(Directory.GetCurrentDirectory(), PathSettings.DriverPath) );
            }
            catch
            {
                MessageBox.Show("Driver installation aborted, try with Admin-rights");
            }

        }

        private void AddButton(object sender, RoutedEventArgs e)
        {
            OpenFileDialog of = new OpenFileDialog
            {
                Multiselect = true,
                Title = "Add BIN-File to collection",
                DefaultExt = ".bin",
                Filter = "Bin Files|*.bin",
                CheckPathExists = true
            };

            if (of.ShowDialog() == true)
            {
                for (int i = 0; i < of.FileNames.Length; i++)
                {
                    if (File.Exists(PathSettings.PayloadPath + of.SafeFileNames[i]))
                    {
                        continue;
                    }
                    File.Copy(of.FileNames[i], Path.Combine(Directory.GetCurrentDirectory(), PathSettings.PayloadPath + of.SafeFileNames[i]));

                    FillItemSource();
                }
            }
        }

        private void RemoveButton(object sender, RoutedEventArgs e)
        {
            FileInfo fs = (FileInfo)Combo.SelectedItem;
            MessageBoxResult result = MessageBox.Show("Do you want to delete " + fs.Name + "?", "Delete", MessageBoxButton.YesNo);
            if (result == MessageBoxResult.Yes)
            {
                File.Delete(fs.FullName);
                FillItemSource();
            }
        }
    }
}
