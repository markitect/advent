using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Day9
{
    class Program
    {
        static void Main(string[] args)
        {
            var lines = File.ReadLines("input.txt");

            Queue<long> numbers = new Queue<long>(lines.Select(x => long.Parse(x)));

            var targetNumber = 70639851;
            var numberQueue = new Queue<long>();

            while (numbers.Any())
            {
                var sum = SumQueue(numberQueue);

                if(sum < targetNumber)
                {
                    numberQueue.Enqueue(numbers.Dequeue());
                }


                if (sum== targetNumber)
                {
                    Console.WriteLine(numberQueue.Min() + numberQueue.Max());
                    break;
                } 
                
                if (sum > targetNumber)
                {
                    numberQueue.Dequeue();
                }
            }

        }

        static long SumQueue(Queue<long> numbers)
        {
            var count = 0L;

            foreach (var number in numbers)
            {
                count += number;
            }

            return count;
        }

        static void Part1()
        {
            var lines = File.ReadLines("input.txt");

            Queue<long> numbers = new Queue<long>(lines.Select(x => long.Parse(x)));

            var validNumber = true;
            long number = 0;
            while (validNumber)
            {
                validNumber = false;
                var buffer = numbers.Take(26).ToList();
                number = buffer.Last();
                var possibleNumbers = buffer.Take(25).ToList();

                for (int i = 0; i < possibleNumbers.Count(); i++)
                {
                    for (int j = 0; j < possibleNumbers.Count(); j++)
                    {
                        if (i != j)
                        {
                            if (possibleNumbers[i] + possibleNumbers[j] == number)
                            {
                                validNumber = true;
                                break;
                            }
                        }
                    }

                    if (validNumber) break;
                }

                numbers.Dequeue();
            }

            Console.WriteLine(number);
        }
    }
}