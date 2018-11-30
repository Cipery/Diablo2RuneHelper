using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Xml.Serialization;
using D2RuneHelper3.Helpers;
using Newtonsoft.Json;

namespace D2RuneHelper3.Model
{
    public class DataTable
    {
        public Rune[] Runes { get; } = new Rune[33];
        public IDictionary<string, Rune> RuneD { get; }

        public Runeword[] Runewords { get; }
        
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
            Runewords = InitializeAllRuneWords().ToArray();
        }

        public IEnumerable<Runeword> GetAvailableRuneWords(int[] runeCounts)
        {
            var resultingList = new List<Runeword>();
            foreach (var runeWord in Runewords)
            {
                var requiredRunes = runeWord.GetAggregatedRuneRequiements();
                var ok = !requiredRunes.Any(r => runeCounts[Runes.Find(r.Key).RuneNumber - 1] < r.Value);

                if (!ok)
                {
                    continue;
                }

                resultingList.Add(runeWord);
            }

            return resultingList;
        }

        public static string testo;
        public static string testoJSON;

        private IEnumerable<Runeword> InitializeAllRuneWords()
        {
            // So yeah, I was being kinda lazy and my plan was to add all these runewords
            // in code - inlined. But that would be kinda totally non-reusable by any other peeps.
            // So let's do it in XML, that will allow any other dev/person to download it and use it as he wishes to
            var runeWords = new List<Runeword>();

            runeWords.Add(new Runeword
            {
                Name = "Infinity",
                RequiredRunes = new[] {"Ber", "Mal", "Ber", "Ist"},
                Stats = new[]
                {
                    "50% Chance To Cast Level 20 Chain Lightning When You Kill An Enemy",
                    "Level 12 Conviction Aura When Equipped",
                    "+35% Faster Run/Walk",
                    "+255-325% Enhanced Damage",
                    "-(45-55)% To Enemy Lightning Resist",
                    "40% Chance of Crushing Blow",
                    "Prevent Monster Heal",
                    "0.5-49.5 To Vitality (Based on Character Level)",
                    "30% Better Chance of Getting Magic Items",
                    "Level 21 Cyclone Armor (30 Charges)"
                },
                ItemTypes = new[] {ItemType.Polearm},
                LadderOnly = true,
                Patch = D2Patch.P1_10
            });

            if (true)
            {
                //return runeWords;
            }

            runeWords.Add(new Runeword
            {
                Name = "Treachery",
                RequiredRunes = new[] { "Shael", "Thul", "Lem" },
                Stats = new[]
                {
                    "5% Chance To Cast Level 15 Fade When Struck",
                    "25% Chance To Cast level 15 Venom On Striking",
                    "+2 To Assassin Skills",
                    "+45% Increased Attack Speed",
                    "+20% Faster Hit Recovery",
                    "Cold Resist +30%",
                    "50% Extra Gold From Monsters"
                },
                ItemTypes = new[] { ItemType.BodyArmor },
                LadderOnly = false,
                Patch = D2Patch.P1_11
            });

            runeWords.Add(new Runeword
            {
                Name = "Rain",
                RequiredRunes = new[] { "Ort", "Mal", "Ith"},
                Stats = new[]
                {
                    "5% Chance To Cast Level 15 Cyclone Armor When Struck",
                    "5% Chance To Cast Level 15 Twister On Striking",
                    "+2 To Druid Skills",
                    "+100-150 To Mana",
                    "Lightning Resist +30%",
                    "Magic Damage Reduced By 7",
                    "15% Damage Taken Goes to Mana"
                },
                ItemTypes = new[] { ItemType.BodyArmor },
                LadderOnly = false,
                Patch = D2Patch.P1_11
            });

            runeWords.Add(new Runeword
            {
                Name = "Principle",
                RequiredRunes = new[] { "Ral", "Gul", "Eld" },
                Stats = new[]
                {
                    "100% Chance To Cast Level 5 Holy Bolt On Striking",
                    "+2 To Paladin Skill Levels",
                    "+50% Damage to Undead",
                    "+100-150 To Life (varies)",
                    "15% Slower Stamina Drain",
                    "+5% To Maximum Poison Resist",
                    "Fire Resist +30%"
                },
                ItemTypes = new[] { ItemType.BodyArmor },
                LadderOnly = false,
                Patch = D2Patch.P1_11
            });

            runeWords.Add(new Runeword
            {
                Name = "Peace",
                RequiredRunes = new[] { "Shael", "Thul", "Amn" },
                Stats = new[]
                {
                    "4% Chance To Cast Level 5 Slow Missiles When Struck",
                    "2% Chance To Cast level 15 Valkyrie On Striking",
                    "+2 To Amazon Skill Levels",
                    "+20% Faster Hit Recovery",
                    "+2 To Critical Strike",
                    "Cold Resist +30%",
                    "Attacker Takes Damage of 14"
                },
                ItemTypes = new[] { ItemType.BodyArmor },
                LadderOnly = false,
                Patch = D2Patch.P1_11
            });

            runeWords.Add(new Runeword
            {
                Name = "Myth",
                RequiredRunes = new[] { "Hel", "Amn", "Nef" },
                Stats = new[]
                {
                    "3% Chance To Cast Level 1 Howl When Struck",
                    "10% Chance To Cast Level 1 Taunt On Striking",
                    "+2 To Barbarian Skill Levels",
                    "+30 Defense vs. Missile",
                    "Replenish Life +10",
                    "Attacker Takes Damage of 14",
                    "Requirements -15%"
                },
                ItemTypes = new[] { ItemType.BodyArmor },
                LadderOnly = false,
                Patch = D2Patch.P1_11
            });

            runeWords.Add(new Runeword
            {
                Name = "Enlightenment",
                RequiredRunes = new[] { "Pul", "Ral", "Sol" },
                Stats = new[]
                {
                    "5% Chance To Cast Level 15 Blaze When Struck",
                    "5% Chance To Cast level 15 Fire Ball On Striking",
                    "+2 To Sorceress Skill Levels",
                    "+1 To Warmth",
                    "+30% Enhanced Defense",
                    "Fire Resist +30%",
                    "Damage Reduced By 7"
                },
                ItemTypes = new[] { ItemType.BodyArmor },
                LadderOnly = false,
                Patch = D2Patch.P1_11
            });

            runeWords.Add(new Runeword
            {
                Name = "Bone",
                RequiredRunes = new[] { "Sol", "Um", "Um" },
                Stats = new[]
                {
                    "15% Chance To Cast level 10 Bone Armor When Struck",
                    "15% Chance To Cast level 10 Bone Spear On Striking",
                    "+2 To Necromancer Skill Levels",
                    "+100-150 To Mana (varies)",
                    "All Resistances +30",
                    "Damage Reduced By 7"
                },
                ItemTypes = new[] { ItemType.BodyArmor },
                LadderOnly = false,
                Patch = D2Patch.P1_11
            });

            runeWords.Add(new Runeword
            {
                Name = "Wrath",
                RequiredRunes = new[] { "Pul", "Lum", "Ber", "Mal" },
                Stats = new[]
                {
                    "30% Chance To Cast Level 1 Decrepify On Striking",
                    "5% Chance To Cast Level 10 Life Tap On Striking",
                    "+375% Damage To Demons",
                    "+100 To Attack Rating Against Demons",
                    "+250-300% Damage To Undead",
                    "Adds 85-120 Magic Damage",
                    "Adds 41-240 Lightning Damage",
                    "20% Chance of Crushing Blow",
                    "Prevent Monster Heal",
                    "+10 To Energy",
                    "Cannot Be Frozen"
                },
                ItemTypes = new[] { ItemType.Bow, ItemType.Crossbow, ItemType.AmazonBow },
                LadderOnly = true,
                Patch = D2Patch.P1_10
            });

            runeWords.Add(new Runeword
            {
                Name = "Voice of Reason",
                RequiredRunes = new[] { "Lem", "Ko", "El", "Eld" },
                Stats = new[]
                {
                    "15% Chance To Cast Level 13 Frozen Orb On Striking",
                    "18% Chance To Cast Level 20 Ice Blast On Striking",
                    "+50 To Attack Rating",
                    "+220-350% Damage To Demons",
                    "+355-375% Damage To Undead",
                    "+50 To Attack Rating Against Undead",
                    "Adds 100-220 Cold Damage",
                    "-24% To Enemy Cold Resistance",
                    "+10 To Dexterity",
                    "Cannot Be Frozen",
                    "75% Extra Gold From Monsters",
                    "+1 To Light Radius"
                },
                ItemTypes = new[] { ItemType.Sword, ItemType.Mace },
                LadderOnly = true,
                Patch = D2Patch.P1_10
            });

            runeWords.Add(new Runeword
            {
                Name = "Spirit (Sword)",
                RequiredRunes = new[] { "Tal", "Thul", "Ort", "Amn" },
                Stats = new[]
                {
                    "+2 To All Skills",
                    "+25-35% Faster Cast Rate",
                    "+55% Faster Hit Recovery",
                    "Adds 1-50 Lightning Damage",
                    "Adds 3-14 Cold Damage 3 Second Duration (Normal)",
                    "+75 Poison Damage Over 5 Seconds",
                    "7% Life Stolen Per Hit",
                    "+250 Defense vs. Missiles",
                    "+22 To Vitality",
                    "+89-112 To Mana",
                    "+3-8 Magic Absorb",
                },
                ItemTypes = new[] { ItemType.Sword },
                LadderOnly = true,
                Patch = D2Patch.P1_10
            });

            runeWords.Add(new Runeword
            {
                Name = "Spirit (Shield)",
                RequiredRunes = new[] { "Tal", "Thul", "Ort", "Amn" },
                Stats = new[]
                {
                    "+2 To All Skills",
                    "+25-35% Faster Cast Rate",
                    "+55% Faster Hit Recovery",
                    "+250 Defense vs. Missiles",
                    "+22 To Vitality",
                    "+89-112 To Mana",
                    "Cold Resist +35%",
                    "Lightning Resist +35%",
                    "Poison Resist +35%",
                    "+3-8 Magic Absorb ",
                    "Attacker Takes Damage of 14",
                },
                ItemTypes = new[] { ItemType.Shield, ItemType.NecroShield, ItemType.PalaShield },
                LadderOnly = true,
                Patch = D2Patch.P1_10
            });

            runeWords.Add(new Runeword
            {
                Name = "Rift",
                RequiredRunes = new[] { "Hel", "Ko", "Lem", "Gul" },
                Stats = new[]
                {
                    "20% Chance To Cast Level 16 Tornado On Striking",
                    "16% Chance To Cast Level 21 Frozen Orb On Attack",
                    "20% Bonus To Attack Rating",
                    "Adds 160-250 Magic Damage",
                    "Adds 60-180 Fire Damage",
                    "+5-10 To All Stats (varies)",
                    "+10 To Dexterity",
                    "38% Damage Taken Goes To Mana",
                    "75% Extra Gold From Monsters",
                    "Level 15 Iron Maiden (40 Charges)",
                    "Requirements -20%",
                },
                ItemTypes = new[] { ItemType.Polearm, ItemType.Scepter },
                LadderOnly = true,
                Patch = D2Patch.P1_10
            });

            runeWords.Add(new Runeword
            {
                Name = "Pride",
                RequiredRunes = new[] { "Cham", "Sur", "Io", "Lo" },
                Stats = new[]
                {
                    "25% Chance To Cast Level 17 Fire Wall When Struck",
                    "Level 16-20 Concentration Aura When Equipped ",
                    "260-300% Bonus To Attack Rating ",
                    "+1-99% Damage To Demons (Based on Character Level)",
                    "Adds 50-280 Lightning Damage",
                    "20% Deadly Strike",
                    "Hit Blinds Target",
                    "Freezes Target +3",
                    "+10 To Vitality",
                    "Replenish Life +8",
                    "1.875-185.625% Extra Gold From Monsters (Based on Character Level)",
                },
                ItemTypes = new[] { ItemType.Polearm },
                LadderOnly = true,
                Patch = D2Patch.P1_10
            });

            runeWords.Add(new Runeword
            {
                Name = "Phoenix (Weapon)",
                RequiredRunes = new[] { "Vex", "Vex", "Lo", "Jah" },
                Stats = new[]
                {
                    "100% Chance To Cast level 40 Blaze When You Level-up",
                    "40% Chance To Cast Level 22 Firestorm On Striking",
                    "Level 10-15 Redemption Aura When Equipped",
                    "+350-400% Enhanced Damage",
                    "Ignores Target's Defense",
                    "14% Mana Stolen Per Hit",
                    "-28% To Enemy Fire Resist",
                    "20% Deadly Strike",
                    "+350-400 Defense vs. Missile",
                    "+15-21 Fire Absorb",
                },
                ItemTypes = ItemType.Weapons,
                LadderOnly = true,
                Patch = D2Patch.P1_10
            });

            runeWords.Add(new Runeword
            {
                Name = "Phoenix (Shield)",
                RequiredRunes = new[] { "Vex", "Vex", "Lo", "Jah" },
                Stats = new[]
                {
                    "100% Chance To Cast level 40 Blaze When You Level-up",
                    "40% Chance To Cast Level 22 Firestorm On Striking",
                    "Level 10-15 Redemption Aura When Equipped",
                    "+350-400% Enhanced Damage",
                    "+350-400 Defense vs. Missile",
                    "+50 To Life",
                    "-28% To Enemy Fire Resist",
                    "+5% To Maximum Lightning Resist",
                    "+10% To Maximum Fire Resist",
                    "+15-21 Fire Absorb",
                },
                ItemTypes = new[] { ItemType.Shield, ItemType.NecroShield, ItemType.PalaShield },
                LadderOnly = true,
                Patch = D2Patch.P1_10
            });

            runeWords.Add(new Runeword
            {
                Name = "Obedience",
                RequiredRunes = new[] { "Hel", "Ko", "Thul", "Eth", "Fal" },
                Stats = new[]
                {
                    "30% Chance To Cast Level 21 Enchant When You Kill An Enemy",
                    "40% Faster Hit Recovery",
                    "+370% Enhanced Damage",
                    "-25% Target Defense",
                    "Adds 3-14 Cold Damage 3 Second Duration (Normal)",
                    "-25% To Enemy Fire Resist",
                    "40% Chance of Crushing Blow",
                    "+200-300 Defense",
                    "+10 To Strength",
                    "+10 To Dexterity",
                    "All Resistances +20-30",
                    "Requirements -20%",
                },
                ItemTypes = new[] { ItemType.Polearm },
                LadderOnly = true,
                Patch = D2Patch.P1_10
            });

            runeWords.Add(new Runeword
            {
                Name = "Oath",
                RequiredRunes = new[] { "Shael", "Pul", "Mal", "Lum" },
                Stats = new[]
                {
                    "30% Chance To Cast Level 20 Bone Spirit On Striking",
                    "Indestructible",
                    "+50% Increased Attack Speed",
                    "+210-340% Enhanced Damage",
                    "+75% Damage To Demons",
                    "+100 To Attack Rating Against Demons",
                    "Prevent Monster Heal",
                    "+10 To Energy",
                    "+10-15 Magic Absorb",
                    "Level 16 Heart of Wolverine (20 Charges)",
                    "Level 17 Iron Golem (14 Charges)",
                },
                ItemTypes = new[] { ItemType.Sword, ItemType.Mace, ItemType.Axe },
                LadderOnly = true,
                Patch = D2Patch.P1_10
            });

            runeWords.Add(new Runeword
            {
                Name = "Lawbringer",
                RequiredRunes = new[] { "Amn", "Lem", "Ko"},
                Stats = new[]
                {
                    "20% Chance To Cast Level 15 Decrepify On Striking",
                    "Level 16-18 Sanctuary Aura When Equipped (varies)",
                    "-50% Target Defense",
                    "Adds 150-210 Fire Damage",
                    "Adds 130-180 Cold Damage",
                    "7% Life Stolen Per Hit",
                    "Slain Monsters Rest in Peace",
                    "+200-250 Defense vs. Missile",
                    "+10 To Dexterity",
                    "75% Extra Gold From Monsters",
                },
                ItemTypes = new[] { ItemType.Sword, ItemType.Hammer, ItemType.Axe },
                LadderOnly = true,
                Patch = D2Patch.P1_10
            });

            runeWords.Add(new Runeword
            {
                Name = "Last Wish",
                RequiredRunes = new[] { "Jah", "Mal", "Jah", "Sur", "Jah", "Ber" },
                Stats = new[]
                {
                    "6% Chance To Cast Level 11 Fade When Struck",
                    "10% Chance To Cast Level 18 Life Tap On Striking",
                    "20% Chance To Cast Level 20 Charged Bolt On Attack",
                    "Level 17 Might Aura When Equipped",
                    "+330-375% Enhanced Damage ",
                    "Ignore Target's Defense",
                    "60-70% Chance of Crushing Blow",
                    "Prevent Monster Heal",
                    "Hit Blinds Target",
                    "+(0.5 per character level) 0.5-49.5% Chance of Getting Magic Items (Based on Character Level)",
                },
                ItemTypes = new[] { ItemType.Sword, ItemType.Hammer, ItemType.Axe },
                LadderOnly = true,
                Patch = D2Patch.P1_10
            });

            runeWords.Add(new Runeword
            {
                Name = "Insight",
                RequiredRunes = new[] { "Ral", "Tir", "Tal", "Sol"},
                Stats = new[]
                {
                    "Level 12-17 Meditation Aura When Equipped",
                    "+35% Faster Cast Rate",
                    "+200-260% Enhanced Damage (varies)",
                    "+9 To Minimum Damage",
                    "180-250% Bonus to Attack Rating",
                    "Adds 5-30 Fire Damage",
                    "+75 Poison Damage Over 5 Seconds",
                    "+1-6 To Critical Strike",
                    "+5 To All Attributes",
                    "+2 To Mana After Each Kill",
                    "23% Better Chance of Getting Magic Items"
                },
                ItemTypes = new[] { ItemType.Polearm, ItemType.Staff },
                LadderOnly = true,
                Patch = D2Patch.P1_10
            });

            runeWords.Add(new Runeword
            {
                Name = "Ice",
                RequiredRunes = new[] { "Amn", "Shael", "Jah", "Ko" },
                Stats = new[]
                {
                    "100% Chance To Cast Level 40 Blizzard When You Level-up",
                    "25% Chance To Cast Level 22 Frost Nova On Striking",
                    "Level 18 Holy Freeze Aura When Equipped",
                    "+20% Increased Attack Speed",
                    "+140-210% Enhanced Damage",
                    "Ignore Target's Defense",
                    "+25-30% To Cold Skill Damage",
                    "-20% To Enemy Cold Resist",
                    "7% Life Stolen Per Hit",
                    "20% Deadly Strike",
                    "3.125-309.375% Extra Gold From Monsters (Based on Character Level)"
                },
                ItemTypes = new[] { ItemType.Bow, ItemType.Crossbow, ItemType.AmazonBow },
                LadderOnly = true,
                Patch = D2Patch.P1_10
            });

            /*FileStream fls = new FileStream("./something.xml", FileMode.OpenOrCreate);
            StringWriter sb = new StringWriter();
            XmlSerializer srz = new XmlSerializer(typeof(Runeword[]));
            srz.Serialize(fls, runeWords);
            srz.Serialize(sb, runeWords);
            sb.Close();
            testo = sb.ToString();
            fls.Flush();
            fls.Close();*/
            //testoJSON = JsonConvert.SerializeObject(runeWords);
            /*runeWords.Add(new Runeword("Ancient's Pledge", new[] { RuneD["Ral"], RuneD["Ort"], RuneD["Tal"] }, "+50% Enhanced Defense"));
            runeWords.Add(new Runeword("Beast", new[] { RuneD["Ber"], RuneD["Tir"], RuneD["Um"], RuneD["Mal"], RuneD["Lum"] }, "Level 9 Fanaticism Aura When Equipped"));
            runeWords.Add(new Runeword("Black", new[] { RuneD["Thul"], RuneD["Io"], RuneD["Nef"] }, "+15% Increased Attack Speed"));
            runeWords.Add(new Runeword("Bone", new[] { RuneD["Sol"], RuneD["Um"], RuneD["Um"] }, "15% Chance To Cast level 10 Bone Armor When Struck"));
            */
            return runeWords;
        }
    }
}
