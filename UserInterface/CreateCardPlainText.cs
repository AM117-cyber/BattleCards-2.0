using BattleCards.Cards;
using BattleCardsLibrary.Cards;
using System.IO;

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
            ICardValidator cardValidator = new CardValidatorForPlainText(new DataProcessor(this.card_exp.Text.Split("\r\n")), new CardCreator());
            if (cardValidator.CheckIfCardIsValid())
            {
                SaveCard(cardValidator.CardDefinition, cardValidator.Card.Name);
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

        public class CardValidatorForPlainText : ICardValidator
        {
            public string[] CardDefinition { get; set; }
            public Card Card { get; set; }

            public ICardCreatorSource Source { get; }

            public ICardCreator CardCreator { get; }

            public CardValidatorForPlainText(ICardCreatorSource source, ICardCreator cardCreator)
            {
                this.Source = source;
                this.CardCreator = cardCreator;

            }
            public bool CheckIfCardIsValid()
            {
                try
                {
                    this.CardDefinition = Source.GetCardDefinition();
                    this.Card = CardCreator.CreateCard(CardDefinition);//
                }
                catch (Exception except)
                {

                    var errorForm = new ErrorCreatingCard(except.Message == "Index was outside the bounds of the array." ? "Non valid card" : except.Message);

                    errorForm.ShowDialog();
                    return false;
                }
                return true;
            }
        }
        private void SaveCard(string[] cardDefinition, string nameOfCard)
        {
            string title = nameOfCard;
            string path = @"..\CardLibrary\" + title + ".txt";//D:\BattleCards\BattleCardsLibrary
            string contentOfTxT = string.Empty;
            for (int i = 0; i < cardDefinition.Length; i++)
            {
                if (cardDefinition[i] == null)
                {
                    continue;
                }
                contentOfTxT += cardDefinition[i++] + ": " + cardDefinition[i] + "\r\n";
            }
            // File.WriteAllText(path, contentOfTxT.TrimEnd());
            File.WriteAllText(path, this.card_exp.Text);
        }

        private void previous_bt_Click(object sender, EventArgs e)
        {
            previousForm.Show();
            Hide();
        }
    }
}
