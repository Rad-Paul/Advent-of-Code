namespace Day_11
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Part1();
        }

        public static void Part1()
        {
            string filepath = @"D:\coding\Personal\AdventOfCode\2022\Day-11\input.txt";
            TextReader reader = new StreamReader(filepath);

            string buffer = "";
            List<Monkey> monkeys = new List<Monkey>();

            while((buffer = reader.ReadLine()) != null)
            {
                monkeys.Add(GetMonkey(reader, buffer));
            }

            for(int i = 0; i < 20; 
                i++)
            {
                for(int j = 0; j < monkeys.Count; j++)
                {
                    Monkey current = monkeys[j];
                    while (current.Items.Count > 0)
                    {
                        current.InspectionCount++;
                        int worry = current.Items.Dequeue();
                        if(current.OpType == "+")
                        {
                            if(current.OpMod == "old")
                            {
                                worry += worry;
                            }
                            else
                            {
                                worry += int.Parse(current.OpMod);
                            }
                        }
                        if (current.OpType == "*")
                        {
                            if (current.OpMod == "old")
                            {
                                worry *= worry;
                            }
                            else
                            {
                                worry *= int.Parse(current.OpMod);
                            }
                        }

                        float division = worry / 3;
                        worry = (int)Math.Floor((double)worry / 3);

                        if(worry % current.Test == 0)
                        {
                            monkeys[current.TrueInd].Items.Enqueue(worry);
                        }
                        else
                        {
                            monkeys[current.FalseInd].Items.Enqueue(worry);
                        }
                    }
                }
            }

            List<int> inspections = new List<int>();
            for(int i = 0; i <  monkeys.Count; i++)
            {
                inspections.Add(monkeys[i].InspectionCount);
            }
            inspections.Sort();
            int monkeyBusiness = inspections[inspections.Count - 1] * inspections[inspections.Count - 2];
            Console.WriteLine(monkeyBusiness);
        }

        public static Monkey GetMonkey(TextReader reader, string buffer)
        {
            Queue<int> items = new Queue<int>();
            string opType; int test; string opMod;
            int trueInd; int falseInd;

            string[] split;
            //6 for empty line
            buffer = reader.ReadLine();
            
            split = buffer.Split(':');
            string[] itemLine = split[1].Split(',');
            for(int i = 0; i < itemLine.Length; i++)
            {
                itemLine[i] = itemLine[i].TrimStart();
                itemLine[i] = itemLine[i].TrimEnd();
            }
            for(int i = 0; i < itemLine.Length; i++)
            {
                items.Enqueue(int.Parse(itemLine[i]));
            }
            split = (buffer = reader.ReadLine()).Split(' ');
            opType = split[6]; opMod = split[7];
            split = (buffer = reader.ReadLine()).Split(' ');
            test = int.Parse(split[split.Length - 1]);
            split = (buffer = reader.ReadLine()).Split(' ');
            trueInd = int.Parse(split[split.Length - 1]);
            split = (buffer = reader.ReadLine()).Split(' ');
            falseInd = int.Parse(split[split.Length - 1]);
            reader.ReadLine();
            return new Monkey(items, opType, opMod, test, trueInd, falseInd);
        }
    }

    public class Monkey
    {
        public Queue<int> Items { get; set; } = new Queue<int>();
        public string OpType { get; set; } = "+";
        public string OpMod { get; set; } = "old";
        public int Test { get; set; } = 1;
        public int TrueInd { get; set; } = -1;
        public int FalseInd { get; set; } = -2;
        public int InspectionCount { get; set; } = 0;

        public Monkey(Queue<int> items, string opType, string opMod, int test, int trueInd, int falseInd)
        {
            Items = items;
            OpType = opType;
            OpMod = opMod;
            Test = test;
            TrueInd = trueInd;
            FalseInd = falseInd;
        }
    }
}
