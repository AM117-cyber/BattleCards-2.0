using static System.Net.Mime.MediaTypeNames;
using System.Threading;
using static Utils.Utils;
using BattleCards;
using System.Linq.Expressions;

namespace BattleCards.Cards;

public interface IEvaluate
{
    public double Evaluate(Card onCard, Card enemyCard);
}

public class TernaryExpression : IEvaluate
{
    public IEvaluate Condition { get; set; }
    public IEvaluate IfTrue { get; set; }
    public IEvaluate Else { get; set; }

    public TernaryExpression(string ternaryExpression, CardType type)
    {
        string[] SeparatedExpressions = Interpreter.SepareTernaryExpression(ternaryExpression, 3);
        Condition = Interpreter.BuildConditionalExpression(SeparatedExpressions[0], type);
        IfTrue = Interpreter.BuildExpression(SeparatedExpressions[1], type);
        Else = Interpreter.BuildExpression(SeparatedExpressions[2], type);
    }


    public double Evaluate(Card onCard, Card enemyCard)
    {
        if (Condition.Evaluate(onCard, enemyCard) == 1)
        {
            return IfTrue.Evaluate(onCard, enemyCard);
        }
        return Else.Evaluate(onCard, enemyCard);
    }
}

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
                throw new Exception("The expression typed isn't correct.");
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
                return new OnCard(expressionToBuild, typeOfCard);
            case "OnPlayer":
                return new OnPlayer(expressionToBuild);
            case "EnemyCard":

                return new EnemyCard(expressionToBuild);
            case "EnemyPlayer":

                return new EnemyPlayer(expressionToBuild);
            default:
                throw new Exception("The expression typed isn't correct.");
        }
    }
    public static IEvaluate BuildConditionalExpression(string expressionToBuild, CardType typeOfCard)
    {
        string[] leftAndRight = new string[3];
        string @operator = string.Empty;
        if (expressionToBuild[0] == '(')
        {
            @operator = GetString(expressionToBuild, 1, GetEndOfExpression(0, expressionToBuild)-1);
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
                throw new Exception("You typed an invalid condition.");
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
        throw new Exception("The expression isn't properly written.");
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

public abstract class BinaryExpression: IEvaluate
{
    public IEvaluate Left { get; set; } // el operador no hace falta porque cuando se construye ya debe saber quien es
    public IEvaluate Right { get; set; }

    public double Evaluate(Card onCard, Card enemyCard)//
    {
        double leftValue = Left.Evaluate(onCard, enemyCard);
        double rightValue = Right.Evaluate(onCard, enemyCard);

        return Evaluate(leftValue, rightValue);
    }

    public abstract double Evaluate(double leftValue, double rightValue);
}
public abstract class NonConditionalBinaryExpression : BinaryExpression
{
    public NonConditionalBinaryExpression(string left, string right, CardType type)
    {
        Left = Interpreter.BuildExpression(left, type);
        Right = Interpreter.BuildExpression(right, type);
    }
}
public abstract class ConditionalBinaryExpression : BinaryExpression
{
    public ConditionalBinaryExpression(string left, string right, CardType type)
    {
        Left = Interpreter.BuildConditionalExpression(left, type);
        Right = Interpreter.BuildConditionalExpression(right, type);
    }
}

public class AndExpression : ConditionalBinaryExpression
{
    public AndExpression(string left, string right, CardType type) : base(left, right, type)
    {
    }
    public override double Evaluate(double leftValue, double rightValue)
    {
        return (leftValue == 1 && rightValue == 1) ? 1 : 0;
    }
}
public class OrExpression : ConditionalBinaryExpression
{
    public OrExpression(string left, string right, CardType type) : base(left, right, type)
    {

    }
    public override double Evaluate(double leftValue, double rightValue)
    {
        return (leftValue == 1 || rightValue == 1) ? 1 : 0;
    }
}
public class LowerThanOperatorExpression : NonConditionalBinaryExpression
{
    public LowerThanOperatorExpression(string left, string right, CardType type) : base(left, right, type)
    {

    }

    public override double Evaluate(double leftValue, double rightValue)
    {
        return leftValue < rightValue ? 1 : 0;
    }
}

public class HigherThanOperatorExpression : NonConditionalBinaryExpression
{
    public HigherThanOperatorExpression(string left, string right, CardType type) : base(left, right, type)
    {

    }

    public override double Evaluate(double leftValue, double rightValue)
    {
        return leftValue > rightValue ? 1 : 0;
    }
}

public class EqualityOperatorExpression : NonConditionalBinaryExpression
{
    public EqualityOperatorExpression(string left, string right, CardType type) : base(left, right, type)
    {

    }

    public override double Evaluate(double leftValue, double rightValue)
    {
        return leftValue == rightValue ? 1 : 0;
    }
}
public class DifferentOperatorExpression : NonConditionalBinaryExpression
{
    public DifferentOperatorExpression(string left, string right, CardType type) : base(left, right, type)
    {

    }

    public override double Evaluate(double leftValue, double rightValue)
    {
        return leftValue != rightValue ? 1 : 0;
    }
}

public class TrueExpression : IEvaluate
{
    public double Evaluate(Card onCard, Card enemyCard)
    {
        return 1;
    }
}

public class FalseExpression : IEvaluate
{
    public double Evaluate(Card onCard, Card enemyCard)
    {
        return 0;
    }
}

public class Add : NonConditionalBinaryExpression
{
    public Add(string left, string right, CardType type) : base(left, right, type)
    {

    }
    public override double Evaluate(double leftValue, double rightValue)
    {
        return leftValue + rightValue;
    }
}
public class Substract : NonConditionalBinaryExpression
{
    public Substract(string left, string right, CardType type) : base(left, right, type)
    {

    }
    public override double Evaluate(double leftValue, double rightValue)
    {
        return leftValue > rightValue ? leftValue - rightValue : 0;
    }
}

public class Multiply : NonConditionalBinaryExpression
{
    public Multiply(string left, string right, CardType type) : base(left, right, type)
    {

    }
    public override double Evaluate(double leftValue, double rightValue)
    {
        return leftValue * rightValue;
    }
}

public class Divide : NonConditionalBinaryExpression
{
    public Divide(string left, string right, CardType type) : base(left, right, type)
    {

    }
    public override double Evaluate(double leftValue, double rightValue)
    {
        if (rightValue == 0)
        {
            throw new Exception("You can't divide by 0.");
        }
        return leftValue / rightValue;
    }
}

public class Pow : NonConditionalBinaryExpression
{
    public Pow(string left, string right, CardType type) : base(left, right, type)//demasiados cambios en constructor
    {

    }
    public override double Evaluate(double leftValue, double rightValue)
    {
        return Math.Pow(leftValue, rightValue);
    }
}

public class Root : NonConditionalBinaryExpression
{
    public Root(string left, string right, CardType type) : base(left, right, type)
    {

    }
    public override double Evaluate(double leftValue, double rightValue)
    {
        if (leftValue < 0 && rightValue % 2 == 0)
        {
            throw new Exception($"You can't get the {rightValue} root of this number.");
        }
        return leftValue / rightValue;
    }
}

public class OnCard : IEvaluate
{
    public string Property { get; set; }
    public OnCard(string property, CardType type)
    {
        if ((property == "LifeTime" && type != CardType.Spell) || property == "HealthPoints" && type != CardType.Monster)
        {
            throw new Exception("Spells have LifeTime while Monsters have HealthPoints. You used a property that doesn't match the card's type.");
        }
        Property = property;
    }
    public double Evaluate(Card onCard, Card enemyCard)
    {
        switch (Property)
        {
            case "Damage":
                return onCard.Damage;
            case "HealthPoints":
                return (onCard as MonsterCard).HealthPoints;
            case "ManaCost":
                return onCard.ManaCost;
            case "LifeTime":
                return (onCard as SpellCard).LifeTime;
            case "Armour":
                return onCard.Armour;
            case "HealingPowers":
                return onCard.HealingPowers;
            default:
                throw new Exception("The property chosen in incorrect.");
        }
    }
}

public class EnemyCard : IEvaluate
{
    public string Property { get; set; }
    public EnemyCard(string property)
    {
        if (property == "LifeTime")
        {
            throw new Exception("Spells have LifeTime while Monsters have HealthPoints. You can not attack a card of type spell, therefore, enemy card can not have a lifeTime property.");
        }
        Property = property;
    }
    public double Evaluate(Card onCard, Card enemyCard)
    {
        switch (Property)
        {
            case "Damage":
                return enemyCard.Damage;
            case "HealthPoints":
                return (enemyCard as MonsterCard).HealthPoints;
            case "ManaCost":
                return enemyCard.ManaCost;
            case "Armour":
                return enemyCard.Armour;
            case "HealingPowers":
                return enemyCard.HealingPowers;
            default:
                throw new Exception("The property chosen in incorrect.");
        }
    }
}

public class OnPlayer : IEvaluate
{
    public string Property { get; set; }

    public OnPlayer(string property)
    {
        Property = property;
    }

    public double Evaluate(Card onCard, Card enemyCard)
    {
        switch (Property)
        {
            case "Health":
                return onCard.Owner.Health;
            case "Mana":
                return onCard.Owner.Mana;

            default:
                throw new Exception("This isn't a player's property");

        }
    }
}
public class EnemyPlayer : IEvaluate
{
    public string Property { get; set; }

    public EnemyPlayer(string property)
    {
        Property = property;
    }

    public double Evaluate(Card onCard, Card enemyCard)
    {
        switch (Property)
        {
            case "Health":
                return enemyCard.Owner.Health;
            case "Mana":
                return enemyCard.Owner.Mana;

            default:
                throw new Exception("This isn't a player's property");

        }
    }
}

public class Constant : IEvaluate
{
    public double Value;

    public Constant(double value)
    {
        Value = value; //puede ser Double.Parse(value).
    }
    public double Evaluate(Card onCard, Card enemyCard)
    {
        return Value;
    }
}
