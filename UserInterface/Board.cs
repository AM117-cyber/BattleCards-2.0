using BattleCardsLibrary.Utils;
using BattleCardsLibrary;
using CardDeveloper1.Cards;
using BattleCardsLibrary.PlayerNamespace;

namespace WindowsFormsApp1
{
    public partial class Board : Form
    {
        private ICard CurrentCard = null;
        public bool isAttacking = false;
        public bool isHealing = false;
        private ToolTip toolTip = new ToolTip();
        private Form startForm { get; set; }
        public Board(Form previous)
        {
            InitializeComponent();
            startForm = previous;
            UpdateGameForVirtualTurn();
            Player1_name_label.Text = Game.Player1.Name;
            Player2_name_label.Text = Game.Player2.Name;
            UpdateHand(1);
            UpdateHand(2);

        }
  
        /*public string SetLabelText
        {
            get { return this.hpOfPlayer1.Text; }
            set { this.hpOfPlayer1.Text = value; }
        }*/

        private void Board_FormClosed(object sender, FormClosedEventArgs e)
        {
            startForm.Close();
        }

        private void attack_button_Click(object sender, EventArgs e)
        {
            //si el turno no es de un jugador humano el click no es valido
            if (!(Game.GetCurrentPlayer().Type == PlayerType.Human))
            {
                return;
            }
            isAttacking = true;
        }
        private void heal_button_Click(object sender, EventArgs e)
        {
            if (!(Game.GetCurrentPlayer().Type == PlayerType.Human))
            {
                return;
            }
            isHealing = true;
        }

        private void deck1_Click(object sender, EventArgs e)
        {
            //si el turno no es de un jugador humano el click no es valido
            if (!(Game.GetCurrentPlayer().Type == PlayerType.Human))
            {
                return;
            }
            Game.CardActionReceiver(ActionsByPlayer.DrawFromDeck, CurrentCard, CurrentCard,1);
            UpdatePlayerLabels("mana_of_Player1");
            UpdateHand(1);
        }

        private void deck2_Click(object sender, EventArgs e)
        {
            //si el turno no es de un jugador humano el click no es valido
            if (!(Game.GetCurrentPlayer().Type == PlayerType.Human))
            {
                return;
            }
            Game.CardActionReceiver(ActionsByPlayer.DrawFromDeck, CurrentCard, CurrentCard,2);
            UpdatePlayerLabels("mana_of_Player2");
            UpdateHand(2);
        }
        private void ProcessCardClick(object sender, EventArgs e)
        {
            if (sender is not Panel)
            {
                sender = ((Control)sender).Parent;
            }
            var panel = ((Panel)sender);
            //panel.BorderStyle = BorderStyle.FixedSingle;
            //panel.Paint += Panel_Paint;
            //panel.Invalidate();

            //si el turno no es de un jugador humano el click no es valido
            if (!(Game.GetCurrentPlayer().Type == PlayerType.Human))
            {
                return;
            }

           ICard targetCard = GetCard(sender);

            if (isAttacking)
            {
                isAttacking = false;
                Game.CardActionReceiver(ActionsByPlayer.Attack, CurrentCard, targetCard,0);
                UpdatePlayerLabels(hp_of_Player1.Name);
                UpdatePlayerLabels(hp_of_Player2.Name);
                UpdateBoard(1);
                UpdateBoard(2);
                
                
                return;
            }
            if (isHealing)
            {
                isHealing = false;
                Game.CardActionReceiver(ActionsByPlayer.Heal, CurrentCard, targetCard,0);
                UpdateBoard(1);
                UpdateBoard(2);
                
                return;
            }
            CurrentCard = targetCard;
        }

        //private void Panel_Paint(object? sender, PaintEventArgs e)
        //{
        //    Color color = Color.DarkBlue;
        //    ButtonBorderStyle buttonStyle = ButtonBorderStyle.Solid;
        //    int thickness = 4;

        //    ControlPaint.DrawBorder(e.Graphics,
        //                            ((Panel)sender).ClientRectangle,
        //                            color,
        //                            thickness,
        //                            buttonStyle,
        //                            color,
        //                            thickness,
        //                            buttonStyle,
        //                            color,
        //                            thickness,
        //                            buttonStyle,
        //                            color,
        //                            thickness,
        //                            buttonStyle);
        //}

