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
    public partial class Buy_shares : Form
    {
        Form1 form = new Form1();
        int index;
        SQL_repository sql = new SQL_repository();

        public Buy_shares(int _index)
        {
            InitializeComponent();
            index = _index;
            unit_count.Text += form.stocks_unit[index].ToString();
        }

        private void buy_btn_Click(object sender, EventArgs e)
        {
            string current_login = form.login.Text;
            double cash = double.Parse(sql.Get_cash(Auth.login));
            string tmp = form.stocks_value[index].Text.Replace("PLN", "");
            int count = form.stocks_unit[index] * int.Parse(amount_txt.Text);
            double cost = form.stocks_unit[index]*int.Parse(amount_txt.Text)*double.Parse(tmp);
            
            DialogResult result = MessageBox.Show("Are you sure you want buy " + count.ToString() + " shares for " + cost.ToString() + "PLN?", "ATTENTION", MessageBoxButtons.YesNo);
            if(result==DialogResult.Yes)
            {
                if (cash < cost)
                {
                    MessageBox.Show("Not enough costs", "Error");
                }
                else if(form.shares_amount[index]<count)
                {
                    MessageBox.Show("Not enough shares", "Error");
                }
                else
                {
                    cash -= cost;
                    sql.Update_after_buy(current_login, cash, form.stocks_company_name[index].Text, int.Parse(amount_txt.Text));
                    this.Close();
                }
            }
            
        }
    }
}
