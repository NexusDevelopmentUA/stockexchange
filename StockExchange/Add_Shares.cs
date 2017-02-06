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
    public partial class Add_Shares : Form
    {
        TextBox[] company_txt;
        TextBox[] amount_txt;
        public int row_count;
        public string login;
        public string pass;
        public string cash;

        public Add_Shares(int count, string _login, string _pass, string _cash)
        {
            InitializeComponent();

            row_count = count;
            login = _login;
            pass = _pass;
            cash = _cash;

            company_txt = new TextBox[row_count];
            amount_txt = new TextBox[row_count];

            for (int i=0; i<count; i++)
            {
                company_txt[i] = new TextBox();
                amount_txt[i] = new TextBox();
                shares_panel.Controls.Add(company_txt[i]);
                shares_panel.Controls.Add(amount_txt[i]);
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            List<Shares> wallet = new List<Shares>();
            for(int i = 0; i<row_count; i++)
            {
                wallet.Add(new Shares() { Company_name = company_txt[i].Text, Amount = int.Parse(amount_txt[i].Text) });
            }
            SQL_repository sql = new SQL_repository();
            sql.SignUp(login, pass, cash, wallet);
            Auth.login = login;
            Form1 form = new Form1();
            form.Show();
            this.Hide();
        }
    }
}
