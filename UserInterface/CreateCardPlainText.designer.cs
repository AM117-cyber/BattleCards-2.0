namespace WindowsFormsApp1
{
    partial class CreateCardPlainText
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
            this.card_exp = new System.Windows.Forms.TextBox();
            this.next_bt = new System.Windows.Forms.Button();
            this.previous_bt = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // card_exp
            // 
            this.card_exp.Location = new System.Drawing.Point(33, 36);
            this.card_exp.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.card_exp.Multiline = true;
            this.card_exp.Name = "card_exp";
            this.card_exp.Size = new System.Drawing.Size(812, 465);
            this.card_exp.TabIndex = 0;
            // 
            // next_bt
            // 
            this.next_bt.Location = new System.Drawing.Point(741, 536);
            this.next_bt.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.next_bt.Name = "next_bt";
            this.next_bt.Size = new System.Drawing.Size(104, 58);
            this.next_bt.TabIndex = 10;
            this.next_bt.Text = "Next";
            this.next_bt.UseVisualStyleBackColor = true;
            this.next_bt.Click += new System.EventHandler(this.next_bt_Click);
            // 
            // previous_bt
            // 
            this.previous_bt.Location = new System.Drawing.Point(33, 536);
            this.previous_bt.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.previous_bt.Name = "previous_bt";
            this.previous_bt.Size = new System.Drawing.Size(104, 58);
            this.previous_bt.TabIndex = 11;
            this.previous_bt.Text = "Previous";
            this.previous_bt.UseVisualStyleBackColor = true;
            this.previous_bt.Click += new System.EventHandler(this.previous_bt_Click);
            // 
            // CreateCardPlainText
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(882, 609);
            this.Controls.Add(this.previous_bt);
            this.Controls.Add(this.next_bt);
            this.Controls.Add(this.card_exp);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "CreateCardPlainText";
            this.Text = "Create Card";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox card_exp;
        private System.Windows.Forms.Button next_bt;
        private System.Windows.Forms.Button previous_bt;
    }
}