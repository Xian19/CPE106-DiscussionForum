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
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {

        System.Data.SqlClient.SqlConnection cn;
        System.Data.SqlClient.SqlCommand cmd;
        System.Data.SqlClient.SqlDataReader dr;
        System.Data.SqlClient.SqlDataAdapter da;


        public Window1()
        {
            InitializeComponent();
        }

        private void Logout_btn_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("You have successfully logged out. ", "Information", MessageBoxButton.OK, MessageBoxImage.Information);
            this.Hide();
            MainWindow mainWindow = new MainWindow();
            mainWindow.ShowDialog();
        }

        private void Profile_btn_Click(object sender, RoutedEventArgs e)
        {
            Profile profile = new Profile();
            profile.Show();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            cn = new System.Data.SqlClient.SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Ian\Desktop\CPE106-DiscussionForum-GioSaur\ThesisDiscussForumV2\TDF_Database.mdf;Integrated Security=True");
            cn.Open();
            cmd = new System.Data.SqlClient.SqlCommand("Select * from PostTable", cn);
            da = new System.Data.SqlClient.SqlDataAdapter(cmd);
            System.Data.DataTable dt = new System.Data.DataTable();
            da.Fill(dt);
            dataGrid.ItemsSource = dt.DefaultView;
        }

        private void Refresh_btn_Click(object sender, RoutedEventArgs e)
        {
            cmd = new System.Data.SqlClient.SqlCommand("Select * from PostTable", cn);
            da = new System.Data.SqlClient.SqlDataAdapter(cmd);
            System.Data.DataTable dt = new System.Data.DataTable();
            da.Fill(dt);
            dataGrid.ItemsSource = dt.DefaultView;
        }



    }
}
