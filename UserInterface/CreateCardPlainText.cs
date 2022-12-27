using BattleCardsLibrary;
using CardDeveloper1;
using BattleCardsLibrary.Utils;
using UserInterface;

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
            ICardValidator cardValidator = new CardValidator(new DataProcessor(this.card_exp.Text.Split("\r\n")), CardCreator.Instance);

            ValidationResponse validationResponse = cardValidator.ValidateCard();

            Helper.ShowMessage(validationResponse);

            if (validationResponse.ValidationResult == ValidationResult.Ok)
            {
                CardSaver.Instance.SaveCard(cardValidator.CardDefinition, cardValidator.Card.Name);
                previousForm.Show();
                Hide();
            }

        }

        public class DataProcessor : ICardCreatorSource
        {
            private string[] Text;
            public DataProcessor(string[] text)
            {
                this.Text = text;
            }
            public string[] GetCardDefinition()
            {
                string textAsString = string.Empty;
                foreach (var item in Text)
                {
                    textAsString += ": " + item;
                }
                string[] cardDefinition = textAsString.Remove(0, 2).Split(": ");
                return cardDefinition;
            }
        }
        

        private void previous_bt_Click(object sender, EventArgs e)
        {
            previousForm.Show();
            Hide();
        }
    }
}
