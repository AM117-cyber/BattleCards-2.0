using BattleCards.Cards;
using static System.Net.Mime.MediaTypeNames;
using System.Threading;
using static Utils.Utils;
using System.Data;
using System.ComponentModel;

namespace BattleCards;

public class CreateCard
{


    public static string textOfCard = "";
    // lo crearia y luego lo leo o eso se hace a la misma vez?

    //assuming you have properties of cards already set

    public void CardCreator(string[] text)//text viene de aplicarle Split('') a string inicial
    {
        string[] propertiesToSet = new string[Enum.GetNames(typeof(BasicCardProperties)).Length];
        for (int i = 1; i < propertiesToSet.Length; i += 2)
        {
            propertiesToSet[i].TrimStart('(').TrimEnd(')');
        }

        switch (text[3])
        {
            case "Monster":
                new MonsterCard(propertiesToSet, Int32.Parse(text[text.Length - 1]));
                break;
            case "Spell":
                new SpellCard(propertiesToSet, Int32.Parse(text[text.Length - 1]));
                break;


            default:
                throw new Exception("The card's type isn't valid.");

        }
    }

    public void CardActionReceiver(Card card1, Card card2, string action)
    {
        double answer = 0;
        //paso 1 evaluar la expresion booleana
        //paso 2 si es true evaluar la 2da si es false la tercera
        //paso 3 enviar double obtenido a metodo con el nombre
        switch (action)
        {
            case "Attack":
                var attack = new TernaryExpression(card1.Attack, card1, card2);
                answer = attack.Evaluate(); //metodo que evalua una terna, dentro de el se evalua booleana y se ve el if para la 2da o tercera, llama a otro que procesa parentesis. 
                Actions.Actions.Attack(card2, answer);
                break;
            case "Heal":
                var heal = new TernaryExpression(card1.Heal, card1, card2);
                answer = heal.Evaluate();
                Actions.Actions.Heal(card2, answer);
                break;
            default:
                throw new Exception("The action chosen was not correct.");
        }
    }
}

public class Interpreter
{
    public static string[] SeparateTernaryExpression(string expressionAsString)
    {
        expressionAsString = expressionAsString.TrimEnd(')').TrimStart('(');//sabemos que la expresion es ternaria,por lo tanto, usamos SeparateTernaryExpression
        Enum.GetValues(typeof(Operators));
        for (int i = 1; i < expressionAsString.Length; i++)
        {

        }
    }
    public static Expression BuildExpression(string expressionAsString, Card onCard, Card enemyCard)//aqui llega el string con parentesis en extremos
    {
        
        switch (expressionAsString[0])
        {
            case '<':
                return new LowerThanOperatorExpression();
            default:
                break;
        }
        return new TrueExpression();
    }
}
    public abstract class Expression
    {
        public abstract double Evaluate();
    }

    public class TernaryExpression : Expression
    {
        public bool BooleanExpr{ get; set; }
        public Expression IfTrue { get; set; }
        public Expression Else { get; set; }

        public TernaryExpression(string[] ternaryExpression, Card onCard, Card enemyCard)
        {
        
        if (Interpreter.BuildExpression(ternaryExpression[0],onCard, enemyCard).Evaluate() == 1)
        {
            case "true":
                this.BooleanExpr = true;
                break;
            case "false":
                this.BooleanExpr = false;//crear una expresion de cada tipo posible y construirla por el switch, una vez construida ya sabe cual es su Evaluate
                break;

            default:
                this.BooleanExpr = SeparatedExpressions[0].Evaluate()==1? true:false;//el evaluate de booleanexpressions devuelve 1 si son verdaderas 
                break;
        }
        this.IfTrue = SeparatedExpressions[1]; 
        this.Else = SeparatedExpressions[2];

        }

    public override double Evaluate()
    {   
        if (BooleanExpr)
        {
            return this.IfTrue.Evaluate();
        }
        return this.Else.Evaluate();
    }
}


public abstract class BinaryExpression : Expression
{
    public Expression Left { get; set; } // el operador no hace falta porque cuando se construye ya debe saber quien es
    public Expression Right { get; set; }

    public BinaryExpression(string left, string right)
    {
        this.Left = BuildExpression(left);
        this.Right = BuildExpression(right);
    }

