namespace Day_1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string filepath = @"D:\coding\Personal\AdventOfCode\2022\Day-1\Day-1\input.txt";
            Part2(filepath);
        }

        public static void Part1(string filepath)
        {
            TextReader sr = new StreamReader(filepath);
            //or add it to array and do .Max :)

            //Dictionary<int, int> ElfInventories = new Dictionary<int, int>();
            string buffer;
            int sum = 0;
            int max = int.MinValue;
            while((buffer = sr.ReadLine()) != null)
            {
                if(buffer == "")
                {
                    if(sum > max)
                    {
                        max = sum;
                    }
                    sum = 0;
                    continue;
                }

                sum += int.Parse(buffer);
            }

            Console.WriteLine(max);
        }

        public static void Part2(string filepath)
        {
            //or sort the list and get the 3 elements
            TextReader sr = new StreamReader(filepath);
            int[] maxValues = new int[3];
            for(int i = 0; i < maxValues.Length; i++)
            {
                maxValues[i] = int.MinValue;
            }
            //Dictionary<int, int> ElfInventories = new Dictionary<int, int>();
            string buffer;
            int sum = 0;

            while ((buffer = sr.ReadLine()) != null)
            {
                if (buffer == "")
                {
                    for(int i = 0; i < maxValues.Length; i++)
                    {
                        if(sum > maxValues[i])
                        {
                            int replaced = maxValues[i];
                            maxValues[i] = sum;
                            Recalculate(replaced);
                            break;
                        }
                    }
                    sum = 0;
                    continue;
                }

                sum += int.Parse(buffer);
            }

            if(sum != 0) 
            { 
                Recalculate(sum);  
                sum = 0; 
            }
            for (int i = 0; i < maxValues.Length; i++)
            {
                sum += maxValues[i];
                Console.WriteLine(maxValues[i]);
            }
            Console.WriteLine(sum);

            void Recalculate(int val)
            {
                for(int i = 0; i < maxValues.Length; i++)
                {
                    if(val > maxValues[i])
                    {
                        int replaced = maxValues[i];
                        maxValues[i] = val;
                        Recalculate(replaced);
                        break;
                    }
                }
            }
        }
    }
}
