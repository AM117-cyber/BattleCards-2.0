﻿
namespace WindowsFormsApp1
{
    public partial class SetPlayer : Form
    {
        private Form previousForm { get; set; }

        public SetPlayer(Form previous)
        {
            InitializeComponent();
            previousForm = previous;
        }

        private void virtual_player_rb_CheckedChanged(object sender, EventArgs e)
        {
            this.difficulty_label.Visible = this.virtual_player_rb.Checked;
            this.easy_rb.Visible = this.virtual_player_rb.Checked;
            this.medium_rb.Visible = this.virtual_player_rb.Checked;
        }

        private void next_bt_Click(object sender, EventArgs e)
        {
            var boardForm = new Board(previousForm);
            boardForm.Show();
            Hide();

        }

        private void previous_bt_Click(object sender, EventArgs e)
        {
           previousForm.Show();
           Hide();
        }

    }
}
