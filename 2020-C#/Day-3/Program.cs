namespace Day3{
    class Program{
        static void Main(string[] args)
        {
            Solutions();
        }

        public static void Solutions(){
            TextReader sr = new StreamReader("D:/coding/Personal/AdventOfCode/2020/Day-3/input.txt");
            string[] map = sr.ReadToEnd().Split("\n");
            Console.WriteLine(Part1(map));

            int[][] part2Inputs = [[1, 1], [3,1], [5,1], [7,1], [1,2]];

            long answer = 1;
            for (int i = 0; i < part2Inputs.Length; i++)
            {
                int[] inputs = part2Inputs[i];
                long current = Part1(map, inputs[0], inputs[1]);
                Console.WriteLine(current);
                answer *= current;
            }
            Console.WriteLine(answer);
        }

        public static int Part1(string[] map, int movex = 3, int movey = 1){
            int y = 0;
            int x = 0;
            int rowLimit = map[0].Length - 1;

            int count = 0;
            while(true){
                y += movey;
                x = (x + movex) % rowLimit;
                if(y >= map.Length){
                    break;
                }
                else if(map[y][x] == '#'){
                    count++;
                }
            }

            return count;
        }   
    }
}