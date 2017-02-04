namespace StockExchange
{
    partial class SignUp
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.login_txt = new System.Windows.Forms.TextBox();
            this.pass_txt = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cash_txt = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.count_txt = new System.Windows.Forms.TextBox();
            this.signup_btn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(118, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(33, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Login";
            // 
            // login_txt
            // 
            this.login_txt.Location = new System.Drawing.Point(88, 45);
            this.login_txt.Name = "login_txt";
            this.login_txt.Size = new System.Drawing.Size(100, 20);
            this.login_txt.TabIndex = 1;
            // 
            // pass_txt
            // 
            this.pass_txt.Location = new System.Drawing.Point(88, 87);
            this.pass_txt.Name = "pass_txt";
            this.pass_txt.Size = new System.Drawing.Size(100, 20);
            this.pass_txt.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(118, 71);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(30, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Pass";
            // 
            // cash_txt
            // 
            this.cash_txt.Location = new System.Drawing.Point(88, 127);
            this.cash_txt.Name = "cash_txt";
            this.cash_txt.Size = new System.Drawing.Size(100, 20);
            this.cash_txt.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(103, 110);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(58, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Cash, PLN";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(85, 150);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(120, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "Owned share packages";
            // 
            // count_txt
            // 
            this.count_txt.Location = new System.Drawing.Point(88, 166);
            this.count_txt.Name = "count_txt";
            this.count_txt.Size = new System.Drawing.Size(100, 20);
            this.count_txt.TabIndex = 8;
            this.count_txt.Text = "0";
            // 
            // signup_btn
            // 
            this.signup_btn.Location = new System.Drawing.Point(97, 192);
            this.signup_btn.Name = "signup_btn";
            this.signup_btn.Size = new System.Drawing.Size(75, 23);
            this.signup_btn.TabIndex = 9;
            this.signup_btn.Text = "Continue";
            this.signup_btn.UseVisualStyleBackColor = true;
            this.signup_btn.Click += new System.EventHandler(this.signup_btn_Click);
            // 
            // SignUp
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(285, 262);
            this.Controls.Add(this.signup_btn);
            this.Controls.Add(this.count_txt);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.cash_txt);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.pass_txt);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.login_txt);
            this.Controls.Add(this.label1);
            this.Name = "SignUp";
            this.Text = "SignUp";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox login_txt;
        private System.Windows.Forms.TextBox pass_txt;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox cash_txt;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox count_txt;
        private System.Windows.Forms.Button signup_btn;
    }
}