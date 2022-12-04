namespace WindowsFormsApp1
{
    partial class SetPlayer
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
            this.label2 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.virtual_player_rb = new System.Windows.Forms.RadioButton();
            this.difficulty_label = new System.Windows.Forms.Label();
            this.medium_rb = new System.Windows.Forms.RadioButton();
            this.easy_rb = new System.Windows.Forms.RadioButton();
            this.next_bt = new System.Windows.Forms.Button();
            this.previous_bt = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(254)));
            this.label1.Location = new System.Drawing.Point(264, 58);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(131, 37);
            this.label1.TabIndex = 0;
            this.label1.Text = "Player 1";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(231, 133);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(51, 20);
            this.label2.TabIndex = 1;
            this.label2.Text = "Name";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(330, 130);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(120, 26);
            this.textBox1.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(231, 228);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(43, 20);
            this.label3.TabIndex = 3;
            this.label3.Text = "Type";
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Location = new System.Drawing.Point(330, 209);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(86, 24);
            this.radioButton1.TabIndex = 4;
            this.radioButton1.TabStop = true;
            this.radioButton1.Text = "Human";
            this.radioButton1.UseVisualStyleBackColor = true;
            // 
            // virtual_player_rb
            // 
            this.virtual_player_rb.AutoSize = true;
            this.virtual_player_rb.Location = new System.Drawing.Point(330, 249);
            this.virtual_player_rb.Name = "virtual_player_rb";
            this.virtual_player_rb.Size = new System.Drawing.Size(126, 24);
            this.virtual_player_rb.TabIndex = 5;
            this.virtual_player_rb.TabStop = true;
            this.virtual_player_rb.Text = "Virtual Player";
            this.virtual_player_rb.UseVisualStyleBackColor = true;
            this.virtual_player_rb.CheckedChanged += new System.EventHandler(this.virtual_player_rb_CheckedChanged);
            // 
            // difficulty_label
            // 
            this.difficulty_label.AutoSize = true;
            this.difficulty_label.Location = new System.Drawing.Point(231, 349);
            this.difficulty_label.Name = "difficulty_label";
            this.difficulty_label.Size = new System.Drawing.Size(69, 20);
            this.difficulty_label.TabIndex = 6;
            this.difficulty_label.Text = "Difficulty";
            this.difficulty_label.Visible = false;
            // 
            // medium_rb
            // 
            this.medium_rb.AutoSize = true;
            this.medium_rb.Location = new System.Drawing.Point(330, 364);
            this.medium_rb.Name = "medium_rb";
            this.medium_rb.Size = new System.Drawing.Size(90, 24);
            this.medium_rb.TabIndex = 8;
            this.medium_rb.TabStop = true;
            this.medium_rb.Text = "Medium";
            this.medium_rb.UseVisualStyleBackColor = true;
            this.medium_rb.Visible = false;
            // 
            // easy_rb
            // 
            this.easy_rb.AutoSize = true;
            this.easy_rb.Location = new System.Drawing.Point(330, 324);
            this.easy_rb.Name = "easy_rb";
            this.easy_rb.Size = new System.Drawing.Size(69, 24);
            this.easy_rb.TabIndex = 7;
            this.easy_rb.TabStop = true;
            this.easy_rb.Text = "Easy";
            this.easy_rb.UseVisualStyleBackColor = true;
            this.easy_rb.Visible = false;
            // 
            // next_bt
            // 
            this.next_bt.Location = new System.Drawing.Point(555, 417);
            this.next_bt.Name = "next_bt";
            this.next_bt.Size = new System.Drawing.Size(94, 46);
            this.next_bt.TabIndex = 9;
            this.next_bt.Text = "Next";
            this.next_bt.UseVisualStyleBackColor = true;
            this.next_bt.Click += new System.EventHandler(this.next_bt_Click);
            // 
            // previous_bt
            // 
            this.previous_bt.Location = new System.Drawing.Point(23, 417);
            this.previous_bt.Name = "previous_bt";
            this.previous_bt.Size = new System.Drawing.Size(94, 46);
            this.previous_bt.TabIndex = 10;
            this.previous_bt.Text = "Previous";
            this.previous_bt.UseVisualStyleBackColor = true;
            this.previous_bt.Click += new System.EventHandler(this.previous_bt_Click);
            // 
            // SetPlayer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(672, 474);
            this.Controls.Add(this.previous_bt);
            this.Controls.Add(this.next_bt);
            this.Controls.Add(this.medium_rb);
            this.Controls.Add(this.easy_rb);
            this.Controls.Add(this.difficulty_label);
            this.Controls.Add(this.virtual_player_rb);
            this.Controls.Add(this.radioButton1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "SetPlayer";
            this.Text = "Set Player";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.RadioButton radioButton1;
        private System.Windows.Forms.RadioButton virtual_player_rb;
        private System.Windows.Forms.Label difficulty_label;
        private System.Windows.Forms.RadioButton medium_rb;
        private System.Windows.Forms.RadioButton easy_rb;
        private System.Windows.Forms.Button next_bt;
        private System.Windows.Forms.Button previous_bt;
    }
}