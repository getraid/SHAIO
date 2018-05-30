using System;
using System.Collections.Generic;
using System.Diagnostics;
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

namespace SHAIO
{
    /// <summary>
    /// Interaction logic for About.xaml
    /// </summary>
    public partial class About : MetroWindow
    {
        private readonly MainWindow _mainWindow;

        public About(MainWindow mainWindow)
        {
            _mainWindow = mainWindow;
            InitializeComponent();
        }

        private void BackToMainFrm(object sender, System.ComponentModel.CancelEventArgs e)
        {
            _mainWindow.Show();
        }

        private void Label_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Label l = (Label) sender;
            string ll = "http://" + l.Content + "/";
            Process.Start(ll);
        }
    }
}
