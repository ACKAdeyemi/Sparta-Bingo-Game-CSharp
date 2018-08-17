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
            Console.WriteLine();
            Console.WriteLine("NEW GAME - BINGO");
            Console.WriteLine();

            Player player = new Player
            {
                name = "Chris",
                playerNumbers = {}
            };

            List<int> pickedNumbers = new List<int>();

            // BELOW confirms player name can be shown, can change to player input later
            Console.WriteLine(player.name);
            // BELOW confirms array items can be listed
            Console.WriteLine("Players numbers are:");
            foreach (int number in player.playerNumbers)
            {
                Console.WriteLine(number);
            }

            Console.WriteLine();
            Console.WriteLine("LET'S PLAY BINGO!");
            Console.WriteLine();

            RollNumbers(pickedNumbers);
            for (int i = 0; i < pickedNumbers.Count; i++)
            {
                Console.WriteLine("The next rolled number is " + pickedNumbers[i]);
            }

            CheckPlayerWin(pickedNumbers, player.playerNumbers, player.name);

            Console.ReadLine();
        }

        public static void CheckPlayerWin (List<int> list, int[] playerArray, string nameOfPlayer)
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

            list.Sort();
            checkWinList.Sort();

            // BELOW checks for match between player numbers and rolled
            for (int i = 0; i < list.Count; i++)
            {
                for (int j = 0; j < checkWinList.Count; j++)
                {
                    if (list[i] == checkWinList[j])
                    {
                        Console.WriteLine();
                        Console.WriteLine(nameOfPlayer + " HAS A MATCH!");
                        Console.WriteLine("Player's number = " + checkWinList[j]);
                        Console.WriteLine("Rolled number = " + list[i]);

                    }
                }
            }
        }

        // BELOW inserts random numbers into a list
        public static void RollNumbers (List<int> list)
        {
            Random randomNumber = new Random();
            int number;

            for (int i = 0; i < 10; i++)
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