using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using D2RuneHelper3.Model;

namespace D2RuneHelper3.Helpers
{
    public static class Extensions
    {
        public static string RuneImage(this string runeName)
        {
            return $"rune-{runeName.ToLower()}.png";
        }

        public static Rune Find(this Rune[] runes, string runeName)
        {
            return runes.FirstOrDefault(r => r.Name.Equals(runeName));
        }
    }
}
