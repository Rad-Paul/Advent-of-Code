namespace Day_9
{
    internal class Program
    {
        static void Main(string[] args)
        {                        
            Part1();
        }

        public static void Part1()
        {
            HashSet<Coords> set = new HashSet<Coords>();
            Coords head = new Coords(100,100);
            Coords tail = new Coords(100,100);

            set.Add(tail);

            string filepath = @"D:\coding\Personal\AdventOfCode\2022\Day-9\input.txt";
            TextReader sr = new StreamReader(filepath);

            string buffer;
            while((buffer = sr.ReadLine()) != null)
            {
                string[] line = buffer.Split(' ');
                Move(line[0], int.Parse(line[1]), ref head, ref tail, ref set);
            }

            Console.WriteLine(set.Count);
        }

        public static void Move(string direction, int distance, ref Coords head, ref Coords tail, ref HashSet<Coords> set)
        {
            for (int i = 0; i < distance; i++)
            {
                Coords prev = head;
                if (direction == "U")
                {
                    head.y++;                    
                }
                else if (direction == "R")
                {
                    head.x++;
                }
                else if (direction == "D")
                {
                    head.y--;
                }
                else if (direction == "L")
                {
                    head.x--;
                }

                if(!IsTouching(ref head, ref tail))
                {
                    tail = prev;
                    set.Add(prev);
                }
            }
        }

        public static bool IsTouching(ref Coords head, ref Coords tail)
        {
            //Why not work
            //int horizontalDif = Math.Abs(Math.Abs(head.x) - Math.Abs(tail.x));
            //int verticalDif = Math.Abs(Math.Abs(head.y) - Math.Abs(tail.y));

            int horizontalDif = Math.Abs(head.x - tail.x);
            int verticalDif = Math.Abs(head.y - tail.y);
            //diagonal
            //if (horizontalDif == 2 && verticalDif == 2)
            //{
            //    return true;
            //}

            if (horizontalDif >= 2 || verticalDif >= 2)
            {
                return false;
            }            

            return true;
        }
    }
   
    public struct Coords() : IEquatable<Coords>
    {
        public int x { get; set; }
        public int y { get; set; } 

        public Coords(int x, int y) :this()
        {
            this.x = x;
            this.y = y;
        }

        public bool Equals(Coords other)
        {
            if(this.x == other.x && this.y == other.y)
            {
                return true;
            }
            return false;
        }
    }
}
