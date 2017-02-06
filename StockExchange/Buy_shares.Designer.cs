namespace StockExchange
{
    partial class Buy_shares
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Buy_shares));
            this.label1 = new System.Windows.Forms.Label();
            this.unit_count = new System.Windows.Forms.Label();
            this.amount_txt = new System.Windows.Forms.TextBox();
            this.buy_btn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(37, 40);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(193, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Input amount of shares you want to buy";
            // 
            // unit_count
            // 
            this.unit_count.AutoSize = true;
            this.unit_count.Location = new System.Drawing.Point(12, 9);
            this.unit_count.Name = "unit_count";
            this.unit_count.Size = new System.Drawing.Size(59, 13);
            this.unit_count.TabIndex = 1;
            this.unit_count.Text = "Unit count:";
            // 
            // amount_txt
            // 
            this.amount_txt.Location = new System.Drawing.Point(78, 56);
            this.amount_txt.Name = "amount_txt";
            this.amount_txt.Size = new System.Drawing.Size(100, 20);
            this.amount_txt.TabIndex = 2;
            // 
            // buy_btn
            // 
            this.buy_btn.Location = new System.Drawing.Point(92, 82);
            this.buy_btn.Name = "buy_btn";
            this.buy_btn.Size = new System.Drawing.Size(75, 23);
            this.buy_btn.TabIndex = 3;
            this.buy_btn.Text = "Buy";
            this.buy_btn.UseVisualStyleBackColor = true;
            this.buy_btn.Click += new System.EventHandler(this.buy_btn_Click);
            // 
            // Buy_shares
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(254, 129);
            this.Controls.Add(this.buy_btn);
            this.Controls.Add(this.amount_txt);
            this.Controls.Add(this.unit_count);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Buy_shares";
            this.Text = "Buy_shares";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label unit_count;
        private System.Windows.Forms.TextBox amount_txt;
        private System.Windows.Forms.Button buy_btn;
    }
}