using BattleCards.Cards;
using System.ComponentModel.DataAnnotations.Schema;
using System.Reflection.Metadata;
using System.Runtime.CompilerServices;

namespace BattleCards;
public class Game //Asumir que la informacion me va a entrar po alguna via, tu solo vas a trabajar con ella.Olvidate de por donde entre.
{
    public static List<Card> AllCardsCreated = GetAllCardsList();
    public List<Card> Board { get; set; }
    public bool EndGame = false;
    public Player Player1 { get; set; }
    public Player Player2 { get; set; }
    private Utils.Utils.Phase CurrentPhase { get; set; }


    public Game(UIPlayer player1, UIPlayer player2)
    {
        if (GetFirstPlayerByDice(player1, player2) == player1)
        {
            this.Player1 = CreateAPlayerInstance(player1);//player1 starts the game
            this.Player2 = CreateAPlayerInstance(player2);
        }
        else
        {
            this.Player1 = CreateAPlayerInstance(player2);//player1 starts the game
            this.Player2 = CreateAPlayerInstance(player1);
        }

        //Initialize the game. First each player shuffles their deck and then draws 5 cards

        Player1.Draw(5);
        Player2.Draw(5);
        //Here starts the game

        this.CurrentPhase = Utils.Utils.Phase.MainPhase;
        while (!EndGame)
        {
            Turn(Player1);
            if (EndGame) break;
            Turn(Player2);
        }




    }

    public void Turn(Player player1)
    {

        // List<SpellCard> SpellsOnBoard = GetSpellCardsOnBoard(board);
        // foreach (var card in SpellsOnBoard)
        // {
        //     if ((card as SpellCard).LifeTime < 1)
        //     {
        //         take card to graveyard;
        //     }
        //     else
        //     {
        //         card.LifeTime--;
        //         card.Effect();
        //     }
        // }

        MainPhase(player1);
        BattlePhase(player1, player2);
        //metodo para comprobar que no se acabo el juego
        if (GameIsOver())
        {
            this.EndGame = true;
        }
        return;
    }

    public bool GameIsOver()
    {
            if (Player1.Health <= 0)
            {
                Console.WriteLine(Player2.Name + "has won.Congratulations!!!");
                return true;
            }
            if (Player2.Health <= 0)
            {
                Console.WriteLine(Player1.Name + "has won.Congratulations!!!");
                return true;
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
            if (dice1!=dice2)
            {
                playersAreSet = true;
            if (dice1>dice2)
            {
                return player1;
            }
                return player2;
            }
           }
            return player1;
    }
   
    public static Player CreateAPlayerInstance(UIPlayer player)
    {
        if (player.PlayerType == PlayerType.Human)
        {
            return new HumanPlayer(player.Name, GenerateRandomDeck(AllCardsCreated, 50));
        }
        else
        {
            return new AIPlayer(player.Name, GenerateRandomDeck(AllCardsCreated, 50));
        }
    }
    public static List<Card> GetAllCardsList()
    {
        List<Card> answer = new List<Card>();
        string[] path = Directory.GetFiles(@"..\CardLibrary");

        foreach (var indivpath in path)
        {
            string[] text = File.ReadAllText(indivpath).Split(' ');
            answer.Add(CreateCard.CardCreator(text));

        }
        return answer;
    }

    public static List<Card> GenerateRandomDeck(List<Card> AllCardsCreated, int total)
    {
        List<Card> deck = new List<Card>();
        bool[] mask = new bool[AllCardsCreated.Count];
        Random r = new Random();
        int current = 0;

        while (current < total)
        {

            int k = r.Next(AllCardsCreated.Count);
            if (mask[k]) continue;
            deck.Add(AllCardsCreated[k]);
            mask[k] = true;
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
    */

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

        /*if (card is ToolCard)
        {

            if (player.board.MonsterZone[pos] == null) throw new Exception("No hay unidades en esta casilla");
            if (player.board.SpellZone[pos] != null) throw new Exception("Ya no puedes equipar mas cartas");
            player.board.SpellZone[pos] = card;
            Activate(card, player);
        }*/

    }

    public static void Activate(Card card, Player player)
    {
        if (card is MonsterCard)
        {
            if (player.Mana < (card as MonsterCard).ManaCost) throw new Exception("No tienes suficente mana");
            player.Mana -= (card as MonsterCard).ManaCost;
        }
        else player.Mana -= card.ManaCost;
        //card.Effect();
    }


    



    public void MainPhase(Player player)
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
    }

//Hacer el metodo discard
