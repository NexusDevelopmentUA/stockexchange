using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace StockExchange
{
    class SQL_repository
    {
        protected const string conn_str = "Data Source=sql5034.mywindowshosting.com;Persist Security Info=True;User ID=DB_A17D55_nexusdev_admin;Password=Rasdagar_1";

        public void SQL_conn()
        {
            SqlConnection conn = new SqlConnection(conn_str);
            try
            {
                conn.Open();
                Console.WriteLine("SUCCESS");
            }
            catch(Exception e) { }
            conn.Close();
        }
        public int LogIn(string login, string pass)
        {
            SqlConnection conn = new SqlConnection(conn_str);
            SqlCommand command = new SqlCommand("SELECT dbo.Auth(@login, @pass)", conn);
            command.Parameters.Add(new SqlParameter("@login", login));
            command.Parameters.Add(new SqlParameter("@pass", pass));
            int result = 0;

            try
            {
                command.Connection.Open();
                result = Int32.Parse(command.ExecuteScalar().ToString());
                Console.WriteLine("SUCCESS");
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }
            conn.Close();
            return result;
        }

        public void SignUp(string login, string pass, string cash, List<Shares> wallet)
        {
            SqlConnection conn = new SqlConnection(conn_str);
            SqlCommand new_user = new SqlCommand("add_new_user", conn);//add info into DB
            SqlCommand get_id = new SqlCommand("SELECT Id FROM users WHERE login = @0", conn);
            string user_id;

            try
            {
                conn.Open();
                new_user.CommandType = CommandType.StoredProcedure;

                new_user.Parameters.AddWithValue("@login", login);
                new_user.Parameters.AddWithValue("@pass", pass);
                new_user.Parameters.AddWithValue("@cash", cash);
                new_user.ExecuteNonQuery();

                get_id.Parameters.Add(new SqlParameter("@0", login));
                user_id = get_id.ExecuteScalar().ToString();

                foreach(var item in wallet)
                {
                    SqlCommand new_share_package = new SqlCommand("add_new_share_package", conn);
                    new_share_package.CommandType = CommandType.StoredProcedure;
                    new_share_package.Parameters.AddWithValue("@company",item.Company_name);
                    new_share_package.Parameters.AddWithValue("@amount",item.Amount);
                    new_share_package.Parameters.AddWithValue("@id_user",user_id);
                    new_share_package.ExecuteNonQuery();
                }
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }
            conn.Close();
        }

        public List<Shares> Get_Shares(string login)
        {
            SqlConnection conn = new SqlConnection(conn_str);
            SqlDataAdapter adapter = new SqlDataAdapter();
            string user_id;
            string company_name = "", amount = "";
            DataSet dset = new DataSet();
            List<Shares> wallet = new List<Shares>();
            SqlCommand get_id = new SqlCommand("SELECT Id FROM users WHERE login = @0",conn);
            get_id.Parameters.Add(new SqlParameter("@0", login));
            SqlCommand get_shares = new SqlCommand("SELECT company_id, amount FROM wallets WHERE id_user=(@id_user)", conn);
            SqlCommand get_company_name = new SqlCommand("SELECT company_name FROM companies WHERE Id_company=(@id_company)", conn);
            //I have done all of this not with UDF because of some sort of bug on server i can't create UDF that will return table
            //
            try
            {
                conn.Open();
                user_id = get_id.ExecuteScalar().ToString();
                get_shares.Parameters.Add(new SqlParameter("@id_user", user_id));
                adapter.SelectCommand = get_shares;
                adapter.Fill(dset, "Main");
                foreach (DataRow row in dset.Tables["Main"].Rows)
                {
                    foreach(DataColumn column in dset.Tables["Main"].Columns)
                    {
                        switch (column.ColumnName)
                        {
                            case "company_id":
                                {
                                    company_name = row[column].ToString();
                                    //get_company_name.Parameters.Add(new SqlParameter("@id_company", tmp));
                                    //company_name=get_company_name.ExecuteScalar().ToString();
                                    break;
                                }
                            case "amount":
                                {
                                    amount = row[column].ToString();
                                    break;
                                }
                        }
                    }
                    wallet.Add(new Shares() { Company_name = company_name, Amount = Int32.Parse(amount) });
                }
                conn.Close();
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }
            Console.WriteLine("DONE");
            return wallet;
        }
        public string Get_cash(string login)
        {
            SqlConnection conn = new SqlConnection(conn_str);
            SqlCommand command = new SqlCommand("SELECT cash FROM users WHERE login=(@login)", conn);
            command.Parameters.AddWithValue("@login", login);
            string cash="";
            try
            {
                conn.Open();
                cash = command.ExecuteScalar().ToString();
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }
            conn.Close();
            return cash;
        }

        public void Update_after_buy(string login, double cash, string company_name, int amount)
        {
            SqlConnection conn = new SqlConnection(conn_str);
            SqlCommand command = new SqlCommand("update_shares", conn);
            command.Parameters.AddWithValue("@login", login);
            command.Parameters.AddWithValue("@cash", cash);
            command.Parameters.AddWithValue("@company_name", company_name);
            command.Parameters.AddWithValue("@amount", amount);
            try
            {
                conn.Open();
                command.CommandType = CommandType.StoredProcedure;
                command.ExecuteNonQuery();

            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public void Update_after_sell(string login, double cash, string company_name, int amount)
        {
            SqlConnection conn = new SqlConnection(conn_str);
            SqlCommand command = new SqlCommand("update_shares_sell", conn);
            command.Parameters.AddWithValue("@login", login);
            command.Parameters.AddWithValue("@cash", cash);
            command.Parameters.AddWithValue("@company_name", company_name);
            command.Parameters.AddWithValue("@amount", amount);
            try
            {
                conn.Open();
                command.CommandType = CommandType.StoredProcedure;
                command.ExecuteNonQuery();

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            conn.Close();
        }
        public int[] Get_current_shares_amount()
        {
            SqlConnection conn = new SqlConnection(conn_str);
            SqlCommand command = new SqlCommand("SELECT shares_amount FROM companies",conn);
            SqlDataAdapter adapter = new SqlDataAdapter();
            DataSet dset = new DataSet();
            int[] output=new int[1];
            int i = 0;

            try
            {
                conn.Open();
                adapter.SelectCommand = command;
                adapter.Fill(dset, "Main");
                output = new int[dset.Tables["Main"].Rows.Count];
                foreach (DataRow row in dset.Tables["Main"].Rows)
                {
                    output[i] = int.Parse(row["shares_amount"].ToString());
                    i++;
                }
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }
            conn.Close();
            return output;
        }
    }

}
