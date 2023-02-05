using BattleCardsLibrary.Utils;
namespace BattleCardsLibrary.PlayerNamespace
{
    public class UIPlayer
    {
        public string Name { get; }
        public PlayerType PlayerType { get; }

        public UIPlayer(string name, PlayerType playerType)
        {
            Name = name;
            PlayerType = playerType;
        }
    }
}