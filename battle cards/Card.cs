namespace BattleCards.Cards;
using  Utils;

public abstract class Card
{   
    public double ManaCost { get; set; }    
    public Utils.CardType Type {get; set;}
    public Player Owner { get; set; }
    public string Name {get; set;}
    public List<Utils.CardType> TargetTypes {get; set;}
    public double DamagePoints {get; private set;}

    public Expression Attack { get; set;}   //lo que se guarda aqui es una TernaryExpression que cuando se evalua devuelve double
    public Expression Heal { get; set;}  //heal se pueden hacer separadas despues en dependencia de la prop, improve health seria heal por ejemplo
    //public string Deffend { get; set;}  // protected de algun tipo? no quiero que salga entre opciones de carta para jugador podria hacerse con if !=
    public Expression Deffend { get; set;}  
    
    public Card(string[] basicProperties)
    {
        this.ManaCost = Double.Parse(basicProperties[0]);
        this.Owner = null;
        this.Name = basicProperties[2];
        this.DamagePoints = Double.Parse(basicProperties[4]);
        this.Attack = new TernaryExpression(basicProperties[5]);//llega la expresion sin () en extremos, despues de Trim
        this.Heal = new TernaryExpression(basicProperties[6]);
        this.Deffend =  new TernaryExpression(basicProperties[7]);
    }
    
}