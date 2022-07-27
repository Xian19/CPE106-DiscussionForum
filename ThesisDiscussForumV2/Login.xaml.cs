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

namespace ThesisDiscussForumV2
{
    /// <summary>
    /// Interaction logic for Login.xaml
    /// </summary>
    public partial class Login : Window
    {

        System.Data.SqlClient.SqlConnection cn;
        System.Data.SqlClient.SqlCommand cmd;
        System.Data.SqlClient.SqlDataReader dr;

        public Login()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            cn = new System.Data.SqlClient.SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Ian\Desktop\CPE106-DiscussionForum-GioSaur\ThesisDiscussForumV2\TDF_Database.mdf;Integrated Security=True");
            cn.Open();
        }

        private void Login_btn_Click(object sender, RoutedEventArgs e)
        {
            if (pass_tbox.Password != string.Empty || name_tbox.Text != string.Empty)
            {
                cmd = new System.Data.SqlClient.SqlCommand("select * from UserTable where user_name='" + name_tbox.Text + "' and user_password='" + pass_tbox.Password + "'", cn);
                dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    dr.Close();
                    cn.Close();
                    this.Hide();
                    Home home = new Home();
                    home.ShowDialog();
                }
                else
                {
                    dr.Close();
                    MessageBox.Show("Account does not exist or incorrect credentials. ", "Please try again.", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            else
            {
                MessageBox.Show("Please enter information in all fields.", "Error(02)", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void Back_btn_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            MainWindow mainWindow = new MainWindow();
            mainWindow.ShowDialog();
        }
    }
}
