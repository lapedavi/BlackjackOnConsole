using BlackjackOnConsole;

internal class Program
{
    private static void Main(string[] args)
    {
        Console.WriteLine("\nWelcome to BlackJack On Console");
        var bank = 10000;

        while (bank > 0)
        {
            Deck.InitializeDeck();

            var bet = 0;
            while(bet <= 0)
            {
                Console.Write($"You have {bank:N0}, how much would you like to bet: ");
                var betInput = Console.ReadLine();

                if(int.TryParse(betInput, out var output) && output <= bank)
                {
                    bet = output;
                }
            }

            bank -= bet;

            var dealersHand = new Hand();
            var playersHand = new Hand();
            var stay = false;

            while(playersHand.Sum <= 21 && !stay)
            {
                DisplayHands(dealersHand, playersHand);

                var choiceInput = "bad input";
                while(choiceInput != "h" && choiceInput != "s")
                {
                    Console.Write("Would you like to hit or stay (h) (s): ");
                    choiceInput = Console.ReadLine();
                }

                if(choiceInput == "h")
                {
                    playersHand.DrawCard();
                } 
                else
                {
                    stay = true;
                }
            }

            if (playersHand.Sum > 21)
            {
                DisplayHands(dealersHand, playersHand);
                Console.WriteLine("Player Busts, Dealer Wins");
            }
            else if(playersHand.Sum < dealersHand.Sum)
            {
                DisplayHands(dealersHand, playersHand);
                Console.WriteLine("Dealer Wins");
            } 
            else
            {
                while(dealersHand.Sum <= playersHand.Sum && dealersHand.Sum <= 21)
                {
                    dealersHand.DrawCard();
                }

                DisplayHands(dealersHand, playersHand); 

                if (dealersHand.Sum > 21)
                {
                    bank += bet * 2;
                    Console.WriteLine("Dealer Busts, Player Wins");
                }
                else if(playersHand.Sum > dealersHand.Sum)
                {
                    bank += bet * 2;
                    Console.WriteLine("Player Wins");
                }
                else
                {
                    Console.WriteLine("Dealer Wins");
                }
            }

            Console.ReadLine();
            Console.Clear();
        }
    }

    private static void DisplayHands(Hand dealersHand, Hand playersHand)
    {
        Console.WriteLine($"\nHouse ({dealersHand.Sum}): {dealersHand.Cards}");
        Console.WriteLine($"Player ({playersHand.Sum}): {playersHand.Cards}");
    }
}

/* MULTIPLAYER STUFF
    var playerNumberInput = "bad value";
    while (!int.TryParse(playerNumberInput, out var players)) 
    {
        Console.Write("How many players will be playing: "); 
        playerNumberInput = Console.ReadLine();
    }
*/

/* QUIT STUFF
     var keepPlayingInput = "bad value";
    while (keepPlayingInput != "y" && keepPlayingInput != "n")
    {
        Console.Write("Would you like to keeping player (y) (n): ");
        keepPlayingInput = Console.ReadLine();
    }

    if(keepPlayingInput == "n")
    {
        Console.WriteLine("Goodbye");
        playing = false;
    }
*/