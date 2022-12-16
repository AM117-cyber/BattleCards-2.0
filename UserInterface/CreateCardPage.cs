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
          
            string[] cardDefinition = ProcessData();
            try
            {
                CreateCard.CardCreator(cardDefinition);//
                SaveCard(cardDefinition);//saves card in txt
                previousForm.Show();
                Hide();
            }
            catch (Exception except)
            {
               
                var errorForm = new ErrorCreatingCard(except.Message == "Index was outside the bounds of the array."? "Non valid card" :except.Message);
                
                errorForm.ShowDialog();
            }
        }

        private void SaveCard(string[] cardDefinition)
        {
            string title = NameValue.Text;
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

        private string[] ProcessData()
        {
            List<string> textToProcess = new List<string>();// monster_card_rb   spell_card_rb
            if (!monster_card_rb.Checked && !spell_card_rb.Checked)
            {
                //show error because you need to choose at least one card type.
                var errorForm = new ErrorCreatingCard("You must select a valid card type.");
                errorForm.ShowDialog();
                
                errorForm.Hide();
            }
            else
            {
                textToProcess.Add("Type");
                textToProcess.Add(monster_card_rb.Checked ? "Monster" : "Spell");
                /*textToProcess[0] = "Type";
                textToProcess[1] = monster_card_rb.Checked ? "Monster" : "Spell";*/
            }
            IEnumerable<TextBox> textboxes = this.panel1.Controls.OfType<TextBox>();
            foreach (var textbox in textboxes)
            {

                if (textbox.Text != string.Empty)
                {
                textToProcess.Add(textbox.Name.Replace("Value", ""));
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
            /*StringBuilder sb = new StringBuilder();
            var cardType = monster_card_rb.Checked ? "Monster" : "Spell";
            var attackExpression = AttackValue.Text;
            //....
            return sb.ToString();*/
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
