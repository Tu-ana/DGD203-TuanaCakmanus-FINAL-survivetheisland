public class Game
{
    private Player player;
    private string[,] grid;
    private int playerX;
    private int playerY;
    private int deltaX;
    private int deltaY;
    private bool isConsoleAvailable;

#pragma warning disable CS8618
    public Game()
#pragma warning restore CS8618
    {
        InitializeConsole();
        ShowMainMenu();
    }

    private void InitializeConsole()
    {
        try
        {
            var windowHeight = Console.WindowHeight;
            isConsoleAvailable = true;
        }
        catch
        {
            isConsoleAvailable = false;
            Console.WriteLine("Warning: Running in limited console mode");
        }
    }

    private void ClearConsole()
    {
        if (isConsoleAvailable)
        {
            try
            {
                Console.Clear();
            }
            catch
            {
                Console.WriteLine("\n\n\n");
            }
        }
        else
        {
            Console.WriteLine("\n\n\n");
        }
    }

    private void ShowMainMenu()
    {
        while (true)
        {
            ClearConsole();
            Console.WriteLine("===============================");
            Console.WriteLine("    Survive the Island     ");
            Console.WriteLine("===============================");
            Console.WriteLine("1. New Game");
            Console.WriteLine("2. Credits");
            Console.WriteLine("3. Exit");
            Console.WriteLine("===============================");
            Console.Write("Select an option: ");

            string? choice = Console.ReadLine()?.Trim();

            switch (choice)
            {
                case "1":
                    InitializeGame();
                    StartGame();
                    break;
                case "2":
                    ShowCredits();
                    break;
                case "3":
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("Invalid option. Press Enter to continue...");
                    Console.ReadLine();
                    break;
            }
        }
    }

    private void ShowCredits()
    {
        ClearConsole();
        Console.WriteLine("===============================");
        Console.WriteLine("          Credits           ");
        Console.WriteLine("===============================");
        Console.WriteLine("Game Design & Programming:");
        Console.WriteLine("Tuana Çakmanus");
        Console.WriteLine("\nCourse:");
        Console.WriteLine("DGD203-Game Programming 1");
        Console.WriteLine("Game Engine & Programming Language: C# ");
        Console.WriteLine("Tool Used: Visual Studio Code");
        Console.WriteLine("AI Assistant: Claude ");
        Console.WriteLine("\nPress Enter to return to main menu...");
        Console.ReadLine();
    }

    private void InitializeGame()
{
    ClearConsole();
    Console.Write("What is your name, adventurer? ");
    string? playerName = Console.ReadLine()?.Trim();
    if (string.IsNullOrEmpty(playerName)) playerName = "Adventurer";

    player = new Player(playerName);

    player.Inventory.Add("Half-eaten bread");
    player.Inventory.Add("Pennies");
    player.Inventory.Add("Compass");

    grid = new string[5, 5]
    {
        { "T1", "-", "OL", "-", "B" },
        { "-", "B2", "-", "-", "-" },
        { "M", "-", "P", "-", "C" },
        { "T2", "-", "-", "TR", "-" },
        { "V", "T2", "-", "-", "AH" }
    };

    playerX = 2;
    playerY = 2;
}

    public void StartGame()
    {
        Introduction();

        while (true)
        {
            ShowChoices();
            string? choice = Console.ReadLine()?.Trim().ToLower();
            HandleChoice(choice);
        }
    }

    private void HandleChoice(string? choice)
    {
        switch (choice)
        {
            case "1": //North
                MovePlayer(0, -1);
                break;
            case "2": //South
                MovePlayer(0, 1);
                break;
            case "3": //East
                MovePlayer(1, 0);
                break;
            case "4": //West
                MovePlayer(-1, 0);
                break;
            case "5": //Check Inventory
                player.ShowInventory();
                break;
            case "6": //Quit
                QuitGame();
                break;
            default:
                Console.WriteLine("Invalid choice. Please try again.");
                break;
        }
    }

    private void Introduction()
    {
        Console.WriteLine($"\nYou woke up right under a tree , {player.Name}.You looked around. Apparently you're in the middle of a forest. Checked your pockets..");
        Console.WriteLine("You have some supplies with you!: Half-eaten bread, pennies, and a shiny compass.");
        Console.WriteLine("Which direction do you want to go?");
    }

    private void ShowChoices()
    {
        Console.WriteLine("\nWhere would you like to go?");
        Console.WriteLine("1. Go North.");
        Console.WriteLine("2. Go South.");
        Console.WriteLine("3. Go East.");
        Console.WriteLine("4. Go West.");
        Console.WriteLine("5. Check Inventory.");
        Console.WriteLine("6. Quit the game.");
    }

    private void HandleEncounter(string location)
{
    switch (location)
    {
        case "T1": HandleTreasureChest(); break;
        case "OL": HandleOldLady(); break;
        case "B": HandleBoats(); break;
        case "B2": HandleBerries(); break;
        case "M": HandleMonkeys(); break;
        case "C": HandleBridge(); break;
        case "T2": HandleTigers(); break; 
        case "TR": HandleTrap(); break;
        case "AH": HandleAbandonedHouse(); break;
        case "V": HandleVillage(); break;
        default: Console.WriteLine("Nothing interesting here."); break;
    }
}

    private void HandleTigers(int deltaX, int deltaY)
    {
        throw new NotImplementedException();
    }

    private void MovePlayer(int dx, int dy)
{
    deltaX = dx;
    deltaY = dy;
    
    int newX = playerX + deltaX;
    int newY = playerY + deltaY;

    if (newX >= 0 && newX < 5 && newY >= 0 && newY < 5)
    {
        playerX = newX;
        playerY = newY;
        HandleEncounter(grid[playerY, playerX]);
    }
    else
    {
        Console.WriteLine("It's ocean!You can't swim.");
    }
}

private void HandleVillage()
{
    Console.WriteLine("You see a village not too far away, with small cottages and a few lanterns glowing softly. The scent of baked bread lingers in the air. You can walk there easily. What would you like to do??");
    Console.WriteLine("1. Enter the village and end your journey");
    Console.WriteLine("2. Continue exploring the island");
    
    string? choice = Console.ReadLine()?.Trim();
    
    if (choice == "1")
    {
        Console.WriteLine("You enter the village and find safety among its friendly villagers.");
        Console.WriteLine("Congratulations! You survived the island!");
        QuitGame();
    }
    else
    {
        Console.WriteLine("You decide to continue your adventure on the island.");
    }
}


    private void HandleTreasureChest()
{
    Console.WriteLine("In the distance, a treasure chest gleams under the light, almost calling to you. But wait… a giant snake is coiled tightly around it, its body still and unmoving. Its lifeless eyes seem to watch you. What do you want to do?");
    Console.WriteLine("1. Get close.");
    Console.WriteLine("2. Leave.");
    string? choice = Console.ReadLine()?.Trim();

    if (choice == "1")
    {
        Console.WriteLine("You're lucky the snake is dead, but the chest is locked. And there's no obvious key nearby.");
        if (player.HasKey)
        {
            Console.WriteLine("You unlocked it with the key you got from monkeys! You found a huge amount of gold that will make you the richest for the rest of your life!");
            player.AddToInventory("Gold Treasure");
            player.Inventory.Remove("Key");
            player.HasKey = false;
        }
        else
        {
            Console.WriteLine("You need a key.");
        }
    }
}

    private void HandleOldLady()
{
    Console.WriteLine("You notice a very wrinkled and aged lady behind a tree. Her face is deeply lined, and her appearance is far from..well..graceful.But there’s a certain mysterious aura about her.");
    Console.WriteLine("1. Ask what she's doing in the forest all alone");
    Console.WriteLine("2. Ask her which witch cursed her to look like that");
    string? choice = Console.ReadLine()?.Trim();

    if (choice == "1")
    {
        Console.WriteLine("The old, wrinkled lady looks at you with pleading eyes, her voice shaky as she says, 'I haven’t eaten in days... Do you have anything to share?'");
    
        Console.WriteLine("You check your inventory. You have the following food items:");

        List<string> foodItems = new List<string>();
        if (player.Inventory.Contains("Berries"))
        {
            foodItems.Add("Berries");
        }
        if (player.Inventory.Contains("Half-eaten bread"))
        {
            foodItems.Add("Half-eaten bread");
        }

        if (foodItems.Count > 0)
        {
            foreach (var food in foodItems)
            {
                Console.WriteLine($"- {food}");
            }

            Console.WriteLine("\nDo you want to give any of your food to her? (Yes/No)");
            string? shareFoodChoice = Console.ReadLine()?.Trim().ToLower();

            if (shareFoodChoice == "yes")
            {
                Console.WriteLine("Which food will you give to her?");
                for (int i = 0; i < foodItems.Count; i++)
                {
                    Console.WriteLine($"{i + 1}. {foodItems[i]}");
                }

                string? foodChoice = Console.ReadLine()?.Trim();
                if (int.TryParse(foodChoice, out int foodIndex) && foodIndex > 0 && foodIndex <= foodItems.Count)
                {
                    string selectedFood = foodItems[foodIndex - 1];
                    Console.WriteLine($"You give the {selectedFood} to the old lady.");
                    if (selectedFood == "Berries")
                    {
                        Console.WriteLine("She smiles warmly and hands you a small bottle filled with a sparkly purple liquid. 'Use it wisely,' she says, her voice faded as she vanished into the shadows, leaving you with the mysterious gift.");
                        player.AddToInventory("Potion");
                    }
                    else if (selectedFood == "Half-eaten bread")
                    {
                        Console.WriteLine("She smiles warmly and hands you a small bottle filled with a sparkly purple liquid. 'Use it wisely,' she says, her voice faded as she vanished into the shadows, leaving you with the mysterious gift.");
                        player.AddToInventory("Potion");
                    }

                    player.Inventory.Remove(selectedFood);
                }
            }
            else
            {
                Console.WriteLine("You decide not to share any food with her.");
            }
        }
        else
        {
            Console.WriteLine("You decide not to share any food with her.");
        }
    }
    else
    {
        Console.WriteLine("The old lady's eyes widen with fury 'How dare you..'  she hisses. With a unnatural movement, she raises her hand 'May your foolishness be your end!' The air around you thickens, and before you can react, a dark suffocating energy surges around you. Your vision blurs as life drains from your body. The last thing you hear is her cold laughter before everything fades to black.");
        QuitGame();
    }
}

    private void HandleBoats()
{
    Console.WriteLine("You spot two new looking boats along the shore.They seem to be in perfect condition, just waiting to be used. The boats gently sway with the rhythm of the waves.Do you want to get on one and leave, or stay a little longer? (yes/no)");
    
    string? choice = Console.ReadLine()?.Trim().ToLower();
    
    if (choice == "yes")
    {
        Console.WriteLine("Which one will you use? Right or Left?");
        
        string? boatChoice = Console.ReadLine()?.Trim().ToLower();
        
        if (boatChoice == "right")
        {
            Console.WriteLine("You step into the right boat, but as you move away, it starts sinking. The water rises quickly, pulling you under. You drown.");
            QuitGame();
        }
        else if (boatChoice == "left")
        {
            Console.WriteLine("You get on the left boat and row away from the island, escaping to safety. You're safe.");
            QuitGame();
        }
        else
        {
            Console.WriteLine("Please choose either 'right' or 'left'.");
            HandleBoats(); 
        }
    }
    else if (choice == "no")
    {
        Console.WriteLine("You decide not to leave the island just yet and continue exploring.");
    }
    else
    {
        Console.WriteLine("Please answer with 'yes' or 'no'.");
        HandleBoats(); 
    }
}


    private void HandleBerries()
    {
        Console.WriteLine("There is a bush of bright berries in front of you, their vivid colors tempting you. You hesitate,unsure if theyre safe to eat.Do you take the risk and pick and eat them? (yes/no)");
        string? choice = Console.ReadLine()?.Trim().ToLower();

        if (choice == "yes")
        {
            Console.WriteLine("You decide to pick the berries, and after tasting one, you realize they're safe to eat.You collected more to save for later.");
            player.AddToInventory("Berries");
        }
    }

    private void HandleMonkeys()
{
    Console.WriteLine("The monkeys are hanging from the trees.One of them holds a shiny key in its paws, eyeing your compass with interest. It looks like they want to trade, but only if you give up your shiny compass. What will you do?");
    Console.WriteLine("Give them the compass? (yes/no)");
    string? choice = Console.ReadLine()?.Trim().ToLower();

    if (choice == "yes")
    {
        Console.WriteLine("You give the compass to the monkeys. They hand you the key in return!");
        player.Inventory.Remove("Compass");
        player.HasKey = true; 
        player.AddToInventory("Key");
    }
    else if (choice == "no")
    {
        Console.WriteLine("The monkeys grow angry. They snatch the compass from you anyway!");
        player.Inventory.Remove("Compass");
    }
    else
    {
        Console.WriteLine("Invalid choice. Please type 'yes' or 'no'.");
    }
}

    private void HandleBridge()
    {
        Console.WriteLine("You stand before a bridge stretching over a deep ravine. Below,a strange, toxic looking liquid bubbling like if it's boiling. The thick,substance gives off an unsettling, dangerous glow, and it's clear that it’s not water. The bridge itself creaks and looks barely able to hold your weight, its structure looking almost on the verge of collapsing. After the bridge, the landscape appears completely different...strange and heavenly, like an entirely separate world. The choice is yours. Will you risk crossing?");
        Console.WriteLine("1. Cross the bridge.");
        Console.WriteLine("2. Turn back.");
        string? choice = Console.ReadLine()?.Trim().ToLower();

        if (choice == "1")
        {
            Console.WriteLine("As you take a step forward the bridge creaks loudly.The last thing you hear is the sizzling sound of the liquid before everything goes dark.");
            QuitGame();
        }
        else
        {
            Console.WriteLine("You decide to turn back and head in the other direction.");
        }
    }

    private void HandleTigers()
{
    Console.WriteLine("You see a pair of tigers blocking your path. The tigers are lying around, seemingly asleep, their bodies relaxed but still..they're tigers. What will you do?");
    Console.WriteLine("1. Leave quietly");
    Console.WriteLine("2. Distract them by throwing something and making a sound");

    if (player.Inventory.Contains("Knife"))
    {
        Console.WriteLine("3. Fight the tigers with your knife");
    }

    if (player.Inventory.Contains("Potion"))
    {
        Console.WriteLine("4. Use the potion");
    }

    string? choice = Console.ReadLine()?.Trim();

    switch (choice)
    {
        case "1":
            Console.WriteLine("You decide to leave quietly and return the way you came.");
            playerX = playerX - deltaX;
            playerY = playerY - deltaY;
            break;
        case "2":
            Console.WriteLine("You throw something away and make a loud noise. The tigers are distracted, and you use the opportunity to sneak past.");
            break;
        case "3":
            if (player.Inventory.Contains("Knife"))
            {
                Console.WriteLine("You foolishly try to fight the tigers with your knife. They overpower you easily.You’ve been defeated.");
                QuitGame();
            }
            else
            {
                Console.WriteLine("Invalid choice. Please select a valid option.");
                HandleTigers();
            }
            break;
        case "4":
            if (player.Inventory.Contains("Potion"))
            {
                Console.WriteLine("You drink the potion and become invisible! The tigers can't see you as you walk right past them.");
                player.Inventory.Remove("Potion");
            }
            else
            {
                Console.WriteLine("Invalid choice. Please select a valid option.");
                HandleTigers();
            }
            break;
        default:
            Console.WriteLine("Invalid choice. Please select a valid option.");
            HandleTigers();
            break;
    }
}

private bool PlayerHasPotion()
{
    return player.HasPotion;
}

private void UsePotion()
{
    player.HasPotion = false;
    Console.WriteLine("Oops! It seems you’ve used the last drop of the potion.You can't use it anymore");
}


private bool PlayerHasKnife()
{
    return player.Inventory.Contains("knife");

}


    private void HandleTrap()
    {
        Console.WriteLine("You step on a hidden trap, and before you can react the net snaps up around you,. lifting you off the ground. You're trapped and hanging in the air");
        Console.WriteLine("1. Try to escape.");
        Console.WriteLine("2. Wait for help.");
        string? choice = Console.ReadLine()?.Trim().ToLower();

        if (choice == "1")
        {
            Console.WriteLine("You escape the trap!");
        }
        else
        {
            Console.WriteLine("No help arrives. You perish in the trap.");
            QuitGame();
        }
    }

    private void HandleAbandonedHouse()
    {
        Console.WriteLine("You find an abandoned house, its walls covered in ivy and windows shattered. It looks very old adn scary with the silence surrounding it. Even the air feels different as you get close to the house. Feels like it's haunted, if you believe in ghosts of course,.");
        Console.WriteLine("1. Enter the house.");
        Console.WriteLine("2. Leave.");
        string? choice = Console.ReadLine()?.Trim().ToLower();

        if (choice == "1")
        {
            Console.WriteLine("Inside, you find an old and rusted knife on a dusty table. Its handle isvery worn, but it could still serve as a useful tool if needed.");
            player.AddToInventory("Knife");

        }
    }

    private void CheckInventory()
    {
        Console.WriteLine("\nYour inventory:");
        foreach (var item in player.Inventory)
        {
            Console.WriteLine("- " + item);
        }
    }

    private void QuitGame()
    {
        Console.WriteLine("\nThanks for playing!");
        Environment.Exit(0);
    }
}