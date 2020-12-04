using System;
using System.Collections.Generic;
using System.IO;

namespace Day3
{
    class Program
    {
        static void Main(string[] args)
        {
            var paths = File.ReadAllLines("input.txt");

            long treeCount = 0;
            var treeCountList = new List<long>();
            var lateralMove = new int[] {1, 3, 5, 7, 1};
            var downMove = new int[] {1, 1, 1, 1, 2};

            var x = 0;
            var y = 0;

            for (var moveIndex = 0; moveIndex < lateralMove.Length; ++moveIndex)
            {
                while (y < paths.Length - 1)
                {
                    x += lateralMove[moveIndex];
                    if (x >= paths[y].Length)
                    {
                        x -= paths[y].Length;
                    }

                    y += downMove[moveIndex];
                    if (paths[y][x] == '#')
                    {
                        treeCount++;
                    }
                }
                treeCountList.Add(treeCount);
                treeCount = 0;
                x = 0;
                y = 0;
            }

            treeCount = treeCountList[0];
            for (var index = 1; index < treeCountList.Count; ++index)
            {
                treeCount *= treeCountList[index];
            }

            Console.WriteLine("Tree count: " + treeCount);
            Console.ReadKey();
        }
    }
}