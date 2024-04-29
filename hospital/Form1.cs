using System.Data.SqlClient;

namespace hastane
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            string username = textBox1.Text;
            string password = textBox2.Text;
            UsersSearch.usersSearch(username, password);
        }
    }
}