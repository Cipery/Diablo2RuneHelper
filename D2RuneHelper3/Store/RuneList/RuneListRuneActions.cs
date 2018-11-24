using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Blazor.Fluxor;

namespace D2RuneHelper3.Store.RuneList
{
    public class RuneListRuneCountIncrease : IAction
    {
        public int RuneIndex { get; }

        public RuneListRuneCountIncrease(int runeIndex)
        {
            RuneIndex = runeIndex;
        }
    }

    public class RuneListRuneCountDecrease : IAction
    {
        public int RuneIndex { get;}

        public RuneListRuneCountDecrease(int runeIndex)
        {
            RuneIndex = runeIndex;
        }
    }
}
