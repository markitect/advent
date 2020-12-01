using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day2
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length == 0)
            {
                InvalidInputMessage();
                return;
            }


            foreach (var arg in args)
            {
                var input = new Dictionary<List<int>, int>();

                try
                {
                    using (var inputFile = new StreamReader(arg))
                    {
                        string line;
                        while ((line = inputFile.ReadLine()) != null)
                        {
                            input.Add(new List<int>(line.Split('\t').Select(n => int.Parse(n)).ToArray()), 0);
                        }
                    }
                }
                catch (FileNotFoundException e)
                {
                    Console.WriteLine($"Input file {e.FileName} not found.");
                }

                var answer1 = CalculateCheckSum(input);
                var answer2 = CalculateDivisorCheckSum(input);

                //Console.WriteLine($"Input: {arg}");
                //Console.WriteLine();

                Console.WriteLine($"Answer 1: {answer1}");
                Console.WriteLine($"Answer 2: {answer2}");
                Console.WriteLine();
            }
            Console.ReadKey();
        }

        private static int CalculateDivisorCheckSum(Dictionary<List<int>, int> input)
        {
            for (var i = 0; i < input.Count; ++i)
            {
                var line = input.ElementAt(i);
                line.Key.Sort();
                for (var j = 0; j < line.Key.Count - 1; ++j)
                {
                    for (var k = j+1; k < line.Key.Count; ++k)
                    {
                        var x = line.Key[j];
                        var y = line.Key[k];
                        if (y % x == 0)
                        {
                            input[line.Key] = y / x;
                            break;
                        }
                    }
                }
            }

            return input.Values.Sum();
        }

        private static int CalculateCheckSum(Dictionary<List<int>, int> input)
        {
            for(var i = 0; i < input.Count; ++i)
            {
                var line = input.ElementAt(i);
                var min = int.MaxValue;
                var max = 0;
                foreach(var number in line.Key)
                {
                    if(number < min)
                    {
                        min = number;
                    }

                    if(number > max)
                    {
                        max = number;
                    }
                }

                input[line.Key] = max - min;
            }

            return input.Values.Sum();
        }

        private static void InvalidInputMessage()
        {
            Console.WriteLine("Invalid input.");
            Console.ReadKey();
        }
    }
}
