namespace Day_3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string filepath = @"D:\coding\Personal\AdventOfCode\2022\Day-3\input.txt";
            Part2(filepath);
        }

        public static void Part1(string filepath)
        {
            TextReader reader = new StreamReader(filepath);
            string buffer;
           
            int sum = 0;
            while((buffer = reader.ReadLine()) != null)
            {
                sum += GetCharValue(FindCommonChar(buffer));
            }

            Console.WriteLine(sum);
        }
        public static void Part2(string filepath)
        {
            TextReader reader = new StreamReader(filepath);
            string buffer;

            int sum = 0;
            List<string> lines = new List<string>();
            while ((buffer = reader.ReadLine()) != null)
            {
                lines.Add(buffer);
                if(lines.Count == 3)
                {
                    sum += GetCharValue(FindGroupCommonItem(lines));
                    lines = new List<string>();
                }          
            }

            Console.WriteLine(sum);
        }
        public static int GetCharValue(char c)
        {
            int a = 1; int A = 27; //ascii A = 65, Z = 90
            int z = 26; int Z = 52; //ascii a = 97, z = 122;
            int lowerDiff = 96;
            int upperDiff = (int)'A'-A;

            int result = 0;
            if (char.IsUpper(c))
            {
                result = (int)c - upperDiff;
            }
            else
            {
                result = (int)c - lowerDiff;
            }

            Console.WriteLine(c + " " + result);
            return result;
        }
        public static char FindGroupCommonItem(List<string> lines)
        {
            Dictionary<char, bool[]> LinesCharCount = new Dictionary<char, bool[]>();

            int amount = 0; //how many we're looking for
            for(int i = 0; i < lines.Count; i++)
            {
                string line = lines[i];
                amount++;
                for (int j = 0; j < line.Length; j++)
                {
                    if (!LinesCharCount.ContainsKey(line[j]))
                    {
                        LinesCharCount.Add(line[j], new bool[3]);
                        LinesCharCount[line[j]][i] = true;
                    }
                    else
                    {
                        LinesCharCount[line[j]][i] = true;
                    }
                }

            }

            bool found;
            foreach(KeyValuePair<char, bool[]> pair in LinesCharCount)
            {
                found = true;
                for(int i = 0; i < pair.Value.Length; i++)
                {
                    if (pair.Value[i] == false)
                    {
                        found = false;
                        break;
                    }
                }
                if (found)
                {
                    return pair.Key;
                }
            }

            return '0';
        }
        public static char FindCommonChar(string input)
        {
            Dictionary<char, int> firstCompartment = new Dictionary<char, int>();
            Dictionary<char, int> SecondCompartment = new Dictionary<char, int>();

            int midPoint = input.Length / 2;
            for(int i = 0; i < input.Length / 2; i++)
            {
                int j = i + midPoint;
                if (!firstCompartment.ContainsKey(input[i]))
                {
                    firstCompartment.Add(input[i], 1);
                }
                else 
                {
                    firstCompartment[input[i]]++; 
                }
                if (!SecondCompartment.ContainsKey(input[j]))
                {
                    SecondCompartment.Add(input[j], 1);
                }
                else
                {
                    SecondCompartment[input[j]]++;
                }

                if (firstCompartment.ContainsKey(input[j]))
                {
                    return input[j];
                }
                else if (SecondCompartment.ContainsKey(input[i]))
                {
                    return input[i];
                }
            }

            return '0';
        }
    }
}
