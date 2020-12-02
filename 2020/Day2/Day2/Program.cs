using System;
using System.Collections.Generic;
using System.IO;

namespace Day2
{
    class Program
    {
        struct Entry
        {
            public int min;
            public int max;
            public char letter;
            public char[] password;
        }
        static void Main(string[] args)
        {
            var input = File.ReadLines("input.txt");

            var entryList = new List<Entry>();

            foreach (var inputString in input)
            {
                var dashIndex = inputString.IndexOf('-');
                var spaceIndex = inputString.IndexOf(' ');
                var colonIndex = inputString.IndexOf(':');

                var min = int.Parse(inputString.Substring(0, dashIndex));
                var max = int.Parse(inputString.Substring(dashIndex+1, spaceIndex - (dashIndex+1)));
                var letter = inputString.Substring(colonIndex -1, 1)[0];
                var password = inputString.Substring(colonIndex+2).ToCharArray();
                entryList.Add(new Entry {min = min, max = max, letter = letter, password = password});
            }

            int validCount = 0;
/*
            foreach (var entry in entryList)
            {
                var count = 0;
                foreach (var letter in entry.password)
                {
                    if (letter == entry.letter)
                    {
                        count++;
                    }

                    if (count > entry.max)
                    {
                        break;
                    }
                }
                
                if (count <= entry.max && count >= entry.min)
                {
                    validCount++;
                }
            }
            */
            
            foreach (var entry in entryList)
            {

                if (entry.min-1 < entry.password.Length && entry.max-1 < entry.password.Length)
                {
                    if (entry.password[entry.min-1] == entry.letter ^ entry.password[entry.max-1] == entry.letter)
                    {
                        validCount++;
                    }
                }
            }
            
            Console.WriteLine(validCount);
            Console.ReadKey();

        }
    }
}
