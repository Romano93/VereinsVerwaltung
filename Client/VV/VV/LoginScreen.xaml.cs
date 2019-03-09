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
using VV.ConfigWindow;

namespace VV
{
    /// <summary>
    /// Interaktionslogik für MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private List<Config> cfgList;
        private LoginWindowController controller;
        public MainWindow()
        {
            InitializeComponent();
            controller = new LoginWindowController();
        }

        private void btnNewClub_Click(object sender, RoutedEventArgs e)
        {
            controller.NewClub();
        }

        private void btnEditClub_Click(object sender, RoutedEventArgs e)
        {
            int i = lsbClubs.SelectedIndex;
            if(i > 0 && cfgList[i] != null)
            {
                controller.EditClub(cfgList[i]);
            }
            else
            {
                MessageBox.Show("Es wurde ein ungültigen Verein ausgewählt.", "Hinweis");
            }
        }

        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            throw new NotImplementedException();
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            controller.Close();
            this.Close();
        }
    }
}
