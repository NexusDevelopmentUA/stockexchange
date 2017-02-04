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
    public partial class SignUp : Form
    {
        
        public SignUp()
        {
            InitializeComponent();
        }

        private void signup_btn_Click(object sender, EventArgs e)
        {
            Add_Shares form = new Add_Shares(int.Parse(count_txt.Text), login_txt.Text, pass_txt.Text, cash_txt.Text);
            form.Show();
            this.Close();
        }
    }
}
