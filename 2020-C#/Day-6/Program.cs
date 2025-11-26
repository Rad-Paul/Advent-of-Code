namespace Day_6
{
    internal class Program
    {
        static void Main()
        {
            Solutions();
        }

        public static void Solutions()
        {
            TextReader sr = new StreamReader("D:\\coding\\Personal\\AdventOfCode\\2020\\Day-6\\input.txt");
            string[] groups = sr.ReadToEnd().Split("\r\n\r\n");
            Part1(groups);
            Part2(groups);
        }

        public static void Part1(string[] groups)
        {
            int result = 0;
            for (int i = 0; i < groups.Length; i++)
            {
                HashSet<char> answered = new HashSet<char>();
                string current = groups[i]; 
                for (int j = 0; j < current.Length; j++)
                {
                    if (current[j] != '\r' && current[j] != '\n')
                    {
                        if (!answered.Contains(current[j]))
                        {
                            answered.Add(current[j]);
                        }
                    }
                }
                result += answered.Count;
            }
            Console.WriteLine(result);
        }

        public static void Part2(string[] groups)
        {
            int result = 0;
            for (int i = 0; i < groups.Length; i++)
            {
                Dictionary<char, int> answered = new Dictionary<char, int>();
                string[] current = groups[i].Split("\r\n");
                int answeredByAll = 0;
                for (int j = 0; j < current.Length; j++)
                {
                    string person = current[j];
                    for(int k = 0; k < person.Length; k++)
                    {
                        if (answered.ContainsKey(person[k]))
                        {
                            answered[person[k]]++;
                        }
                        else
                        {
                            answered.Add(person[k], 1);
                        }

                        if (answered[person[k]] == current.Length)
                        {
                            answeredByAll++;
                        }
                    }
                }
                //Console.WriteLine(answeredByAll);
                result += answeredByAll;
            }
            Console.WriteLine(result);
        }


    }
}
