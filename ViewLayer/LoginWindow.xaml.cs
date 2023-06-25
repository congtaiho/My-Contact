using System.Windows;
using BussinessLayer;

namespace TP_Gestion_Contact
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {
        public LoginWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            bool isLogin = FuntionsLogic.CheckLogin(tbUserName.Text, tbPassWord.Password);
            if (isLogin)
            {
                Window fenetre1 = new MenuWindow();
                fenetre1.Show();
                this.Close();
            }
            else
            {
                MessageBox.Show("Login not Success!");
            }
        }
    }
}
