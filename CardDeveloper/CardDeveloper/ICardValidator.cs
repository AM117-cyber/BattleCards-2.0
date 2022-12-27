using LanguageToCreateCards.Cards;

namespace BattleCardsLibrary.Cards.CardDeveloper
{
    public interface ICardValidator
    {
        public string[] CardDefinition { get; set; }
        public Card Card { get; set; }
        public ICardCreatorSource Source { get; }
        public ICardCreator CardCreator { get; }
        public ValidationResponse ValidateCard();

    }
}
