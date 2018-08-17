using System;
using System.Collections.Generic;

namespace BingoConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World! From Virtual Machine");
            Console.WriteLine("Successfully linked to personal machine!");
            // CODE GOES BELOW HERE
            Console.WriteLine("\nNEW GAME - BINGO");

            Player player = new Player
            {
                name = "Chris",
                playerNumbers = { }
            };

            List<int> pickedNumbers = new List<int>();

            // BELOW confirms player name can be shown, can change to player input later
            Console.WriteLine("\n" + player.name);
            // BELOW confirms array items can be listed
            Console.WriteLine("Players numbers are:");
            foreach (int number in player.playerNumbers)
            {
                Console.WriteLine(number);
            }

            Console.WriteLine("\nLET'S PLAY BINGO!");
            Console.WriteLine();

            int rolledNumbersCounter = 1;
            RollNumbers(pickedNumbers, rolledNumbersCounter);

            for (int i = 10; rolledNumbersCounter < i; rolledNumbersCounter++)
            {
                Console.WriteLine("Players numbers are:");
                foreach (int number in player.playerNumbers)
                {
                    Console.Write(number + ", ");
                }
                Console.WriteLine("Press enter to roll a number...");
                if (Console.ReadKey().Key == ConsoleKey.Enter)
                {
                    for (int j = 0; j < pickedNumbers.Count; j++)
                    {
                        Console.WriteLine("The next rolled number is " + pickedNumbers[j]);
                    }
                }
                CheckPlayerWin(pickedNumbers, player.playerNumbers, player.name);
            }

            Console.ReadLine();
        }

        public static void CheckPlayerWin(List<int> list, int[] playerArray, string nameOfPlayer)
        {
            List<int> checkWinList = new List<int>();
            // BELOW adds player's numbers to a list for comparison
            for (int i = 0; i < playerArray.Length; i++)
            {
                if (list.Contains(playerArray[i]))
                {
                    checkWinList.Add(playerArray[i]);
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
                        Console.WriteLine("\n" + nameOfPlayer + " HAS A MATCH!");
                        Console.WriteLine("Player's number = " + checkWinList[j]);
                        Console.WriteLine("Rolled number = " + list[i]);
                    }
                }
            }
            if (playerArray.Length == checkWinList.Count)
            {
                Console.WriteLine("\nBINGO!");
                Console.WriteLine(nameOfPlayer + " wins the GAME!");
                Console.WriteLine("GAME END");
            }
        }

        // BELOW inserts random numbers into a list
        public static void RollNumbers(List<int> list, int counter)
        {
            Random randomNumber = new Random();
            int number;

            // loop iterations needs to be one lower than max random num to work
            for (int i = 0; i < counter; i++)
            {
                do
                {
                    number = randomNumber.Next(1, 11);
                } while (list.Contains(number));
                list.Add(number);
            }
        }
    }

    public class Player
    {
        public string name;
        public int[] playerNumbers = new int[5]
        {
            1, 2, 5, 7, 8
        };
    }
}

// So we have players, each player has a name and a bingo card
// Start with one player. 
// Need to add press enter for new ball funtionality
// ABOVE - needs to include info on players numbers and current rolled number list ("All rolled numbers so far:")

// ADD THIS FUNCTIONALITY - PRESS ENTER FOR NEW BALL (BELOW NOT WORKING YET...)
//public static void RollNumbers(List<int> list)
//{
//    Random randomNumber = new Random();
//    int number;

//    for (int i = 0; i < 10; i++)
//    {
//        Console.WriteLine("Press enter to roll a number...");
//        if (Console.ReadKey().Key == ConsoleKey.Enter)
//        {
//            do
//            {
//                number = randomNumber.Next(1, 11);
//            } while (list.Contains(number));
//            list.Add(number);
//        }
//        else
//        {
//            continue;
//        }
//    }
//}