    public override double Evaluate()
    {
        double leftValue = this.Left.Evaluate();
        double rightValue = this.Right.Evaluate();

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

public class HigherOperatorExpression : BinaryExpression
{
    public HigherOperatorExpression(string left, string right) : base(left, right)
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

public class TrueExpression : Expression
{
    public override double Evaluate()
    {
        return 1;
    }
}

public class FalseExpression : Expression
{
    public override double Evaluate()
    {
        return 0;
    }
}

public class Sum : BinaryExpression
{
    public Sum(string left, string right) : base(left, right)
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

public class OnCardOrEnemyCard:Expression
{
    public Card CurrentCard { get; set; }
    public string Property { get; set; }
   public OnCardOrEnemyCard(Card currentCard, string property)
    {
        this.CurrentCard = currentCard;
        this.Property = property;
    }
    public override double Evaluate()
    {
        switch (this.Property)
        {
            case "Damage":
                return this.CurrentCard.DamagePoints;
            case "Health":
                if (this.CurrentCard.Type != CardType.Monster)
                {
                    throw new Exception("This type of card doesn't have a Health value.Only monsters have health.");
                }
                return (this.CurrentCard as MonsterCard).HealthPoints;
            case "ManaCost":
                return this.CurrentCard.ManaCost;
            case "LifeTime":
                if (this.CurrentCard.Type != CardType.Spell)
                {
                    throw new Exception("This type of card doesn't have a Lifetime value.Only SpellCards have a lifetime.");
                }
                return (this.CurrentCard as SpellCard).LifeTime;
            default:
                throw new Exception("The property chosen in incorrect.");
        }

    }
}

public class OnPlayerOrEnemyPlayer : Expression
{
    public Card OnCard { get; set; }   
    public string Property { get; set; }

    public OnPlayerOrEnemyPlayer(Card onCard, string property)
    {
        this.OnCard = onCard;
        this.Property = property;
    }

    public override double Evaluate()
    {
        switch (this.Property)
        {
            case "Health":
                return this.OnCard.Owner.Health;
            case "Mana":
                return this.OnCard.Owner.Mana;

            default:
                throw new Exception("This isn't a player's property");
             
        }
    }

    public class Constant: Expression
    {
        public double Value;   

        public Constant(double value)
        {
            this.Value = value; //puede ser Double.Parse(value).
        }
        public override double Evaluate()
        {
            return this.Value;
        }
    }
}



/*if (EvaluateBoolExp(booleanPartOfAttack))
{

}

public bool EvaluateBoolExp(string booleanPartOfAttack)
{
    switch (booleanPartOfAttack[0])// seleccionando entre tipos 
    {
        case '<':
            return lessComparator(booleanPartOfAttack.Remove(0, 0)).Evaluate;

        case '>':
            return moreComparator(booleanPartOfAttack.Remove(0, 0)).Evaluate;

        case '=':
            return equalityComparer(booleanPartOfAttack.Remove(0, 0)).Evaluate;

        case '!':
            return differetComparer(booleanPartOfAttack.Remove(0, 0)).Evaluate;

        default:
            throw new Exception("El primer elemento de terna debe ser una expresion booleana.");  
    }
}
public abstract class Expression
{

    public abstract double EvaluateExpression(string expression);

}
public abstract class UnaryExpression : Expression
{
    protected readonly Expression inner;

    public UnaryExpression(Expression inner)
    {
        this.inner = inner;
    }

    public override double Evaluate()
    {
        return this.Evaluate(this.inner.Evaluate());
    }

    protected abstract double Evaluate(double inner);
}
}*/




















/*public abstract class BinaryExpression : Expression
{
     Expression left;
     Expression right;

    public BinaryExpression(Expression left, Expression right)
    {
        this.left = left;
        this.right = right;
    }

    public override double Evaluate()
    {
        double leftValue = this.left.Evaluate();
        double rightValue = this.right.Evaluate();

        return this.Evaluate(leftValue, rightValue);
    }

    protected abstract double Evaluate(double left, double right);
}

public class Add : BinaryExpression
{
    public Add(Expression left, Expression right) : base(left, right)
    {

    }

    protected override double Evaluate(double left, double right)
    {
        return left + right;
    }

    public override string ToString()
    {
        return $"({left.ToString()}) + ({right.ToString()})";
    }
}

public class Subtract : BinaryExpression
{
    public Subtract(Expression left, Expression right) : base(left, right)
    {

    }

    protected override double Evaluate(double left, double right)
    {
        return left - right;
    }

    public override string ToString()
    {
        return $"({left.ToString()}) - ({right.ToString()})";
    }
}

public class Multiply : BinaryExpression
{
    public Multiply(Expression left, Expression right) : base(left, right)
    {

    }

    protected override double Evaluate(double left, double right)
    {
        return left * right;
    }

    public override string ToString()
    {
        return $"({left.ToString()}) * ({right.ToString()})";
    }
}

public class Divide : BinaryExpression
{
    public Divide(Expression left, Expression right) : base(left, right)
    {

    }

    protected override double Evaluate(double left, double right)
    {
        return left / right;
    }

    public override string ToString()
    {

        return $"({left.ToString()}) / ({right.ToString()})";
    }
}

public class Pow : BinaryExpression
{
    public Pow(Expression left, Expression right) : base(left, right)
    {

    }

    protected override double Evaluate(double left, double right)
    {
        return Math.Pow(left, right);
    }

    public override string ToString()
    {
        return $"({left.ToString()}) ^ ({right.ToString()})";
    }
}

public abstract class UnaryExpression : Expression
{
    protected readonly Expression inner;

    public UnaryExpression(Expression inner)
    {
        this.inner = inner;
    }

    public override double Evaluate()
    {
        return this.Evaluate(this.inner.Evaluate());
    }

    protected abstract double Evaluate(double inner);
}

public class Exp : UnaryExpression
{
    public Exp(Expression inner) : base(inner)
    {

    }

    protected override double Evaluate(double inner)
    {
        return Math.Exp(inner);
    }

    public override string ToString()
    {
        return $"e^({inner.ToString()})";
    }
}

public class Sin : UnaryExpression
{
    public Sin(Expression inner) : base(inner)
    {

    }

    protected override double Evaluate(double inner)
    {
        return Math.Sin(inner);
    }

    public override string ToString()
    {
        return $"sin({inner.ToString()})";
    }
}

public class Cos : UnaryExpression
{
    public Cos(Expression inner) : base(inner)
    {

    }

    protected override double Evaluate(double inner)
    {
        return Math.Cos(inner);
    }

    public override string ToString()
    {
        return $"cos({inner.ToString()})";
    }
}

public class Constant : Expression
{
    double value;

    public Constant(double value)
    {
        this.value = value;
    }

    public override string ToString()
    {
        return value.ToString();
    }

    public override double Evaluate()
    {
        return this.value;
    }
}*/