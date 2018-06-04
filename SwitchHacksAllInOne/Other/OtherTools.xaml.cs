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

namespace SHAIO.Other
{
    /// <summary>
    /// Interaction logic for OtherTools.xaml
    /// </summary>
    public partial class OtherTools : MetroWindow
    {
        private readonly MainWindow _mainWindow;

        public OtherTools(MainWindow mainWindow)
        {
            _mainWindow = mainWindow;
            InitializeComponent();
        }

        private void BackToMainFrm(object sender, System.ComponentModel.CancelEventArgs e)
        {
            _mainWindow.Show();
        }


        private void HacDiskMount_Click(object sender, RoutedEventArgs e)
        {
            Process.Start(GetFolderPath(@"HacDiskMount/HacDiskMount.exe"));
        }

        private void HacTool_Click(object sender, RoutedEventArgs e)
        {
            Process.Start(GetFolderPath(@"HACToolGUI"));
        }

        private void Joiner_Click(object sender, RoutedEventArgs e)
        {
            Process.Start(GetFolderPath(@"JoinerScripts"));
        }

        private void TegraRCMGUI_Click(object sender, RoutedEventArgs e)
        {
            Process.Start(GetFolderPath(@"TegraRcmGUI/TegraRcmGUI.exe"));
        }

        private void XciReader_Click(object sender, RoutedEventArgs e)
        {
            Process.Start(GetFolderPath(@"XCI Reader/XCI.Reader.exe"));
        }
        private void XciCutter_Click(object sender, RoutedEventArgs e)
        {
            Process.Start(GetFolderPath(@"XCI-Cutter/XCI-Cutter.exe"));
        }

        private void ToolsFolder_Click(object sender, RoutedEventArgs e)
        {
            Process.Start(GetFolderPath(""));
        }

        public string GetFolderPath(string where)
        {
            return @Path.Combine(Directory.GetCurrentDirectory(), PathSettings.Tools + where);
        }
    }
}
