class Program
{
    static void Main()
    {
        string filepath = "D:\\coding\\Personal\\AdventOfCode\\2020\\Day-7\\input.txt";
        TextReader reader = new StreamReader(filepath);
        string buffer;

        Dictionary<string, List<Bag>> bagMap = new Dictionary<string, List<Bag>>();
        HashSet<string> canContain = new HashSet<string>();
        while ((buffer = reader.ReadLine()) != null)
        {
            string[] line = buffer.Split(" bags contain ");
            List<Bag> bags = new List<Bag>();
            string[] containedBags = line[1].Split(", ");
            foreach (string s in containedBags)
            {
                string[] details = s.Split(" ");
                string type = details[1] + " " + details[2];
                if (type == "shiny gold")
                {
                    canContain.Add(line[0]);
                }
                if (details[0] != "no")
                {
                    Bag b = new Bag(int.Parse(details[0]), type);
                    bags.Add(b);
                }
            }
            bagMap.Add(line[0], bags);
        }
        Part1(bagMap, canContain);
        Part2(bagMap);
    }
    public static void Part1(Dictionary<string, List<Bag>> bagMap, HashSet<string> canContain)
    {
        int result = 0;
        foreach (string s in bagMap.Keys) {
            List<Bag> bags = bagMap[s];
            for (int i = 0; i < bags.Count; i++)
            {
                int has = DFS(bagMap, canContain, bags[i]);
                if(has == 1)
                {
                    if (!canContain.Contains(s))
                    {
                        canContain.Add(s);
                    }
                    result += has;
                    break;
                }
            }
        }
        Console.WriteLine(result);

        foreach (string s in canContain) { 
            //Console.WriteLine(s);
        }
    }
    public static void Part2(Dictionary<string, List<Bag>> bagMap)
    {
        int total = 0;
        List<Bag> bags = bagMap["shiny gold"];
        for (int i = 0; i < bags.Count; i++)
        {
            total += DFS2(bagMap, bags[i], bags[i].Count);
        }
   
        Console.WriteLine(total);
    }
    public static int DFS(Dictionary<string, List<Bag>> bagMap, HashSet<string> canContain, Bag bag)
    {
        if (canContain.Contains(bag.Type) || bag.Type == "shiny gold")
        {
            return 1;
        }

        List<Bag> bags = bagMap[bag.Type];
        for (int i = 0; i < bags.Count; i++)
        {
            int has = DFS(bagMap, canContain, bags[i]);
            if (has == 1)
            {
                if (!canContain.Contains(bag.Type))
                {
                    canContain.Add(bag.Type);
                }
                return 1;
            }
        }
        return 0;
    }
    public static int DFS2(Dictionary<string, List<Bag>> bagMap, Bag bag, int amount)
    {
        int total = amount;
        List<Bag> bags = bagMap[bag.Type];
        for (int i = 0; i < bags.Count; i++)
        {
            total += DFS2(bagMap, bags[i], amount * bags[i].Count);
        }
        return total;
    }
    public class Bag
    {
        public int Count { get; set; }
        public string Type { get; set; }

        public Bag(int count, string type = "") { 
            Count = count;
            Type = type;
        }
    }
}