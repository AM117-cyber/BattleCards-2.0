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
            this.NameValue = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.DamageValue = new System.Windows.Forms.TextBox();
            this.HealthPointsValue = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.monster_card_rb = new System.Windows.Forms.RadioButton();
            this.spell_card_rb = new System.Windows.Forms.RadioButton();
            this.ManaCostValue = new System.Windows.Forms.TextBox();
            this.AttackValue = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.HealValue = new System.Windows.Forms.TextBox();
            this.DefendValue = new System.Windows.Forms.TextBox();
            this.previous_bt = new System.Windows.Forms.Button();
            this.next_bt = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label12 = new System.Windows.Forms.Label();
            this.LifeTimeValue = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.ArmourValue = new System.Windows.Forms.TextBox();
            this.HealingPowersValue = new System.Windows.Forms.TextBox();
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
            // NameValue
            // 
            this.NameValue.Location = new System.Drawing.Point(178, 219);
            this.NameValue.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.NameValue.Name = "NameValue";
            this.NameValue.Size = new System.Drawing.Size(134, 31);
            this.NameValue.TabIndex = 2;
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
            // DamageValue
            // 
            this.DamageValue.Location = new System.Drawing.Point(178, 518);
            this.DamageValue.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.DamageValue.Name = "DamageValue";
            this.DamageValue.Size = new System.Drawing.Size(134, 31);
            this.DamageValue.TabIndex = 7;
            // 
            // HealthPointsValue
            // 
            this.HealthPointsValue.Location = new System.Drawing.Point(178, 739);
            this.HealthPointsValue.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.HealthPointsValue.Name = "HealthPointsValue";
            this.HealthPointsValue.Size = new System.Drawing.Size(134, 31);
            this.HealthPointsValue.TabIndex = 8;
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
            // ManaCostValue
            // 
            this.ManaCostValue.Location = new System.Drawing.Point(178, 813);
            this.ManaCostValue.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.ManaCostValue.Name = "ManaCostValue";
            this.ManaCostValue.Size = new System.Drawing.Size(134, 31);
            this.ManaCostValue.TabIndex = 18;
            // 
            // AttackValue
            // 
            this.AttackValue.Location = new System.Drawing.Point(436, 181);
            this.AttackValue.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.AttackValue.Multiline = true;
            this.AttackValue.Name = "AttackValue";
            this.AttackValue.Size = new System.Drawing.Size(684, 135);
            this.AttackValue.TabIndex = 19;
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
            // HealValue
            // 
            this.HealValue.Location = new System.Drawing.Point(436, 405);
            this.HealValue.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.HealValue.Multiline = true;
            this.HealValue.Name = "HealValue";
            this.HealValue.Size = new System.Drawing.Size(684, 154);
            this.HealValue.TabIndex = 23;
            // 
            // DefendValue
            // 
            this.DefendValue.Location = new System.Drawing.Point(436, 652);
            this.DefendValue.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.DefendValue.Multiline = true;
            this.DefendValue.Name = "DefendValue";
            this.DefendValue.Size = new System.Drawing.Size(684, 154);
            this.DefendValue.TabIndex = 24;
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
            this.panel1.Controls.Add(this.LifeTimeValue);
            this.panel1.Controls.Add(this.label11);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.ArmourValue);
            this.panel1.Controls.Add(this.HealingPowersValue);
            this.panel1.Controls.Add(this.next_bt);
            this.panel1.Controls.Add(this.previous_bt);
            this.panel1.Controls.Add(this.DefendValue);
            this.panel1.Controls.Add(this.HealValue);
            this.panel1.Controls.Add(this.label10);
            this.panel1.Controls.Add(this.label9);
            this.panel1.Controls.Add(this.label8);
            this.panel1.Controls.Add(this.AttackValue);
            this.panel1.Controls.Add(this.ManaCostValue);
            this.panel1.Controls.Add(this.spell_card_rb);
            this.panel1.Controls.Add(this.monster_card_rb);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.HealthPointsValue);
            this.panel1.Controls.Add(this.DamageValue);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.NameValue);
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
            // LifeTimeValue
            // 
            this.LifeTimeValue.Location = new System.Drawing.Point(178, 446);
            this.LifeTimeValue.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.LifeTimeValue.Name = "LifeTimeValue";
            this.LifeTimeValue.Size = new System.Drawing.Size(134, 31);
            this.LifeTimeValue.TabIndex = 31;
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
            // ArmourValue
            // 
            this.ArmourValue.Location = new System.Drawing.Point(178, 592);
            this.ArmourValue.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.ArmourValue.Name = "ArmourValue";
            this.ArmourValue.Size = new System.Drawing.Size(134, 31);
            this.ArmourValue.TabIndex = 28;
            // 
            // HealingPowersValue
            // 
            this.HealingPowersValue.Location = new System.Drawing.Point(178, 668);
            this.HealingPowersValue.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.HealingPowersValue.Name = "HealingPowersValue";
            this.HealingPowersValue.Size = new System.Drawing.Size(134, 31);
            this.HealingPowersValue.TabIndex = 27;
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
        private System.Windows.Forms.TextBox NameValue;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox DamageValue;
        private System.Windows.Forms.TextBox HealthPointsValue;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.RadioButton monster_card_rb;
        private System.Windows.Forms.RadioButton spell_card_rb;
        private System.Windows.Forms.TextBox ManaCostValue;
        private System.Windows.Forms.TextBox AttackValue;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox HealValue;
        private System.Windows.Forms.TextBox DefendValue;
        private System.Windows.Forms.Button previous_bt;
        private System.Windows.Forms.Button next_bt;
        private System.Windows.Forms.Panel panel1;
        private Label label11;
        private Label label7;
        private TextBox ArmourValue;
        private TextBox HealingPowersValue;
        private Label label12;
        private TextBox LifeTimeValue;
    }
}