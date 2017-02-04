using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WebSocketSharp;

namespace StockExchange
{
    public partial class Auth : Form
    {
        string login;

        public Auth()
        {
            InitializeComponent();
        }

        private void Auth_Load(object sender, EventArgs e)
        {

        }

        private void LogIn_btn_Click(object sender, EventArgs e)
        {
            SQL_repository sql = new SQL_repository();
            string login = login_txt.Text;
            string pass = pass_txt.Text;
            int result;
            result = sql.LogIn(login, pass);
            if(result==1)
            {
                Form1 form = new Form1();
                form.label5.Text += login;
                form.InitializeWallet(login, sql.Get_cash(login));
                const string host = "ws://webtask.future-processing.com:8068/ws/stocks";
                WebSocket client = new WebSocket(host);
                client.Connect();
                client.OnMessage +=(ss,ee)=>MessageBox.Show("");
                this.Hide();
                form.Show();
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
