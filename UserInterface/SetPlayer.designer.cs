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
            this.name_textBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.human_rb = new System.Windows.Forms.RadioButton();
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
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(293, 72);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(131, 37);
            this.label1.TabIndex = 0;
            this.label1.Text = "Player 1";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(257, 166);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 25);
            this.label2.TabIndex = 1;
            this.label2.Text = "Name";
            // 
            // name_textBox
            // 
            this.name_textBox.Location = new System.Drawing.Point(367, 162);
            this.name_textBox.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.name_textBox.Name = "name_textBox";
            this.name_textBox.Size = new System.Drawing.Size(133, 31);
            this.name_textBox.TabIndex = 2;
            this.name_textBox.Text = "Player1";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(257, 285);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(49, 25);
            this.label3.TabIndex = 3;
            this.label3.Text = "Type";
            // 
            // human_rb
            // 
            this.human_rb.AutoSize = true;
            this.human_rb.Checked = true;
            this.human_rb.Location = new System.Drawing.Point(367, 261);
            this.human_rb.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.human_rb.Name = "human_rb";
            this.human_rb.Size = new System.Drawing.Size(95, 29);
            this.human_rb.TabIndex = 4;
            this.human_rb.TabStop = true;
            this.human_rb.Text = "Human";
            this.human_rb.UseVisualStyleBackColor = true;
            // 
            // virtual_player_rb
            // 
            this.virtual_player_rb.AutoSize = true;
            this.virtual_player_rb.Location = new System.Drawing.Point(367, 311);
            this.virtual_player_rb.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.virtual_player_rb.Name = "virtual_player_rb";
            this.virtual_player_rb.Size = new System.Drawing.Size(139, 29);
            this.virtual_player_rb.TabIndex = 5;
            this.virtual_player_rb.Text = "Virtual Player";
            this.virtual_player_rb.UseVisualStyleBackColor = true;
            this.virtual_player_rb.CheckedChanged += new System.EventHandler(this.virtual_player_rb_CheckedChanged);
            // 
            // difficulty_label
            // 
            this.difficulty_label.AutoSize = true;
            this.difficulty_label.Location = new System.Drawing.Point(257, 436);
            this.difficulty_label.Name = "difficulty_label";
            this.difficulty_label.Size = new System.Drawing.Size(82, 25);
            this.difficulty_label.TabIndex = 6;
            this.difficulty_label.Text = "Difficulty";
            this.difficulty_label.Visible = false;
            // 
            // medium_rb
            // 
            this.medium_rb.AutoSize = true;
            this.medium_rb.Location = new System.Drawing.Point(367, 455);
            this.medium_rb.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.medium_rb.Name = "medium_rb";
            this.medium_rb.Size = new System.Drawing.Size(103, 29);
            this.medium_rb.TabIndex = 8;
            this.medium_rb.Text = "Medium";
            this.medium_rb.UseVisualStyleBackColor = true;
            this.medium_rb.Visible = false;
            // 
            // easy_rb
            // 
            this.easy_rb.AutoSize = true;
            this.easy_rb.Location = new System.Drawing.Point(367, 405);
            this.easy_rb.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.easy_rb.Name = "easy_rb";
            this.easy_rb.Size = new System.Drawing.Size(72, 29);
            this.easy_rb.TabIndex = 7;
            this.easy_rb.Text = "Easy";
            this.easy_rb.UseVisualStyleBackColor = true;
            this.easy_rb.Visible = false;
            // 
            // next_bt
            // 
            this.next_bt.Location = new System.Drawing.Point(617, 521);
            this.next_bt.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.next_bt.Name = "next_bt";
            this.next_bt.Size = new System.Drawing.Size(104, 58);
            this.next_bt.TabIndex = 9;
            this.next_bt.Text = "Next";
            this.next_bt.UseVisualStyleBackColor = true;
            this.next_bt.Click += new System.EventHandler(this.next_bt_Click);
            // 
            // previous_bt
            // 
            this.previous_bt.Location = new System.Drawing.Point(26, 521);
            this.previous_bt.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.previous_bt.Name = "previous_bt";
            this.previous_bt.Size = new System.Drawing.Size(104, 58);
            this.previous_bt.TabIndex = 10;
            this.previous_bt.Text = "Previous";
            this.previous_bt.UseVisualStyleBackColor = true;
            this.previous_bt.Click += new System.EventHandler(this.previous_bt_Click);
            // 
            // SetPlayer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(747, 592);
            this.Controls.Add(this.previous_bt);
            this.Controls.Add(this.next_bt);
            this.Controls.Add(this.medium_rb);
            this.Controls.Add(this.easy_rb);
            this.Controls.Add(this.difficulty_label);
            this.Controls.Add(this.virtual_player_rb);
            this.Controls.Add(this.human_rb);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.name_textBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "SetPlayer";
            this.Text = "Set Player";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox name_textBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.RadioButton human_rb;
        private System.Windows.Forms.RadioButton virtual_player_rb;
        private System.Windows.Forms.Label difficulty_label;
        private System.Windows.Forms.RadioButton medium_rb;
        private System.Windows.Forms.RadioButton easy_rb;
        private System.Windows.Forms.Button next_bt;
        private System.Windows.Forms.Button previous_bt;
    }
}