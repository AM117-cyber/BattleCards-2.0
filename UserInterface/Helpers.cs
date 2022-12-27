using BattleCardsLibrary;
using BattleCardsLibrary.Utils;
using CardDeveloper1;

namespace UserInterface
{
    public static class Helper
    {
        public static void ShowMessage(ValidationResponse validationResponse)
        {
            var message = validationResponse.ValidationResult == ValidationResult.Ok ? "Card was created sucessfully :)" : validationResponse.Message;
            var title = validationResponse.ValidationResult == ValidationResult.Ok ? "Validation Info" : "Validation Error";
            MessageBoxIcon icon = validationResponse.ValidationResult == ValidationResult.Ok ? MessageBoxIcon.Information : MessageBoxIcon.Error;
            MessageBox.Show(message, title, MessageBoxButtons.OK, icon);
        }
    }
}
