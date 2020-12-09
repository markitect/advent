using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace Day7
{
    class Program
    {
        private static Dictionary<string, LinkedList<string>> bagRules;
        private static HashSet<string> validBags;
        static void Main(string[] args)
        {
            var input = File.ReadAllLines("input.txt");

            var goldBag = "shiny gold";
            var count = 0;
            
            bagRules = new Dictionary<string, LinkedList<string>>();

            validBags = new HashSet<string>() {goldBag};
            
            foreach (var line in input)
            {
                var rule = line.Split("contain");
                var bagRule = rule[0].Substring(0, rule[0].TrimEnd().LastIndexOf(' '));

                var matches = Regex.Matches(rule[1], "[0-9]+[\\s][a-z]+[\\s][a-z]+");
                
                bagRules.Add(bagRule, new LinkedList<string>(matches.Select(x => x.ToString().Substring(2))));
                
                
            }

            bool newBagFound;

            do
            {
                newBagFound = false;
                foreach (var bag in bagRules)
                {
                    if (IsValid(bag.Key))
                    {
                        if (!validBags.Contains(bag.Key))
                        {
                            validBags.Add(bag.Key);
                            newBagFound = true;
                        }
                    }
                }
            } while (newBagFound);

            Console.WriteLine(validBags.Count - 1);

        }

        static bool IsValid(string bag)
        {
            foreach (var subBag in bagRules[bag])
            {
                if (validBags.Contains(subBag))
                {
                    return true;
                }
                else
                {
                    IsValid(subBag);
                }
            }

            return false;
        }
    }
}