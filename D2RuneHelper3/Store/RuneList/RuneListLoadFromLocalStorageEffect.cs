using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Blazor.Extensions.Storage;
using Blazor.Fluxor;

namespace D2RuneHelper3.Store.RuneList
{
    public class RuneListLoadFromLocalStorageEffect : Effect<RuneListLoadFromLocalStoreAction>
    {
        protected LocalStorage LocalStorage { get; }

        public RuneListLoadFromLocalStorageEffect(LocalStorage localStorage)
        {
            LocalStorage = localStorage;
        }

        protected override async Task HandleAsync(RuneListLoadFromLocalStoreAction action, IDispatcher dispatcher)
        {
            try
            {
                Console.WriteLine("RuneListLoadFromLocalStorageEffect.HandleAsync()");
                var runeCounts = await LocalStorage.GetItem<int[]>("rune_counts");
                dispatcher.Dispatch(new RuneListSetBulkRuneCount(runeCounts));
            }
            catch (Exception e)
            {
                throw e; //TODO:
            }
        }
    }
}
