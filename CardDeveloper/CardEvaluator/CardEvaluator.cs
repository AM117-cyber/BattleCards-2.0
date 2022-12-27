using static System.Net.Mime.MediaTypeNames;
using System.Threading;
using System.Linq.Expressions;
using LanguageToCreateCards.Cards;
using BattleCardsLibrary.Exceptions;
using LanguageToCreateCards.UtilsForLanguage;

namespace BattleCardsLibrary.Cards.CardEvaluator;
public class Interpreter
{

    public static IEvaluate BuildExpression(string expressionToBuild, CardType typeOfCard)
    {
        string[] leftAndRight = new string[3];
        string @operator = string.Empty;
        int opBuilder = GetParenthesiStart(0, expressionToBuild) - 1;
        @operator = GetString(expressionToBuild, 0, opBuilder);
        expressionToBuild = expressionToBuild.Remove(expressionToBuild.Length - 1).Remove(0, opBuilder + 2);// because opBuilder goes to last char before (
        switch (@operator)
        {
            case "":
                double constantValue = 0;
                if (double.TryParse(expressionToBuild.TrimStart('(').TrimEnd(')'), out constantValue))
                {
                    return new Constant(constantValue);
                }
                if (expressionToBuild == "")
                {
                    return new Constant(0);
                }
                throw new InvalidOperatorException("The expression typed isn't correct.");
            case "IfElse":
                return new TernaryExpression(expressionToBuild, typeOfCard);
            case "Add":
                //revisar que pasa con true al principio
                leftAndRight = SepareTernaryExpression(expressionToBuild, 2);
                return new Add(leftAndRight[0], leftAndRight[1], typeOfCard);
            case "Substract":

                leftAndRight = SepareTernaryExpression(expressionToBuild, 2);
                return new Substract(leftAndRight[0], leftAndRight[1], typeOfCard);
            case "Multiply":


                leftAndRight = SepareTernaryExpression(expressionToBuild, 2);
                return new Multiply(leftAndRight[0], leftAndRight[1], typeOfCard);
            case "Divide":


                leftAndRight = SepareTernaryExpression(expressionToBuild, 2);
                return new Divide(leftAndRight[0], leftAndRight[1], typeOfCard);
            case "Pow":


                leftAndRight = SepareTernaryExpression(expressionToBuild, 2);
                return new Pow(leftAndRight[0], leftAndRight[1], typeOfCard);
            case "Root":

                leftAndRight = SepareTernaryExpression(expressionToBuild, 2);
                return new Root(leftAndRight[0], leftAndRight[1], typeOfCard);
            case "OnCard":
                if (typeOfCard == CardType.Monster) 
                {
                    CheckIfArgumentIsValid(expressionToBuild, Enum.GetValues(typeof(MonsterCardValidProperties)).Cast<MonsterCardValidProperties>(), @operator);
                }
                else
                {
                    CheckIfArgumentIsValid(expressionToBuild, Enum.GetValues(typeof(SpellCardValidProperties)).Cast<SpellCardValidProperties>(), @operator);
                }
                return new OnCard(expressionToBuild, typeOfCard);
            case "OnPlayer":
                CheckIfArgumentIsValid(expressionToBuild, Enum.GetValues(typeof(PlayerValidProperties)).Cast<PlayerValidProperties>(),@operator);
                return new OnPlayer(expressionToBuild);
            case "EnemyCard":
                CheckIfArgumentIsValid(expressionToBuild,Enum.GetValues(typeof(MonsterCardValidProperties)).Cast<MonsterCardValidProperties>(), @operator);
                return new EnemyCard(expressionToBuild);
            case "EnemyPlayer":
                CheckIfArgumentIsValid(expressionToBuild, Enum.GetValues(typeof(PlayerValidProperties)).Cast<PlayerValidProperties>(), @operator);
                return new EnemyPlayer(expressionToBuild);
            default:
                throw new InvalidOperatorException("The expression typed isn't correct.");
        }
    }
    public static void CheckIfArgumentIsValid<T>(string argument, IEnumerable<T> EnumProperties, string typeOfExpression)
    {
        foreach (var validPropertyInEnum in EnumProperties)
        {
            if (argument == validPropertyInEnum.ToString())
            {
                return;
            }
        }
        throw new InvalidPropertyException(argument + " is an invalid argument for " + typeOfExpression);
        
    }

