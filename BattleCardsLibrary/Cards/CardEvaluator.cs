using static System.Net.Mime.MediaTypeNames;
using System.Threading;
using static Utils.Utils;
using BattleCards;

namespace BattleCards.Cards;

public class CreateCard
{
    public static Card CardCreator(string[] text)//text viene de aplicarle Split('') a string inicial
    {
        if ((text.Length % 2) != 0)
        {
            throw new Exception("Syntax error, there isn't a value for every property.");
        }
        string cardType = text[1].TrimEnd();
        if (cardType != "Monster" && cardType != "Spell")
        {
            throw new Exception("You must insert a valid card type.");
        }
        Dictionary<AllCardProperties, string> CardProperties = SetDefaultValuesInSpecificDict(cardType);

        //Enum.GetNames(typeof(AllCardProperties)).Length];
        //text[i].Remove(text[i].Length - 1, 1).Remove(0, 1);
        for (int i = 2; i < text.Length - 1; i++)
        {
            if (text[i] == null)
            {
                continue;
            }
            bool propertyIsValid = false;
            foreach (var property in (Enum.GetValues(typeof(AllCardProperties))).Cast<AllCardProperties>())
            {
                string item = property.ToString();
                if (text[i].TrimEnd() == item)
                {
                    if ((item == "HealthPoints" && CardProperties[AllCardProperties.Type] != "Monster") || (item == "LifeTime" && CardProperties[AllCardProperties.Type] != "Spell"))
                    {
                        throw new Exception("Health parameter is only for monsters and lifetime parameter is only for spells.They are not exchangable.");
                    }
                    if (item == "Defend" && CardProperties[AllCardProperties.Type] != "Monster")
                    {
                        throw new Exception("Spells' value to increase a card's defense can only be expressed as a constant value in this version.");
                    }
                    //if it doesn't throw Exception the property is valid hence, you add it to dictionary.
                    CardProperties[property] = text[i + 1].TrimEnd();
                    if (item != "Name")
                    {
                        CardProperties[property] = CardProperties[property].Replace(" ", "");
                    }
                    propertyIsValid = true;
                    break;
                }
            }
            if (!propertyIsValid)
            {
                throw new Exception("You typed an invalid property.");
            }
            i++;
        }//dictionary's been filled with values given from user
        if (!CardProperties.ContainsKey(AllCardProperties.Name))
        {
            throw new Exception("All cards must have a name.");
        }


        switch (cardType)
        {
            case "Monster":
                return new MonsterCard(CardProperties);
            default:
                return new SpellCard(CardProperties);//because if the card type weren't valid an exception would have been thrown at the top.
        }

    }
    public static Dictionary<AllCardProperties, string> SetDefaultValuesInSpecificDict(string cardType)
    {
        Dictionary<AllCardProperties, string> dictToReturn = new Dictionary<AllCardProperties, string>();
        dictToReturn[AllCardProperties.Type] = cardType;
        dictToReturn[AllCardProperties.ManaCost] = "5";
        dictToReturn[AllCardProperties.Damage] = cardType == "Monster" ? "50" : "0";
        dictToReturn[AllCardProperties.Armour] = cardType == "Monster" ? "10" : "0";//las cartas magicas nunca van a tener este parametro
        dictToReturn[AllCardProperties.HealthPoints] = "100";
        dictToReturn[AllCardProperties.LifeTime] = "1";
        dictToReturn[AllCardProperties.HealingPowers] = cardType == "Monster" ? "0" : "50";

        return dictToReturn;

    }

    public static void CardActionReceiver(Card card1, Card card2, string action)
    {
        switch (action)
        {
            case "Attack":
                ExecuteActions.ExecuteAction.Attack(card1, card2 as MonsterCard, card1.Attack.Evaluate(card1, card2));
                break;
            case "Heal":
                ExecuteActions.ExecuteAction.Heal(card1, card2 as MonsterCard, card1.Heal.Evaluate(card2, card1));
                break;
            default:
                throw new Exception("The action chosen was not correct.");
        }
    }
    /*public static void CardActionReceiver(ActionReceiver actionReceiver)
    {
        //paso 1 evaluar la expresion booleana
        //paso 2 si es true evaluar la 2da si es false la tercera
        //paso 3 enviar double obtenido a metodo con el nombre
        switch (action)
        {
            case ActionType.Attack:
                Actions.Actions.Attack(card1, card2 as MonsterCard, card1.Attack.Evaluate(card1, card2));
                break;
            case ActionType.Heal:
                Actions.Actions.Heal(card1, card2 as MonsterCard, card1.Heal.Evaluate(card2, card1));
                break;
            default:
                throw new Exception("The action chosen was not correct.");
        }
    }*/
}

