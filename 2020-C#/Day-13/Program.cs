using System.Numerics;

namespace Day_13
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string filepath = "D:\\coding\\Personal\\AdventOfCode\\2020\\Day-13\\input.txt";
            TextReader reader = new StreamReader(filepath);
            string[] input = reader.ReadToEnd().Split("\r\n");

            int earliestTime = int.Parse(input[0]);
            string[] busIntervalTable = input[1].Split(',');
            List<string> busIntervals1 = new List<string>();
            //for Part2
            List<Tuple<int, int>> intervalsAndOffsets = new List<Tuple<int,int>>();
            int indexOfLargest = -1;
            int largest = int.MinValue;
            for (int i = 0; i < busIntervalTable.Length; i++)
            {
                if (busIntervalTable[i] != "x")
                {
                    busIntervals1.Add(busIntervalTable[i]);
                    int asNum = int.Parse(busIntervalTable[i]);
                    intervalsAndOffsets.Add(new Tuple<int, int>(asNum, i));
                    if (asNum > largest)
                    {
                        largest = asNum;
                        indexOfLargest = intervalsAndOffsets.Count-1;
                    }
                }
            }
            Part1(earliestTime, busIntervals1);
            Part2(int.Parse(busIntervals1[0]), intervalsAndOffsets, indexOfLargest);
        }
        public static void Part1(int earliestTime, List<string> busIntervals)
        {
            (int id, int bestTime) result = (-1, int.MaxValue);

            for(int i = 0; i < busIntervals.Count; i++) 
            {
                int interval = int.Parse(busIntervals[i]);
                int time = (earliestTime / interval + 1) * interval - earliestTime;
                if(result.bestTime > time)
                {
                    result.bestTime = time;
                    result.id = interval;
                }
            }

            Console.WriteLine(result.id * result.bestTime);
        }
        public static void Part2(int firstInterval, List<Tuple<int,int>> offsets, int indexOfLargest)
        {
            //chinese remainder theorem TO ADD
            ulong iterations = 1;
            bool answer = false;
            var largest = offsets[indexOfLargest];
            while (!answer)
            {
                ulong time = iterations * (ulong)firstInterval;
                
                if((time + (ulong)largest.Item2) % (ulong)largest.Item1 == 0)
                {
                    answer = true;
                    for (int i = 0; i < offsets.Count; i++)
                    {
                        if ((time + (ulong)offsets[i].Item2) % (ulong)offsets[i].Item1 != 0)
                        {
                            answer = false;
                            break;
                        }
                    }
                }
                iterations++;

                if (answer)
                {
                    Console.WriteLine(time);
                }
            }
        }
    }
}