        private ICard GetCard(object sender)
        {
            if (!(sender as Panel).Controls[1].Visible)
            {
                return null;
            }
            string[] CardOwnerAndPlacement = (sender as Panel).Name.Split('_');
            string pos = CardOwnerAndPlacement[2];
            char placement = pos[0];
            int index = Int32.Parse(pos.Remove(0, 1)) - 1;
            if (CardOwnerAndPlacement[1] == "P1")
            {
                if (placement == 'C')
                {
                    return Game.Player1.CardsOnBoard.Count > index ? Game.Player1.CardsOnBoard[index] : null;
                }
              return Game.Player1.Hand.Count > index ? Game.Player1.Hand[index] : null;
            }
            if (placement == 'C')
            {
                return Game.Player2.CardsOnBoard.Count > index ? Game.Player2.CardsOnBoard[index] : null;
            }
            return Game.Player2.Hand.Count > index ? Game.Player2.Hand[index] : null;
        }
            //Game.CurrentPlayer hacer switch con sender.Name y el numero en el nombre indica la posicion en la lista Hand o Board del jugador, tomando que sea es la que se guarda en currentCard.
  /*  privateICardRetrieveCard(Player player, string cardPlacement)
    {
        char placement = cardPlacement[0];
        int index = Int32.Parse(cardPlacement.Remove(0, 1)) - 1;

        if (placement == 'C')
        {
            return Game.Player1.CardsOnBoard.Count > index ? Game.Player1.CardsOnBoard[index] : null;
        }
        return Game.Player1.Hand.Count > index ? Game.Player1.Hand[index] : null;
    }*/

        private void invoke_button_Click(object sender, EventArgs e)
        {
            //si el turno no es de un jugador humano el click no es valido
            if (!(Game.GetCurrentPlayer().Type == PlayerType.Human))
            {
                return;
            }
            Game.CardActionReceiver(ActionsByPlayer.InvokeCard, CurrentCard, CurrentCard,0);
            if (Game.CurrentPlayer == 1)
            {
                UpdatePlayerLabels(mana_of_Player1.Name);
                //updateboard() and updatehand() only of currentPlayery
                UpdateBoard(1);
                UpdateHand(1);
            }
            else
            {
                UpdatePlayerLabels(mana_of_Player2.Name);
                UpdateBoard(2);
                UpdateHand(2);
            }
            CurrentCard = null;
            
        }

            private void direct_attack_button_Click(object sender, EventArgs e)//mandar acciones a Game y procesar cada una
        {
            //si el turno no es de un jugador humano el click no es valido
            if (!(Game.GetCurrentPlayer().Type == PlayerType.Human))
            {
                return;
            }
            Game.CardActionReceiver(ActionsByPlayer.DirectAttack, CurrentCard, CurrentCard,0);
            if (Game.CurrentPlayer == 1)
            {
                UpdatePlayerLabels(hp_of_Player2.Name);
                return;
            }
            UpdatePlayerLabels(hp_of_Player1.Name);
        }

        private void end_turn_button_Click(object sender, EventArgs e)
        {
            //si el turno no es de un jugador humano el click no es valido
            if (!(Game.GetCurrentPlayer().Type == PlayerType.Human))
            {
                return;
            }
            Game.CardActionReceiver(ActionsByPlayer.TurnIsOver,null,null,0);
            if (Game.CurrentPhase == Phase.MainPhase)
            {
                UpdatePlayerLabels("mana_of_Player" + Game.CurrentPlayer);
                current_player_label.Text = Game.GetCurrentPlayer().Name;     //$"\"{Game.GetCurrentPlayer().Name}\"";
                UpdateLifeTime(Game.GetCurrentPlayer());
                UpdateBoard(Game.CurrentPlayer);
            }
            
            
        }