public abstract class Expression
{
    public abstract double Evaluate(Card onCard, Card enemyCard);
}

public class TernaryExpression : Expression
{
    public Expression Condition { get; set; }
    public Expression IfTrue { get; set; }
    public Expression Else { get; set; }

    public TernaryExpression(string ternaryExpression, CardType type)
    {
        string[] SeparatedExpressions = Interpreter.SepareTernaryExpression(ternaryExpression, 3);
        Condition = Interpreter.BuildConditionalExpression(SeparatedExpressions[0], type);
        IfTrue = Interpreter.BuildExpression(SeparatedExpressions[1], type);
        Else = Interpreter.BuildExpression(SeparatedExpressions[2], type);
    }


    public override double Evaluate(Card onCard, Card enemyCard)
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

    public static Expression BuildExpression(string expressionToBuild, CardType typeOfCard)
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
    public static Expression BuildConditionalExpression(string expressionToBuild, CardType typeOfCard)
    {
        string[] leftAndRight = new string[3];
        string @operator = string.Empty;
        int opBuilder = GetParenthesiStart(0, expressionToBuild) - 1;
        @operator = GetString(expressionToBuild, 0, opBuilder);
        if (@operator != "") leftAndRight = SepareTernaryExpression(expressionToBuild.Remove(expressionToBuild.Length - 1).Remove(0, opBuilder + 2), 2);
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
            case "":
                if (expressionToBuild[1] == 't')//check it is true
                {
                    return new TrueExpression();
                }
                if (expressionToBuild[1] == 'f')
                {
                    return new FalseExpression();
                }
                throw new Exception("You typed an invalid condition.");
            default:
                throw new Exception("You typed an invalid condition.");
        }
    }
    /*public static Expression BuildExpression(string expressionToBuild)
    {

        string[] leftAndRight = new string[3];
        switch (expressionToBuild[0])
        {
            case '>':

                leftAndRight = SepareTernaryExpression(expressionToBuild.Remove(expressionToBuild.Length - 1).Remove(0, 2), 2);
                return new HigherThanOperatorExpression(leftAndRight[0], leftAndRight[1]);// le pasas expressionToBuild quitando >(  y ) y separando en MI y MD
            case '<':

                leftAndRight = SepareTernaryExpression(expressionToBuild.Remove(expressionToBuild.Length - 1).Remove(0, 2), 2);
                return new LowerThanOperatorExpression(leftAndRight[0], leftAndRight[1]);
            case '=':

                leftAndRight = SepareTernaryExpression(expressionToBuild.Remove(expressionToBuild.Length - 1).Remove(0, 2), 2);
                return new EqualityOperatorExpression(leftAndRight[0], leftAndRight[1]);
            case '!':

                leftAndRight = SepareTernaryExpression(expressionToBuild.Remove(expressionToBuild.Length - 1).Remove(0, 2), 2);
                return new DifferentOperatorExpression(leftAndRight[0], leftAndRight[1]);
            case '(':
                if (expressionToBuild[1] == 't')
                {
                    return new TrueExpression();
                }
                if (expressionToBuild[1] == 'f')
                {
                    return new FalseExpression();
                }
                double constantValue = 0;
                if (double.TryParse(expressionToBuild.TrimStart('(').TrimEnd(')'), out constantValue))
                {
                    return new Constant(constantValue);
                }
                if (expressionToBuild == "()")
                {
                    return new Constant(0);
                }
                throw new Exception("The expression typed isn't correct.");
            case 'A':
                //revisar que pasa con true al principio
                leftAndRight = SepareTernaryExpression(expressionToBuild.Remove(expressionToBuild.Length - 1).Remove(0, 4), 2);
                return new Add(leftAndRight[0], leftAndRight[1]);
            case 'S':

                leftAndRight = SepareTernaryExpression(expressionToBuild.Remove(expressionToBuild.Length - 1).Remove(0, 10), 2);
                return new Substract(leftAndRight[0], leftAndRight[1]);
            case 'M':


                leftAndRight = SepareTernaryExpression(expressionToBuild.Remove(expressionToBuild.Length - 1).Remove(0, 9), 2);
                return new Multiply(leftAndRight[0], leftAndRight[1]);
            case 'D':


                leftAndRight = SepareTernaryExpression(expressionToBuild.Remove(expressionToBuild.Length - 1).Remove(0, 7), 2);
                return new Divide(leftAndRight[0], leftAndRight[1]);
            case 'P':


                leftAndRight = SepareTernaryExpression(expressionToBuild.Remove(expressionToBuild.Length - 1).Remove(0, 4), 2);
                return new Pow(leftAndRight[0], leftAndRight[1]);
            case 'R':


                leftAndRight = SepareTernaryExpression(expressionToBuild.Remove(expressionToBuild.Length - 1).Remove(0, 5), 2);
                return new Root(leftAndRight[0], leftAndRight[1]);
            case 'O':
                if (expressionToBuild[2] == 'C')
                {

                    return new OnCard(expressionToBuild.Remove(expressionToBuild.Length - 1).Remove(0, 7));
                }

                return new OnPlayer(expressionToBuild.Remove(expressionToBuild.Length - 1).Remove(0, 9));
            case 'E':
                if (expressionToBuild[5] == 'C')
                {

                    return new EnemyCard(expressionToBuild.Remove(expressionToBuild.Length - 1).Remove(0, 10));
                }

                return new EnemyPlayer(expressionToBuild.Remove(expressionToBuild.Length - 1).Remove(0, 11));
            default:
                throw new Exception("The expression typed isn't correct.");

        }
    }*/

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

