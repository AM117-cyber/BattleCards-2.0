using BattleCards.Cards;
using BattleCardsLibrary.Cards;
using static Utils.Utils;
using static BattleCards.ExecuteActions.ExecuteAction;
using System.ComponentModel.DataAnnotations.Schema;
using System.Reflection.Metadata;
using System.Runtime.CompilerServices;
using System.Security.Principal;

namespace BattleCards;
public class Game //Asumir que la informacion me va a entrar po alguna via, tu solo vas a trabajar con ella.Olvidate de por donde entre.
{
    public static bool InterfaceUpdated { get; set; }
    public static List<Card> AllCardsCreated = GetAllCardsList();
    public List<Card> Board { get; set; }
    public static bool EndGame = false;
    public static int CurrentPlayer { get; set; }//it is declared when Game State is first updated
    public static Player Player1 { get; set; }
    public static Player Player2 { get; set; }
    public static Phase CurrentPhase { get; private set; }
    //when you create a card first input is type and second is name

    public Game(UIPlayer player1, UIPlayer player2)
    {

        if (GetFirstPlayerByDice(player1, player2) == player1)
        {
            Player1 = CreateAPlayerInstance(player1, 1);//player1 starts the game
            Player2 = CreateAPlayerInstance(player2, 2);
            CurrentPlayer = 1;
        }
        else
        {
            Player1 = CreateAPlayerInstance(player2, 1);//player2 starts the game
            Player2 = CreateAPlayerInstance(player1, 2);
            CurrentPlayer = 2;
        }


        //Initialize the game. First each player shuffles their deck and then draws 5 cards

       
        Player1.Draw(5);
        Player2.Draw(5);
        InterfaceUpdated = true;
        //Here starts the game

        CurrentPhase = Phase.MainPhase;





    }

    public static void CheckAndChangePhaseAndCurrentPlayer()
    {
        Player current = GetCurrentPlayer();
        if (CurrentPhase == Phase.MainPhase)
        {
            CurrentPhase = Phase.BattlePhase;
        }
        else
        {
            //reducing LifeTime of spells
            current.MarkCardsAsUnused();
            CurrentPhase = Phase.MainPhase;
            current.Mana = (current.Mana + 5) < 20? current.Mana + 5: current.Mana = 20;
            ChangePlayer();
            GetCurrentPlayer().UpdateSpellsMana();
            

        }
    }
    public static void ChangePlayer()
    {
        CurrentPlayer = (CurrentPlayer == 1 ? 2 : 1);
    }

    public static Player GetCurrentPlayer()
    {
        if (CurrentPlayer == 1)
        {
            return Player1;
        }
        return Player2;
    }
    public static void CardActionReceiver(ActionsByPlayer action, Card card1, Card card2, int numberOfDeck)
    {
        //solo puede hacer draw el currentplayer si es humano
        switch (action)
        {
            case ActionsByPlayer.DrawFromDeck:
                //solo puedes sacar si es tu turno
                if (CurrentPhase == Phase.MainPhase && numberOfDeck == CurrentPlayer)
                {
                    if (GetCurrentPlayer().Mana >= 1 && GetCurrentPlayer().Hand.Count < 5 && GetCurrentPlayer().Deck.Count >= 1) GetCurrentPlayer().Draw(1);
                    return;
                }

                break;
            case ActionsByPlayer.InvokeCard:
                //si la fase es correcta, la carta no es null, el jugador que ejecuta la accion es el del turno que se juega, tiene al menos un espacio en su board y suficiente mana
                if (CurrentPhase == Phase.MainPhase && card1 != null && card1.Owner.Number == CurrentPlayer && card1.Owner.CardsOnBoard.Count < 5 && card1.Owner.Mana >= card1.ManaCost)
                {
                    card1.Owner.InvokeCard(card1);

                }

                break;
            case ActionsByPlayer.TurnIsOver:
                CheckAndChangePhaseAndCurrentPlayer();
                break;
            case ActionsByPlayer.Attack:
                //fase debe ser batalla, cartas no pueden ser nulas,la carta debe pertenecer al jugador cuyo turno se juega y la victima debe ser un monstruo. 
                if (CurrentPhase == Phase.BattlePhase && card1 != null && card2 != null && card2.Type == CardType.Monster && card1.Owner.Number == CurrentPlayer)//la interfaz es quien comprueba que sea humano
                {
                    Attack(card1, card2 as MonsterCard, card1.Attack.Evaluate(card1, card2));
                }
                break;
            case ActionsByPlayer.Heal:
                if (CurrentPhase == Phase.BattlePhase && card1 != null && card2 != null && card2.Type == CardType.Monster && card1.Owner.Number == CurrentPlayer)
                {
                    Heal(card1, card2 as MonsterCard, card1.Heal.Evaluate(card1, card2));
                }
                break;
            case ActionsByPlayer.DirectAttack:
                if (CurrentPhase == Phase.BattlePhase && card1.Owner.Number == CurrentPlayer)
                {
                    DirectAttack(card1);

                }

                break;
            case ActionsByPlayer.None:
                CheckAndChangePhaseAndCurrentPlayer();
                break;

            default:
                break;
        }

    }

    public static bool GameIsOver()
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


    public static UIPlayer GetFirstPlayerByDice(UIPlayer player1, UIPlayer player2)
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

    public Player CreateAPlayerInstance(UIPlayer player, int number)
    {
        if (player.PlayerType == PlayerType.Human)
        {
            return new HumanPlayer(player.Name, GenerateRandomDeck(AllCardsCreated, 7), number);//50
        }
        else
        {
            return new AIPlayer(player.Name, GenerateRandomDeck(AllCardsCreated, 7), number);
        }
    }
    public static List<Card> GetAllCardsList()
    {
        List<Card> answer = new List<Card>();
        string[] path = Directory.GetFiles(@"..\CardLibrary");
        CardCreator cardCreator = new CardCreator();
        foreach (var indivpath in path)
        {
            string[] text = File.ReadAllText(indivpath).Split("\r\n");
            string processedTextAsString = string.Empty;
            foreach (var item in text)
            {
                processedTextAsString += ": " + item;
            }
            string[] textToCreateCard = processedTextAsString.Remove(0, 2).Split(": ");
            answer.Add(cardCreator.CreateCard(textToCreateCard));

        }
        return answer;
    }

    public static List<Card> GenerateRandomDeck(List<Card> AllCardsCreated, int total)
    {
        List<Card> deck = new List<Card>();
        Random r = new Random();
        int current = 0;

        while (current < total)
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


   public static void Summon(Player player, Card card, int pos)
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
                 Console.WriteLine("Select a card to Summon by typing the position of the card.");
                 int cardS = int.Parse(Console.ReadLine());
                 Console.WriteLine("Select a position to Summon.");
                 int pos = int.Parse(Console.ReadLine());
                 Summon(player, player.Hand[cardS], pos);
                 break;

             case "a":
                 Console.WriteLine("Select a card to Activate");
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
                 Console.WriteLine("Choose a card to attack");
                 int onCard = int.Parse(Console.ReadLine());
                 if (attackMask[onCard]) throw new Exception("This card already attacked");
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
