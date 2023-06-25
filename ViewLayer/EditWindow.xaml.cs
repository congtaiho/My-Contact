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
using BussinessLayer;

namespace TP_Gestion_Contact
{
    /// <summary>
    /// Interaction logic for Window4.xaml
    /// </summary>
    public partial class EditWindow : Window
    {
        public EditWindow()
        {
            InitializeComponent();
            dataEditContact.ItemsSource = FuntionsLogic.ShowContacts();
        }
        static readonly String dbConnectionString = @"Data Source=751FJW2\SQLEXPRESS;Initial Catalog=gestion_contacts;Integrated Security=True;Connect Timeout=30";


        private void BtCancleEdit_Click(object sender, RoutedEventArgs e)
        {
            Window backFenetreMenu = new MenuWindow();
            backFenetreMenu.Visibility = Visibility.Visible;
            this.Close();
        }

        

        private void TbPrenom_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void DataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
           
        }
       
        
        ////Button save
        private void BtSubmitEdit_Click(object sender, RoutedEventArgs e)
        {
            SqlConnection sqlCon = new SqlConnection(dbConnectionString);

            try
            {
                sqlCon.Open();
                string query = @"INSERT INTO contacts(id,nom,prenom,telephone) values ('" + this.tbId.Text + "', '" + this.tbName.Text + "','" + this.tbPrenom.Text + "','" + this.tbPhone.Text + "')";
                SqlCommand createCommand = new SqlCommand(query, sqlCon);
                createCommand.ExecuteNonQuery();
                MessageBox.Show("Saved");
                sqlCon.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }


        }

        
        //Button update
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            SqlConnection sqlCon = new SqlConnection(dbConnectionString);

            try
            {
                sqlCon.Open();
                string query = "update contacts set nom='" + this.tbName.Text + "',prenom='" + this.tbPrenom.Text + "',telephone='" + this.tbPhone.Text + "' where id='" + this.tbId.Text + "'";
                SqlCommand createCommand = new SqlCommand(query, sqlCon);
                createCommand.ExecuteNonQuery();
                MessageBox.Show("Updated");
                sqlCon.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void DataEditContact_RequestBringIntoView(object sender, RequestBringIntoViewEventArgs e)
        {
            //tbName.Text = dataEditContact.RowStyleSelector[e.];
            //je ne sais pas comment lien data entre DataGrid et TextBox
        }
    }
}
