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
            string temp = form.wallet_company_name[index].Text;
            temp.Replace(" ", "");
            string[] values = new string[form.stocks_company_name.Count()];
            int j = 0;
            foreach(var item in form.stocks_company_name)
            {
                values[j] = item.Text;
                j++;
            }
            stock_index = Array.IndexOf(values, temp);
            unit_count.Text += form.stocks_unit[stock_index].ToString();
        }

        private void sell_btn_Click(object sender, EventArgs e)
        {
            string current_login = form.login.Text;
            string tmp = form.stocks_value[index].Text.Replace("PLN", "");
            double cash = double.Parse(sql.Get_cash(Auth.login));
            double cost = form.stocks_unit[stock_index] * int.Parse(amount_txt.Text) * double.Parse(tmp);
            int amount = int.Parse(amount_txt.Text) * form.stocks_unit[stock_index];

            DialogResult result = MessageBox.Show("Are you sure you want sell " + amount + " shares for " + cost.ToString() + "PLN?", "ATTENTION", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                if (amount > int.Parse(form.amount[index].Text))
                {
                    MessageBox.Show("Not enough shares", "Error");
                }
                else
                {
                    cash += cost;
                    sql.Update_after_sell(current_login, cash, form.stocks_company_name[stock_index].Text, amount);
                   // form.Form_update();
                    this.Close();
                }
            }
        }
    }
}
