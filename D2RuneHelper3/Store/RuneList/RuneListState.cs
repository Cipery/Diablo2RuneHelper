using D2RuneHelper3.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace D2RuneHelper3.Store.RuneList
{
    public class RuneListState
    {
        public int[] RuneCounts { get; }
        public IEnumerable<Runeword> PossibleRuneWords { get; }

        private RuneListState()
        {

        }

        public RuneListState(int[] runeCounts, IEnumerable<Runeword> possibleRuneWords)
        {
            RuneCounts = runeCounts;
            PossibleRuneWords = possibleRuneWords;  
        }
    }
}
