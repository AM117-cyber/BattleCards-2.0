using BattleCardsLibrary;

namespace CardDeveloper
{
    public interface ICardValidator
    {
        public string[] CardDefinition { get; set; }
        public ICard Card{ get; set; }
        public ICardCreatorSource Source { get; }
        public ICardCreator CardCreator { get; }
        public ValidationResponse ValidateCard();

    }
}
