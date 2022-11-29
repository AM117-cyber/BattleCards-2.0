using BattleCards.Cards;

namespace BattleCards;
public class Game //Asumir que la informacion me va a entrar po alguna via, tu solo vas a trabajar con ella.Olvidate de por donde entre.
{
    public static List<Player> Players;
        public static void SetGamePlayers(List<Player> Players, string name1, string name2)
        {

            /*switch (name)
            {
                case "Seamus-Virtual":
                VirtualPlayerSeamus P2 = new VirtualPlayerSeamus(name);
                break;

                case "Dean-Virtual":
                 VirtualPlayerDean P2 = new VirtualPlayerDean(name);
                break;

                default:
                Player P1 = new Player(name);
                break;
            }*/
        }
        public static void SetCardOwner(Player player)
        {
            foreach (var card in player.Deck)
            {
                card.Owner = player;
            }

        }

        public Game(Player player1, Player player2)
        {
            Board Board = new Board();
            //Initialize the game. First each player shuffles their deck an then draws 5 cards

            SetCardOwner(player1);
            SetCardOwner(player2);
            Support.Shuffle(player1.Deck);
            Support.Shuffle(player2.Deck);
            Support.Draw(player1, 5);
            Support.Draw(player2, 5);
            //Here starts the game

            while (!EndGame(player1, player2))
            {
                Turn(player1, Board);
                if (EndGame(player1, player2)) break;

                Turn(player2, Board);
            }
            if (player1.Winner) Console.WriteLine(player1.Name + "es el ganador");

            if (player2.Winner)
            {
                Console.WriteLine(player2.Name + "es el ganador");
            }
            else
            {
                System.Console.WriteLine("Draw, nobody won.");
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


        static void GenerateDiceResults(int[] diceResults)
        {
            int[] answer = new int[diceResults.Length];
            for (int i = 0; i < diceResults.Length; i++)
            {

                /*string player = "Player " + (i + 1);
                System.Console.WriteLine(player + ", Please press enter to throw the dice.");
                Random rnd = new Random();
                int dice1 = rnd.Next(1, 7);
                int dice2 = rnd.Next(1, 7);
                int sum = dice1 + dice2;
                System.Console.WriteLine(sum);
                (bool boolean, int pos) unique = IsUnique(sum, diceResults,i);
                if (!unique.boolean)
                {   
                    System.Console.WriteLine("Another player already threw that number. All players will proceed to throw the dice again.");
                    i = -1;
                    continue;
                }

                diceResults[i] = sum;
                answer[unique.pos] = i+1;
            }

            System.Console.WriteLine("All players have thrown the dice.Turns are:");
            for (int i = 0; i < diceResults.Length; i++)
            {
                System.Console.WriteLine($"Player {i + 1}: {GetTurn(i, diceResults)} turno");
            }

        }

        static (bool boolean, int pos) IsUnique(int sum, int[] diceResults, int player)
        {
            int pos = 1;
            int a = player - 1;
            for (int i = a; i >= 0; i--)
            {
                if (diceResults[i] == sum)
                {
                    return (false, pos);
                }
            }
            return (true, pos);
        }

        static int GetTurn(int player, int[] diceResults)
        {
            int count = diceResults.Length - player;
            for (int i = player + 1; i < diceResults.Length; i++)
            {
                if (diceResults[player] < diceResults[i])
                {
                    count--;
                }
            }
            return count;
        }

       static void OrdenarPorMezcla(int[] a)
       {
         Ordenar(a,0,a.Length-1);
       }
       static void Ordenar(int[] a, int firstPos, int lastPos)
       {
           if (firstPos < lastPos)
           {
               int middle = (lastPos + firstPos)/2;
               Ordenar(a, firstPos, middle);
               Ordenar(a, middle+1, lastPos);
               Mezclar(a,firstPos, middle, lastPos);
           }
       }
       static void Mezclar(int[] a, int firstPos, int middle, int lastPos)
       {
           int startOf1 = firstPos;
           int startOf2 = middle + 1;
           int currentPos = 0;
           int[] arr = new int[lastPos-firstPos+1];
           while (startOf1 <= middle && startOf2 <= lastPos)
           {
               if(a[startOf1] < a[startOf2])
               { 
                   arr[currentPos++] = a[startOf1++];
               } else{ 
                   arr[currentPos++] = a[startOf2++];
                   }
           }
       if (startOf1 <= middle)
       {
            Array.Copy(a,startOf1,arr,currentPos,middle-startOf1+1);
       }
       if (startOf2 <= lastPos)
       {
           Array.Copy(a,startOf2,arr,currentPos,lastPos-startOf2+1);
       }
       Array.Copy(arr, 0, a,firstPos,arr.Length);

       }*/


        public static void Summon(Player player, Board board, Card card, int pos)
        {
            if (player.Mana < card.ManaCost) throw new Exception("No tienes suficiente mana.");
            player.Hand.Remove(card);

            if (card is SpellCard)
            {
                Activate(card, player);
            }

            if (card is MonsterCard)
            {
                if (board.table[player.Number, pos].Count == 0)
                {
                    board.SetBoard(card, player.Number, pos);
                    player.Mana -= card.ManaCost;
                }
                else throw new Exception("Ya existe una unidad en esa casilla");
            }

            if (card is Equipment)
            {
                int s = player.Number == 1 ? player.Number - 1 : player.Number + 1;
                if (board.table[player.Number, pos].Count == 0) throw new Exception("No hay unidades en esta casilla");
                if (board.table[s, pos].Count == 3) throw new Exception("Ya no puedes equipar mas cartas");
                board.SetBoard(card, s, pos);
                Activate(card, player);
            }

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


        public void Turn(Player player, Board board)
        {
            Support.Draw(player, 1);
            List<SpellCard> SpellsOnBoard = GetSpellCardsOnBoard(board);
            foreach (var card in SpellsOnBoard)
            {
                if ((card as SpellCard).LifeTime < 1)
                {
                    //take card to graveyard;
                }
                else
                {
                    card.LifeTime--;
                    //card.Effect();
                }
            }

            MainPhase(player, board);
            BattlePhase(player, board);
        }



        public void MainPhase(Player player, Board board)
        {
            bool end = false;
            while (!end)
            {
                Console.WriteLine("Type 's' and then press 'ENTER' to Summon a card"); //
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
                        Summon(player, board, player.Hand[cardS], pos);
                        break;

                    case "a":
                        Console.WriteLine("Select a card to Activate");
                        int cardA = int.Parse(Console.ReadLine());
                        if (board.table[player.Number, cardA].Count == 0) throw new Exception("No hay ninguna carta en esa posicion");
                        Activate(board.table[player.Number, cardA][0], player);
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

        public void BattlePhase(Player player, Board board)
        {
            int cant = 0;
            for (int i = 0; i < board.table.GetLength(0); i++)
            {
                if (board.table[player.Number, i].Count == 1) cant++;
            }
            bool[] attackMask = new bool[cant]; //array of cards that can attack
            bool end = false;
            while (!end)
            {
                Console.WriteLine("Choose a card to attack");
                int card = int.Parse(Console.ReadLine());
                Console.WriteLine("Choose your target");
                int obj = int.Parse(Console.ReadLine());


            }
        }

        public void Attack(Card card1, Card card2)
        {
            //se evalua la expresion y se llama a Actions.Attack(Card card2,evaluatedExpression);
        }


        public bool EndGame(Player player1, Player player2)
        {
            if (player1.Health <= 0 || player1.Deck.Count == 0)
            {
                player2.Winner = true;
                return true;
            }
            if (player2.Health <= 0 || player2.Deck.Count == 0)
            {
                player1.Winner = true;
                return true;
            }
            else return false;
        }

    }


    
