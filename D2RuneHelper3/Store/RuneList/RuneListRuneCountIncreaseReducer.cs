using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Blazor.Fluxor;

namespace D2RuneHelper3.Store.RuneList
{
    public class RuneListRuneCountIncreaseReducer : IReducer<RuneListState>
    {
        public RuneListState Reduce(RuneListState state, IAction action)
        {
            switch (action)
            {
                case RuneListRuneCountIncrease _:
                {
                    var runeCounts = state.RuneCounts;
                    runeCounts[((RuneListRuneCountIncrease)action).RuneIndex]++;
                    return new RuneListState(runeCounts);
                }
                case RuneListRuneCountDecrease _:
                {
                    var runeCounts = state.RuneCounts;
                    runeCounts[((RuneListRuneCountDecrease)action).RuneIndex]++;
                    return new RuneListState(runeCounts);
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
