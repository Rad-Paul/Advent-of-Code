namespace Day_4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string filepath = @"D:\coding\Personal\AdventOfCode\2022\Day-4\input.txt";

            TextReader sr = new StreamReader(filepath);

            string buffer;
            int sum = 0;
            while ((buffer = sr.ReadLine()) != null)
            {
                string[] pair = buffer.Split(',');
                
                sum += Part2(new Range(pair[0]), new Range(pair[1]));
            }
            Console.WriteLine(sum);
        }

        public static int Part1(Range first, Range second)
        {
            if(first.s <= second.s && first.e >= second.e)
            {
                return 1;
            }
            if(second.s <= first.s && second.e >= first.e)
            {
                return 1;
            }

            return 0;
        }

        public static int Part2(Range first, Range second)
        {
            if(first.s <= second.s && first.e >= second.s)
            {
                return 1;
            }
            if(first.s >= second.s && first.s <= second.e)
            {
                return 1;
            }
            return 0;
        }

        public class Range()
        {
            public int s { get; set; }
            public int e { get; set; }

            public Range(int start, int end) : this()
            {
                s = start; e = end;
            }
            
            public Range(string range) :this()
            {
                string[] temp = range.Split('-');
                s = int.Parse(temp[0]);
                e = int.Parse(temp[1]);
            }
        }
    }
}
