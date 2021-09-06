using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Test
{
    public class BigramCounter
    {
        public Dictionary<string,int> Count(string input)
        {
            input = input.Replace(" ", "_");
            return Pairs(input)
                .GroupBy(x => x)
                .ToDictionary(x => x.Key, y => y.Count());
            
        }

        public IEnumerable<string> Pairs(string input)
        {
            for (int i = 0; i < input.Length - 1; i++)
            {
                yield return $"{input[i]}{input[i + 1]}";
            }
        }
    }
}
