using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Numerics;
using System.Security.Cryptography;
class Program
{
    static void Main(string[] args)
    {
        string filepath = @"D:\coding\Personal\AdventOfCode\2023\Day-5\input.txt";
        TextReader sr = new StreamReader(filepath);

        string buffer;
        List<long> seeds = new List<long>();
        buffer = sr.ReadLine();

        string[] line = buffer.Split(' ');
        for(int i = 1; i < line.Length; i++)
        {
            seeds.Add(long.Parse(line[i]));
        }

        List<Map> maps = new List<Map>();
        Map currentMap = new Map();
        while((buffer = sr.ReadLine()) != null)
        {
            if(buffer == "")
            {
                currentMap = new Map();
                maps.Add(currentMap);
                sr.ReadLine(); //skip the map description line
                continue;
            }
            else
            {
                string[] input = buffer.Split(" ");
                long destStart = long.Parse(input[0]);
                long srcStart = long.Parse(input[1]);
                long length = long.Parse(input[2]);
                currentMap.Ranges.Add(new Range(destStart, srcStart, length));
            }           
        }

        Console.WriteLine(AOC5PART2(maps, seeds));
    }

    public static long AOC5PART1(List<Map> maps, List<long> seeds)
    {
        List<long> locations = new List<long>();
        long bestLocation = int.MaxValue;

        foreach(long seed in seeds)
        {
            long currentResult = seed;
            foreach(Map map in maps)
            {
                currentResult = GetLocation(map, currentResult);
            }
            if (currentResult < bestLocation)
            {
                bestLocation = currentResult;
            }
            locations.Add(currentResult);
        }

        int minecraft = 0;
        return bestLocation;
    }
    public static long GetLocation(Map map, long seed)
    {
        List<Range> ranges = map.Ranges;
        long minLocation = long.MaxValue;

        for(int i = 0; i <  ranges.Count; i++)
        {
            Range range = ranges[i];
            long startRange = range.srcStart + range.length - 1;

            if(seed < range.srcStart || seed > startRange) { continue; }
            long offset = seed - range.srcStart;
            long location = offset + range.destStart;
            if(location < minLocation)
            {
                minLocation = location;
            }
        }
        if(minLocation == long.MaxValue) { return seed; }
        return minLocation;
    }
    public static long AOC5PART2(List<Map> maps, List<long> seeds)
    {
        List<long> locations = new List<long>();
        long bestLocation = int.MaxValue;

        for(int i = 0; i < seeds.Count / 2; i+=2)
        {
            long seedStart = seeds[i];
            long seedEnd = seeds[i + 1];
            SeedRange current = new SeedRange(seedStart, seedEnd);
            foreach(Map map in maps)
            {
                current = GetLocationPart2(map, current);
            }
            if (current.start < bestLocation)
            {
                bestLocation = current.start;
            }
            locations.Add(current.start);
        }
        int minecraft = 0;
        return bestLocation;
    }
    public static SeedRange GetLocationPart2(Map map, SeedRange inputSeedRange)
    {
        List<Range> ranges = map.Ranges;
        SeedRange toR = new SeedRange(long.MaxValue, long.MaxValue);
        for (int i = 0; i < ranges.Count; i++)
        {          
            
        }
        if(toR.start == long.MaxValue)
        {
            return inputSeedRange;
        }
        
        return toR;
    }
    public class Map()
    {
        public List<Range> Ranges { get; set;} = new List<Range>();
    }
    public class Range()
    {
        public long destStart { get; set; }
        public long srcStart { get; set; }
        public long length { get; set; }

        public Range(long deststart, long srcstart, long length) :this()
        {
            this.destStart = deststart;
            this.srcStart = srcstart;
            this.length = length;
        }
    }
    public class SeedRange()
    {
        public long start { get; set; } = 0;
        public long end { get; set; } = 0;
        public SeedRange(long str, long length) :this()
        {
           start = str;
           this.end = length + str-1;
        }
    }
}