using System;
using System.Collections.Generic;
using System.IO;

namespace Day6
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = File.ReadAllLines("input.txt");
            
            var answerSet = new Dictionary<char, int>();

            var count = 0;
            var personCount = 0;

            for(var i = 0; i < input.Length; ++i)
            {
                if (!string.IsNullOrWhiteSpace(input[i]) && i != input.Length - 1)
                {
                    ++personCount;
                    foreach (var answer in input[i])
                    {
                        if (answerSet.ContainsKey(answer))
                        {
                            answerSet[answer]++;
                        }
                        else
                        {
                            answerSet.Add(answer, 1);
                        }
                    }
                }
                else
                {
                    var allYesCount = 0;
                    foreach (var answer in answerSet)
                    {
                        if (answer.Value == personCount)
                        {
                            allYesCount++;
                        }
                    }

                    count += allYesCount;
                    personCount = 0;
                    answerSet.Clear();
                }
            }
            
            Console.WriteLine(count);
            Console.ReadKey();
        }
    }
}