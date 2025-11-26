using System.Collections.Generic;

class Program
{  
    static void Main(string[] args)
    {
        string filepath = "D:/coding/AdventOfCode/2023/Day-4/input.txt";
        TextReader reader = new StreamReader(filepath);
        string line = "";
        int totalSum = 0;
        var watch = System.Diagnostics.Stopwatch.StartNew();
        // the code that you want to measure comes here
        
        
        //while((line = reader.ReadLine()) != null)
        //{
        //    //totalSum += Part1(line);
        //}
        Part2();
        watch.Stop();
        var elapsedMs = watch.ElapsedMilliseconds;
        Console.WriteLine(elapsedMs);
        //Console.WriteLine(totalSum);
    }

    static int Part1(string line)
    {
        string[] fullCard = line.Split(':');
        string[] allNums = fullCard[1].Split('|');
        int score = 0;

        Dictionary<int, int> winningNums = new Dictionary<int, int>();
        string[] justWinningNums = allNums[0].Split(" ");
        for(int i = 0; i  < justWinningNums.Length; i++)
        {
            if (justWinningNums[i] != "" && justWinningNums[i] != " ")
            {
                winningNums.Add(i, int.Parse(justWinningNums[i]));
            }
        }

        string[] inHand = allNums[1].Split(" ");
        for(int i = 0; i < inHand.Length; i++)
        {
            if (inHand[i] != "" && inHand[i] != " ")
            {
                if (winningNums.ContainsValue(int.Parse(inHand[i])))
                {
                    if (score == 0)
                    {
                        score++;
                    }
                    else
                    {
                        score *= 2;
                    }
                }
            }
        }

        int minecraft = 0;
        return score;
    }

    static int Part2()
    {
        string filepath = "D:/coding/AdventOfCode/2023/Day-4/input.txt";
        TextReader reader = new StreamReader(filepath);
        string line = "";

        Dictionary<int, int> copies = new Dictionary<int, int>();
        int id = 0;


        int totalCopies = 0;
        while ((line = reader.ReadLine()) != null)
        {            
            if (!copies.ContainsKey(id))
            {
                copies.Add(id, 1);
            }
            else
            {
                copies[id]++;
            }
            
            string[] fullCard = line.Split(':');
            string[] allNums = fullCard[1].Split('|');

            Dictionary<int, int> winningNums = new Dictionary<int, int>();
            string[] justWinningNums = allNums[0].Split(" ");

            for (int i = 0; i < justWinningNums.Length; i++)
            {
                if (justWinningNums[i] != "" && justWinningNums[i] != " ")
                {
                    winningNums.Add(i, int.Parse(justWinningNums[i]));
                }
            }

            string[] inHand = allNums[1].Split(" ");
            int carryOverId = id;

            for(int i = 0; i < inHand.Length; i++)
            {
                if (inHand[i] != "" && inHand[i] != " ")
                {
                    if (winningNums.ContainsValue(int.Parse(inHand[i])))
                    {
                        carryOverId++;
                        if (!copies.ContainsKey(carryOverId))
                        {
                            copies.Add(carryOverId, copies[id]);
                        }
                        else
                        {//add up all the copies
                            copies[carryOverId] += copies[id];
                        }
                    }
                }
            }
            
            totalCopies += copies[id];
            Console.WriteLine(totalCopies);
            id++;
        }
        int minecraft2 = 0;
        return totalCopies;
    }
}