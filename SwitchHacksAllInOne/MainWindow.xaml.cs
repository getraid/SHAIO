using System;
using System.Collections.Generic;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using MahApps.Metro.Controls;
using AutoUpdaterDotNET;
using SHAIO.PayloadTools;

namespace SHAIO
{

    public partial class MainWindow : MetroWindow
    {
        public MainWindow()
        {
            InitializeComponent();
            CheckForUpdates();
        }

        /// <summary>
        /// Check if updates are available
        /// </summary>
        private static void CheckForUpdates()
        {
            AutoUpdater.ShowRemindLaterButton = false;
            AutoUpdater.OpenDownloadPage = true;
            AutoUpdater.AppCastURL = "http://git.getraid.com/SHAIO/version.xml";
            AutoUpdater.Start();

            //todo autoupdating everything
            //AutoUpdater.DownloadPath = Environment.CurrentDirectory;

        }

        private void Update_Click(object sender, RoutedEventArgs e)
        {
            Updates.Update up = new Updates.Update(this);
            up.Show();
            this.Hide();
        }

        private void SDTools_Click(object sender, RoutedEventArgs e)
        {
            SDTool.SDTools sdTools = new SDTool.SDTools(this);
            sdTools.Show();
            this.Hide();
        }

        private void PayloadClick(object sender, RoutedEventArgs e)
        {
            MainTool payloadTools = new MainTool(this);
            payloadTools.Show();
            this.Hide();
        }

        private void AboutClick(object sender, RoutedEventArgs e)
        {
            About about = new About(this);
            about.Show();
            this.Hide();
        }

  
    }
}
