
using BattleCardsLibrary.PlayerNamespace;
using BattleCardsLibrary.Utils;
using static BattleCardsLibrary.ExecuteActions.ExecuteAction;

namespace BattleCardsLibrary;
public class Game //Asumir que la informacion me va a entrar po alguna via, tu solo vas a trabajar con ella.Olvidate de por donde entre.
{
    private int currentTurn = 0;
    //public static bool InterfaceUpdated { get; set; }
    public static List<ICard> AllCardsCreated { get; private set; }
    public static bool EndGame = false;
    public Player CurrentPlayer => currentTurn % 2 == 0 ? Player1 : Player2;//it is declared when Game State is first updated
    public Player Player1 { get; set; }
    public Player Player2 { get; set; }
    public Phase CurrentPhase { get; private set; }
    //when you create a Card,first input is type and second is name

    public Game(UIPlayer uiPlayer1, UIPlayer uiPlayer2, List<ICard> allCardsCreated)
    {
        AllCardsCreated = allCardsCreated;
        int amountOfCardsInDeck = AllCardsCreated.Count / 2;
        if (GetFirstPlayerByDiceThrowing(uiPlayer1, uiPlayer2) == uiPlayer1)
        {
            Player1 = CreateAPlayerInstance(uiPlayer1, 1, amountOfCardsInDeck);//player1 starts the game
            Player2 = CreateAPlayerInstance(uiPlayer2, 2, amountOfCardsInDeck);

        }
        else
        {
            Player1 = CreateAPlayerInstance(uiPlayer2, 1, amountOfCardsInDeck);//the second UIPlayer starts the game
            Player2 = CreateAPlayerInstance(uiPlayer1, 2, amountOfCardsInDeck);
        }

        Player1.Draw(5);
        Player2.Draw(5);
        //InterfaceUpdated = true;
        //Here starts the game

        CurrentPhase = Phase.MainPhase;
    }

    public void CheckAndChangePhaseAndCurrentPlayer()
    {
        if (CurrentPhase == Phase.MainPhase)
        {
            CurrentPhase = Phase.BattlePhase;
        }
        else
        {
            //CurrentPlayer.FinishTurn();
            //ChangeTurn();
            //CurrentPlayer.StartTurn();
            //reducing LifeTime of spells
            CurrentPlayer.MarkCardsAsUnused();
            CurrentPhase = Phase.MainPhase;
            CurrentPlayer.Mana = (CurrentPlayer.Mana + 5) < 20 ? CurrentPlayer.Mana + 5 : CurrentPlayer.Mana = 20;
            ChangePlayer();
            CurrentPlayer.UpdateSpellsMana();
        }
    }
    public void ChangePlayer()
    {
        currentTurn++;
    }

    public void CardActionReceiver(PlayerAction action, ICard onCard, ICard enemyCard, int playerNumber)
    {

        //solo puede hacer draw el currentplayer si es humano
        switch (action)
        {
            case PlayerAction.DrawFromDeck:
                //solo puedes sacar si es tu turno
                if (CanDraw(playerNumber))
                    CurrentPlayer.Draw();
                break;
            case PlayerAction.InvokeCard:
                //si la fase es correcta, la carta no es null, el jugador que ejecuta la accion es el del turno que se juega, tiene al menos un espacio en su board y suficiente mana
                if (CanInvoke(onCard))
                {
                    onCard.Owner.InvokeCard(onCard);

                }

                break;
            case PlayerAction.TurnIsOver:
                CheckAndChangePhaseAndCurrentPlayer();
                break;
            case PlayerAction.Attack:
                //fase debe ser batalla, cartas no pueden ser nulas,la carta debe pertenecer al jugador cuyo turno se juega y la victima debe ser un monstruo. 
                if (CanAttack(onCard, enemyCard))//la interfaz es quien comprueba que sea humano
                {
                    Attack(onCard, enemyCard as IMonsterCard, onCard.Attack.Evaluate(onCard, enemyCard as IMonsterCard));
                }
                break;
            case PlayerAction.Heal:
                if (CanHeal(onCard, enemyCard))
                {
                    Heal(onCard, enemyCard as IMonsterCard, onCard.Heal.Evaluate(onCard, enemyCard as IMonsterCard));
                }
                break;
            case PlayerAction.DirectAttack:
                if (CanAttackDirectly(onCard))
                {
                    DirectAttack(onCard);

                }

                break;
            //  case ActionsByPlayer.None:    este caso nunca va a llegar 
            //     CheckAndChangePhaseAndCurrentPlayer();
            //      break;

            default:
                break;
        }

    }

