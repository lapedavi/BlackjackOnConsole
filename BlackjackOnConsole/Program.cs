﻿using BlackjackOnConsole;

internal class Program
{
    private static void Main(string[] args)
    {
        string replayInput = string.Empty;
        while (replayInput != "n") {
            Play();

            replayInput = string.Empty;
            while (replayInput != "y" && replayInput != "n")
            {
                Console.Write("\nWould you like to play again (y) (n): ");
                replayInput = Console.ReadLine() ?? string.Empty;
            }

            Console.Clear();
        }
    }

    private static void Play()
    {
        Console.WriteLine("\nWelcome to BlackJack On Console");
        var bank = 100;

        while (bank > 0)
        {
            Deck.InitializeDeck();

            var bet = 0;
            while (bet <= 0)
            {
                Console.Write($"You have {bank:N0}, how much would you like to bet: ");
                var betInput = Console.ReadLine();

                if (int.TryParse(betInput, out var output) && output <= bank)
                {
                    bet = output;
                }
            }

            bank -= bet;

            var dealersHand = new Hand("Dealer");
            var playersHand = new Hand("Player");
            var stay = false;

            while (playersHand.Sum <= 21 && !stay)
            {
                DisplayHands(dealersHand, playersHand);

                var choiceInput = string.Empty;
                while (choiceInput != "h" && choiceInput != "s")
                {
                    Console.Write("Would you like to hit or stay (h) (s): ");
                    choiceInput = Console.ReadLine();
                }

                if (choiceInput == "h")
                {
                    playersHand.DrawCard();
                } else
                {
                    stay = true;
                }
            }

            if (playersHand.Sum > 21)
            {
                DisplayHands(dealersHand, playersHand);
                Console.WriteLine("Player Busts, Dealer Wins");
            } else if (playersHand.Sum < dealersHand.Sum)
            {
                DisplayHands(dealersHand, playersHand);
                Console.WriteLine("Dealer Wins");
            } else
            {
                while (dealersHand.Sum <= playersHand.Sum && dealersHand.Sum <= 21)
                {
                    dealersHand.DrawCard();
                }

                DisplayHands(dealersHand, playersHand);

                if (dealersHand.Sum > 21)
                {
                    bank += bet * 2;
                    Console.WriteLine("Dealer Busts, Player Wins");
                } else if (playersHand.Sum > dealersHand.Sum)
                {
                    bank += bet * 2;
                    Console.WriteLine("Player Wins");
                } else
                {
                    Console.WriteLine("Dealer Wins");
                }
            }
        }
    }

    private static void DisplayHands(params Hand[] hands)
    {
        foreach(Hand hand in hands)
        {
            Console.WriteLine(hand);
        }
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