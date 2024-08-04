using System;

namespace Distinction
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to the Distinction Card Game!");

            // Initialize the deck
            Deck deck = new Deck();
            Game game = new Game(deck);

            // Add players to the game
            Console.Write("Enter the number of players: ");
            int playerCount;
            while (!int.TryParse(Console.ReadLine(), out playerCount) || playerCount < 2)
            {
                Console.Write("Invalid input. Please enter a valid number of players (2 or more): ");
            }

            game.AddPlayersToGame(playerCount);

            // Subscribe to game events
            game.PlayerNotification += OnPlayerNotification;
            game.OnGameEnded += OnGameEnded;

            // Start the game loop
            while (true)
            {
                Player currentPlayer = game.CurrentPlayer;
                Console.WriteLine($"{currentPlayer.Name}'s turn.");
                Console.WriteLine($"Current card: {game.CurrentCard}");
                Console.WriteLine("Your hand:");
                for (int i = 0; i < currentPlayer.Hand.Count; i++)
                {
                    Console.WriteLine($"{i + 1}: {currentPlayer.Hand[i]}");
                }

                Console.Write("Choose a card to play (enter the number), or draw a card (enter 'd'): ");
                string input = Console.ReadLine();

                if (input.ToLower() == "d")
                {
                    game.StartPlayerTurn();
                }
                else if (int.TryParse(input, out int cardIndex) && cardIndex >= 1 && cardIndex <= currentPlayer.Hand.Count)
                {
                    Card chosenCard = currentPlayer.Hand[cardIndex - 1];
                    if (chosenCard.Match(game.CurrentCard))
                    {
                        game.PlayCard(chosenCard);
                    }
                    else
                    {
                        Console.WriteLine("Invalid move. The card does not match the current card.");
                    }
                }
                else
                {
                    Console.WriteLine("Invalid input. Please try again.");
                }
            }
        }

        static void OnPlayerNotification(object sender, string e)
        {
            Console.WriteLine(e);
        }

        static void OnGameEnded(object sender, GameEndedEventArgs e)
        {
            Console.WriteLine($"Game Over! {e.WinnerName} is the winner!");
            Environment.Exit(0);
        }
    }
}
