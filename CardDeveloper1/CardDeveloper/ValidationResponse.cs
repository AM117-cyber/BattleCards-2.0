using BattleCardsLibrary.Utils;

namespace CardDeveloper
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