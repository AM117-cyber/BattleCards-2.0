using BattleCards;

Console.WriteLine("Welcome to Wizarding World Trading Card Game!!!");
for (int i = 0; i < 5; i++)
{
    System.Console.WriteLine();
}
Console.WriteLine("Please select a playing mode:");
System.Console.WriteLine("Type '1' to play PvP and then press ENTER");
System.Console.WriteLine("Type '2' to play PvPC and then press ENTER");
string answer = Console.ReadLine();
string name1;
string name2;
Player player1;
Player player2;
switch (answer)
{
    case "1":
        Console.Write("Player1 please insert your name");
        Console.WriteLine();
        name1 = Console.ReadLine();
        player1 = new Player(name1);
        Console.Write("Player2 please insert your name");
        Console.WriteLine();
        name2 = Console.ReadLine();
        player2 = new Player(name2);    //Add a function to go back in case the user wants to change the name

        Console.Clear();
        break;

    case "2":
        Console.Write("Player1 please insert your name");
        Console.WriteLine();
        name1 = Console.ReadLine();
        player1 = new Player(name1);
        System.Console.WriteLine("Select a virtual player");
        Console.WriteLine("Type 1 for Seamus");
        Console.WriteLine("Type 2 for Dean");
        name2 = Console.ReadLine();
        if (name2 == "1") name2 = "Seamus-Virtual";   //Add while in case user types wrong
        if (name2 == "2") name2 = "Dean-Virtual";
        else Console.WriteLine("You typed wrong. Try again");
        player2 = new Player(name2);

        Console.Clear();
        break;

    default:
        System.Console.Write("You typed a wrong answer. Type again: ");
        break;
}

Console.WriteLine("Please select your deck");
Console.WriteLine("Type 1 to select your previous deck");