        public void UpdateLifeTime(Player player)
        {
            IEnumerable<Panel> CardsOnPanel = this.panel1.Controls.OfType<Panel>();
            for (int i = 0; i < player.CardsOnBoard.Count; i++)
            {
                if (player.CardsOnBoard[i].Type == CardType.Spell)
                {
                    string name = "card_P" + player.CardsOnBoard[i].Owner.Number + "_C" + (i+1);
                    foreach (var panel in CardsOnPanel)
                    {
                        if (panel.Name == name) //hp_P2_C1
                        {
                            SetLifeTimeToCardLabel(panel, player.CardsOnBoard[i], "hp_P" + player.Number + "_C" + (i+1));
                            continue;
                        }
                    }
                }
            }
        }
        public void SetLifeTimeToCardLabel(Panel panel, ICard card, string propertyName)
        {
            IEnumerable<Label> CardPropertiesAsLabels = panel.Controls.OfType<Label>();
            foreach (var item in CardPropertiesAsLabels)
            {
                if (item.Name == propertyName)
                {
                    item.Text = (card as SpellCard).LifeTime.ToString();
                }
            }

        }
        public void UpdateBoard(int player)
        {
            UpdateListOfCards('C', player);
        }
        public void UpdateListOfCards(char boardOrHand, int player)
        {
            List<ICard> listOfCards = new List<ICard>();
            string nameOfCardPanel = string.Empty;
            List <Panel> CardsOnPanel = this.panel1.Controls.OfType<Panel>().ToList();
            foreach (var panel in CardsOnPanel)
            {
                foreach (Control child in panel.Controls)
                {
                    if (child is not Button)
                    {
                        child.Click -= ProcessCardClick;
                        child.Click += ProcessCardClick;
                    }
                }
            }
            if (player == 1)
            {
               listOfCards = boardOrHand == 'C' ? Game.Player1.CardsOnBoard : Game.Player1.Hand;
                nameOfCardPanel = "card_" +  "P1_"  + boardOrHand;
            }
            else
            {
                listOfCards = boardOrHand == 'C' ? Game.Player2.CardsOnBoard : Game.Player2.Hand;
               nameOfCardPanel = "card_" + "P2_" + boardOrHand;
            }

            int cardCount = listOfCards == null ? 0 : listOfCards.Count;
            for (int i = 0; i < cardCount; i++)
            {
                //if panel.name matches nameOfCardPanel then you iterate through the labels 
                //inside such panel and send enumerable of labels andICardto set value of each label as value ofICardproperty 
                foreach (var panel in CardsOnPanel)
                {
                    if (panel.Name == nameOfCardPanel+(i+1))
                    {
                        SetValueToEachLabelInPanel(panel, listOfCards[i]);//here visible is set true
                        CardsOnPanel.Remove(panel);
                        break;
                    }
                }

            }
            SetAsFalseVisibilityOfUnusedPanels(cardCount, nameOfCardPanel, CardsOnPanel);
        }
        public void UpdateHand(int player)
        {
            UpdateListOfCards('H', player);
        }
        public void SetValueToEachLabelInPanel(Panel panel, ICard card)
        {
            IEnumerable<Label> CardPropertiesAsLabels = panel.Controls.OfType<Label>();
            Dictionary<string, string> propertyRelator = SetDictionary(card);
            
            foreach (var label in CardPropertiesAsLabels)
            {
                if (label.Name[0] != 'l')
                {
                    string keyOfDictionary = label.Name.Split('_')[0];
                    label.Text = propertyRelator[keyOfDictionary];
                }
                label.Visible = true;
                
                toolTip.SetToolTip(label, card.Description);    
            }


            toolTip.SetToolTip(panel, card.Description);
        }
        private Dictionary<string, string> SetDictionary(ICard card)
        {
            Dictionary<string, string> answer = new Dictionary<string, string>();
            answer["name"] = card.Name; 
            answer["type"] = card.Type.ToString();
            answer["damage"] = card.Damage.ToString();
            answer["hp"] = card.Type == CardType.Monster ? (card as MonsterCard).OnGameHealth.ToString() : (card as SpellCard).LifeTime.ToString();
            answer["cost"] = card.ManaCost.ToString();
            answer["healing"] = card.HealingPowers.ToString();
            return answer;
        }
        public void SetAsFalseVisibilityOfUnusedPanels(int panelsUsed, string nameOfCardPanel, List<Panel> CardsOnPanel)
        {
            for (int i = panelsUsed; i < 6; i++)
            {
                foreach (var panel in CardsOnPanel)
                {
                    if (panel.Name == nameOfCardPanel +(i))
                    {
                        IEnumerable<Label> CardPropertiesAsLabels = panel.Controls.OfType<Label>();
                        foreach (var label in CardPropertiesAsLabels)
                        {
                            label.Visible = false;
                            toolTip.SetToolTip(label, null);
                        }
                        toolTip.SetToolTip(panel, null);
                    }
                }
            }
        }
        private void UpdatePlayerLabels(string nameOfLabelToUpdate)
        {
            
            if (nameOfLabelToUpdate == hp_of_Player1.Name)
            {
                try
                {
                    Game.GameIsOver();
                }
                catch (Exception exception)
                {
                    var FinalMessage = new GameIsOver(exception.Message);
                    FinalMessage.ShowDialog();
                    Hide();
                    startForm.Close();
                }
                hp_of_Player1.Text = Game.Player1.Health.ToString();
                
                return;
                
            }
            if (nameOfLabelToUpdate == hp_of_Player2.Name)
            {
                try
                {
                    Game.GameIsOver();
                }
                catch (Exception exception)
                {
                    var FinalMessage = new GameIsOver(exception.Message);
                    FinalMessage.ShowDialog();
                    Hide();
                    startForm.Close();
                }

                hp_of_Player2.Text = Game.Player2.Health.ToString();
                return;

            }
            if (nameOfLabelToUpdate == mana_of_Player1.Name)
            {
                mana_of_Player1.Text = Game.Player1.Mana.ToString();
                return;
            }
            if (nameOfLabelToUpdate == mana_of_Player2.Name)
            {
                mana_of_Player2.Text = Game.Player2.Mana.ToString();
                return;
            }
        }

