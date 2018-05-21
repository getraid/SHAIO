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

namespace SwitchHacksAllInOne.PayloadTools
{
    /// <summary>
    /// Interaction logic for OtherPayloads.xaml
    /// </summary>
    public partial class OtherPayloads : MetroWindow
    {
        private readonly MainTool _mainTool;

        public OtherPayloads(MainTool mainTool)
        {
            _mainTool = mainTool;
            InitializeComponent();
        }

        private void CloseWindow(object sender, System.ComponentModel.CancelEventArgs e)
        {
            _mainTool.Show();
        }

        private void WebButton(object sender, RoutedEventArgs e)
        {
            Process.Start(@"https://elijahzawesome.github.io/web-cfw-loader/");
        }
        private void fuseeButton(object sender, RoutedEventArgs e)
        {
            Process.Start(@"https://github.com/reswitched/fusee-launcher");
        }
        private void NXLoader(object sender, RoutedEventArgs e)
        {
            Process.Start(@"https://github.com/DavidBuchanan314/NXLoader");
        }
    }
}
