namespace WindowsFormsApp1
{
    partial class CreateCardPage
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
            this.Name_value = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.Damage_value = new System.Windows.Forms.TextBox();
            this.HealthPoints_value = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.monster_card_rb = new System.Windows.Forms.RadioButton();
            this.spell_card_rb = new System.Windows.Forms.RadioButton();
            this.ManaCost_value = new System.Windows.Forms.TextBox();
            this.Attack_value = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.Heal_value = new System.Windows.Forms.TextBox();
            this.Defend_value = new System.Windows.Forms.TextBox();
            this.previous_bt = new System.Windows.Forms.Button();
            this.next_bt = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label12 = new System.Windows.Forms.Label();
            this.LifeTime_value = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.Armour_value = new System.Windows.Forms.TextBox();
            this.HealingPowers_value = new System.Windows.Forms.TextBox();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(428, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(191, 37);
            this.label1.TabIndex = 0;
            this.label1.Text = "Create Card";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(18, 219);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(63, 25);
            this.label2.TabIndex = 1;
            this.label2.Text = "Name:";
            // 
            // Name_value
            // 
            this.Name_value.Location = new System.Drawing.Point(178, 219);
            this.Name_value.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name_value.Name = "Name_value";
            this.Name_value.Size = new System.Drawing.Size(134, 31);
            this.Name_value.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(28, 341);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 25);
            this.label3.TabIndex = 3;
            this.label3.Text = "Type:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(19, 524);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(136, 25);
            this.label4.TabIndex = 5;
            this.label4.Text = "Damage Points:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(19, 745);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(120, 25);
            this.label5.TabIndex = 6;
            this.label5.Text = "Health Points:";
            // 
            // Damage_value
            // 
            this.Damage_value.Location = new System.Drawing.Point(178, 518);
            this.Damage_value.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Damage_value.Name = "Damage_value";
            this.Damage_value.Size = new System.Drawing.Size(134, 31);
            this.Damage_value.TabIndex = 7;
            // 
            // HealthPoints_value
            // 
            this.HealthPoints_value.Location = new System.Drawing.Point(178, 739);
            this.HealthPoints_value.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.HealthPoints_value.Name = "HealthPoints_value";
            this.HealthPoints_value.Size = new System.Drawing.Size(134, 31);
            this.HealthPoints_value.TabIndex = 8;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(19, 813);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(101, 25);
            this.label6.TabIndex = 11;
            this.label6.Text = "Mana Cost:";
            // 
            // monster_card_rb
            // 
            this.monster_card_rb.AutoSize = true;
            this.monster_card_rb.Location = new System.Drawing.Point(178, 322);
            this.monster_card_rb.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.monster_card_rb.Name = "monster_card_rb";
            this.monster_card_rb.Size = new System.Drawing.Size(145, 29);
            this.monster_card_rb.TabIndex = 16;
            this.monster_card_rb.Text = "Monster Card";
            this.monster_card_rb.UseVisualStyleBackColor = true;
            this.monster_card_rb.CheckedChanged += new System.EventHandler(this.monster_card_rb_CheckedChanged);
            // 
            // spell_card_rb
            // 
            this.spell_card_rb.AutoSize = true;
            this.spell_card_rb.Location = new System.Drawing.Point(178, 359);
            this.spell_card_rb.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.spell_card_rb.Name = "spell_card_rb";
            this.spell_card_rb.Size = new System.Drawing.Size(117, 29);
            this.spell_card_rb.TabIndex = 17;
            this.spell_card_rb.Text = "Spell Card";
            this.spell_card_rb.UseVisualStyleBackColor = true;
            // 
            // ManaCost_value
            // 
            this.ManaCost_value.Location = new System.Drawing.Point(178, 813);
            this.ManaCost_value.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.ManaCost_value.Name = "ManaCost_value";
            this.ManaCost_value.Size = new System.Drawing.Size(134, 31);
            this.ManaCost_value.TabIndex = 18;
            // 
            // Attack_value
            // 
            this.Attack_value.Location = new System.Drawing.Point(436, 181);
            this.Attack_value.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Attack_value.Multiline = true;
            this.Attack_value.Name = "Attack_value";
            this.Attack_value.Size = new System.Drawing.Size(684, 135);
            this.Attack_value.TabIndex = 19;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(680, 128);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(151, 25);
            this.label8.TabIndex = 20;
            this.label8.Text = "Attack Expression";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(680, 356);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(136, 25);
            this.label9.TabIndex = 21;
            this.label9.Text = "Heal Expression";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(672, 582);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(159, 25);
            this.label10.TabIndex = 22;
            this.label10.Text = "Defend Expression";
            // 
            // Heal_value
            // 
            this.Heal_value.Location = new System.Drawing.Point(436, 405);
            this.Heal_value.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Heal_value.Multiline = true;
            this.Heal_value.Name = "Heal_value";
            this.Heal_value.Size = new System.Drawing.Size(684, 154);
            this.Heal_value.TabIndex = 23;
            // 
            // Defend_value
            // 
            this.Defend_value.Location = new System.Drawing.Point(436, 652);
            this.Defend_value.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Defend_value.Multiline = true;
            this.Defend_value.Name = "Defend_value";
            this.Defend_value.Size = new System.Drawing.Size(684, 154);
            this.Defend_value.TabIndex = 24;
            // 
            // previous_bt
            // 
            this.previous_bt.Location = new System.Drawing.Point(24, 869);
            this.previous_bt.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.previous_bt.Name = "previous_bt";
            this.previous_bt.Size = new System.Drawing.Size(104, 58);
            this.previous_bt.TabIndex = 25;
            this.previous_bt.Text = "Previous";
            this.previous_bt.UseVisualStyleBackColor = true;
            this.previous_bt.Click += new System.EventHandler(this.previous_bt_Click);
            // 
            // next_bt
            // 
            this.next_bt.Location = new System.Drawing.Point(1016, 869);
            this.next_bt.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.next_bt.Name = "next_bt";
            this.next_bt.Size = new System.Drawing.Size(104, 58);
            this.next_bt.TabIndex = 26;
            this.next_bt.Text = "Next";
            this.next_bt.UseVisualStyleBackColor = true;
            this.next_bt.Click += new System.EventHandler(this.next_bt_Click);
            // 
            // panel1
            // 
            this.panel1.AutoSize = true;
            this.panel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.panel1.Controls.Add(this.label12);
            this.panel1.Controls.Add(this.LifeTime_value);
            this.panel1.Controls.Add(this.label11);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.Armour_value);
            this.panel1.Controls.Add(this.HealingPowers_value);
            this.panel1.Controls.Add(this.next_bt);
            this.panel1.Controls.Add(this.previous_bt);
            this.panel1.Controls.Add(this.Defend_value);
            this.panel1.Controls.Add(this.Heal_value);
            this.panel1.Controls.Add(this.label10);
            this.panel1.Controls.Add(this.label9);
            this.panel1.Controls.Add(this.label8);
            this.panel1.Controls.Add(this.Attack_value);
            this.panel1.Controls.Add(this.ManaCost_value);
            this.panel1.Controls.Add(this.spell_card_rb);
            this.panel1.Controls.Add(this.monster_card_rb);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.HealthPoints_value);
            this.panel1.Controls.Add(this.Damage_value);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.Name_value);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(13, 15);
            this.panel1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.panel1.MinimumSize = new System.Drawing.Size(1139, 940);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1139, 940);
            this.panel1.TabIndex = 27;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(24, 452);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(81, 25);
            this.label12.TabIndex = 32;
            this.label12.Text = "LifeTime:";
            // 
            // LifeTime_value
            // 
            this.LifeTime_value.Location = new System.Drawing.Point(178, 446);
            this.LifeTime_value.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.LifeTime_value.Name = "LifeTime_value";
            this.LifeTime_value.Size = new System.Drawing.Size(134, 31);
            this.LifeTime_value.TabIndex = 31;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(18, 598);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(77, 25);
            this.label11.TabIndex = 30;
            this.label11.Text = "Armour:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(19, 668);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(137, 25);
            this.label7.TabIndex = 29;
            this.label7.Text = "Healing Powers:";
            // 
            // Armour_value
            // 
            this.Armour_value.Location = new System.Drawing.Point(178, 592);
            this.Armour_value.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Armour_value.Name = "Armour_value";
            this.Armour_value.Size = new System.Drawing.Size(134, 31);
            this.Armour_value.TabIndex = 28;
            // 
            // HealingPowers_value
            // 
            this.HealingPowers_value.Location = new System.Drawing.Point(178, 668);
            this.HealingPowers_value.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.HealingPowers_value.Name = "HealingPowers_value";
            this.HealingPowers_value.Size = new System.Drawing.Size(134, 31);
            this.HealingPowers_value.TabIndex = 27;
            // 
            // CreateCardPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(1198, 1050);
            this.Controls.Add(this.panel1);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MinimumSize = new System.Drawing.Size(1188, 1026);
            this.Name = "CreateCardPage";
            this.Text = "Create Card";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox Name_value;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox Damage_value;
        private System.Windows.Forms.TextBox HealthPoints_value;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.RadioButton monster_card_rb;
        private System.Windows.Forms.RadioButton spell_card_rb;
        private System.Windows.Forms.TextBox ManaCost_value;
        private System.Windows.Forms.TextBox Attack_value;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox Heal_value;
        private System.Windows.Forms.TextBox Defend_value;
        private System.Windows.Forms.Button previous_bt;
        private System.Windows.Forms.Button next_bt;
        private System.Windows.Forms.Panel panel1;
        private Label label11;
        private Label label7;
        private TextBox Armour_value;
        private TextBox HealingPowers_value;
        private Label label12;
        private TextBox LifeTime_value;
    }
}