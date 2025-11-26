namespace Day5
{
    class Program
    {
        static void Main()
        {          
            Solution();
        }

        public static void Solution() {
            TextReader sr = new StreamReader("D:\\coding\\Personal\\AdventOfCode\\2020\\Day-5\\input.txt");
            string[] input = sr.ReadToEnd().Split("\r\n");
            int max = -99999;
            bool[,] occupied = new bool[128, 8];
            
            for (int i = 0; i < input.Length; i++)
            {
                string rowDirections = input[i].Substring(0, input[i].Length-3);
                string colDirections = input[i].Substring(input[i].Length-3);

                int row = FindSeat(rowDirections, 0, 127);
                int col = FindSeat(colDirections, 0, 7);
                occupied[row, col] = true;
                int id = row * 8 + col;
                Console.WriteLine($"{row} {col} {id}");
                if(id > max)
                {
                    max = id;
                }
            }
            Console.WriteLine(max);
            for (int i = 0; i < 128; i++)
            {
                Console.Write($"row:{i} - ");
                for (int j = 0; j < 8; j++)
                {
                    if (occupied[i, j]) {
                        Console.Write('T');
                    }
                    else
                    {
                        Console.Write('F');
                    }
                }
                Console.WriteLine();
            }
            //We know that the seats above and below are occupied
            //so our seat is on row 63 col 0 => id 504
        }

        public static int FindSeat(string directions, int s, int e)
        {
            for (int i = 0; i < directions.Length; i++)
            {
                char c = directions[i];
                if(c == 'F' || c == 'L')
                {
                    e = s + (int)Math.Floor((double)((double)(e - s) / 2));
                }else if(c == 'B' || c == 'R')
                {
                    s = s + (int)Math.Ceiling((double)((double)(e - s) / 2));
                }
                //Console.WriteLine($"{s}->{e}");
            }
            return s;
        }

    }
}