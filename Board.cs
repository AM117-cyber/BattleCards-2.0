using BattleCards.Cards;
namespace BattleCards;
public class Board
{
    public List<Card>[,] table { get; private set; }
    public Board()
    {
        table = new List<Card>[4, 5];
    }

    public void SetBoard(Card card, int i, int j)
    {
        table[i, j].Add(card);
    }

    public void UpdateBattleBoard()
    {

    }



}

