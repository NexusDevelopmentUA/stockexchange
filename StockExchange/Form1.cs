using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using WebSocketSharp;

namespace StockExchange
{
    public partial class Form1 : Form
    {
        SQL_repository sql = new SQL_repository();

        private WebSocket client;
        const string host = "ws://webtask.future-processing.com:8068/ws/stocks";

        public Form1()
        {
            InitializeComponent();
        }
     
        public void InitalizeStocks()
        {
            GetData variable = new GetData();
            var data = variable.download();
            var item = data["items"];
            List<Company> companies = new List<Company>();
            foreach (var j in item)
            {
                Company company = j.ToObject<Company>();
                companies.Add(company);
            }
            foreach (var i in companies)
            {
                AddNewStock(i);
            }
        }

        public void InitializeWallet(string login, string cash)
        {
            List<Shares> wallet = sql.Get_Shares(login);
            foreach (var item in wallet)
            {
                AddNewShare(item);
            }
            this.cash.Text += cash + " PLN";
        }
        private void AddNewStock(Company data)
        {
            Label company_name = new Label();
            Label value = new Label();
            Button buy_btn = new Button();
            buy_btn.Click += Buy_btn_Click;
            GetData gdata = new GetData();
            List<Company> companies = new List<Company>();

            company_name.Text = data.Name;
            value.Text = data.Price.ToString();//need to round to 2 digits after point
            buy_btn.Text = "Buy";
            Stocks_panel.Controls.Add(company_name);
            Stocks_panel.Controls.Add(value);
            Stocks_panel.Controls.Add(buy_btn);
        }

        private void AddNewShare(Shares share)
        {
            Label company_name = new Label();
            Label unit_price = new Label();
            Label amount = new Label();
            Label value = new Label();
            Button sell_btn = new Button();
            sell_btn.Click += Sell_btn_Click;
            GetData gdata = new GetData();
            List<Company> companies = new List<Company>();
            var data = gdata.download();
            var item = data["items"];

            foreach (var j in item)
            {
                Company company = j.ToObject<Company>();
                companies.Add(company);
            }
            company_name.Text = share.Company_name;
            amount.Text = share.Amount.ToString();
            sell_btn.Text = "sell";
            foreach(var i in companies)
            {
                string temp1, temp2;
                temp1 = i.Name.Replace(" ","");
                temp2 = share.Company_name.Replace(" ", "");
                if(temp1==temp2)
                {
                    unit_price.Text = i.Price.ToString();
                    value.Text = (share.Amount * i.Price).ToString();
                    break;
                }
            }
            Wallet_panel.Controls.Add(company_name);
            Wallet_panel.Controls.Add(unit_price);
            Wallet_panel.Controls.Add(amount);
            Wallet_panel.Controls.Add(value);
            Wallet_panel.Controls.Add(sell_btn);
        }

        private void Sell_btn_Click(object sender, EventArgs e)
        {
            MessageBox.Show("");//buy shares
        }

        private void Buy_btn_Click(object sender, EventArgs e)
        {
            MessageBox.Show(e.ToString());//buy shares
        }

        private void new_acc_login_btn_Click(object sender, EventArgs e)
        {
            Auth form = new Auth();
            form.Show();
        }

        private void log_out_btn_Click(object sender, EventArgs e)
        {
            Auth form = new Auth();
            this.Hide();
            form.Show();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            client = new WebSocket(host);
            client.Connect();
            client.OnMessage += (ss, ee) =>
              MessageBox.Show(ee.Data);
        }
    }
}
