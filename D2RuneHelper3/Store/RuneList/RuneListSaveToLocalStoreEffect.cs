using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Blazor.Extensions.Storage;
using Blazor.Fluxor;

namespace D2RuneHelper3.Store.RuneList
{
    public class RuneListSaveToLocalStoreEffect : Effect<RuneListSaveToLocalStoreAction>
    {
        protected LocalStorage LocalStorage { get; }

        public RuneListSaveToLocalStoreEffect(LocalStorage localStorage)
        {
            LocalStorage = localStorage;
        }

        protected override async Task HandleAsync(RuneListSaveToLocalStoreAction action, IDispatcher dispatcher)
        {
            try
            {
                Console.WriteLine("RuneListSaveToLocalStoreAction.HandleAsync()");
                await LocalStorage.SetItem("rune_counts", action.RuneCounts);
            }
            catch (Exception e)
            {
                throw e; //TODO:
            }
        }
    }
}
