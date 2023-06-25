using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
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
using TP_Gestion_Contacts;

namespace TP_Gestion_Contact
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class MenuWindow : Window
    {
        public MenuWindow()
        {
            InitializeComponent();
        }

        private void BtShowAll_Click(object sender, RoutedEventArgs e)
        {
            Window fenetre2 = new SearchWindow();
            fenetre2.Visibility = Visibility.Visible;
            this.Close();
        }

        private void BtAdd_Click(object sender, RoutedEventArgs e)
        {
            Window fenetre3 = new AddWindow();
            fenetre3.Visibility = Visibility.Visible;
            this.Close();
        }

        private void BtDelete_Click(object sender, RoutedEventArgs e)
        {
            Window fenetre4 = new EditWindow();
            fenetre4.Visibility = Visibility.Visible;
            this.Close();
        }

        private void BtEdit_Click(object sender, RoutedEventArgs e)
        {
            Window fenetre5 = new DeleteWindow();
            fenetre5.Visibility = Visibility.Visible;
            this.Close();
        }
    }
}
