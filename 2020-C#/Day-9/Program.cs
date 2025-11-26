namespace Day_9
{
    internal class Program
    {
        static void Main(string[] args)
        {
            TextReader reader = new StreamReader("D:\\coding\\Personal\\AdventOfCode\\2020\\Day-9\\input.txt");
            string input = reader.ReadToEnd();
            Part1(input);
        }

        public static void Part1(string input, int length = 25)
        {
            string[] nums = input.Split("\r\n");
            Dictionary<int, int> set = new Dictionary<int, int>();
            int tail = 0; int head = length-1;
            for(int i = 0; i < length; i++)
            { 
                set.Add(i,int.Parse(nums[i]));
            }

            for (int i = length; i < nums.Length; i++) 
            {
                bool valid = false;
                int current = int.Parse(nums[i]);
                foreach (var pair in set) 
                {
                   if(set.ContainsValue(Math.Abs(pair.Value - current)))
                   {
                        set.Remove(tail);
                        tail++;
                        head++;
                        set.Add(head, current);
                        valid = true;
                        break;
                   }
                }
                if (!valid)
                {
                    Console.WriteLine(current);
                    Part2(nums, current);
                    break;
                }
            }


        }

        public static void Part2(string[] nums, long target)
        {
            LinkedList<long> list = new LinkedList<long>();
            long currentSum = 0;
            int end = 0;
            while(true)
            {
                if(currentSum < target)
                {
                    long num = long.Parse(nums[end]);
                    currentSum += num;
                    list.AddLast(num);
                    end++;
                }
                else if(currentSum == target)
                {
                    long min = list.Min();
                    long max = list.Max();
                    Console.WriteLine($"Min:{min} Max:{max}");
                    Console.WriteLine("Sum:" + (min + max));
                    break;
                }
                else
                {
                    currentSum -= list.First.Value;
                    list.RemoveFirst();
                }
            }
        }
    }
}
