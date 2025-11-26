namespace Day_10
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string filepath = "D:\\coding\\Personal\\AdventOfCode\\2020\\Day-10\\input.txt";
            TextReader reader = new StreamReader(filepath);
            string[] input = reader.ReadToEnd().Split("\r\n");
            int[] ints = Array.ConvertAll(input, int.Parse);
            Part1(ints);
            Part2(ints);
        }

        public static void Part1(int[] joltages)
        {
            Array.Sort(joltages);
            int ones = 0;
            int threes = 1;
            if (joltages[0] == 1) { ones++; }
            else if (joltages[0] == 3) { threes++; }
            for (int i = 0; i < joltages.Length - 1; i++) {
                if (joltages[i+1] - joltages[i] == 1)
                {
                    ones++;
                }
                else if (joltages[i+1] - joltages[i] == 3)
                {
                    threes++;
                }
            }
            //Console.WriteLine(ones);
            //Console.WriteLine(threes);
            Console.WriteLine(ones * threes);
        }

        public static void Part2(int[] joltages)
        {
            
        }
    }
}
