using BattleCards.Cards;
using static System.Net.Mime.MediaTypeNames;
using System.Threading;
using static Utils.Utils;
using System.Data;
using System.ComponentModel;
using System.Reflection.Metadata.Ecma335;

namespace BattleCards;

public class CreateCard
{
    public static Card CardCreator(string[] text)//text viene de aplicarle Split('') a string inicial
    {
        string[] propertiesToSet = new string[Enum.GetNames(typeof(BasicCardProperties)).Length];
        int j = 0;
        for (int i = 1; i < text.Length-2; i += 2)
        {
            propertiesToSet[j++] = text[i].Remove(text[i].Length-1,1).Remove(0,1);
        }

        switch (propertiesToSet[1])
        {
            case "Monster":
                return new MonsterCard(propertiesToSet, Int32.Parse(text[text.Length - 1].Remove(text[text.Length - 1].Length-1,1).Remove(0,1)));
                
            case "Spell":
                return new SpellCard(propertiesToSet, Int32.Parse(text[text.Length - 1].Remove(text[text.Length - 1].Length-1,1).Remove(0,1)));
                


            default:
                throw new Exception("The card's type isn't valid.");

        }
    }

    public static void CardActionReceiver(Card card1, Card card2, string action)
    {
        //paso 1 evaluar la expresion booleana
        //paso 2 si es true evaluar la 2da si es false la tercera
        //paso 3 enviar double obtenido a metodo con el nombre
        switch (action)
        {
            case "Attack":
                Actions.Actions.Attack(card1,card2 as MonsterCard, card1.Attack.Evaluate(card1, card2));
                break;
            case "Heal":
                Actions.Actions.Heal(card1,card2 as MonsterCard, card1.Heal.Evaluate(card2, card1));
                break;
            default:
                throw new Exception("The action chosen was not correct.");
        }
    }
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
    
    public TernaryExpression(string ternaryExpression)
    {
        string[] SeparatedExpressions = Interpreter.SepareTernaryExpression(ternaryExpression,3);
        this.Condition = Interpreter.BuildExpression(SeparatedExpressions[0]);
        this.IfTrue = Interpreter.BuildExpression(SeparatedExpressions[1]);
        this.Else = Interpreter.BuildExpression(SeparatedExpressions[2]);
    }
    
  
    public override double Evaluate(Card onCard, Card enemyCard)
    {
        if (Condition.Evaluate(onCard, enemyCard) ==1)
        {
            return IfTrue.Evaluate( onCard, enemyCard);
        }
        return Else.Evaluate(onCard, enemyCard);
    }
}