    private bool CanAttackDirectly(ICard onCard)
    {
        return CurrentPhase == Phase.BattlePhase && onCard != null && onCard.Owner == CurrentPlayer;
    }

    private bool CanHeal(ICard onCard, ICard enemyCard)
    {
        return CurrentPhase == Phase.BattlePhase && onCard != null && enemyCard != null && enemyCard.Type == CardType.Monster && onCard.Owner == CurrentPlayer;
    }

    private bool CanAttack(ICard card1, ICard card2)
    {
        return CurrentPhase == Phase.BattlePhase && card1 != null && card2 != null && card2.Type == CardType.Monster && card1.Owner == CurrentPlayer;
    }

    private bool CanInvoke(ICard card)
    {
        return CurrentPhase == Phase.MainPhase
            && card != null
            && card.Owner == CurrentPlayer
            && card.Owner.CardsOnBoard.Count < 5
            && card.Owner.Mana >= card.ManaCost;
    }

    private bool CanDraw(int playerNumber)
    {
        return CurrentPhase == Phase.MainPhase
            && playerNumber == CurrentPlayer.Number
            && CurrentPlayer.Mana >= 1
            && CurrentPlayer.Hand.Count < 5
            && CurrentPlayer.Deck.Count >= 1;
    }

    public bool GameIsOver()
    {
        if (Player1.Health <= 0)
        {
            throw new Exception(Player2.Name + " has won. Congratulations!!!");
        }
        if (Player2.Health <= 0)
        {
            throw new Exception(Player1.Name + " has won.Congratulations!!!");
        }
        return false;

    }


    public static UIPlayer GetFirstPlayerByDiceThrowing(UIPlayer player1, UIPlayer player2)
    {

        bool playersAreSet = false;
        Random rnd = new Random();
        while (!playersAreSet)
        {
            int dice1 = rnd.Next(1, 7);
            int dice2 = rnd.Next(1, 7);
            if (dice1 != dice2)
            {
                playersAreSet = true;
                if (dice1 > dice2)
                {
                    return player1;
                }
                return player2;
            }
        }
        return player1;
    }

    public Player CreateAPlayerInstance(UIPlayer player, int number, int amountOfCardsInDeck)
    {

        if (player.PlayerType == PlayerType.Human)
        {
            return new Player(player.Name, GenerateRandomDeck(AllCardsCreated, amountOfCardsInDeck), number);//50
        }
        else
        {
            return new AIPlayerMedium(player.Name, GenerateRandomDeck(AllCardsCreated, amountOfCardsInDeck), number, this);
        }
    }


    public static List<ICard> GenerateRandomDeck(List<ICard> AllCardsCreated, int total)
    {

        List<ICard> deck = new List<ICard>();
        Random r = new Random();
        int current = 0;

        while (current < (total < 20 ? total : 20))
        {

            int k = r.Next(AllCardsCreated.Count);
            deck.Add(AllCardsCreated[k]);
            AllCardsCreated.Remove(AllCardsCreated[k]);
            current++;
        }

        return deck;
    }
}





