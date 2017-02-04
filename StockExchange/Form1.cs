using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Newtonsoft.Json.Linq;
using WebSocketSharp;
using System.Threading;

namespace StockExchange
{
    public partial class Form1 : Form
    {
        private Thread thread;
        delegate void StockArgReturningVoidDelegate(Label company_name, Label value, Button buy);
        delegate void UpdateArgReturningVoidDelegate();

        //Arrays of controls for stocks
        Label[] stocks_company_name;
        Label[] stocks_value;
        int[] stocks_unit;
        Button[] buy_btn;

        //Array of controls for wallet
        Label[] wallet_company_name;
        Label[] unit_price;
        Label[] amount;
        Label[] wallet_value;
        Button[] sell_btn;

        SQL_repository sql = new SQL_repository();
        const string host = "ws://webtask.future-processing.com:8068/ws/stocks";
        private WebSocket client;

        public Form1()
        {
            string raw_data="";

            InitializeComponent();
            //this.Load() += new EventHandler(Form1_Load);
            client = new WebSocket(host);
            client.Connect();
            client.OnMessage += Client_OnMessage;
            client.OnError += (ss, ee) => Console.WriteLine(ee.Message);
            thread = new Thread(() => Update_Stocks(Get_data(raw_data)));
            thread.Start();
        }

        private void Client_OnMessage(object sender, MessageEventArgs e)
        {
            Console.WriteLine(e.Data);
        }

        private void InitalizeStocks(List<Company> _companies)
        {
            
            stocks_company_name = new Label[_companies.Count];
            stocks_value = new Label[_companies.Count];
            buy_btn = new Button[_companies.Count];
            stocks_unit = new int[_companies.Count];
            int i = 0;

            foreach (var item in _companies)
            {
                stocks_company_name[i] = new Label();
                stocks_value[i] = new Label();
                buy_btn[i] = new Button();

                //AddNewStock(item);
                stocks_company_name[i].Text = item.Name;
                stocks_value[i].Text = item.Price.ToString();//need to round to 2 digits after point
                stocks_unit[i] = item.Unit;
                buy_btn[i].Text = "Buy";
                buy_btn[i].Click += Buy_btn_Click;
                AddNewStock(stocks_company_name[i], stocks_value[i], buy_btn[i]);
                //Stocks_panel.Controls.Add(stocks_company_name[i]);
                //Stocks_panel.Controls.Add(stocks_value[i]);
                //Stocks_panel.Controls.Add(buy_btn[i]);

                i++;
            }
        }

        private void AddNewStock(Label company_name, Label value, Button buy)
        {
            if(Stocks_panel.InvokeRequired)
            {
                StockArgReturningVoidDelegate d = new StockArgReturningVoidDelegate(AddNewStock);
                this.Invoke(d, new object[] { company_name, value, buy });
            }
            else
            {
                Stocks_panel.Controls.Add(company_name);
                Stocks_panel.Controls.Add(value);
                Stocks_panel.Controls.Add(buy);
            }
        }

        private void Update_Stocks(List<Company> _companies)
        {
            int i = 0;
            foreach(var item in _companies)
            {
                stocks_company_name[i].Text = item.Name;
                stocks_value[i].Text = item.Price.ToString();
                stocks_unit[i] = item.Unit;
            }
        }

        public void InitializeWallet(string login, string cash)
        {
            List<Shares> wallet = sql.Get_Shares(login);
            wallet_company_name = new Label[wallet.Count];
            unit_price = new Label[wallet.Count];
            amount = new Label[wallet.Count];
            wallet_value = new Label[wallet.Count];
            sell_btn = new Button[wallet.Count];
            GetData gdata = new GetData();
            List<Company> companies = new List<Company>();
            int i = 0;

            //getting data using HTTP protocol
            var data = gdata.download();
            var item = data["items"];
            
            foreach (var j in item)
            {
                Company company = j.ToObject<Company>();
                companies.Add(company);
            }
            
            foreach (var share in wallet)//getting controls into panel
            {
                //AddNewShare(item);
                wallet_company_name[i] = new Label();
                amount[i] = new Label();
                sell_btn[i] = new Button();
                unit_price[i] = new Label();
                wallet_value[i] = new Label();

                wallet_company_name[i].Text = share.Company_name;
                amount[i].Text = share.Amount.ToString();
                sell_btn[i].Text = "sell";

                foreach (var c in companies)//getting the newest price of shares
                {
                    string temp1, temp2;
                    temp1 = c.Name.Replace(" ", "");
                    temp2 = share.Company_name.Replace(" ", "");
                    if (temp1 == temp2)
                    {
                        unit_price[i].Text = c.Price.ToString();
                        wallet_value[i].Text = (share.Amount * c.Price).ToString();
                        break;
                    }
                }
                Wallet_panel.Controls.Add(wallet_company_name[i]);
                Wallet_panel.Controls.Add(unit_price[i]);
                Wallet_panel.Controls.Add(amount[i]);
                Wallet_panel.Controls.Add(wallet_value[i]);
                Wallet_panel.Controls.Add(sell_btn[i]);
                sell_btn[i].Click += Sell_btn_Click;

                i++;
            }
            this.cash.Text += cash + " PLN";
        }

        private void Sell_btn_Click(object sender, EventArgs e)
        {
            MessageBox.Show(sender.ToString());//sell shares
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

            client.Close();
            this.Close();
            form.Show();
        }

        private List<Company> Get_data(string data)
        {
            JObject jdata = JObject.Parse(data);
            var item = jdata["Items"];
            List<Company> companies = new List<Company>();
            foreach (var j in item)
            {
                Company company = j.ToObject<Company>();
                companies.Add(company);
            }
            return companies;
        }

        
    }
}