public interface IEvaluate
{

}
public abstract class BinaryExpression : Expression
{
    public Expression Left { get; set; } // el operador no hace falta porque cuando se construye ya debe saber quien es
    public Expression Right { get; set; }

    public BinaryExpression(string left, string right, CardType type)
    {
        Left = Interpreter.BuildExpression(left, type);
        Right = Interpreter.BuildExpression(right, type);
    }

    public override double Evaluate(Card onCard, Card enemyCard)//
    {
        double leftValue = Left.Evaluate(onCard, enemyCard);
        double rightValue = Right.Evaluate(onCard, enemyCard);

        return Evaluate(leftValue, rightValue);
    }

    public abstract double Evaluate(double leftValue, double rightValue);//
}

public class AndExpression : Expression
{
    public Expression Left { get; set; }
    public Expression Right { get; set; }
    public AndExpression(string left, string right, CardType type)
    {
        Left = Interpreter.BuildConditionalExpression(left, type);
        Right = Interpreter.BuildConditionalExpression(right, type);
    }
    public override double Evaluate(Card onCard, Card enemyCard)
    {

        double leftValue = Left.Evaluate(onCard, enemyCard);
        double rightValue = Right.Evaluate(onCard, enemyCard);

        return Evaluate(leftValue, rightValue);
    }
    public double Evaluate(double leftValue, double rightValue)
    {
        return (leftValue == 1 && rightValue == 1) ? 1 : 0;
    }
}
public class OrExpression : Expression
{
    public Expression Left { get; set; }
    public Expression Right { get; set; }
    public OrExpression(string left, string right, CardType type)
    {
        Left = Interpreter.BuildConditionalExpression(left, type);
        Right = Interpreter.BuildConditionalExpression(right, type);
    }
    public override double Evaluate(Card onCard, Card enemyCard)//
    {
        double leftValue = Left.Evaluate(onCard, enemyCard);
        double rightValue = Right.Evaluate(onCard, enemyCard);

        return Evaluate(leftValue, rightValue);
    }
    public double Evaluate(double leftValue, double rightValue)
    {
        return (leftValue == 1 || rightValue == 1) ? 1 : 0;
    }
}
public class LowerThanOperatorExpression : BinaryExpression
{
    public LowerThanOperatorExpression(string left, string right, CardType type ) : base(left, right, type)
    {

    }