    public static IEvaluate BuildConditionalExpression(string expressionToBuild, CardType typeOfCard)
    {
        string[] leftAndRight = new string[3];
        string @operator = string.Empty;
        if (expressionToBuild[0] == '(')
        {
            @operator = GetString(expressionToBuild, 1, GetEndOfExpression(0, expressionToBuild) - 1);
        }
        else
        {
            int opBuilder = GetParenthesiStart(0, expressionToBuild) - 1;
            @operator = GetString(expressionToBuild, 0, opBuilder);
            leftAndRight = SepareTernaryExpression(expressionToBuild.Remove(expressionToBuild.Length - 1).Remove(0, opBuilder + 2), 2);
        }

        switch (@operator)
        {
            case "AND":
                return new AndExpression(leftAndRight[0], leftAndRight[1], typeOfCard);
            case "OR":
                return new OrExpression(leftAndRight[0], leftAndRight[1], typeOfCard);
            case "<":
                return new LowerThanOperatorExpression(leftAndRight[0], leftAndRight[1], typeOfCard);
            case ">":
                return new HigherThanOperatorExpression(leftAndRight[0], leftAndRight[1], typeOfCard);
            case "=":
                return new EqualityOperatorExpression(leftAndRight[0], leftAndRight[1], typeOfCard);
            case "!=":
                return new DifferentOperatorExpression(leftAndRight[0], leftAndRight[1], typeOfCard);
            case "true":

                return new TrueExpression();
            case "false":

                return new FalseExpression();

            default:
                throw new InvalidConditionException("You typed an invalid condition.");
        }
    }


    public static string[] SepareTernaryExpression(string ternaryExpression, int elementsInExpression)
    {

        int endOfCondition = GetEndOfExpression(0, ternaryExpression);
        //quitamos parentesis de extremos

        int endOfIfTrue = GetEndOfExpression(endOfCondition + 2, ternaryExpression);
        string[] answer = new string[elementsInExpression];
        if (elementsInExpression == 3)
        {
            answer[2] = GetString(ternaryExpression, endOfIfTrue + 2, ternaryExpression.Length - 1);
        }
        answer[1] = GetString(ternaryExpression, endOfCondition + 2, endOfIfTrue);
        answer[0] = GetString(ternaryExpression, 0, endOfCondition);

        return answer;


    }

    public static int GetEndOfExpression(int start, string ternaryExpression)
    {
        int count = 1;
        int endOfExpression = 0;
        start = GetParenthesiStart(start, ternaryExpression);


        for (int i = start + 1; i < ternaryExpression.Length; i++)//empieza en 2 porque al ser expr ternaria el primer operador es >,<,! o =, luego viene el primer parentesis
        {
            if (count == 0)
            {
                return endOfExpression;
            }

            if (ternaryExpression[i] == '(')
            {
                count++;
            }

            if (ternaryExpression[i] == ')')
            {
                count--;
                endOfExpression = i;
            }

        }
        return endOfExpression;
    }
    public static int GetParenthesiStart(int start, string ternaryExpression)
    {
        for (int i = start; i < ternaryExpression.Length; i++)
        {
            if (ternaryExpression[i] == '(')
            {
                return i;
            }
        }
        throw new InvalidExpressionException("The expression isn't properly written.");
    }

    public static string GetString(string ternaryExpression, int start, int end)
    {
        string expression = string.Empty;
        for (int i = start; i <= end; i++)
        {
            expression += ternaryExpression[i];
        }
        return expression;
    }
}






