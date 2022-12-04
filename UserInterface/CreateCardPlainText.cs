using BattleCards.Cards;

namespace WindowsFormsApp1
{
    public partial class CreateCardPlainText : Form
    {
        private Form previousForm { get; set; }
        public CreateCardPlainText(Form previous)
        {
            InitializeComponent();
            previousForm = previous;
        }
        private void next_bt_Click(object sender, EventArgs e)
        {
            
            //call method to evaluate expression

            try
            {
                var cardDefinition = this.card_exp.Text;
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

        private void previous_bt_Click(object sender, EventArgs e)
        {
            previousForm.Show();
            Hide();
        }
    }
}
