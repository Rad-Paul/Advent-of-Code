namespace Day_8
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string filepath = "D:\\coding\\Personal\\AdventOfCode\\2020\\Day-8\\input.txt";
            TextReader reader = new StreamReader(filepath);
            string input = reader.ReadToEnd();
            Part1(input);
            Part2(input);
        }

        public static void Part1(string input)
        {
            string[] lines = input.Split("\r\n");
            List<Tuple<string, int>> operations = new List<Tuple<string, int>>();
            foreach (string line in lines)
            {
                string[] parts = line.Split(' ');
                operations.Add(new Tuple<string, int>(parts[0], int.Parse(parts[1])));
            }

            bool[] used = new bool[operations.Count];

            Tuple<string, int> current;
            int index = 0;
            int accumulator = 0;

            while (!used[index])
            {
                current = operations[index];
                used[index] = true;
                string operation = current.Item1;
                int val = current.Item2;

                if(operation == "nop")
                {
                    index++;
                }else if(operation == "acc")
                {
                    accumulator += val;
                    index++;
                }else if(operation == "jmp")
                {
                    index += val;
                }
            }

            Console.WriteLine(accumulator);
        }

        public static void Part2(string input)
        {
            string[] lines = input.Split("\r\n");
            List<Tuple<string, int>> operations = new List<Tuple<string, int>>();
            foreach (string line in lines)
            {
                string[] parts = line.Split(' ');
                operations.Add(new Tuple<string, int>(parts[0], int.Parse(parts[1])));
            }

            for (int i = 0; i < operations.Count; i++)
            {
                string operation = operations[i].Item1;
                int value = operations[i].Item2;

                int res = 0;
                if(operations[i].Item1 == "nop")
                {
                    operations[i] = new Tuple<string, int>("jmp", value);
                    res = TryFix(operations);
                    operations[i] = new Tuple<string, int>(operation, value);
                }else if (operations[i].Item1 == "jmp")
                {
                    operations[i] = new Tuple<string, int>("nop", value);
                    res = TryFix(operations);
                    operations[i] = new Tuple<string, int>(operation, value);
                }

                if(res > 0)
                {
                    Console.WriteLine(res);
                    break;
                }
            }
        }
        public static int TryFix(List<Tuple<string, int>> operations)
        {        
            bool[] used = new bool[operations.Count];

            Tuple<string, int> current;
            int index = 0;
            int accumulator = 0;

            while (index < operations.Count && !used[index])
            {
                current = operations[index];
                used[index] = true;
                string operation = current.Item1;
                int val = current.Item2;

                if (operation == "nop")
                {
                    index++;
                }
                else if (operation == "acc")
                {
                    accumulator += val;
                    index++;
                }
                else if (operation == "jmp")
                {
                    index += val;
                }
            }

            if (index >= operations.Count)
            {
                return accumulator;
            }
            return 0;
        }

        public class Operation
        {
            public string Type { get; set; }
            public int Value { get; set; }

            public Operation(string type, string value) {
                Type = type;
                Value = int.Parse(value);
            }
        }
    }
}
