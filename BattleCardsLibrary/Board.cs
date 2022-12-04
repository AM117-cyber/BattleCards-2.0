using BattleCards.Cards;

namespace BattleCards;
public class Board
{
    public Card[] MonsterZone;
    public Board()
    {
        MonsterZone = new Card[5];
    }

    public void SetBoard(Card card, int i, int j)
    {
        // table[i, j].Add(card);
    }

    public void UpdateBattleBoard()
    {

    }



}

