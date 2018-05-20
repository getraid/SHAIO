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

namespace SwitchHacksAllInOne
{

    public partial class MainWindow : MetroWindow
    {
    public MainWindow()
        {
            InitializeComponent();
            //Check if update is available 
            AutoUpdater.OpenDownloadPage = true;
            AutoUpdater.Start("http://git.getraid.com/SHAIO/version.xml");
           
        }

        private void Update_Click(object sender, RoutedEventArgs e)
        {
            Update up =  new Update(this);
            up.Show();
            this.Hide();
        }

        private void SDTools_Click(object sender, RoutedEventArgs e)
        {
            SDTools sdTools = new SDTools(this);
            sdTools.Show();
            this.Hide();
        }

        private void PayloadClick(object sender, RoutedEventArgs e)
        {
            PayloadTools payloadTools = new PayloadTools(this);
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
