
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using FuzzySharp;


namespace ConsoleApp22
{
    class Sean2
    {
        public static void Run()
        {
            var nameList = File.ReadLines(@"C:\Dev\Teaching\Students\Sarah\MailingGroups\Week14\Duplicates\Duplicates\PlaceNamesUkWithC.txt").ToArray();

            var breakIndex = nameList.Count() - 1;
            var matchedNameList = new ConcurrentBag<MatchedNameSean>();
            Parallel.For(0, breakIndex, (i, state) =>
            {
                var newMatchedNameSean = new MatchedNameSean();
                newMatchedNameSean.Name1 = nameList[(int)i];
                double score;
                for (int x = 0; x < breakIndex; x++)
                {
                    if (i == x)
                    {
                        continue;
                    }
                    var name2 = nameList[x];
                    score = Fuzz.Ratio(newMatchedNameSean.Name1, name2);
                    if (score > newMatchedNameSean.Score)
                    {
                        newMatchedNameSean.Score = score;
                        newMatchedNameSean.Name2 = name2;
                    }
                }
                matchedNameList.Add(newMatchedNameSean);
            });
            var matchedNameList2 = matchedNameList.OrderByDescending(x => x.Score).AsEnumerable();
            foreach (var scoring in matchedNameList2)
            {
                Console.WriteLine(scoring.ToString());
            }
        }
    }

    public class MatchedNameSean
    {
        public MatchedNameSean()
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
