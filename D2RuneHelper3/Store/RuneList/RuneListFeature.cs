using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Blazor.Fluxor;
using D2RuneHelper3.Model;

namespace D2RuneHelper3.Store.RuneList
{
    public class RuneListFeature : Feature<RuneListState>
    {
        public override string GetName() => "RuneList";
        protected override  RuneListState GetInitialState() => new RuneListState(new int[33], new List<RuneWord>());
    }
}
