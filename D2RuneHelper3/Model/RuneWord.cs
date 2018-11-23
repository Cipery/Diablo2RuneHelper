using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace D2RuneHelper3.Model
{
    public class RuneWord
    {
        public Rune[] RequiredRunes { get; }
        public string Stats { get; set; }

        public RuneWord(Rune[] requiredRunes, string stats)
        {
            RequiredRunes = requiredRunes;
            Stats = stats;
        }
    }
}
