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
using BussinessLayer;
using Modell;using TP_Gestion_Contacts;

namespace TP_Gestion_Contact
{
    /// <summary>
    /// Interaction logic for Window3.xaml
    /// </summary>
    public partial class AddWindow : Window
    {
        public AddWindow()
        {
            InitializeComponent();
        }

        private void BtCancleContact_Click(object sender, RoutedEventArgs e)
        {
            Window backFenetreMenu = new MenuWindow();
            backFenetreMenu.Visibility = Visibility.Visible;
            this.Close();
        }

        private void BtAddContact_Click(object sender, RoutedEventArgs e)
        {
            Contact contacts = new Contact(tbAddNom.Text, tbAddPrenom.Text, tbAddTelephone.Text);
            bool addContact = FuntionsLogic.AddContact(contacts);
            if (addContact)
            {
                MessageBox.Show("Add contact success!");
                Window window = new SearchWindow();
                window.Show();
                this.Close();
            }
            else
            {
                MessageBox.Show("Add contact not success! Try Again!");
            }
        }
    }
}
