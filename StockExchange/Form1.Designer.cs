namespace StockExchange
{
    partial class Form1
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
            this.Stocks_panel = new System.Windows.Forms.TableLayoutPanel();
            this.Wallet_panel = new System.Windows.Forms.TableLayoutPanel();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.log_out_btn = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.new_acc_login_btn = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.cash = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // Stocks_panel
            // 
            this.Stocks_panel.ColumnCount = 3;
            this.Stocks_panel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.Stocks_panel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.Stocks_panel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 123F));
            this.Stocks_panel.Location = new System.Drawing.Point(15, 101);
            this.Stocks_panel.Name = "Stocks_panel";
            this.Stocks_panel.RowCount = 2;
            this.Stocks_panel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.Stocks_panel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.Stocks_panel.Size = new System.Drawing.Size(481, 286);
            this.Stocks_panel.TabIndex = 1;
            // 
            // Wallet_panel
            // 
            this.Wallet_panel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Wallet_panel.ColumnCount = 5;
            this.Wallet_panel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.Wallet_panel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.Wallet_panel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.Wallet_panel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.Wallet_panel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.Wallet_panel.Location = new System.Drawing.Point(684, 101);
            this.Wallet_panel.Name = "Wallet_panel";
            this.Wallet_panel.RowCount = 2;
            this.Wallet_panel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.Wallet_panel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.Wallet_panel.Size = new System.Drawing.Size(544, 60);
            this.Wallet_panel.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(15, 82);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(51, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Company";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(197, 82);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(34, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Value";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(378, 82);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(42, 13);
            this.label4.TabIndex = 5;
            this.label4.Text = "Actions";
            // 
            // log_out_btn
            // 
            this.log_out_btn.Location = new System.Drawing.Point(1151, 13);
            this.log_out_btn.Name = "log_out_btn";
            this.log_out_btn.Size = new System.Drawing.Size(75, 23);
            this.log_out_btn.TabIndex = 6;
            this.log_out_btn.Text = "Log out";
            this.log_out_btn.UseVisualStyleBackColor = true;
            this.log_out_btn.Click += new System.EventHandler(this.log_out_btn_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(1062, 13);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 7;
            this.button2.Text = "Settings";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(931, 16);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(60, 13);
            this.label5.TabIndex = 8;
            this.label5.Text = "Logged as ";
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.new_acc_login_btn);
            this.groupBox1.Controls.Add(this.log_out_btn);
            this.groupBox1.Controls.Add(this.button2);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Location = new System.Drawing.Point(12, 13);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1226, 42);
            this.groupBox1.TabIndex = 9;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Stocks";
            // 
            // new_acc_login_btn
            // 
            this.new_acc_login_btn.Location = new System.Drawing.Point(57, 13);
            this.new_acc_login_btn.Name = "new_acc_login_btn";
            this.new_acc_login_btn.Size = new System.Drawing.Size(114, 23);
            this.new_acc_login_btn.TabIndex = 9;
            this.new_acc_login_btn.Text = "Another Account";
            this.new_acc_login_btn.UseVisualStyleBackColor = true;
            this.new_acc_login_btn.Click += new System.EventHandler(this.new_acc_login_btn_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Location = new System.Drawing.Point(12, 61);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(498, 339);
            this.groupBox2.TabIndex = 10;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Stock";
            // 
            // groupBox3
            // 
            this.groupBox3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox3.Controls.Add(this.label8);
            this.groupBox3.Controls.Add(this.label7);
            this.groupBox3.Controls.Add(this.label6);
            this.groupBox3.Controls.Add(this.label1);
            this.groupBox3.Location = new System.Drawing.Point(674, 61);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(564, 278);
            this.groupBox3.TabIndex = 11;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Wallet";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(120, 21);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(52, 13);
            this.label8.TabIndex = 3;
            this.label8.Text = "Unit price";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(334, 20);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(34, 13);
            this.label7.TabIndex = 2;
            this.label7.Text = "Value";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(221, 20);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(43, 13);
            this.label6.TabIndex = 1;
            this.label6.Text = "Amount";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(80, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Company name";
            // 
            // cash
            // 
            this.cash.AutoSize = true;
            this.cash.Location = new System.Drawing.Point(882, 374);
            this.cash.Name = "cash";
            this.cash.Size = new System.Drawing.Size(90, 13);
            this.cash.TabIndex = 12;
            this.cash.Text = "Avaliable money: ";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1266, 399);
            this.Controls.Add(this.cash);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.Wallet_panel);
            this.Controls.Add(this.Stocks_panel);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox3);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TableLayoutPanel Stocks_panel;
        private System.Windows.Forms.TableLayoutPanel Wallet_panel;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button log_out_btn;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        public System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button new_acc_login_btn;
        private System.Windows.Forms.Label cash;
    }
}

