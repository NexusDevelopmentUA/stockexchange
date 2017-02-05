using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StockExchange
{
    public partial class Auth : Form
    {
        static string _login;

        public static string login
        {
            get { return _login; }
            set { _login = value; }
        }

        public Auth()
        {
            InitializeComponent();
        }

        private void LogIn_btn_Click(object sender, EventArgs e)
        {
            SQL_repository sql = new SQL_repository();
            string tmp_login = login_txt.Text;
            string pass = pass_txt.Text;
            int result;
            result = sql.LogIn(tmp_login, pass);
            if(result==1)
            {
                login = tmp_login;
                Form1 form = new Form1();
                form.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Login/pass was incorent. Please, try again.");
            }
        }

        private void signup_btn_Click(object sender, EventArgs e)
        {
            SignUp form = new SignUp();
            form.Show();
            this.Hide();
        }
    }
}
