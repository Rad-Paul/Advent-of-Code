namespace Day_5
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string filepath = @"D:\coding\Personal\AdventOfCode\2022\Day-5\input.txt";
            TextReader sr = new StreamReader(filepath);

            string buffer;
            List<string> input = new List<string>();
            while((buffer = sr.ReadLine()) != "")
            {
                input.Add(buffer);
            }

            //creating the stacks
            List<Stack<char>> stacks = new List<Stack<char>>();
            string lastLine = input[input.Count - 1];
            for(int i = 0; i < lastLine.Length; i++)
            {
                if (char.IsDigit(lastLine[i]))
                {
                    Stack<char> newStack = new Stack<char>();
                    stacks.Add(newStack);
                    int lineAboveInd = input.Count - 2;
                    while(lineAboveInd >= 0)
                    {
                        string currentLine = input[lineAboveInd];
                        if (currentLine[i] == ' ')
                        {
                            break;
                        }
                        else 
                        {
                            newStack.Push(currentLine[i]);
                        }
                        lineAboveInd--;
                    }
                }
            }

            //processing moves
            while((buffer = sr.ReadLine()) != null)
            {
                //Part1(buffer, stacks);
                Part2(buffer, stacks);
            }

            foreach(Stack<char> stack in stacks)
            {
                Console.Write(stack.Peek());
            }
            
        }

        public static void Part1(string move, List<Stack<char>> stacks)
        {
            string[] split = move.Split(' ');

            int amount = int.Parse(split[1]);
            int from = int.Parse(split[3]);
            int to = int.Parse(split[5]);

            Stack<char> fromStack = stacks[from - 1];
            Stack<char> toStack = stacks[to - 1];

            for(int i = 0; i < amount; i++)
            {
                char crate = fromStack.Pop();
                Stack<char> intermediary = new Stack<char>();
                intermediary.Push(crate);
                toStack.Push(crate);
            }
        }

        public static void Part2(string move, List<Stack<char>> stacks)
        {
            string[] split = move.Split(' ');

            int amount = int.Parse(split[1]);
            int from = int.Parse(split[3]);
            int to = int.Parse(split[5]);

            Stack<char> fromStack = stacks[from - 1];
            Stack<char> toStack = stacks[to - 1];

            Stack<char> intermediary = new Stack<char>();
            for (int i = 0; i < amount; i++)
            {
                char crate = fromStack.Pop();                
                intermediary.Push(crate);
            }
            
            while(intermediary.Count > 0)
            {
                char crate = intermediary.Pop();
                toStack.Push(crate);
            }
        }
    }
}
