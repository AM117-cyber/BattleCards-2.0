using BattleCardsLibrary;
using BattleCardsLibrary.Cards.CardDeveloper;
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
                SaveCard(cardValidator.CardDefinition, cardValidator.Card.Name);
                previousForm.Show();
                Hide();
            }

            //if (message != string.Empty)
            //{
            //    var errorForm = new ErrorCreatingCard(message);
            //    //var errorForm = new ErrorCreatingCard(except.Message == "Index was outside the bounds of the array." ? "Non valid card" : except.Message);
            //    errorForm.ShowDialog();
            //}

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

private void SaveCard(string[] cardDefinition, string nameOfCard)
        {
            string title = nameOfCard;
            string path = @"..\CardLibrary\" + title + ".txt";//D:\BattleCards\BattleCardsLibrary
            string contentOfTxT = GetCardDescription(cardDefinition);
             File.WriteAllText(path, contentOfTxT.TrimEnd());
            //File.WriteAllText(path, this.card_exp.Text);
        }

        public string GetCardDescription(string[] cardDefinition)
        {
            string contentOfTxT = string.Empty;
            for (int i = 0; i < cardDefinition.Length; i++)
            {
                if (cardDefinition[i] == null)
                {
                    continue;
                }
                contentOfTxT += cardDefinition[i++] + ": " + cardDefinition[i] + "\r\n";
            }
            return contentOfTxT;
        }
        

        private void previous_bt_Click(object sender, EventArgs e)
        {
            previousForm.Show();
            Hide();
        }
    }
}
