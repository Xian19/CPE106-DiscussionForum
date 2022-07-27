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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ThesisDiscussForumV2
{
    /// <summary>
    /// Interaction logic for Start.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        System.Data.SqlClient.SqlConnection cn;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            cn = new System.Data.SqlClient.SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Ian\Desktop\CPE106-DiscussionForum-GioSaur\ThesisDiscussForumV2\TDF_Database.mdf;Integrated Security=True");
            cn.Open();
        }

        private void Gosignup_btn_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            Signup signup = new Signup();
            signup.ShowDialog();
        }

        private void Gologin_btn_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            Login login = new Login();
            login.ShowDialog();
        }
    }
}
