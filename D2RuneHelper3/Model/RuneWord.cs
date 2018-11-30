using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace D2RuneHelper3.Model
{
    /// <summary>
    /// Why is this not enum? Cause it would serialize to json as integer. There is a way, for sure, but.. lazy
    /// </summary>
    public class ItemType
    {
        public const string Mace = "Mace";
        public const string Scepter = "Scepter";
        public const string Axe = "Axe";
        public const string Hammer = "Hammer";
        public const string Polearm = "Polearm";
        public const string Staff = "Staff";
        public const string Sword = "Mace";
        public const string BodyArmor = "Armor";
        public const string Bow = "Bow";
        public const string Crossbow = "Crossbow";
        public const string AmazonBow = "AmazonBow";
        public const string Shield = "Shield";
        public const string NecroShield = "NecroShield";
        public const string PalaShield = "PalaShield";

        public static readonly string[] Weapons = {Mace, Scepter, Polearm, Sword, Bow, Crossbow, AmazonBow};
    }

    public class D2Patch
    {
        public const string Original = "Original";
        public const string P1_10 = "1.10";
        public const string P1_11 = "1.11";
    }

    public class Runeword
    {
        public string Name { get; set; }
        [XmlArray("Runes")]
        [XmlArrayItem("Rune")]
        public string[] RequiredRunes { get; set; }
        [XmlArray("ItemTypes")]
        [XmlArrayItem("ItemType")]
        public string[] ItemTypes { get; set; }
        [XmlArray("Stats")]
        [XmlArrayItem("Stat")]
        public string[] Stats { get; set; }
        public bool LadderOnly { get; set; }
        public string Patch { get; set; }

        public Runeword()
        {

        }

        public Runeword(string name, string[] requiredRunes, string[] stats, string[] itemTypes)
        {
            Name = name;
            RequiredRunes = requiredRunes;
            Stats = stats;
            ItemTypes = itemTypes;
        }

        public IDictionary<string, int> GetAggregatedRuneRequiements()
        {
            var dict = new Dictionary<string, int>();
            foreach (var requiredRune in RequiredRunes)
            {
                if (!dict.ContainsKey(requiredRune))
                {
                    dict.Add(requiredRune, RequiredRunes.Count(r => r.Equals(requiredRune)));
                }
            }

            return dict;
        }
    }
}
