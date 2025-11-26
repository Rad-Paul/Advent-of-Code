namespace Day2{
    class Program{
        static void Main(string[] args){
            Solutions();
        }

        public static void Solutions(){
            Console.WriteLine(Part1());
            Console.WriteLine(Part2());
        }

        public static int Part1(){
            TextReader sr = new StreamReader("D:/coding/Personal/AdventOfCode/2020/Day-2/input.txt");
            int total = 0;
            string line;
            #pragma warning disable CS8600 // Converting null literal or possible null value to non-nullable type.
            while ((line = sr.ReadLine())!=null){
                string[] parts = line.Split(" ");
                string[] limits = parts[0].Split("-");

                int lowerLimit = int.Parse(limits[0]);
                int upperLimit = int.Parse(limits[1]);

                char current = parts[1][0];

                string password = parts[2];

                int count = 0; bool valid = true;
                for (int i = 0; i < password.Length; i++)
                {
                    char c = password[i];

                    if(c == current){
                        count++;
                        if(count > upperLimit){
                            valid = false;
                        }
                    }
                    if(!valid){break;}
                }
                if(count < lowerLimit || !valid){
                    continue;
                }
                total++;
            }

            return total;
        }

        public static int Part2(){
            TextReader sr = new StreamReader("D:/coding/Personal/AdventOfCode/2020/Day-2/input.txt");
            int total = 0;
            string line;
            #pragma warning disable CS8600 // Converting null literal or possible null value to non-nullable type.
            while ((line = sr.ReadLine())!=null){
                string[] parts = line.Split(" ");
                string[] limits = parts[0].Split("-");

                int firstIndex = int.Parse(limits[0]) - 1;
                int secondIndex = int.Parse(limits[1]) - 1;
                char current = parts[1][0];

                string password = parts[2];
                if(password[firstIndex] == current){
                    if(password[secondIndex] == current){
                        continue;
                    }else{
                        total++;
                    }
                }else if(password[secondIndex] == current){
                    if(password[firstIndex] == current){
                        continue;
                    }else{
                        total++;
                    }
                }
            }
            
            return total;
        }
    }
}