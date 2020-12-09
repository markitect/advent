using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace Day7
{
    class Program
    {
        private static Dictionary<string, Dictionary<string, int>> bagRules;
        private static HashSet<string> validBags;
        
        static void Main(string[] args)
        {
            var input = File.ReadAllLines("input.txt");

            var goldBag = "shiny gold";
            var count = 0;
            
            bagRules = new Dictionary<string, Dictionary<string, int>>();

            validBags = new HashSet<string>() {goldBag};
            
            foreach (var line in input)
            {
                var rule = line.Split("contain");
                var bagRule = rule[0].Substring(0, rule[0].TrimEnd().LastIndexOf(' '));

                var matches = Regex.Matches(rule[1], "[0-9]+[\\s][a-z]+[\\s][a-z]+");
                var intMatches = Regex.Matches(rule[1], "[0-9]");
                var bagCounts = new Dictionary<string, int>();
                for (int i = 0; i < matches.Count; i++)
                {
                    bagCounts.Add(matches[i].Value.Substring(2), int.Parse(intMatches[i].Value));
                }

                bagRules.Add(bagRule, bagCounts);
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

            var numBags = CountBagsInBags(bagRules["shiny gold"]);
            
            Console.WriteLine(numBags);


        }

        static bool IsValid(string bag)
        {
            foreach (var subBag in bagRules[bag])
            {
                if (validBags.Contains(subBag.Key))
                {
                    return true;
                }
                else
                {
                    IsValid(subBag.Key);
                }
            }

            return false;
        }

        static int CountBagsInBags(Dictionary<string, int> bags)
        {
            var count = 0;
            
            foreach (var bag in bags)
            {
                count += bag.Value + (bag.Value * CountBagsInBags(bagRules[bag.Key]));
            }

            return count;
        }
    }
}