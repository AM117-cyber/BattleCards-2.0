using static System.Net.Mime.MediaTypeNames;
using static Utils.Utils;
namespace BattleCards.Cards;
public class MonsterCard : Card
{
    public double HealthPoints { get; private set; }
    public double OnGameHealth { get; set; }

    public MonsterCard(Dictionary<AllCardProperties, string> CardProperties) : base(CardProperties)
    {
        int value;
        if (!Int32.TryParse(CardProperties[AllCardProperties.HealthPoints], out value))
        {
            throw new Exception("The value corresponding to healthpoints property isn't a number.");
        }

        HealthPoints = value;
        OnGameHealth = HealthPoints;
    }

}