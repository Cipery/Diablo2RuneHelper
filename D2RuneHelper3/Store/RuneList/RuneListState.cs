﻿using D2RuneHelper3.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace D2RuneHelper3.Store.RuneList
{
    public class RuneListState
    {
        public int[] RuneCounts { get; private set; }

        private RuneListState()
        {

        }

        public RuneListState(int[] runeCounts)
        {
            RuneCounts = runeCounts;
        }
    }
}