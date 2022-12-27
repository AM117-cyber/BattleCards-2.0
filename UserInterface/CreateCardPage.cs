using BattleCardsLibrary;
using BattleCardsLibrary.Cards.CardDeveloper;
using BattleCardsLibrary.Utils;
using BattleCardsLibrary.Exceptions;
using UserInterface;

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
            ICardCreatorSource cardSource = new DataProcessor(this.panel1.Controls.OfType<TextBox>(), monster_card_rb.Checked, spell_card_rb.Checked);
            ICardValidator cardValidator = new CardValidator(cardSource, CardCreator.Instance);

            ValidationResponse validationResponse = cardValidator.ValidateCard();

            Helper.ShowMessage(validationResponse);
             
            if (validationResponse.ValidationResult == ValidationResult.Ok)
            {
                SaveCard(cardValidator.CardDefinition, cardValidator.Card.Name);
                previousForm.Show();
                Hide();
            }

        }
        public class DataProcessor : ICardCreatorSource
        {
            public IEnumerable<TextBox> Textboxes;
            public bool Monster;
            public bool Spell;
            public DataProcessor(IEnumerable<TextBox> textboxes, bool monster, bool spell)
            {
                this.Spell = spell;
                this.Monster = monster;
                this.Textboxes = textboxes;
            }

            public string[] GetCardDefinition()
            {
                List<string> textToProcess = new List<string>();// monster_card_rb   spell_card_rb
                if (!Monster && !Spell)
                {
                    //show error because you need to choose at least one card type.
                    throw new InvalidCardTypeException("You must select a valid card type.");
                }
                else
                {
                    textToProcess.Add("Type");
                    textToProcess.Add(Monster ? "Monster" : "Spell");
                    /*textToProcess[0] = "Type";
                    textToProcess[1] = monster_card_rb.Checked ? "Monster" : "Spell";*/
                }
                foreach (var textbox in Textboxes)
                {
                    if (textbox.Text != string.Empty)
                    {
                        textToProcess.Add(textbox.Name.Replace("_value", ""));
                        textToProcess.Add(textbox.Text);
                        //textToProcess[i++] = textbox.Name.Replace("Value", "");
                        //textToProcess[i++] = textbox.Text;
                    }
                }
                string[] textToReturn = new string[textToProcess.Count];
                for (int j = 0; j < textToProcess.Count; j++)
                {
                    textToReturn[j] = textToProcess[j];
                }
                return textToReturn;
            }
            /*StringBuilder sb = new StringBuilder();
            var cardType = monster_card_rb.Checked ? "Monster" : "Spell";
            var attackExpression = AttackValue.Text;
            //....
            return sb.ToString();*/

        }


        private void SaveCard(string[] cardDefinition, string nameOfCard)//poner junto a CardCreator
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
            File.WriteAllText(path, contentOfTxT.TrimEnd());
        }
        private void previous_bt_Click(object sender, EventArgs e)
        {
            previousForm.Show();
            Hide();
        }

        private void monster_card_rb_CheckedChanged(object sender, EventArgs e)
        {
            spell_card_rb.Checked = !monster_card_rb.Checked;
        }
    }
}
