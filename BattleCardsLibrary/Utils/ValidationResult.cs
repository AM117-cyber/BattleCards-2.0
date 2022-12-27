namespace BattleCardsLibrary.Utils
{
    public enum ValidationResult
    {
        Ok,
        NoValueForEachProperty,
        InvalidCardType,
        InvalidCard,
        InvalidExpression,
        InvalidOperator,
        InvalidCodition,
        InvalidCondition,
        HealIsNotANumber,
        InvalidProperty,
        InvalidPropertyForCardType,
        SpellDontHaveDefense,
        NamelessCard,
        Unknown,
    }
}