/*
public int AmountOfPlayers;//= Int32.Parse(Console.ReadLine());  You need amount of players to initialize a game.
public List<string> PlayersNames;

public Game(int amountOfPlayers)
{
    if (amountOfPlayers < 1)
    {
        throw new ArgumentException("Amount of players for dueling must be of at least 1.");//change message
    }

    this.AmountOfPlayers = amountOfPlayers;
    this.PlayersNames = GetNames(PlayersNames);
}

public static IEnumerable<Player> players = ;


public static IEnumerable<Document> ProcessFolder(string[] path)
{
    foreach (var indivpath in path)
    {
        string text = File.ReadAllText(indivpath);
        string pattern = @"\w+";
        var Docs = new Document(indivpath, ProcessText(text, pattern));
        yield return Docs;
    }
}

public static List<string> GetNames(List<string> names)
{
    string name = Console.ReadLine();
    while (name != "")// mientras que no se le de al boton done;
    {
        names.Add(name);
        name = Console.ReadLine();
    }

    return names;
}


   public static void Summon(Player player,ICardcard, int pos)
{
    if (player.Mana < card.ManaCost) throw new Exception("No tienes suficiente mana.");
    player.Hand.Remove(card);

    if (card is SpellCard)
    {
        Activate(card, player);
        player.Graveyard.Add(card);
    }

    if (card is MonsterCard)
    {
        if (player.board.MonsterZone[pos] == null)
        {
            player.board.MonsterZone[pos] = card;
            player.Mana -= card.ManaCost;
        }
        else throw new Exception("Ya existe una unidad en esa casilla");
    }
*/
/*if (card is ToolCard)
{

    if (player.board.MonsterZone[pos] == null) throw new Exception("No hay unidades en esta casilla");
    if (player.board.SpellZone[pos] != null) throw new Exception("Ya no puedes equipar mas cartas");
    player.board.SpellZone[pos] = card;
    Activate(card, player);
}*/



/*public static void Activate(Card card, Player player)
{
    if (card is MonsterCard)
    {
        if (player.Mana < (card as MonsterCard).ManaCost) throw new Exception("No tienes suficente mana");
        player.Mana -= (card as MonsterCard).ManaCost;
    }
    else player.Mana -= card.ManaCost;
    //card.Effect();
}
*/





/* public void MainPhase(Player player)
 {
     bool end = false;
     while (!end)
     {
         Console.WriteLine("Type 's' and then press 'ENTER' to Summon a card"); 
         Console.WriteLine("Type 'a' and then press 'ENTER' to Activate an Effect");
         Console.WriteLine("Type 'e' and then prees 'ENTER' to end the MainPhase");
         string answer = Console.ReadLine();
         switch (answer)
         {
             case "s":
                 Console.WriteLine("Select aICardto Summon by typing the position of the card.");
                 int cardS = int.Parse(Console.ReadLine());
                 Console.WriteLine("Select a position to Summon.");
                 int pos = int.Parse(Console.ReadLine());
                 Summon(player, player.Hand[cardS], pos);
                 break;

             case "a":
                 Console.WriteLine("Select aICardto Activate");
                 int cardA = int.Parse(Console.ReadLine());
                 if (player.board.MonsterZone[cardA] == null) throw new Exception("No hay ninguna carta en esa posicion");
                 Activate(player.board.MonsterZone[cardA], player);
                 break;

             case "e":
                 end = true;
                 break;

             default:
                 System.Console.Write("You typed a wrong answer. Type again: ");
                 break;
         }
     }
 }

 public void BattlePhase(Player player1, Player player2)
 {
     int cant = 0;
     for (int i = 0; i < player1.board.MonsterZone.Length; i++)
     {
         if (player1.board.MonsterZone[i] != null) cant++;
     }
     bool[] attackMask = new bool[cant]; //array of cards that can attack
     bool end = false;
     while (!end)
     {
         Console.WriteLine("Type 'a' and then 'ENTER' to attack");
         Console.WriteLine("Type 'e' and then 'ENTER' to end your turn");
         string answer = Console.ReadLine();
         switch (answer)
         {
             case "a":
                 Console.WriteLine("Choose aICardto attack");
                 int onCard = int.Parse(Console.ReadLine());
                 if (attackMask[onCard]) throw new Exception("ThisICardalready attacked");
                 Console.WriteLine("Choose your target");
                 int target = int.Parse(Console.ReadLine());
                 if (player2.board.MonsterZone == null) throw new Exception("No hay ninguna carta en esta posicion");

                 var actionReceiver = new ActionReceiver(
                     (MonsterCard)player1.board.MonsterZone[onCard],
                     (MonsterCard)player2.board.MonsterZone[target],
                     ActionType.Attack);

                 CreateCard.CardActionReceiver(actionReceiver);
                 if ((player2.board.MonsterZone[target] as MonsterCard).OnGameHealth <= 0) Died((MonsterCard)player2.board.MonsterZone[target], player2);
                 break;

             case "e":
                 end = true;
                 break;
         }
     }
 }*/

//Hacer el metodo discard
