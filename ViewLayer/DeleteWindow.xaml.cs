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
using System.Windows.Shapes;
using System.Data;
using BussinessLayer;

namespace TP_Gestion_Contact
{
    /// <summary>
    /// Interaction logic for Window5.xaml
    /// </summary>
    public partial class DeleteWindow : Window
    {
        public DeleteWindow()
        {
            InitializeComponent();
            dataSortSearch.ItemsSource = FuntionsLogic.ShowContacts();
        }

        private void BtCancleDeleteContact_Click(object sender, RoutedEventArgs e)
        {
            Window backFenetreMenu = new MenuWindow();
            backFenetreMenu.Visibility = Visibility.Visible;
            this.Close();
        }

        private void BtSearchDeleteContact_Click(object sender, RoutedEventArgs e)
        {
            dataSortSearch.ItemsSource = FuntionsLogic.SearchByyName(tbSearchDeleteContact.Text);
        }

        private void DataSortSearch_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
           
        }

        private void BtDeleteContact_Click(object sender, RoutedEventArgs e)
        {

            //MessageBox.Show(dataSortSearch.SelectedItem.ToString().Split('-')[0]);

            FuntionsLogic.DeleteContactById(Convert.ToInt16(dataSortSearch.SelectedItem.ToString().Split('-')[0]));
            dataSortSearch.ItemsSource = FuntionsLogic.ShowContacts();
        }
    }
}
