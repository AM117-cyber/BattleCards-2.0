using BattleCards;
using System.Text;
using System.Text.RegularExpressions;

string[] paths = Directory.GetFiles(@"C:\Users\Melissa\Desktop\TestingLanguage\CardLibrary");
/*foreach (var path in paths)
{
    string text = File.ReadAllText(path);
    string[] txt = text.Split(' ');
    BattleCards.Cards.Card card = CreateCard.CardCreator(txt);
}*/
BattleCards.Cards.Card card = CreateCard.CardCreator(File.ReadAllText(paths[0]).Split(' '));
System.Console.WriteLine(card.DamagePoints);
System.Console.WriteLine(card.ManaCost);
System.Console.WriteLine(card.Owner);
System.Console.WriteLine((card as BattleCards.Cards.MonsterCard).OnGameHealth);
System.Console.WriteLine((card as BattleCards.Cards.MonsterCard).HealthPoints);
BattleCards.CreateCard.CardActionReceiver(card,card,"Attack");// if you type attack and throw exception the game stops
System.Console.WriteLine((card as BattleCards.Cards.MonsterCard).OnGameHealth);

System.Console.WriteLine((card as BattleCards.Cards.MonsterCard).HealthPoints);