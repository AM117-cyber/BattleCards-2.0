using BattleCards.Cards;
using System.Text;

namespace WindowsFormsApp1
{
    public partial class CreateCardPage : Form
    {
        private Form previousForm { get; set; }
        public CreateCardPage(Form previous)
        {
            InitializeComponent();
            previousForm = previous;
        }
        private void next_bt_Click(object sender, EventArgs e)
        {
            //Gather all data and call method to evaluate expression
            var cardDefinition = ProcessData();
            try
            {
                CreateCard.CardCreator(cardDefinition.Split(' '));
                SaveCard(cardDefinition);
                previousForm.Show();
                Hide();
            }
            catch (Exception)
            {
                var errorForm = new ErrorCreatingCard();
                errorForm.ShowDialog();
            }
        }

        private void SaveCard(string cardDefinition)
        {
            throw new NotImplementedException();
        }

        private string ProcessData()
        {
            StringBuilder sb = new StringBuilder();
            var cardType = monster_rb.Checked ? "Monster" : "Spell";
            var attackExpression = attack_exp.Text;
            //....
            return sb.ToString();
        }

        private void previous_bt_Click(object sender, EventArgs e)
        {
            previousForm.Show();
            Hide();
        }

        private void monster_rb_CheckedChanged(object sender, EventArgs e)
        {
            spell_card_rb.Checked = !monster_rb.Checked;
        }

    }
}