    public override double Evaluate(double leftValue, double rightValue)
    {
        return leftValue < rightValue ? 1 : 0;
    }
}

public class HigherThanOperatorExpression : BinaryExpression
{
    public HigherThanOperatorExpression(string left, string right, CardType type) : base(left, right, type)
    {

    }

    public override double Evaluate(double leftValue, double rightValue)
    {
        return leftValue > rightValue ? 1 : 0;
    }
}

public class EqualityOperatorExpression : BinaryExpression
{
    public EqualityOperatorExpression(string left, string right, CardType type) : base(left, right, type)
    {

    }

    public override double Evaluate(double leftValue, double rightValue)
    {
        return leftValue == rightValue ? 1 : 0;
    }
}
public class DifferentOperatorExpression : BinaryExpression
{
    public DifferentOperatorExpression(string left, string right, CardType type) : base(left, right, type)
    {

    }

    public override double Evaluate(double leftValue, double rightValue)
    {
        return leftValue != rightValue ? 1 : 0;
    }
}

public class TrueExpression : Expression
{
    public override double Evaluate(Card onCard, Card enemyCard)
    {
        return 1;
    }
}

public class FalseExpression : Expression
{
    public override double Evaluate(Card onCard, Card enemyCard)
    {
        return 0;
    }
}

public class Add : BinaryExpression
{
    public Add(string left, string right, CardType type) : base(left, right, type)
    {

    }
    public override double Evaluate(double leftValue, double rightValue)
    {
        return leftValue + rightValue;
    }
}
public class Substract : BinaryExpression
{
    public Substract(string left, string right, CardType type) : base(left, right, type)
    {

    }
    public override double Evaluate(double leftValue, double rightValue)
    {
        return leftValue>rightValue?leftValue - rightValue: 0;
    }
}

public class Multiply : BinaryExpression
{
    public Multiply(string left, string right, CardType type) : base(left, right, type)
    {

    }
    public override double Evaluate(double leftValue, double rightValue)
    {
        return leftValue * rightValue;
    }
}

public class Divide : BinaryExpression
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

public class Pow : BinaryExpression
{
    public Pow(string left, string right, CardType type) : base(left, right, type)//demasiados cambios en constructor
    {

    }
    public override double Evaluate(double leftValue, double rightValue)
    {
        return Math.Pow(leftValue, rightValue);
    }
}

public class Root : BinaryExpression
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

public class OnCard : Expression
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
    public override double Evaluate(Card onCard, Card enemyCard)
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

public class EnemyCard : Expression
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
    public override double Evaluate(Card onCard, Card enemyCard)
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

public class OnPlayer : Expression
{
    public string Property { get; set; }

    public OnPlayer(string property)
    {
        Property = property;
    }

    public override double Evaluate(Card onCard, Card enemyCard)
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
public class EnemyPlayer : Expression
{
    public string Property { get; set; }

    public EnemyPlayer(string property)
    {
        Property = property;
    }

    public override double Evaluate(Card onCard, Card enemyCard)
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

public class Constant : Expression
{
    public double Value;

    public Constant(double value)
    {
        Value = value; //puede ser Double.Parse(value).
    }
    public override double Evaluate(Card onCard, Card enemyCard)
    {
        return Value;
    }
}



/*public static void CardActionReceiver(ActionReceiver actionReceiver)
{
    //paso 1 evaluar la expresion booleana
    //paso 2 si es true evaluar la 2da si es false la tercera
    //paso 3 enviar double obtenido a metodo con el nombre
    //switch (action)
    //{
    //    case ActionType.Attack:
    //        Actions.Actions.Attack(card1, card2 as MonsterCard, card1.Attack.Evaluate(card1, card2));
    //        break;
    //    case ActionType.Heal:
    //        Actions.Actions.Heal(card1, card2 as MonsterCard, card1.Heal.Evaluate(card2, card1));
    //        break;
    //    default:
    //        throw new Exception("The action chosen was not correct.");
    //}
}*/