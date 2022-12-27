using LanguageToCreateCards.UtilsForLanguage;

namespace BattleCardsLibrary
{
    public class ValidationResponse
    {
        public ValidationResponse(ValidationResult validationResult, string message)
        {
            ValidationResult = validationResult;
            Message = message;
        }

        public ValidationResult ValidationResult { get; }
        public string Message { get; }
    }
}