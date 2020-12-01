using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.IO.Enumeration;
using System.Linq;

namespace Day1
{
    class Program
    {
        private static List<string> input;
        
        static void Main(string[] args)
        {
            input = new List<string>(
                File.ReadLines("input.txt"));
            
            var numbers = input.Select(x => int.Parse(x)).ToList();
            bool found = false;
            
            
            //Faster?  No - less  loops but waaay slower - not sure why?
            var watch = Stopwatch.StartNew();
            numbers.Sort();
            var startIndex = 0;
            var endIndex = numbers.Count()-1;
            int loops = 0;

            while (startIndex < endIndex)
            {
                loops++;
                if (found) break;
                var sum = numbers[startIndex] + numbers[endIndex];
                if (sum == 2020)
                {
                    Console.WriteLine("Faster 1");
                    Console.WriteLine(numbers[startIndex] + " " + numbers[endIndex]);
                    Console.WriteLine(numbers[startIndex] * numbers[endIndex]);
                    Console.WriteLine("Time: " + watch.ElapsedTicks);
                    Console.WriteLine("Loops: " + loops);
                    found = true;
                }
                else if(sum < 2020)
                {
                    startIndex++;
                }
                else
                {
                    endIndex--;
                }
            }

            found = false;
            loops = 0;
            watch.Restart();

            //brute force 1
            for (int i = 0; i < numbers.Count(); ++i)
            {
                loops++;
                if (found) break;
                for (int j = 0; j < numbers.Count(); ++j)
                {
                    loops++;
                    if (i != j && numbers[i] + numbers[j] == 2020)
                    {
                        Console.WriteLine("Brute Force 1");
                        Console.WriteLine(numbers[i] + " " + numbers[j]);
                        Console.WriteLine(numbers[i] * numbers[j]);
                        Console.WriteLine("Time: " + watch.ElapsedTicks);
                        Console.WriteLine("Loops: " + loops);
                        found = true;
                        break;
                    }
                }
            }

            found = false;
            watch.Restart();

            //brute force 2
            for (int i = 0; i < numbers.Count(); ++i)
            {
                loops++;
                if (found) break;
                for (int j = 0; j < numbers.Count(); ++j)
                {
                    loops++;
                    if (found) break;
                    for (int k = 0; k < numbers.Count(); ++k)
                    {
                        loops++;
                        if (i != j && i != k && j != k && numbers[i] + numbers[j] + numbers[k] == 2020)
                        {
                            Console.WriteLine("Brute Force 2");
                            Console.WriteLine(numbers[i] + " " + numbers[j] + " " + numbers[k]);
                            Console.WriteLine(numbers[i] * numbers[j] * numbers[k]);
                            Console.WriteLine("Time: " + watch.ElapsedTicks);
                            Console.WriteLine("Loops: " + loops);
                            found = true;
                            break;
                        }
                    }
                }
            }

            Console.ReadKey();
        }
    }
}