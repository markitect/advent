using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;

namespace Day10
{
    class Program
    {
        struct TrieNode
        {
            public int value;
            public List<TrieNode> links;
            public bool visited;
        }

        private static List<ulong> numbers;
        
        static void Main(string[] args)
        {
            var inputLines = File.ReadAllLines("input.txt");
            //var inputLines = File.ReadAllLines("test.txt");
            numbers = inputLines.Select(x => ulong.Parse(x)).ToList();
            numbers.Add(numbers.Last() + 3);
            numbers.Add(0);
            numbers.Sort();

            Dictionary<int, int> differences = new Dictionary<int, int>();
            TrieNode configs = new TrieNode() {value = 0, links = new List<TrieNode>()};

            //differences.Add(numbers[0], 1);
            //differences.Add(3, 1);

            //FindConfigs(configs);
            //CountConfigs(configs);
            
            var count = countToMax(1, numbers) + countToMax(2, numbers) + countToMax(3, numbers);
            
            Console.WriteLine(count);

            //Console.WriteLine(differences[1] * differences[3]);
        }

        // static void FindConfigs(TrieNode node)
        // {
        //     if (node.visited) return;
        //     var startIndex = Math.Max(0, numbers.IndexOf(node.value));
        //     node.visited = true;
        //     for (var i = startIndex; i < numbers.Count; ++i)
        //     {
        //         if (numbers[i] - node.value <= 3 && numbers[i] - node.value > 0)
        //         { 
        //             var linkExists = false;
        //             foreach (var nodeLink in node.links)
        //             {
        //                 if (nodeLink.value == numbers[i])
        //                 {
        //                     linkExists = true;
        //                 }
        //             }
        //
        //             if (!linkExists)
        //             {
        //                 node.links.Add(new TrieNode() {value = numbers[i], links = new List<TrieNode>()});
        //             }
        //         }
        //         else
        //         {
        //             foreach (var link in node.links)
        //             {
        //                 FindConfigs(link);
        //             }
        //         }
        //     }
        // }

        // private static int count = 0;
        //
        // static void CountConfigs(TrieNode configs)
        // {
        //     foreach (var link in configs.links)
        //     {
        //         if (link.links.Any())
        //         {
        //             CountConfigs(link);
        //         }
        //         else if(link.value == numbers.Last())
        //         {
        //             count++;
        //         }
        //     }
        // }
        
        static Dictionary<ulong, ulong> dict = new Dictionary<ulong, ulong>();
        private static ulong countToMax(ulong i, List<ulong> elems)
        {
            if (dict.ContainsKey(i))
                return dict[i];
            ulong res = 0;
            if (elems.Contains(i) == false)
            {
                res = 0;
            }
            else
            {
                if (i > elems.Last()) 
                    res = 0;
                else if (i == elems.Last())
                    res = 1;
                else
                    res = countToMax(i + 1, elems) + countToMax(i + 2, elems) + countToMax(i + 3, elems);
            }
            dict[i] = res;
            return res;
        }
    }
}