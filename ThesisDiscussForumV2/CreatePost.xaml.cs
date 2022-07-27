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
    /// Interaction logic for CreatePost.xaml
    /// </summary>
    public partial class CreatePost : Window
    {

        System.Data.SqlClient.SqlConnection cn;
        System.Data.SqlClient.SqlCommand cmd;
        System.Data.SqlClient.SqlDataReader dr;
        System.Data.SqlClient.SqlDataAdapter da;

        public CreatePost()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            cn = new System.Data.SqlClient.SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Ian\Desktop\CPE106-DiscussionForum-GioSaur\ThesisDiscussForumV2\TDF_Database.mdf;Integrated Security=True");
            cn.Open();
        }

        private void Submit_btn_Click(object sender, RoutedEventArgs e)
        {
            Home home = new Home();
            cmd = new System.Data.SqlClient.SqlCommand("Select uid,user_name from UserTable", cn);
            dr = cmd.ExecuteReader();
            dr.Read();
            if (postTitle_tbox.Text != string.Empty || userPost_tbox.Text != string.Empty)
            {
                cmd = new System.Data.SqlClient.SqlCommand("insert into PostTable values(@uid,@post_title,@post_owner,@post_content,@post_date)", cn);
                cmd.Parameters.AddWithValue("uid", dr.GetValue(0).ToString());
                cmd.Parameters.AddWithValue("post_title", postTitle_tbox.Text);
                cmd.Parameters.AddWithValue("post_owner", dr.GetValue(1).ToString());
                cmd.Parameters.AddWithValue("post_content", userPost_tbox.Text);
                cmd.Parameters.AddWithValue("post_date", DateTime.Now);
                dr.Close();
                cmd.ExecuteNonQuery();
                MessageBox.Show("Post submitted!", "Thank you!", MessageBoxButton.OK, MessageBoxImage.Information);
                da = new System.Data.SqlClient.SqlDataAdapter(cmd);
                System.Data.DataTable dt = new System.Data.DataTable();
                da.Update(dt);
                home.dataGrid.ItemsSource = dt.DefaultView;
                this.Hide();
            }
            else
            {
                dr.Close();
                MessageBox.Show("Please enter information in all fields.", "Error(02)", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

    }
}
