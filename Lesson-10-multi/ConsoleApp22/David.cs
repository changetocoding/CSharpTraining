using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FuzzySharp;

namespace ConsoleApp22
{
    class David
    {
        public static void Run()
        {
            var names = File
                .ReadLines(
                    @"C:\Dev\Teaching\Students\Sarah\MailingGroups\Week14\Duplicates\Duplicates\PlaceNamesUkWithC.txt")
                .ToArray();
            DoIt(names);
        }

        public static void DoIt(string[] values)
        {
            var results = CompareIt(values);
            DisplayOrdered(results);
        }

        public static List<FinalScore> CompareIt(string[] values)
        {
            var results = new ConcurrentDictionary<int, FinalScore>();
            Parallel.For(0, values.Length, (index) =>
            {
                var result = StringToCompare(index, values);
                results.TryAdd(index, new FinalScore(values[index], result.StringTwo, result.Score));
            });

            return results.Values.ToList();
        }

        private static void DisplayOrdered(List<FinalScore> results)
        {
            var sorted = results.OrderByDescending(x => x.Score).ToList();
            foreach (var finalScore in sorted)
            {
                Console.WriteLine(finalScore);
            }
        }

        private static ComparisonScore StringToCompare(int index, string[] fullList)
        {
            // var stopWatch = Stopwatch.StartNew();
            var current = fullList[index];
            var topDog = new ComparisonScore("", 0);
            for (int i = 0; i < fullList.Length; i++)
            {
                if (i == index)
                    continue;

                var score = Fuzz.Ratio(current, fullList[i]);

                if (score > topDog.Score)
                {
                    topDog = new ComparisonScore(fullList[i], score);
                }
            }

            return topDog;
        }
    }


    public class FinalScore
    {
        public FinalScore(string ours, string stringTwo, int score)
        {
            Ours = ours;
            StringTwo = stringTwo;
            Score = score;
        }

        public string Ours { get; }
        public string StringTwo { get; }
        public int Score { get; }

        public override string ToString()
        {
            return $"{Ours} -> {StringTwo} : {Score}";
        }
    }

    public class ComparisonScore
    {
        public ComparisonScore()
        {

        }
        public ComparisonScore(string other, int score)
        {
            StringTwo = other;
            Score = score;
        }
        public string StringTwo { get; set; }
        public int Score { get; set; }
    }

    public class StringsToCompare
    {
        private List<string> _stringList = new List<string>();


        // For multi-Threading there is a concurrent dictionary (which prevents some problems I'll explain in the next lesson).
        // https://docs.microsoft.com/en-us/dotnet/api/system.collections.concurrent.concurrentdictionary-2?view=netcore-3.1
        // But I think a Dictionary will also work (90% certain, depending on how you set up your multithreading). So I want you to do it with a dictionary.
        // Best to learn the hard way about these problems haha :D). You may lose some entries but ok with that.
        private Dictionary<string, ComparisonScore> _DictionaryFuzzyResults = new Dictionary<string, ComparisonScore>();

        private object _lock = new object();

        public void AddStringToList(string name)
        {
            _stringList.Add(name);
        }

        public void StringToCompareMultiThreading()
        {
            var stopWatch = Stopwatch.StartNew();
            // foreach (string name in _stringList)
            Parallel.ForEach(_stringList, name =>
            {
                var indexOfNameToCompare = _stringList.IndexOf(name);
                var stringListWithoutStringToCompare =
                    _stringList.Where((v, i) => i != indexOfNameToCompare).ToList();
                lock (_lock)
                {
                    if (!_DictionaryFuzzyResults.ContainsKey(name))
                    {
                        _DictionaryFuzzyResults.Add(name, new ComparisonScore()

                        {
                            StringTwo = "",
                            Score = 0
                        });
                    }
                }

                CompareStringToListMultiThreading(stringListWithoutStringToCompare, name);
            }
            );
            Console.WriteLine("Parallel 1st forEach loop execution time = {0} seconds\n", stopWatch.Elapsed.TotalSeconds);
        }

        public Dictionary<string, ComparisonScore> CompareStringToListMultiThreading(IEnumerable<string> stringList,
            string stringToCompare)
        {
            var stopWatch = Stopwatch.StartNew();
            //foreach (string name in stringList)
            Parallel.ForEach(stringList, name =>

            {
                var stringsBeingCompared = stringToCompare + " v " + name;
                var result = Fuzz.WeightedRatio(stringToCompare, name);
                // Console.WriteLine($"{stringsBeingCompared} : {result}");
                var isHigherThanExistingResult = _DictionaryFuzzyResults[stringToCompare].Score < result;
                if (isHigherThanExistingResult)
                    lock (_lock)
                    {
                        _DictionaryFuzzyResults[stringToCompare] = new ComparisonScore()
                        {
                            StringTwo = name,
                            Score = result
                        };
                    }
            }
            );

            Console.WriteLine("Parallel 2nd forEach loop execution time = {0} seconds\n", stopWatch.Elapsed.TotalSeconds);

            return _DictionaryFuzzyResults;
        }


        public void StringToCompare()
        {
            var stopWatch = Stopwatch.StartNew();
            foreach (string name in _stringList)
            {
                var indexOfNameToCompare = _stringList.IndexOf(name);
                // Very good. Didnt think about this but yeah you need to use index otherwise will remove duplicates too
                var stringListWithoutStringToCompare = _stringList.Where((v, i) => i != indexOfNameToCompare).ToList();

                // This is not good: Confusing as you are using class for 2 purposes: Should refactor second purpose into a new class (A data class ComparisionScore/Result) - SK Changed but now properties are public and didn't think they should be
                _DictionaryFuzzyResults.Add(name, new ComparisonScore()
                {
                    StringTwo = "",
                    Score = 0
                });
                CompareStringToList(stringListWithoutStringToCompare, name);
            }
            Console.WriteLine("Foreach 1st loop execution time = {0} seconds\n", stopWatch.Elapsed.TotalSeconds);
        }


        private void CompareStringToList(IEnumerable<string> stringList,
            string stringToCompare)
        {
            var stopWatch = Stopwatch.StartNew();
            foreach (string name in stringList)
            {
                // var stringsBeingCompared = stringToCompare + " v " + name;
                var result = Fuzz.WeightedRatio(stringToCompare, name);
                // Console.WriteLine($"{stringsBeingCompared} : {result}");
                var isHigherThanExistingResult = _DictionaryFuzzyResults[stringToCompare].Score < result;
                if (isHigherThanExistingResult)
                    _DictionaryFuzzyResults[stringToCompare] = new ComparisonScore()
                    {
                        StringTwo = name,
                        Score = result
                    };
            }

            Console.WriteLine("Foreach 2nd loop execution time = {0} seconds\n", stopWatch.Elapsed.TotalSeconds);
        }

        public void GetTopMatchPerString()
        {
            var orderedDictionary = _DictionaryFuzzyResults.OrderByDescending(x => x.Value.Score);
            foreach (var item in orderedDictionary)
            {
                Console.WriteLine($" Top Match for {item.Key} is {item.Value.StringTwo} with a score of {item.Value.Score}");
            }
        }
    }
}
