
using BattleCards;

namespace WindowsFormsApp1
{
    public partial class SetPlayer : Form
    {
        private UIPlayer firstPlayer = null;
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
            if (!human_rb.Checked && !virtual_player_rb.Checked)
            {
                return;

            }
            PlayerType playerType = human_rb.Checked ? PlayerType.Human : easy_rb.Checked ? PlayerType.RandomAI : PlayerType.GreedyAI;
            if (firstPlayer != null)
            {
                //start new game
                new Game(firstPlayer, new UIPlayer(name_textBox.Text, playerType));
                var boardForm = new Board(previousForm);
                boardForm.Show();
                Hide();
                return;
            }
            
            firstPlayer = new UIPlayer(name_textBox.Text,playerType);
            
            

        }

        private void previous_bt_Click(object sender, EventArgs e)
        {
           previousForm.Show();
           Hide();
        }

        
    }
}
