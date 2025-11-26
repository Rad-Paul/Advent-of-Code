namespace Day_15
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] input = "0,3,6".Split(',');
            Part1(input);
        }

        public static void Part1(string[] input)
        {
            Dictionary<int, Num> valueAndTurn = new Dictionary<int, Num>();
            
            for(int i = 0; i < input.Length; i++)
            {
                valueAndTurn.Add(int.Parse(input[i]), new Num(false, i+1));
            }

            int lastNumSpoken = int.Parse(input[input.Length-1]);
            int current = -1;
            for (int i = input.Length+1; i < 2020; i++)
            {
                if (valueAndTurn.ContainsKey(lastNumSpoken))
                {
                    if (valueAndTurn[lastNumSpoken].Seen == false)
                    {
                        valueAndTurn[lastNumSpoken].Seen = true;
                        current = 0;
                    }
                    else
                    {
                        current = i - 1 - valueAndTurn[lastNumSpoken].lastSeen;
                    }
                }
                else
                {
                    current = 0;
                }
                valueAndTurn[lastNumSpoken].lastSeen = i - 1;
                lastNumSpoken = current;
            }

        }

        public class Num()
        {
            public bool Seen;
            public int lastSeen;
            public Num(bool seen, int last) : this()
            {
                Seen = seen;
                lastSeen = last;
            }
        }

    }
}
