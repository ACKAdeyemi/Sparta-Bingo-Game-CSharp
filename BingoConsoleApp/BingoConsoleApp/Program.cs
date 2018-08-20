using System;
using System.Collections.Generic;
using BingoPlayerClass;
using System.Linq;

namespace BingoConsoleApp
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("Hello World! From Virtual Machine");
            Console.WriteLine("Successfully linked to personal machine!");
            // CODE GOES BELOW HERE
            Console.WriteLine("\nNEW GAME - BINGO");

            Player player = new Player
            {
                name = "Player",
                playerNumbers = { }
            };

            RandomPlayerNumbers(player);

            // BELOW allows player to set their own name 
            Console.WriteLine("\nHi Player 1. \nWelcome to BINGO by ACKA. \nWhat is your name?");
            player.name = Console.ReadLine();
            Console.WriteLine("\nHi " + player.name + ", thanks for joining! Have a great game!");

            Console.WriteLine("\nGenerating " + player.name + "'s numbers...");
            // BELOW confirms array items can be listed
            Console.WriteLine(player.name + "'s numbers are:");
            foreach (int number in player.playerNumbers)
            {
                Console.Write(number + ", ");
            }

            Console.WriteLine("\n\nLET'S PLAY BINGO!");

            List<int> pickedNumbers = new List<int>();

            RollNumbers(pickedNumbers, player);

            // BELOW is to prevent application ended after player wins/final number roll
            Console.ReadLine();
        }

        public static void RandomPlayerNumbers(Player playerClass)
        {
            Random randNum = new Random();
            for (int i = 0; i < playerClass.playerNumbers.Length; i++)
            {
                int number;
                number = randNum.Next(1, 10);
                if (!playerClass.playerNumbers.Contains(number))
                {
                    playerClass.playerNumbers[i] = number;
                }
                else
                {
                    // prevents adding zeros to player's numbers by going back to the index
                    i--;
                }
            }
        }

        public static void GameState()
        {
            bool keepPlaying = true;

            while (keepPlaying)
            {
                Console.WriteLine("Would you like to play again? \nEnter 1 for YES and 2 for NO");
                string entry = Console.ReadLine();

                try
                {
                    // BELOW converts user input to integer
                    int num = int.Parse(entry);

                    if (num == 1)
                    {
                        Main();
                    }
                    else if (num == 2)
                    {
                        keepPlaying = false;
                        Console.WriteLine("Thank you for playing! Goodbye. Press any key and enter or enter to exit.");
                        Console.ReadLine();
                        Environment.Exit(0);
                    }
                    else
                    {
                        Console.WriteLine("That is not valid input.");
                        continue;
                    }
                }
                catch (FormatException)
                {
                    Console.WriteLine("That is not valid input.");
                    continue;
                }
            }
        }

        public static void CheckPlayerWin(List<int> list, Player playerClass)
        {
            List<int> checkWinList = new List<int>();
            // BELOW adds player's numbers to a list for comparison
            for (int i = 0; i < playerClass.playerNumbers.Length; i++)
            {
                if (list.Contains(playerClass.playerNumbers[i]))
                {
                    checkWinList.Add(playerClass.playerNumbers[i]);
                }
            }

            // BELOW orders both lists in ascending order
            list.Sort();
            checkWinList.Sort();

            // BELOW checks for match between player numbers and rolled
            for (int i = 0; i < list.Count; i++)
            {
                for (int j = 0; j < checkWinList.Count; j++)
                {
                    if (list[i] == checkWinList[j])
                    {
                        Console.WriteLine("\n\n" + playerClass.name + " HAS A MATCH!");
                        Console.WriteLine("Player's number = " + checkWinList[j]);
                        Console.WriteLine("Rolled number = " + list[i]);
                    }
                }
            }
            if (playerClass.playerNumbers.Length == checkWinList.Count)
            {
                Console.WriteLine("\nBINGO!");
                Console.WriteLine(playerClass.name + " wins the GAME!");
                Console.WriteLine("GAME END");
                GameState();
            }
        }

        // BELOW inserts random numbers into a list
        public static void RollNumbers(List<int> list, Player playerClass)
        {
            Random randomNumber = new Random();
            int number;

            // loop iterations needs to be one lower than max random num to work
            for (int i = 0; i < 10; i++)
            {
                do
                {
                    number = randomNumber.Next(1, 11);
                } while (list.Contains(number));
                list.Add(number);
                Console.WriteLine("\nPress SPACEBAR to roll a number...");
                if (Console.ReadKey().Key == ConsoleKey.Spacebar)
                {
                    Console.WriteLine("\nThe next rolled number is " + number);

                    Console.WriteLine("\n" + playerClass.name + "'s numbers are:");
                    foreach (int playerNumber in playerClass.playerNumbers)
                    {
                        Console.Write(playerNumber + ", ");
                    }

                    Console.WriteLine("\nThese are the rolled numbers so far:");
                    foreach (int num in list)
                    {
                        Console.Write(num + ", ");
                    }
                    CheckPlayerWin(list, playerClass);
                }
            }
        }
    }
}

// ========= PSUEDO CODE: =========
// So we have players, each player has a name and a bingo card
// Start with one player. 
// Need to add press enter for new ball funtionality
// ABOVE - needs to include info on players numbers and current rolled number list ("All rolled numbers so far:")
// Need to incliude a way for the game to be restart (use a bool and say "while play = true, do method" - take content out of main and put into seperate method and then maybe wrap the while loop in that method... call it 'playBingo')