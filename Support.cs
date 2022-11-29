using BattleCards.Cards;

namespace BattleCards;
public class Support
{
   static public void Shuffle(List<Card> deck)//Should this method go into Game class?
   {
      Random r = new Random();
      for(int n = deck.Count-1; n > 0; n--)
      {
         int k = r.Next(n+1);
         Card temp = deck[n];//declare with Card.ID
         deck[n] = deck[k];
         deck[k] = temp;
      }
   }

   public List<Card> CreateRandomDeck(List<Card> cardList)//le pasas todas las cartas que existen
        {
            List<Card> deck = new List<Card>();
            bool[] mask = new bool[cardList.Count];
            Random c = new Random();
            int total = c.Next(29, 51); //generates a random integer between 30 and 50 which will be the total amount of cards in the deck
            Random r = new Random();
            int current = 0;

            while (current < total)
            {
                int k = r.Next(cardList.Count);
                Card card = cardList[k];
                if (mask[k]) continue;
                deck.Add(card);
                mask[k] = true;
                current++;
            }

            return deck;
        }

        public static void Draw(Player player, int cant)
        {
            for (int i = 0; i < cant; i++)
            {
                player.Hand.Add(player.Deck[0]);
                player.Deck.Remove(player.Deck[0]);
            }
        }



    }




}
