using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace D2RuneHelper3.Model
{
    public class DataTable
    {
        public Rune[] Runes { get; } = new Rune[33];
        public IDictionary<string, Rune> RuneD { get; }

        public RuneWord[] RuneWords { get; }

        public DataTable()
        {
            Runes[0] = new Rune(1, "El");
            Runes[1] = new Rune(2, "Eld");
            Runes[2] = new Rune(3, "Tir");
            Runes[3] = new Rune(4, "Nef");
            Runes[4] = new Rune(5, "Eth");
            Runes[5] = new Rune(6, "Ith");
            Runes[6] = new Rune(7, "Tal");
            Runes[7] = new Rune(8, "Ral");
            Runes[8] = new Rune(9, "Ort");
            Runes[9] = new Rune(10, "Thul");
            Runes[10] = new Rune(11, "Amn");
            Runes[11] = new Rune(12, "Sol");
            Runes[12] = new Rune(13, "Shael");
            Runes[13] = new Rune(14, "Dol");
            Runes[14] = new Rune(15, "Hel");
            Runes[15] = new Rune(16, "Io");
            Runes[16] = new Rune(17, "Lum");
            Runes[17] = new Rune(18, "Ko");
            Runes[18] = new Rune(19, "Fal");
            Runes[19] = new Rune(20, "Lem");
            Runes[20] = new Rune(21, "Pul");
            Runes[21] = new Rune(22, "Um");
            Runes[22] = new Rune(23, "Mal");
            Runes[23] = new Rune(24, "Ist");
            Runes[24] = new Rune(25, "Gul");
            Runes[25] = new Rune(26, "Vex");
            Runes[26] = new Rune(27, "Ohm");
            Runes[27] = new Rune(28, "Lo");
            Runes[28] = new Rune(29, "Sur");
            Runes[29] = new Rune(30, "Ber");
            Runes[30] = new Rune(31, "Jah");
            Runes[31] = new Rune(32, "Cham");
            Runes[32] = new Rune(33, "Zod");

            RuneD = Runes.ToDictionary(p => p.Name);

            var runeWords = new List<RuneWord>();
            runeWords.Add(new RuneWord("Infinity", new []
            {
                RuneD["Ber"],
                RuneD["Mal"],
                RuneD["Ber"],
                RuneD["Ist"]
            }, "Conviction aura bro"));

            RuneWords = runeWords.ToArray();
        }

        public IEnumerable<RuneWord> GetAvailableRuneWords(int[] runeCounts)
        {
            var resultingList = new List<RuneWord>();
            foreach (var runeWord in RuneWords)
            {
                var requiredRunes = runeWord.GetAggregatedRuneRequiements();
                var ok = !requiredRunes.Any(r => runeCounts[r.Key.RuneNumber - 1] < r.Value);

                if (!ok)
                {
                    continue;
                }

                resultingList.Add(runeWord);
            }

            return resultingList;
        }
    }
}
