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
using System.Globalization;

namespace StockExchange
{
    public partial class Form1 : Form
    {
        private Thread thread;
        delegate void StockArgReturningVoidDelegate(Label company_name, Label value, Button buy, int row);//initialising stocks
        delegate void WalletArgReturningVoidDelegate(Label company_name, Label value, Label amount, Label unit_price, Button sell);//initialising wallet
        delegate void UpdateStockArgReturningVoidDelegate(List<Company> companies);//updating stocks when get new values from server
        delegate void UpdateWalletValueArgReturnVoidDelegate();//update wallet value when updating shares values
        delegate void UpdateWalletArgReturnVoidDelegate();//update all wallet after sell operation

        //Arrays of controls for stocks
        public Label[] stocks_company_name;
        public Label[] stocks_value;
        Button[] buy_btn;
        public int[] stocks_unit;
        public int[] shares_amount;

        //Array of controls for wallet
        public Label[] wallet_company_name;
        Label[] unit_price;
        public Label[] amount;
        Label[] wallet_value;
        Button[] sell_btn;

        SQL_repository sql = new SQL_repository();

        private WebSocket client;
        const string host = "ws://webtask.future-processing.com:8068/ws/stocks";
        bool initialized = false;
        bool error = false;
        List<Company> _companies;
        List<Shares> wallet;
        string raw_companies_data;

        public Form1()
        {
            InitializeComponent();
            shares_amount= sql.Get_current_shares_amount();
            client = new WebSocket(host);
            client.Connect();
            client.OnMessage += Client_OnMessage;
            InitializeWallet(Auth.login, sql.Get_cash(Auth.login));
            client.OnError += Client_OnError;
            login.Text = Auth.login;
           
        }
        //if something will happen during connectin to webserver
        //error message will appear and all buttons will be disable
        private void Client_OnError(object sender, ErrorEventArgs e)
        {
            MessageBox.Show("Server error occuered!", "Error");
            foreach(var item in sell_btn)
            {
                item.Enabled = false;
            }
            foreach(var item in buy_btn)
            {
                item.Enabled = false;
            }
            error = true;
        }
        //if everything okay, inititalise stocks
        
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
                thread = new Thread(() => Update_Stocks(Get_data(e.Data)));//updating stocks
                thread.Start();
                thread = new Thread(() => Update_wallet_value());//updating wallet values
                thread.Start();
            }
            if (error == true)
            {
                MessageBox.Show("Session established");
                foreach (var item in sell_btn)
                {
                    item.Enabled = true;
                }
                foreach (var item in buy_btn)
                {
                    item.Enabled = true;
                }
                error = false;
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


                stocks_company_name[i].Text = item.Code;
                stocks_value[i].Text = Math.Round(item.Price,2).ToString()+" PLN";//need to round to 2 digits after point
                stocks_unit[i] = item.Unit;
                buy_btn[i].Text = "Buy";
                buy_btn[i].Click += Buy_btn_Click;
                AddNewStock(stocks_company_name[i], stocks_value[i], buy_btn[i], i); //calling method to add new contorls for each stock on tableviewpanel
                i++;
            }
            
