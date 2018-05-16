using System;
using System.Collections.Generic;
using System.Diagnostics;
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
using Path = System.IO.Path;

namespace SwitchHacksAllInOne
{
    /// <summary>
    /// Interaction logic for PayloadTools.xaml
    /// </summary>
    public partial class PayloadTools : MetroWindow
    {
        private readonly MainWindow _mainWindow;

        public PayloadTools(MainWindow mainWindow)
        {
            _mainWindow = mainWindow;
            InitializeComponent();
        }

        private void BackToMainFrm(object sender, System.ComponentModel.CancelEventArgs e)
        {
            _mainWindow.Show();
        }

        private void ClickThisWindowsPC(object sender, RoutedEventArgs e)
        {
            string[] d = Directory.GetDirectories(Directory.GetCurrentDirectory());
            //todo install drivers prompt on first launch
            for (int i = 0; i < d.Length; i++)
            {



            }
        }

        private void ClickWhatShouldIDo(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("You should get redirected to a YouTube video where you'd see a tutorial");
            MessageBox.Show("...but kinda I didn't feel like it yet. Just follow the guide: Switch Hacking 101: How to launch the Homebrew menu on 4.x-5.x");
            MessageBox.Show("Google is a thing, you know?");
        }

        private void ClickMacOs(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Since I wrote this program in C# the chances that you are using macOS seem pretty low." +
                            " I maybe later will port this via Xamarine or Mono. Easiest way is launch it with Chome!");
            Process.Start("chrome.exe", @"https://atlas44.s3-us-west-2.amazonaws.com/web-fusee-launcher/index.html");

        }

        private void ClickLinux(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Since I wrote this program in C# the chances that you are using linux seem pretty low." +
                            " I maybe later will port this via Xamarine or Mono. Easiest way is launch it with Chome!");
            Process.Start("chrome.exe", @"https://atlas44.s3-us-west-2.amazonaws.com/web-fusee-launcher/index.html");

        }

        private void ClickAndroid(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Mr Stackoverflow showed me this:\n Connect Android device to PC via USB cable " +
                            "and turn on USB storage.\r\n\r\nCopy .apk file to attached device\'s storage.\r\n\r\nTurn" +
                            " off USB storage and disconnect it from PC.\r\n\r\nCheck the option " +
                            "Settings → Applications → Unknown sources.\r\n\r\nOpen FileManager app and " +
                            "click on the copied .apk file.\r\nIt will ask you whether to install this" +
                            " app or not. Click Yes or OK.");
            Process.Start(@Path.Combine(Directory.GetCurrentDirectory()));
        }
    }
}