public class Interpreter
{
    public static Expression BuildExpression(string expressionToBuild)
    {
        
        string[] leftAndRight = new string[3];
        switch (expressionToBuild[0])
        {
            case '>':
                
                leftAndRight = SepareTernaryExpression(expressionToBuild.Remove(0,2).Remove(expressionToBuild.Length-1), 2);
                return new HigherThanOperatorExpression(leftAndRight[0], leftAndRight[1]);// le pasas expressionToBuild quitando >(  y ) y separando en MI y MD
            case '<':
                
                leftAndRight = SepareTernaryExpression(expressionToBuild.Remove(expressionToBuild.Length-1).Remove(0,2), 2);
                return new LowerThanOperatorExpression(leftAndRight[0], leftAndRight[1]);
            case '=':
                
                leftAndRight = SepareTernaryExpression(expressionToBuild.Remove(expressionToBuild.Length-1).Remove(0,2), 2);
                return new EqualityOperatorExpression(leftAndRight[0], leftAndRight[1]);
            case '!':
                
                leftAndRight = SepareTernaryExpression(expressionToBuild.Remove(expressionToBuild.Length-1).Remove(0,2), 2);
                return new DifferentOperatorExpression(leftAndRight[0], leftAndRight[1]);
            case '(':
            if (expressionToBuild[1]=='t')
            {
                return new TrueExpression();
            }
            if (expressionToBuild[1]=='f')
            {
                return new FalseExpression();
            }
              double constantValue = 0;
                if (double.TryParse(expressionToBuild.TrimStart('(').TrimEnd(')'),out constantValue))
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
                leftAndRight = SepareTernaryExpression(expressionToBuild.Remove(expressionToBuild.Length-1).Remove(0,4), 2);
                return new Add(leftAndRight[0], leftAndRight[1]);
            case 'S':
                
                leftAndRight = SepareTernaryExpression(expressionToBuild.Remove(expressionToBuild.Length-1).Remove(0,10), 2);
                return new Substract(leftAndRight[0], leftAndRight[1]);
            case 'M':

                
                leftAndRight = SepareTernaryExpression(expressionToBuild.Remove(expressionToBuild.Length-1).Remove(0,9), 2);
                return new Multiply(leftAndRight[0], leftAndRight[1]);
            case 'D':

                
                leftAndRight = SepareTernaryExpression(expressionToBuild.Remove(expressionToBuild.Length-1).Remove(0,7), 2);
                return new Divide(leftAndRight[0], leftAndRight[1]);
            case 'P':

                
                leftAndRight = SepareTernaryExpression(expressionToBuild.Remove(expressionToBuild.Length-1).Remove(0,4), 2);
                return new Pow(leftAndRight[0], leftAndRight[1]);
            case 'R':

                
                leftAndRight = SepareTernaryExpression(expressionToBuild.Remove(expressionToBuild.Length-1).Remove(0,5), 2);
                return new Root(leftAndRight[0], leftAndRight[1]);
            case 'O':
                if (expressionToBuild[2]=='C')
                {
                    
                    return new OnCard(expressionToBuild.Remove(expressionToBuild.Length-1).Remove(0,7));
                }
                
                return new OnPlayer(expressionToBuild.Remove(expressionToBuild.Length-1).Remove(0,9));
            case 'E':
                if (expressionToBuild[5] == 'C')
                {
                    
                    return new EnemyCard(expressionToBuild.Remove(expressionToBuild.Length-1).Remove(0,10));
                }
                
                return new EnemyPlayer(expressionToBuild.Remove(expressionToBuild.Length-1).Remove(0,11));
            default:
                throw new Exception("The expression typed isn't correct.");
                
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
            answer[2] = GetString(ternaryExpression, endOfIfTrue+2, ternaryExpression.Length-1);
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

        
            for (int i = start+1; i < ternaryExpression.Length; i++)//empieza en 2 porque al ser expr ternaria el primer operador es >,<,! o =, luego viene el primer parentesis
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

public abstract class BinaryExpression : Expression
{
    public Expression Left { get; set; } // el operador no hace falta porque cuando se construye ya debe saber quien es
    public Expression Right { get; set; }

    public BinaryExpression(string left, string right)
    {
        this.Left = Interpreter.BuildExpression(left);
        this.Right = Interpreter.BuildExpression(right);
    }

    public override double Evaluate(Card onCard, Card enemyCard)
    {
        double leftValue = this.Left.Evaluate(onCard, enemyCard);
        double rightValue = this.Right.Evaluate(onCard, enemyCard);

        return this.Evaluate(leftValue, rightValue);
    }

    public abstract double Evaluate(double leftValue, double rightValue);
}

public class LowerThanOperatorExpression : BinaryExpression
{
    public LowerThanOperatorExpression(string left, string right) : base(left, right)
    {

    }

    public override double Evaluate(double leftValue, double rightValue)
    {
        return leftValue < rightValue ? 1 : 0;
    }
}

public class HigherThanOperatorExpression : BinaryExpression
{
    public HigherThanOperatorExpression(string left, string right) : base(left, right)
    {

    }

    public override double Evaluate(double leftValue, double rightValue)
    {
        return leftValue > rightValue ? 1 : 0;
    }
}

public class EqualityOperatorExpression : BinaryExpression
{
    public EqualityOperatorExpression(string left, string right) : base(left, right)
    {

    }

    public override double Evaluate(double leftValue, double rightValue)
    {
        return leftValue == rightValue ? 1 : 0;
    }
}
public class DifferentOperatorExpression : BinaryExpression
{
    public DifferentOperatorExpression(string left, string right) : base(left, right)
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
    public Add(string left, string right) : base(left, right)
    {

    }
    public override double Evaluate(double leftValue, double rightValue)
    {
        return leftValue + rightValue;
    }
}
public class Substract : BinaryExpression
{
    public Substract(string left, string right) : base(left, right)
    {

    }
    public override double Evaluate(double leftValue, double rightValue)
    {
        return leftValue - rightValue;
    }
}

public class Multiply: BinaryExpression
{
    public Multiply(string left, string right) : base(left, right)
    {

    }
    public override double Evaluate(double leftValue, double rightValue)
    {
        return leftValue * rightValue;
    }
}

public class Divide : BinaryExpression
{
    public Divide(string left, string right) : base(left, right)
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
    public Pow(string left, string right) : base(left, right)//agotadores cambios en constructor
    {

    }
    public override double Evaluate(double leftValue, double rightValue)
    {
        return Math.Pow(leftValue,rightValue);
    }
}

public class Root : BinaryExpression
{
    public Root(string left, string right) : base(left, right)
    {

    }
    public override double Evaluate(double leftValue, double rightValue)
    {
        if (leftValue < 0 && (rightValue%2 == 0))
        {
            throw new Exception($"You can't get the {rightValue} root of this number.");
        }
        return leftValue / rightValue;
    }
}

public class OnCard:Expression
{
    public string Property { get; set; }
   public OnCard(string property)
    {
        this.Property = property;
    }
    public override double Evaluate(Card onCard, Card enemyCard)
    {
        switch (this.Property)
        {
            case "Damage":
                return onCard.DamagePoints;
            case "Health":
                if (onCard.Type != CardType.Monster)
                {
                    throw new Exception("This type of card doesn't have a Health value.Only monsters have health.");
                }
                return (onCard as MonsterCard).HealthPoints;
            case "ManaCost":
                return onCard.ManaCost;
            case "LifeTime":
                if (onCard.Type != CardType.Spell)
                {
                    throw new Exception("This type of card doesn't have a Lifetime value.Only SpellCards have a lifetime.");
                }
                return (onCard as SpellCard).LifeTime;
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
        this.Property = property;
    }
    public override double Evaluate(Card onCard, Card enemyCard)
    {
        switch (this.Property)
        {
            case "Damage":
                return enemyCard.DamagePoints;
            case "Health":
                if (enemyCard.Type != CardType.Monster)
                {
                    throw new Exception("This type of card doesn't have a Health value.Only monsters have health.");
                }
                return (enemyCard as MonsterCard).HealthPoints;
            case "ManaCost":
                return enemyCard.ManaCost;
            case "LifeTime":
                if (enemyCard.Type != CardType.Spell)
                {
                    throw new Exception("This type of card doesn't have a Lifetime value.Only SpellCards have a lifetime.");
                }
                return (enemyCard as SpellCard).LifeTime;
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
        this.Property = property;
    }

    public override double Evaluate(Card onCard, Card enemyCard)
    {
        switch (this.Property)
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
        this.Property = property;
    }

    public override double Evaluate(Card onCard, Card enemyCard)
    {
        switch (this.Property)
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

public class Constant: Expression
    {
        public double Value;   

        public Constant(double value)
        {
            this.Value = value; //puede ser Double.Parse(value).
        }
        public override double Evaluate(Card onCard, Card enemyCard)
        {
            return this.Value;
        }
    }

