namespace StockExchange
{
    partial class Sell_shares
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
            this.sell_btn = new System.Windows.Forms.Button();
            this.amount_txt = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.unit_count = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // sell_btn
            // 
            this.sell_btn.Location = new System.Drawing.Point(95, 90);
            this.sell_btn.Name = "sell_btn";
            this.sell_btn.Size = new System.Drawing.Size(75, 23);
            this.sell_btn.TabIndex = 7;
            this.sell_btn.Text = "Sell";
            this.sell_btn.UseVisualStyleBackColor = true;
            this.sell_btn.Click += new System.EventHandler(this.sell_btn_Click);
            // 
            // amount_txt
            // 
            this.amount_txt.Location = new System.Drawing.Point(83, 64);
            this.amount_txt.Name = "amount_txt";
            this.amount_txt.Size = new System.Drawing.Size(100, 20);
            this.amount_txt.TabIndex = 6;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(42, 48);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(191, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Input amount of shares you want to sell";
            // 
            // unit_count
            // 
            this.unit_count.AutoSize = true;
            this.unit_count.Location = new System.Drawing.Point(12, 9);
            this.unit_count.Name = "unit_count";
            this.unit_count.Size = new System.Drawing.Size(59, 13);
            this.unit_count.TabIndex = 8;
            this.unit_count.Text = "Unit count:";
            // 
            // Sell_shares
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(264, 125);
            this.Controls.Add(this.unit_count);
            this.Controls.Add(this.sell_btn);
            this.Controls.Add(this.amount_txt);
            this.Controls.Add(this.label1);
            this.Name = "Sell_shares";
            this.Text = "Sell_shares";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button sell_btn;
        private System.Windows.Forms.TextBox amount_txt;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label unit_count;
    }
}