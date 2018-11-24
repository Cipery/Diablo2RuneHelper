using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace D2RuneHelper3.Model
{
    public class RuneWord
    {
        public Rune[] RequiredRunes { get; }
        public string Name { get; }
        public string Stats { get; }
        
        public RuneWord(string name, Rune[] requiredRunes, string stats)
        {
            Name = name;
            RequiredRunes = requiredRunes;
            Stats = stats;
        }

        public IDictionary<Rune, int> GetAggregatedRuneRequiements()
        {
            var dict = new Dictionary<Rune, int>();
            foreach (var requiredRune in RequiredRunes)
            {
                if (!dict.ContainsKey(requiredRune))
                {
                    dict.Add(requiredRune, RequiredRunes.Count(r => r.Name.Equals(requiredRune.Name)));
                }
            }

            return dict;
        }
    }
}
