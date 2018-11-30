using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Blazor.Fluxor;

namespace D2RuneHelper3.Store.RuneList
{
    public class RuneListLoadFromLocalStoreAction : IAction
    {
        
    }

    public class RuneListSaveToLocalStoreAction : IAction
    {
        public int[] RuneCounts;

        public RuneListSaveToLocalStoreAction(int[] runeCounts)
        {
            RuneCounts = runeCounts;
        }
    }

    public class RuneListSetBulkRuneCount : IAction, IRefilterRuneWordsAfterDispatch
    {
        public int[] RuneCounts;

        public RuneListSetBulkRuneCount(int[] runeCounts)
        {
            RuneCounts = runeCounts;
        }
    }

    public class RuneListRuneCountIncrease : IAction, ISaveAfterDispatch, IRefilterRuneWordsAfterDispatch
    {
        public int RuneIndex { get; }

        public RuneListRuneCountIncrease(int runeIndex)
        {
            RuneIndex = runeIndex;
        }
    }

    public class RuneListRuneCountDecrease : IAction, ISaveAfterDispatch, IRefilterRuneWordsAfterDispatch
    {
        public int RuneIndex { get;}

        public RuneListRuneCountDecrease(int runeIndex)
        {
            RuneIndex = runeIndex;
        }
    }

    public class RecalculateAvailableRuneWordsAction : IAction
    {

    }
}
