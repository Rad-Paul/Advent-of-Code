namespace Test{
    class Program{
        static void Main(string[] args){
            Solutions();
        }

        public static void Solutions(){
            TextReader sr = new StreamReader("D:/coding/Personal/AdventOfCode/2020/Day-1/input.txt");
            string input = sr.ReadToEnd();
            string[] lines = input.Split("\n");
            
            Console.WriteLine(Part1(lines));
            Console.WriteLine(Part2(lines));
        }   

        public static int Part1(string[] lines){
            HashSet<int> set = new HashSet<int>();
            int goal = 2020;
            for(int i = 0; i < lines.Length; i++){
                int current = int.Parse(lines[i]);
                if(set.Contains(goal - current)){
                    return current * (goal - current);
                }else{
                    set.Add(current);
                }
                set.Add(current);
            }
            return 0;
        }   

        public static int Part2(string[] lines){
            HashSet<int> set = new HashSet<int>();
            int goal = 2020;
            for(int i = 0; i < lines.Length; i++){
                int current = int.Parse(lines[i]);
                
                foreach(int entry in set){
                    int needed = goal - current - entry;
                    if(set.Contains(needed)){
                        return current * entry * needed;
                    }
                }

                set.Add(current);
            }
            return 0;
        }  
    }
}