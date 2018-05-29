using System;
using System.Diagnostics;
using System.IO;
using System.Runtime.InteropServices;
using System.Windows;
using System.Windows.Controls;
using MahApps.Metro.Controls;
using SwitchHacksAllInOne.Model;
using SwitchHacksAllInOne.Properties;
using SwitchHacksAllInOne.SDTool;

namespace SwitchHacksAllInOne.PayloadTools
{
    /// <summary>
    /// Interaction logic for PayloadTools.xaml
    /// </summary>
    public partial class MainTool : MetroWindow
    {
        private readonly MainWindow _mainWindow;
        public FileManager FileManager { get; set; }
        public string PathToRcmSmash { get; set; }

        public MainTool(MainWindow mainWindow)
        {
            _mainWindow = mainWindow;
            InitializeComponent();

            //Sets path to RCM-Smash tool by rajkosto
            PathToRcmSmash = @"Tools/TegraRcmSmash/TegraRcmSmash.exe";

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
            Combo.ItemsSource = FileManager.FindPayloadFiles();
        }

        private void BackToMainFrm(object sender, System.ComponentModel.CancelEventArgs e)
        {
            _mainWindow.Show();
        }


        private void ClickWhatShouldIDo(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("You should get redirected to a YouTube video where you'd see a tutorial or maybe to git.getraid.com/SHAIO");
            MessageBox.Show("...but I kinda didn't feel like making one yet.");
            MessageBox.Show("Google is your friend, if not, then shoot me a PN. See the About page");
        }


        private void ShowOtherPayloadLaunchers(object sender, RoutedEventArgs e)
        {
            var otherPayloads = new OtherPayloads(this);
            otherPayloads.Show();
            this.Hide();
        }

        private void MainButtonClick(object sender, RoutedEventArgs e)
        {
            string tempPath = Path.Combine(Directory.GetCurrentDirectory(), PathToRcmSmash);
            FileInfo temp = (FileInfo) Combo.SelectedItem;
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
    }
}
