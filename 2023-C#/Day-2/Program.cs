using System;
using System.Drawing;
class Program
{
    //for part 1
    public static Dictionary<string, int> colorAmount = new Dictionary<string, int>()
    {
        {"red", 12 },
        {"green", 13 },
        {"blue", 14}
    };

    static void Main(string[] args)
    {
        Part2();
    }

    public static void Part1()
    {
        string filePath = @"D:/coding/AdventOfCode/2023/Day-2/input.txt";
        TextReader reader = new StreamReader(filePath);
        string line;
        int toReturn = 0;
        int id = 1;
        while ((line = reader.ReadLine()) != null)
        {
            //split the game from the rounds/sets
            bool possibleGame = true;
            string[] game = line.Split(':');
            //split the sets from eachother so we can look at each one
            string[] sets = game[1].Split(';');
            for (int i = 0; i < sets.Length; i++)
            {
                //split the shown cubes so we can see the amount and color of each
                string[] shownCubes = sets[i].Split(",");

                for (int j = 0; j < shownCubes.Length; j++)
                {
                    string currentPair = shownCubes[j];
                    if (id == 3)
                    {
                        int minecraft = 0;
                    }
                    int amount = 0;
                    string[] amountAndColor = currentPair.Split(' ');

                    //amountAndColor[0] will always be ""
                    amount = int.Parse(amountAndColor[1]);
                    string color = amountAndColor[2];

                    if (amount > colorAmount[color])
                    {
                        possibleGame = false;
                    }
                    if (!possibleGame) { break; }
                }
                if (!possibleGame)
                {
                    break;
                }
            }
            if (possibleGame)
            {
                toReturn += id;
            }
            id++;
        }

        Console.WriteLine(toReturn);
    }
    public static void Part2()
    {
         Dictionary<string, int> minAmountForEachColor = new Dictionary<string, int>()
         {
            {"red", int.MinValue },
            {"green", int.MinValue },
            {"blue", int.MinValue}
         };

        string filePath = @"D:/coding/AdventOfCode/2023/Day-2/input.txt";
        TextReader reader = new StreamReader(filePath);
        string line;
        int toReturn = 0;

        while ((line = reader.ReadLine()) != null)
        {
            //split the game from the rounds/sets
            string[] game = line.Split(':');
            //split the sets from eachother so we can look at each one
            string[] sets = game[1].Split(';');
            for (int i = 0; i < sets.Length; i++)
            {
                //split the shown cubes so we can see the amount and color of each
                string[] shownCubes = sets[i].Split(",");

                for (int j = 0; j < shownCubes.Length; j++)
                {
                    string currentPair = shownCubes[j];
                    int amount = 0;
                    string[] amountAndColor = currentPair.Split(' ');

                    //amountAndColor[0] will always be ""
                    amount = int.Parse(amountAndColor[1]);
                    string color = amountAndColor[2];

                    if (amount > minAmountForEachColor[color])
                    {
                        minAmountForEachColor[color] = amount;
                    }
                }
            }

            toReturn += (minAmountForEachColor["red"] * minAmountForEachColor["green"] * minAmountForEachColor["blue"]);

            minAmountForEachColor["red"] = int.MinValue;
            minAmountForEachColor["green"] = int.MinValue;
            minAmountForEachColor["blue"] = int.MinValue;
        }
        Console.WriteLine(toReturn);
    }
}