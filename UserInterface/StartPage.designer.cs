namespace WindowsFormsApp1
{
    partial class StartPage
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
            this.start_bt = new System.Windows.Forms.Button();
            this.card_friendly_ui_bt = new System.Windows.Forms.Button();
            this.cad_plain_text_bt = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(254)));
            this.label1.Location = new System.Drawing.Point(250, 49);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(150, 37);
            this.label1.TabIndex = 0;
            this.label1.Text = "Welcome";
            // 
            // start_bt
            // 
            this.start_bt.Location = new System.Drawing.Point(205, 161);
            this.start_bt.Name = "start_bt";
            this.start_bt.Size = new System.Drawing.Size(251, 56);
            this.start_bt.TabIndex = 1;
            this.start_bt.Text = "Start Game";
            this.start_bt.UseVisualStyleBackColor = true;
            this.start_bt.Click += new System.EventHandler(this.start_bt_Click);
            // 
            // card_friendly_ui_bt
            // 
            this.card_friendly_ui_bt.Location = new System.Drawing.Point(205, 261);
            this.card_friendly_ui_bt.Name = "card_friendly_ui_bt";
            this.card_friendly_ui_bt.Size = new System.Drawing.Size(251, 56);
            this.card_friendly_ui_bt.TabIndex = 2;
            this.card_friendly_ui_bt.Text = "CreateICard(Friendly UI)";
            this.card_friendly_ui_bt.UseVisualStyleBackColor = true;
            this.card_friendly_ui_bt.Click += new System.EventHandler(this.card_friendly_ui_bt_Click);
            // 
            // cad_plain_text_bt
            // 
            this.cad_plain_text_bt.Location = new System.Drawing.Point(205, 364);
            this.cad_plain_text_bt.Name = "cad_plain_text_bt";
            this.cad_plain_text_bt.Size = new System.Drawing.Size(251, 56);
            this.cad_plain_text_bt.TabIndex = 3;
            this.cad_plain_text_bt.Text = "CreateICard(Plain text)";
            this.cad_plain_text_bt.UseVisualStyleBackColor = true;
            this.cad_plain_text_bt.Click += new System.EventHandler(this.cad_plain_text_bt_Click);
            // 
            // StartPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(660, 480);
            this.Controls.Add(this.cad_plain_text_bt);
            this.Controls.Add(this.card_friendly_ui_bt);
            this.Controls.Add(this.start_bt);
            this.Controls.Add(this.label1);
            this.Name = "StartPage";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Game Name";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.StartPage_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button start_bt;
        private System.Windows.Forms.Button card_friendly_ui_bt;
        private System.Windows.Forms.Button cad_plain_text_bt;
    }
}