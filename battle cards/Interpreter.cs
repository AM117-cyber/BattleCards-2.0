namespace BattleCards;

    //creating an interpreter to send the needed data to method Attack in Actions
    public static class Interpreter
{
    public static List<string> SeparatingExpressions(string wholeExpression)
    {
        //asumir que retorna lista con expresiones globales separadas
    }
    public static double GetDamageThroughExpression(string attackContent)
    {
        List<string> SeparatedExpressions = SeparatedExpressions(attackContent);
        if (SeparatedExpressions[0].Evaluate)
        {
            Actions.Actions.Attack(algo, SeparatedExpressions[1].Evaluate);
        }
        else
        {
            Actions.Actions.Attack(algo, SeparatedExpressions[2].Evaluate);
        }
    }


}