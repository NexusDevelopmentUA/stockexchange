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
using System.Threading;

namespace StockExchange
{
    public partial class Form1 : Form
    {
        private Thread thread;
        delegate void StockArgReturningVoidDelegate(Label company_name, Label value, Button buy, int row);//initialising stocks
        delegate void UpdateStockArgReturningVoidDelegate(List<Company> companies);//updating stocks when get new values from server
        delegate void UpdateWalletValueArgReturnVoidDelegate();//update wallet value when updating shares values
        delegate void UpdateWalletArgReturnVoidDelegate();//update all wallet after sell operation

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

        private WebSocket client;
        const string host = "ws://webtask.future-processing.com:8068/ws/stocks";
        bool initialized = false;
        List<Company> _companies;
        string raw_companies_data;

        public Form1()
        {
            InitializeComponent();
            client = new WebSocket(host);
            client.Connect();
            client.OnMessage += Client_OnMessage;
            InitializeWallet(Auth.login, sql.Get_cash(Auth.login));
        }

        private void Client_OnMessage(object sender, MessageEventArgs e)
        {
            raw_companies_data = e.Data;
            _companies = Get_data(raw_companies_data);

            if (initialized == false)
            {
                thread = new Thread(() => InitalizeStocks(_companies));
                thread.Start();
            }
            else
            {
                thread = new Thread(() => Update_Stocks(Get_data(e.Data)));
                thread.Start();
            }
        }

        private void InitalizeStocks(List<Company> _companies) //initialise stocks with latest data from server
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


                stocks_company_name[i].Text = item.Name;
                stocks_value[i].Text = item.Price.ToString();//need to round to 2 digits after point
                stocks_unit[i] = item.Unit;
                buy_btn[i].Text = "Buy";
                buy_btn[i].Click += Buy_btn_Click;
                AddNewStock(stocks_company_name[i], stocks_value[i], buy_btn[i], i); //calling method to add new contorls on tableviewpanel for stocks
                i++;
            }
            initialized = true;
        }
        //need to initialze wallet inside form 1, not auth
        public void InitializeWallet(string login, string cash) // initialise wallet with data from DB
        {
            List<Shares> wallet = sql.Get_Shares(login);
            wallet_company_name = new Label[_companies.Count];
            unit_price = new Label[_companies.Count];
            amount = new Label[_companies.Count];
            wallet_value = new Label[_companies.Count];

            foreach (var item in wallet)
            {
                AddNewShare(item); //calling method to add new 
            }
            this.cash.Text += cash + " PLN";
        }
        private void AddNewStock(Label company_name, Label value, Button buy, int row)
        {
            if (Stocks_panel.InvokeRequired)
            {
                StockArgReturningVoidDelegate d = new StockArgReturningVoidDelegate(AddNewStock);
                this.Invoke(d, new object[] { company_name, value, buy, row });
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
            if (Stocks_panel.InvokeRequired)
            {
                UpdateStockArgReturningVoidDelegate d = new UpdateStockArgReturningVoidDelegate(Update_Stocks);
                this.Invoke(d, new object[] { _companies });
            }
            else
            {
                int i = 0;

                foreach (var item in _companies)
                {
                    stocks_company_name[i].Text = item.Name;
                    stocks_value[i].Text = item.Price.ToString();//need to round to 2 digits after point
                    stocks_unit[i] = item.Unit;
                    buy_btn[i].Text = "Buy";
                    buy_btn[i].Click += Buy_btn_Click;
                    AddNewStock(stocks_company_name[i], stocks_value[i], buy_btn[i], i);
                    i++;
                }
            }
        }

        private void Update_wallet_value()
        {
            
        }

        private void AddNewShare(Shares share)
        {
            Label company_name = new Label();
            Label unit_price = new Label();
            Label amount = new Label();
            Label value = new Label();
            Button sell_btn = new Button();
            sell_btn.Click += Sell_btn_Click;
            company_name.Text = share.Company_name;
            amount.Text = share.Amount.ToString();
            sell_btn.Text = "sell";
            foreach(var i in _companies)
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

        private void Client_OnMessage_Load(object sender, MessageEventArgs e)
        {
            thread = new Thread(() => Update_Stocks(Get_data(e.Data)));
            thread.Start();
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

        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show(stocks_company_name[3].Text);
        }
    }
}
