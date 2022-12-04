namespace BattleCards
{
    public class UIPlayer
    {
        public string Name { get; private set; }
        public PlayerType PlayerType { get; private set; }

        public UIPlayer(string name, PlayerType playerType)
        {
            Name = name;
            PlayerType = playerType;
        }
    }
}