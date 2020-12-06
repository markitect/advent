using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Day4
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = File.ReadAllLines("input.txt");

            var validCount = 0;
            var processedCount = 0;
            var lineCount = 0;
            var fieldCount = 0;
            var hasCID = false;

            Dictionary<string, bool> fieldChecks = new Dictionary<string, bool>
            {
                {"byr", false},
                {"cid", false},
                {"iyr", false},
                {"hgt", false},
                {"eyr", false},
                {"pid", false},
                {"hcl", false},
                {"ecl", false}
            };



            foreach (var line in input)
            {
                if (string.IsNullOrWhiteSpace(line))
                {
                    processedCount++;
                }
            }
            
            Console.WriteLine(processedCount);

            foreach (var inputLine in input)
            {
                ++lineCount;
                if (inputLine.Length > 0 || lineCount == input.Length-2)
                {
                    var fields = inputLine.Split(' ');
                    foreach (var field in fields)
                    {
                        var fieldName = field.Split(':')[0];
                        fieldChecks[fieldName] = true;
                    }
                }
                else
                {
                    bool valid = true;
                    foreach (var field in fieldChecks)
                    {
                        if (field.Value == false && field.Key != "cid")
                        {
                            valid = false;
                            break;
                        }
                    }

                    if (valid)
                    {
                        ++validCount;
                    }

                    fieldChecks = fieldChecks.ToDictionary(p => p.Key, p => false);
                }
            }

            Console.WriteLine("Count: " + validCount + " out of " + processedCount);
            Console.ReadKey();
        }
    }
}