            DateTime time = DateTime.Now;
            update_time.Text = time.Hour.ToString() +":"+ time.Minute.ToString() + ":" + time.Second.ToString();
            initialized = true;
        }
        public void InitializeWallet(string login, string cash) // initialise wallet with data from DB
        {
            wallet = sql.Get_Shares(login);
            wallet_company_name = new Label[_companies.Count];
            unit_price = new Label[_companies.Count];
            amount = new Label[_companies.Count];
            wallet_value = new Label[_companies.Count];
            sell_btn = new Button[_companies.Count];
            int i = 0;

            foreach (var item in wallet)
            {
                wallet_company_name[i] = new Label();
                unit_price[i] = new Label();
                amount[i] = new Label();
                wallet_value[i] = new Label();
                sell_btn[i] = new Button();

                sell_btn[i].Click += Sell_btn_Click;
                wallet_company_name[i].Text = item.Company_name;
                amount[i].Text = item.Amount.ToString();
                sell_btn[i].Text = "Sell";

                foreach (var c in _companies)
                {
                    string temp1, temp2;
                    temp1 = c.Code.Replace(" ", "");//removing free spaces from database varchar values
                    temp2 = item.Company_name.Replace(" ", "");
                    if (temp1 == temp2)
                    {
                        unit_price[i].Text = Math.Round(c.Price,2).ToString()+" PLN";
                        wallet_value[i].Text = Math.Round((item.Amount * c.Price),2).ToString()+" PLN";
                        break;
                    }
                }
                AddNewShare(wallet_company_name[i], wallet_value[i], amount[i], unit_price[i], sell_btn[i]); //calling method to add new contorls for each share package in tableviewpanel
                i++;
            }
            this.cash.Text = Math.Round(double.Parse(cash),2) + " PLN";
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
                    stocks_value[i].Text = Math.Round(item.Price,2).ToString()+" PLN";
                    stocks_unit[i] = item.Unit;
                    i++;
                }
                sql.Get_current_shares_amount();
                DateTime time = DateTime.Now;
                update_time.Text = time.Hour.ToString() + ":" + time.Minute.ToString() + ":" + time.Second.ToString();
            }
        }

        private void Update_wallet_value()
        {
           if(Wallet_panel.InvokeRequired)
            {
                UpdateWalletValueArgReturnVoidDelegate d = new UpdateWalletValueArgReturnVoidDelegate(Update_wallet_value);
                this.Invoke(d, new object[] { });
            } 
           else
            {
                wallet = sql.Get_Shares(login.Text);
                string cash = sql.Get_cash(login.Text);
                this.cash.Text = Math.Round(double.Parse(cash), 2) + " PLN";
                int i = 0;
                foreach (var item in wallet)
                {
                    if (i >= Wallet_panel.Controls.Count/5)//checking if need to add new element to array and display it on the form
                    {
                        wallet_company_name[i] = new Label();
                        amount[i] = new Label();
                        unit_price[i] = new Label();
                        wallet_value[i] = new Label();
                        sell_btn[i] = new Button();
                        sell_btn[i].Click += Sell_btn_Click;

                        wallet_company_name[i].Text = item.Company_name;
                        amount[i].Text = item.Amount.ToString();
                        sell_btn[i].Text = "Sell";

                        foreach (var c in _companies)
                        {
                            string temp1, temp2;
                            temp1 = c.Code.Replace(" ", "");//removing free spaces from database varchar values
                            temp2 = item.Company_name.Replace(" ", "");
                            if (temp1 == temp2)
                            {
                                unit_price[i].Text = c.Price.ToString();
                                wallet_value[i].Text = (item.Amount * c.Price).ToString();
                                break;
                            }
                        }
                        AddNewShare(wallet_company_name[i], wallet_value[i], amount[i], unit_price[i], sell_btn[i]);
                    }
                    else
                    {
                        wallet_company_name[i].Text = item.Company_name;
                        amount[i].Text = item.Amount.ToString();
                        foreach (var c in _companies)
                        {
                            string temp1, temp2;
                            temp1 = c.Code.Replace(" ", "");//removing free spaces from database varchar values
                            temp2 = item.Company_name.Replace(" ", "");
                            if (temp1 == temp2)
                            {
                                unit_price[i].Text = c.Price.ToString();
                                wallet_value[i].Text = (item.Amount * c.Price).ToString();
                                break;
                            }
                        }
                        i++;
                    }
                }
            }
        }

        private void AddNewShare(Label company_name, Label value, Label amount, Label unit_price, Button sell)
        {
            if (Wallet_panel.InvokeRequired)
            {
                WalletArgReturningVoidDelegate d = new WalletArgReturningVoidDelegate(AddNewShare);
                this.Invoke(d, new object[] { company_name, value, amount, unit_price, sell });
            }
            else
            {
                Wallet_panel.Controls.Add(company_name);
                Wallet_panel.Controls.Add(unit_price);
                Wallet_panel.Controls.Add(amount);
                Wallet_panel.Controls.Add(value);
                Wallet_panel.Controls.Add(sell);
            }
        }

        private void Sell_btn_Click(object sender, EventArgs e)
        {
            var index = Array.IndexOf(sell_btn, sender);
            Sell_shares form = new Sell_shares(index);
            form.Show();
        }

        private void Buy_btn_Click(object sender, EventArgs e)
        {
            var index = Array.IndexOf(buy_btn, sender);
            Buy_shares form = new Buy_shares(index);
            form.Show();
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

        private List<Company> Get_data(string data)//convert data from string into json and then fitting list of objects
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

        public void Form_update()
        {
            Thread wallet_update = new Thread(() => Update_wallet_value());
            wallet_update.Start();
        }

        private void Form1_Enter(object sender, EventArgs e)
        {
            Thread wallet_update = new Thread(() => Update_wallet_value());
            wallet_update.Start();
        }

        private void Form1_Activated(object sender, EventArgs e)
        {
            Thread wallet_update = new Thread(() => Update_wallet_value());
            wallet_update.Start();
            Console.WriteLine("ACTIVATED");
        }
    }
}
