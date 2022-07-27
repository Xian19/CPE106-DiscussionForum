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
    /// Interaction logic for Profile.xaml
    /// </summary>
    public partial class Profile : Window
    {

        System.Data.SqlClient.SqlConnection cn;
        System.Data.SqlClient.SqlCommand cmd;
        System.Data.SqlClient.SqlDataReader dr;

        public Profile()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            cn = new System.Data.SqlClient.SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Ian\Desktop\CPE106-DiscussionForum-GioSaur\ThesisDiscussForumV2\TDF_Database.mdf;Integrated Security=True");
            cn.Open();

            cmd = new System.Data.SqlClient.SqlCommand("Select uid, user_name, user_course, user_email from UserTable", cn);
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                uid_db_lbl.Content = dr.GetValue(0).ToString();
                username_db_lbl.Content = dr.GetValue(1).ToString();
                course_db_lbl.Content = dr.GetValue(2).ToString();
                email_db_lbl.Content = dr.GetValue(3).ToString();
            }
            dr.Close();
        }

        private void Goback_btn_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            dr.Close();
            cn.Close();
        }
    }
}