        private void virtual_player_play_Click(object sender, EventArgs e)
        {
            //si el turno es de un jugador humano el click no es valido porque el virtual no puede jugar hasta que llegue su turno
            if (Game.GetCurrentPlayer().Type == PlayerType.Human)
            {
                return;
            }
            // if ((Game.CurrentPlayer == 1? Player2.Type : Player1.Type )== PlayerType.Human)
            //{
            //    return;
            //}


            (Game.GetCurrentPlayer() as AIPlayer).Play();
            UpdateGameForVirtualTurn();
            Game.InterfaceUpdated = true;
       

        }

        private void UpdateGameForVirtualTurn()
        {
            string[] labels = { "mana_of_Player1", "mana_of_Player2", "hp_of_Player1", "hp_of_Player2" };
            foreach (var label in labels)
            {
                UpdatePlayerLabels(label);
            }

            current_player_label.Text = Game.GetCurrentPlayer().Name;
            UpdateBoard(1);
            UpdateBoard(2);
            if (Game.CurrentPhase == Phase.BattlePhase)
            {
                UpdateHand(Game.CurrentPlayer);
            }

        }







        /* private void deck1_Click(object sender, EventArgs e)
    {
        if (Game.CurrentPlayer == Game.Player1 && Game.CurrentPhase == Phase.MainPhase)
        {
            Game.Player1.Draw(1);
        }
    }

    private void deck2_Click(object sender, EventArgs e)
    {
        if (Game.CurrentPlayer == Game.Player2 && Game.CurrentPhase == Phase.MainPhase)
        {
            Game.Player2.Draw(1);
        }
    }
    private void ProcessCardClick(object sender, EventArgs e)
    {
       ICardtargetCard = GetCard(sender);
        if (isAttacking)
        {
            ExecuteAction.Attack(currentCard, targetCard, currentCard.Attack.Evaluate(currentCard, targetCard));
        }
        if (isHealing)
        {
            ExecuteAction.Heal(currentCard, targetCard, currentCard.Heal.Evaluate(currentCard, targetCard));
        }


    }
    privateICardGetCard(object sender)
    {
        //Game.CurrentPlayer hacer switch con sender.Name y el numero en el nombre indica la posicion en la lista Hand o Board del jugador, tomando que sea es la que se guarda en currentCard.
    }

    private void direct_attack_button_Click(object sender, EventArgs e)//mandar acciones a Game y procesar cada una
    {
        if (currentCard.Owner == Game.CurrentPlayer)
        {
            ExecuteAction.DirectAttack(currentCard);
        }
    }

    private void invoke_button_Click(object sender, EventArgs e)
    {
        if (currentCard != null && currentCard.Owner == Game.CurrentPlayer && currentCard.ManaCost <= currentCard.Owner.Mana)
        {
            currentCard.Owner.InvokeCard(currentCard);
        }
    }

    private void end_turn_button_Click(object sender, EventArgs e)
    {
        Game.CheckAndChangePhaseAndCurrentPlayer();
    }*/
    }
}
