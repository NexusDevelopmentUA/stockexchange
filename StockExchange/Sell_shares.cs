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
    public partial class Sell_shares : Form
    {
        Form1 form = new Form1();
        int index, stock_index;
        SQL_repository sql = new SQL_repository();

        public Sell_shares(int _index)
        {
            InitializeComponent();
            index = _index;
            string shares_name = form.wallet_company_name[index].Text;
            stock_index = Array.IndexOf(form.stocks_company_name, shares_name);
            unit_count.Text += form.stocks_unit[stock_index].ToString();
        }

        private void sell_btn_Click(object sender, EventArgs e)
        {
            string current_login = form.login.Text;
            string tmp = form.stocks_value[index].Text.Replace("PLN", "");
            double cash = double.Parse(sql.Get_cash(Auth.login));
            double cost = form.stocks_unit[stock_index] * int.Parse(amount_txt.Text) * double.Parse(tmp);

            DialogResult result = MessageBox.Show("Are you sure you want sell " + amount_txt.Text + " shares for " + cost.ToString() + "PLN?", "ATTENTION", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                if (int.Parse(amount_txt.Text) > int.Parse(form.amount[index].Text))
                {
                    MessageBox.Show("Not enough shares", "Error");
                }
                else
                {
                    cash += cost;
                    sql.Update_after_sell(current_login, cash, form.stocks_company_name[stock_index].Text, int.Parse(amount_txt.Text));
                    this.Close();
                }
            }
        }
    }
}
