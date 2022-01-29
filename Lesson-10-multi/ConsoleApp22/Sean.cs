﻿using System;
using System.Collections.Concurrent;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using FuzzySharp;

namespace ConsoleApp22
{
    class Sean
    {
        public static void Run()
        {
            string[] nameList = File.ReadLines(@"C:\Dev\Teaching\Students\Sarah\MailingGroups\Week14\Duplicates\Duplicates\PlaceNamesUkWithC.txt").ToArray();

            var breakIndex = nameList.Count() - 1;
            var matchedNameList = new ConcurrentBag<MatchedName>();
            Parallel.For(0, breakIndex, (i, state) =>
            {
                var newMatchedName = new MatchedName();
                newMatchedName.Name1 = nameList[(int)i];
                double score;
                for (int x = 0; x < breakIndex; x++)
                {
                    if (newMatchedName.Name1.Equals(nameList[x]))
                    {
                        continue;
                    }
                    var name2 = nameList[x];
                    score = Fuzz.Ratio(newMatchedName.Name1, name2);
                    if (score > newMatchedName.Score)
                    {
                        newMatchedName.Score = score;
                        newMatchedName.Name2 = name2;
                    }
                }
                matchedNameList.Add(newMatchedName);
            });

            var matchedNameList2 = matchedNameList.OrderByDescending(x => x.Score).AsEnumerable();
            foreach (var scoring in matchedNameList2)
            {
                Console.WriteLine(scoring.ToString());
            }
        }
    }
    public class MatchedName
    {
        public MatchedName()
        {
            Score = 0;
        }
        public string Name1 { get; set; }
        public string Name2 { get; set; }
        public double Score { get; set; }
        public override string ToString()
        {
            return $"{Name1} -> {Name2}: {Score}";
        }
    }
}