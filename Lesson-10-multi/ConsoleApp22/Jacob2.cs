
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using FuzzySharp;


namespace ConsoleApp22
{
    class Jacob2
    {
        public static void Run()
        {
            var names = File.ReadLines(@"C:\Dev\Teaching\Students\Sarah\MailingGroups\Week14\Duplicates\Duplicates\PlaceNamesUkWithC.txt").ToArray();
            List<MatchedResults> results = new List<MatchedResults>();

            Parallel.ForEach(names, baseName =>
            {
                List<MatchedResults> comparativeValues = new List<MatchedResults>();

                foreach (string comparedName in names)
                {
                    if (baseName != comparedName)
                    {
                        double score = Fuzz.Ratio(baseName, comparedName);
                        comparativeValues.Add(
                            new MatchedResults(baseName, comparedName, score)
                        );
                    }
                };
                var bestMatch = comparativeValues.OrderByDescending(x => x.Score).FirstOrDefault();
                results.Add(bestMatch);
            });

            var orderedResults = results.OrderByDescending(x => x.Score).AsEnumerable();
            foreach (var result in orderedResults)
            {
                Console.WriteLine($"{result.Score}: {result.BaseName} -> {result.ComparedName}");
            }
        }

        public class MatchedResults
        {
            public string BaseName { get; set; }
            public string ComparedName { get; set; }
            public double Score { get; set; }

            public MatchedResults(string baseName, string comparedName, double score)
            {
                BaseName = baseName;
                ComparedName = comparedName;
                Score = score;
            }
        }
    }
}
