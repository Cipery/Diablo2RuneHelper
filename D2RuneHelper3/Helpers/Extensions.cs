using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace D2RuneHelper3.Helpers
{
    public static class Extensions
    {
        public static string RuneImage(this string runeName)
        {
            return $"rune-{runeName}.png";
        }
    }
}
