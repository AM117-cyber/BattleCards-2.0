using BattleCards.Cards;
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

            //call method to evaluate expression
            string[] text = this.card_exp.Text.Split("\r\n");
            string textAsString = string.Empty;
            foreach (var item in text)
            {
                textAsString += ": " + item;
            }
            string[] cardDefinition = textAsString.Remove(0, 2).Split(": ");
            try
            {
                CreateCard.CardCreator(cardDefinition);
              //  File.WriteAllText(@"..\CardLibrary\CardStats.txt", card.Damage + "," + card.HealingPowers + (card as MonsterCard).OnGameHealth + card.Armour);
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

        private void SaveCard(string[] cardDefinition)
        {
            string title = cardDefinition[3];
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
