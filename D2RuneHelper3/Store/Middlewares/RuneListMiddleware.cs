using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Blazor.Fluxor;
using D2RuneHelper3.Store.RuneList;

namespace D2RuneHelper3.Store.Middlewares
{
    public class RuneListMiddleware : Middleware
    {
        public RuneListMiddleware()
        {

        }

        public override string GetClientScripts()
        {
            return "";
            //return "alert('AnExampleMiddleware script inserted successfully');";
        }

        public override void Initialize(IStore store) => base.Initialize(store);

        public override void AfterInitializeAllMiddlewares()
        {
            base.AfterInitializeAllMiddlewares();
        }

        public override bool MayDispatchAction(IAction action)
        {
            //Console.WriteLine($"Action {action.GetType().Name} has been allowed to execute");
            return true;
        }

        public override void BeforeDispatch(IAction action)
        {
            //Console.WriteLine($"Action {action.GetType().Name} is about to be dispatched to all features");
        }

        public override void AfterDispatch(IAction action)
        {
            //Console.WriteLine($"Action {action.GetType().Name} has just been dispatched to all features");
            if (action is ISaveAfterDispatch)
            {
                //TODO: unscrew this
                Store.Dispatch(new RuneListSaveToLocalStoreAction(((RuneListState)Store.Features["runeList"].GetState()).RuneCounts));
            }

            if (action is IRefilterRuneWordsAfterDispatch)
            {
                Store.Dispatch(new RecalculateAvailableRuneWordsAction());
            }
        }
    }
}
