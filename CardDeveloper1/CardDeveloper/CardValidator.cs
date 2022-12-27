using BattleCardsLibrary;
using CardDeveloper1.Exceptions;
using BattleCardsLibrary.Utils;

namespace CardDeveloper1;

public class CardValidator : ICardValidator
{
    public string[] CardDefinition { get; set; }
    public ICard Card{ get; set; }

    public ICardCreatorSource Source { get; }

    public ICardCreator CardCreator { get; }

    public CardValidator(ICardCreatorSource source, ICardCreator cardCreator)
    {
        this.Source = source;
        this.CardCreator = cardCreator;

    }
    public ValidationResponse ValidateCard()
    {
        try
        {
            this.CardDefinition = Source.GetCardDefinition();
            this.Card = CardCreator.CreateCard(CardDefinition);//
        }
        catch (Exception e)
        {
            return GetValidationResponseFromException(e);
        }

        return new ValidationResponse(ValidationResult.Ok, ValidationResult.Ok.ToString());
    }

    private static ValidationResponse GetValidationResponseFromException(Exception e)
    {
        if (e is PropertyIsNotANumberException)
        {
            return new ValidationResponse(ValidationResult.HealIsNotANumber, e.Message);
        }
        if (e is InvalidCardTypeException)
        {
            return new ValidationResponse(ValidationResult.InvalidCardType, e.Message);
        }
        if (e is InvalidConditionException)
        {
            return new ValidationResponse(ValidationResult.InvalidCondition, e.Message);
        }
        if (e is InvalidExpressionException)
        {
            return new ValidationResponse(ValidationResult.InvalidExpression, e.Message);
        }
        if (e is InvalidOperatorException)
        {
            return new ValidationResponse(ValidationResult.InvalidOperator, e.Message);
        }
        if (e is InvalidPropertyException)
        {
            return new ValidationResponse(ValidationResult.InvalidProperty, e.Message);
        }
        if (e is InvalidPropertyForCardTypeException)
        {
            return new ValidationResponse(ValidationResult.InvalidPropertyForCardType, e.Message);
        }
        if (e is NamelessCardException)
        {
            return new ValidationResponse(ValidationResult.NamelessCard, e.Message);
        }
        if (e is NoValueForEachPropertyException)
        {
            return new ValidationResponse(ValidationResult.NoValueForEachProperty, e.Message);
        }
        if (e is SpellsDontHaveDefenseException)
        {
            return new ValidationResponse(ValidationResult.SpellDontHaveDefense, e.Message);
        }
        if (e is IndexOutOfRangeException)
        {
            return new ValidationResponse(ValidationResult.InvalidCard, e.Message);
        }

        return new ValidationResponse(ValidationResult.Unknown, e.Message);
    }
}

