using RockPaperScissors;

Run(args);

static void Run(string[] args)
{
    if (!CheckArgs(args))
    {
        return;
    }

    var key = RandomGenerator.Generate();

    var computerMove = ComputerMoveGenerator(args);

    var hmac = HmacEncryption.Encrypt(key, computerMove);

    Menu(args, hmac, computerMove, key);    
}

static string ComputerMoveGenerator(string[] args){

    var randomMove = new Random(Environment.TickCount);

    var move = randomMove.Next(0, args.Length);
    
    return args[move];
}

static bool CheckArgs(string[] args)
{
    if (args.Length < 3)
    {
        Console.WriteLine("The number of arguments must be greater than or equal to three.");

        return false;   
    }

    if ((args.Length % 2) == 0)
    {
        Console.WriteLine("The number of arguments must be odd.");

        return false;
    }

    if (ContainNoRepitions(args))
    {
        Console.WriteLine("Arguments should not contain repeatable values.");

        return false;
    }

    return true;
}

static bool ContainNoRepitions(string[] args)
{
    return args.Length != args.Distinct().ToArray().Length; 
}

static void Menu(string[] args, string hmac, string computerMove, string key)
{
    var menuFlag = true;

    while(menuFlag)
    {
        Console.WriteLine("HMAC: " + hmac);
        Console.WriteLine("Available moves:");

        var argCounter = 0;

        foreach (string arg in args)
        {
            Console.WriteLine(++argCounter + " - " + arg);
        }

        Console.WriteLine("0" + " - Exit");
        Console.WriteLine("?" + " - Help");
        Console.WriteLine();

        Console.Write("Enter your move: ");
        var userInput = Console.ReadLine();

        var isNumber = Int32.TryParse(userInput, out int userInputInt);

        if (userInput == "0")
        {
            menuFlag = false;
        }
        else if (userInput == "?")
        {
            Console.WriteLine();
            GenerateHelpTable.CreateTable(args);
            Console.WriteLine();
        }
        else if ( isNumber && (userInputInt >= 1 && userInputInt <= argCounter) )
        {
            var gameWinner = GetGameWinner.GetWinner(computerMove, userInputInt, args);

            Console.WriteLine("Your move: " + args[--userInputInt]);
            Console.WriteLine("Computer move: " + computerMove);          
            Console.WriteLine(gameWinner);
            Console.WriteLine("HMAC key: " + key);

            menuFlag = false;
        }
        else
        {
            Console.WriteLine("Enter correct number");
            Console.WriteLine();
        }
    }
}