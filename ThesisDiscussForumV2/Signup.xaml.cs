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
    /// Interaction logic for Signup.xaml
    /// </summary>
    public partial class Signup : Window
    {

        System.Data.SqlClient.SqlConnection cn;
        System.Data.SqlClient.SqlCommand cmd;
        System.Data.SqlClient.SqlDataReader dr;

        public Signup()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            cn = new System.Data.SqlClient.SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Ian\Desktop\CPE106-DiscussionForum-GioSaur\ThesisDiscussForumV2\TDF_Database.mdf;Integrated Security=True");
            cn.Open();
        }

        private void Register_btn_Click(object sender, RoutedEventArgs e)
        {
            if (password_tbox.Password != string.Empty || password_tbox.Password != string.Empty || username_tbox.Text != string.Empty || email_tbox.Text != string.Empty)
            {
                if (password_tbox.Password == confirmpass_tbox.Password)
                {
                    cmd = new System.Data.SqlClient.SqlCommand("select * from UserTable where user_name='" + username_tbox.Text + "'", cn);
                    dr = cmd.ExecuteReader();
                    if (dr.Read())
                    {
                        dr.Close();
                        MessageBox.Show("Username already exists, please try again.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                    else
                    {
                        dr.Close();
                        cmd = new System.Data.SqlClient.SqlCommand("insert into UserTable values(@uid,@user_name,@user_password,@user_email,@user_course)", cn);
                        cmd.Parameters.AddWithValue("uid", uid_tbox.Text);
                        cmd.Parameters.AddWithValue("user_name", username_tbox.Text);
                        cmd.Parameters.AddWithValue("user_password", password_tbox.Password);
                        cmd.Parameters.AddWithValue("user_email", email_tbox.Text);
                        cmd.Parameters.AddWithValue("user_course", course_tbox.Text);
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("You have successfully created an account. Please login now.", "Account Created", MessageBoxButton.OK, MessageBoxImage.Information);
                        this.Hide();
                        Login login = new Login();
                        login.ShowDialog();
                    }
                }
                else
                {
                    MessageBox.Show("Confirm Password Incorrect! ", "Error(01)", MessageBoxButton.OK, MessageBoxImage.Error);
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
