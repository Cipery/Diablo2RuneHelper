using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Blazor.Fluxor;
using D2RuneHelper3.Model;

namespace D2RuneHelper3.Store.RuneList
{
    public class RuneListReducers : IReducer<RuneListState>
    {
        protected DataTable DataTable;

        public RuneListReducers(DataTable dataTable)
        {
            DataTable = dataTable;
        }

        public RuneListState Reduce(RuneListState state, IAction action)
        {
            switch (action)
            {
                case RuneListRuneCountIncrease _:
                {
                    var runeCounts = state.RuneCounts;
                    runeCounts[((RuneListRuneCountIncrease) action).RuneIndex]++;
                    return new RuneListState(runeCounts, state.PossibleRuneWords);
                }
                case RuneListRuneCountDecrease _:
                {
                    var runeCounts = state.RuneCounts;
                    runeCounts[((RuneListRuneCountDecrease) action).RuneIndex]--;
                    return new RuneListState(runeCounts, state.PossibleRuneWords);
                }
                case RuneListSetBulkRuneCount _:
                {
                    var runeCounts = ((RuneListSetBulkRuneCount) action).RuneCounts;
                    return runeCounts == null ? state : new RuneListState(runeCounts, state.PossibleRuneWords);
                }
                case RecalculateAvailableRuneWordsAction _:
                {
                    var possibleRuneWords = DataTable.GetAvailableRuneWords(state.RuneCounts);
                    return new RuneListState(state.RuneCounts, possibleRuneWords);
                }
            }

            return state;
        }

        public bool ShouldReduceStateForAction(IAction action)
        {
            return true;
        }
    }
}
