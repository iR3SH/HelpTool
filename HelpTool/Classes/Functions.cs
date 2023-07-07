using HelpData.Classes.Effects;
using HelpData.Classes.Game;
using HelpData.Classes.Items;
using HelpData.Classes.Monsters;
using HelpData.Classes.Spells;
using HelpTool.Languages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Security.Policy;
using System.Text;
using System.Text.RegularExpressions;

namespace HelpTool.Classes
{
    public static partial class Functions
    {
        private static char[] HEX = {'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p',
            'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z', 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L',
            'M', 'N', 'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z', '0', '1', '2', '3', '4', '5', '6', '7',
            '8', '9', '-', '_'};
        public static char GetIntByHashedValue(int num)
        {
            if (num < HEX.Length)
            {
                return HEX[num];
            }
            else
            {
                return HEX[^1];
            }
        }
        [GeneratedRegex("[^0-9]+")]
        public static partial Regex NumRegex();
        /// <summary>
        /// Get a translated word with selected Culture
        /// </summary>
        /// <param name="Key"></param>
        /// <returns></returns>
        public static string? Word(string Key)
        {
            if (!string.IsNullOrEmpty(Key))
            {
                return TranslationHelper.Instance[Key]?.ToString();
            }
            else
            {
                return "";
            }
        }
        /// <summary>
        /// Returns all effects to create an item
        /// </summary>
        /// <returns></returns>
        public static List<ItemEffect> GenerateAllEffect()
        {
            List<ItemEffect> effects = new()
            {
                new ItemEffect()
                {
                    Name = "Vie",
                    AddHexId = "6e",
                    RemHexId = "",
                    IsCacEffect = false,
                    IconPath = "vita"
                },
                new ItemEffect()
                {
                    Name = "Vitalité",
                    AddHexId = "7d",
                    RemHexId = "99",
                    IsCacEffect = false,
                    IconPath = "vita"
                },
                new ItemEffect()
                {
                    Name = "Sagesse",
                    AddHexId = "7c",
                    RemHexId = "9c",
                    IsCacEffect = false,
                    IconPath = "sagesse"
                },
                new ItemEffect()
                {
                    Name = "Force",
                    AddHexId = "76",
                    RemHexId = "9d",
                    IsCacEffect = false,
                    IconPath = "force"
                },
                new ItemEffect()
                {
                    Name = "Intelligence",
                    AddHexId = "7e",
                    RemHexId = "9b",
                    IsCacEffect = false,
                    IconPath = "intel"
                },
                new ItemEffect()
                {
                    Name = "Chance",
                    AddHexId = "7b",
                    RemHexId = "98",
                    IsCacEffect = false,
                    IconPath = "eau"
                },
                new ItemEffect()
                {
                    Name = "Agilité",
                    AddHexId = "77",
                    RemHexId = "9a",
                    IsCacEffect = false,
                    IconPath = "agi"
                },
                new ItemEffect()
                {
                    Name = "% Res Neutre",
                    AddHexId = "d6",
                    RemHexId = "db",
                    IsCacEffect = false,
                    IconPath = "ReNeutre"
                },
                new ItemEffect()
                {
                    Name = "% Res Terre",
                    AddHexId = "d2",
                    RemHexId = "9d",
                    IsCacEffect = false,
                    IconPath = "ReTerre"
                },
                new ItemEffect()
                {
                    Name = "% Res Feu",
                    AddHexId = "d5",
                    RemHexId = "9b",
                    IsCacEffect = false,
                    IconPath = "ReFeu"
                },
                new ItemEffect()
                {
                    Name = "% Res Eau",
                    AddHexId = "d3",
                    RemHexId = "98",
                    IsCacEffect = false,
                    IconPath = "ReEau"
                },
                new ItemEffect()
                {
                    Name = "% Res Air",
                    AddHexId = "d4",
                    RemHexId = "9a",
                    IsCacEffect = false,
                    IconPath = "ReAir"
                },
                new ItemEffect()
                {
                    Name = "PA",
                    AddHexId = "6f",
                    RemHexId = "65",
                    IsCacEffect = false,
                    IconPath = "pa"
                },
                new ItemEffect()
                {
                    Name = "Porté",
                    AddHexId = "75",
                    RemHexId = "74",
                    IsCacEffect = false,
                    IconPath = "po"
                },
                new ItemEffect()
                {
                    Name = "PM",
                    AddHexId = "80",
                    RemHexId = "7f",
                    IsCacEffect = false,
                    IconPath = "pm"
                },
                new ItemEffect()
                {
                    Name = "% Esquive PA",
                    AddHexId = "a0",
                    RemHexId = "a2",
                    IsCacEffect = false,
                    IconPath = "EsqPa"
                },
                new ItemEffect()
                {
                    Name = "% Esquive PM",
                    AddHexId = "a1",
                    RemHexId = "a3",
                    IsCacEffect = false,
                    IconPath = "EsqPm"
                },
                new ItemEffect()
                {
                    Name = "Dommages",
                    AddHexId = "79",
                    RemHexId = "91",
                    IsCacEffect = false,
                    IconPath = "DoPer"
                },
                new ItemEffect()
                {
                    Name = "% Dommages",
                    AddHexId = "8a",
                    RemHexId = "a4",
                    IsCacEffect = false,
                    IconPath = "DoPer"
                },
                new ItemEffect()
                {
                    Name = "Dommages de Pièges",
                    AddHexId = "e1",
                    RemHexId = "841",
                    IsCacEffect = false,
                    IconPath = "DoPer"
                },
                new ItemEffect()
                {
                    Name = "% Dommages de Pièges",
                    AddHexId = "e2",
                    RemHexId = "842",
                    IsCacEffect = false,
                    IconPath = "DoPer"
                },
                new ItemEffect()
                {
                    Name = "Critiques",
                    AddHexId = "73",
                    RemHexId = "ab",
                    IsCacEffect = false,
                    IconPath = "crit"
                },
                new ItemEffect()
                {
                    Name = "Echec Critiques",
                    AddHexId = "7a",
                    IsCacEffect = false,
                    IconPath = "crit"
                },
                new ItemEffect()
                {
                    Name = "Pods",
                    AddHexId = "9e",
                    RemHexId = "da",
                    IsCacEffect = false,
                    IconPath = "Pods"
                },
                new ItemEffect()
                {
                    Name = "Initiatives",
                    AddHexId = "ae",
                    RemHexId = "af",
                    IsCacEffect = false,
                    IconPath = "ini"
                },
                new ItemEffect()
                {
                    Name = "Prospection",
                    AddHexId = "b0",
                    RemHexId = "b1",
                    IsCacEffect = false,
                    IconPath = "pp"
                },
                new ItemEffect()
                {
                    Name = "Soins",
                    AddHexId = "b2",
                    RemHexId = "b3",
                    IsCacEffect = false,
                    IconPath = "soin"
                },
                new ItemEffect()
                {
                    Name = "Créatures Invocables",
                    AddHexId = "b6",
                    RemHexId = "",
                    IsCacEffect = false,
                    IconPath = "invoc"
                },
                new ItemEffect()
                {
                    Name = "Vol de PDV (neutre)",
                    AddHexId = "5f",
                    RemHexId = "",
                    IsCacEffect = true,
                    IconPath = "DoNeutre"
                },
                new ItemEffect()
                {
                    Name = "Vol de PDV (terre)",
                    AddHexId = "5c",
                    RemHexId = "",
                    IsCacEffect = true,
                    IconPath = "DoTerre"
                },
                new ItemEffect()
                {
                    Name = "Vol de PDV (feu)",
                    AddHexId = "5e",
                    RemHexId = "",
                    IsCacEffect = true,
                    IconPath = "DoFeu"
                },
                new ItemEffect()
                {
                    Name = "Vol de PDV (eau)",
                    AddHexId = "5b",
                    RemHexId = "",
                    IsCacEffect = true,
                    IconPath = "DoEau"
                },
                new ItemEffect()
                {
                    Name = "Vol de PDV (air)",
                    AddHexId = "5d",
                    RemHexId = "",
                    IsCacEffect = true,
                    IconPath = "DoAir"
                },
                new ItemEffect()
                {
                    Name = "Dommages (neutre)",
                    AddHexId = "64",
                    RemHexId = "",
                    IsCacEffect = true,
                    IconPath = "DoNeutre"
                },
                new ItemEffect()
                {
                    Name = "Dommages (terre)",
                    AddHexId = "61",
                    RemHexId = "",
                    IsCacEffect = true,
                    IconPath = "DoTerre"
                },
                new ItemEffect()
                {
                    Name = "Dommages (feu)",
                    AddHexId = "63",
                    RemHexId = "",
                    IsCacEffect = true,
                    IconPath = "DoFeu"
                },
                new ItemEffect()
                {
                    Name = "Dommages (eau)",
                    AddHexId = "60",
                    RemHexId = "",
                    IsCacEffect = true,
                    IconPath = "DoEau"
                },
                new ItemEffect()
                {
                    Name = "Dommages (air)",
                    AddHexId = "62",
                    RemHexId = "",
                    IsCacEffect = true,
                    IconPath = "DoAir"
                },
            };
            return effects;
        }

        /// <summary>
        /// Calculating the final Hex values
        /// </summary>
        /// <param name="effectIdHex"> Effect ID in Hex</param>
        /// <param name="jet1">Jet Min</param>
        /// <param name="jet2">Jet Max</param>
        /// <param name="isFirst">It is the first Carac ?</param>
        /// <returns></returns>
        public static string CalcEffectItem(string effectIdHex, int jet1, int jet2, bool isFirst)
        {
            int num = 1;
            int num2 = jet2;
            int num3 = jet1;
            string jetHex1 = num3.ToString("X");
            string jetHex2 = num2.ToString("X");
            if (num2 == 0)
            {
                num = 0;
            }
            else
            {
                num2 -= num3 + 1;
                num3--;
            }
            string result;
            if (!isFirst)
            {
                result = ";" + effectIdHex + "#" + jetHex1 + "#" + jetHex2 + "#0#" + num + "d" + num2 + "+" + num3;
            }
            else
            {
                result = effectIdHex + "#" + jetHex1 + "#" + jetHex2 + "#0#" + num + "d" + num2 + "+" + num3;
            }
            return result;
        }
        public static string CalcJetD(int jet1, int jet2)
        {
            int num = 1;
            int num2 = jet2;
            int num3 = jet1;
            string jetHex1 = num3.ToString("X");
            string jetHex2 = num2.ToString("X");
            if (num2 == 0)
            {
                num = 0;
            }
            else
            {
                num2 -= num3 + 1;
                num3--;
            }

            return num + "d" + num2 + "+" + num3;
        }
        /// <summary>
        /// Give the Directory to load the StatsTemplate of an Item
        /// </summary>
        /// <param name="statsTemplate"></param>
        /// <returns></returns>
        public static Dictionary<ItemEffect, string[]> UnCryptEffectItem(string statsTemplate)
        {
            Dictionary<ItemEffect, string[]> dico = new();
            string[] effects = statsTemplate.Split(';');
            foreach(string effect in effects)
            {
                string[] detail = effect.Split("#");
                string effectIdHex = detail[0];
                int jetMin = Convert.ToInt32(detail[1],16);
                int jetMax = Convert.ToInt32(detail[2],16);

                dico.Add(GetItemEffect(effectIdHex)!, new string[] { effectIdHex, jetMin.ToString(), jetMax.ToString() });
            }
            return dico;
        }
        /// <summary>
        /// Get sign with the EffectId in Hex (Add or Remove)
        /// </summary>
        /// <param name="effectIdHex"></param>
        /// <returns></returns>
        public static string GetStatsSign(string effectIdHex)
        {
            string sign = "";
            List<ItemEffect> effects = GenerateAllEffect();
            foreach(ItemEffect effect in effects)
            {
                if(effectIdHex == effect.AddHexId)
                {
                    sign = "+";
                    break;
                }
                else if(effectIdHex == effect.RemHexId)
                {
                    sign = "-";
                    break;
                }
                else
                {
                    continue;
                }
            }
            return sign;
        }
        /// <summary>
        /// Get ItemEffect with effectId in Hex
        /// </summary>
        /// <param name="effectIdHex"></param>
        /// <returns></returns>
        public static ItemEffect? GetItemEffect(string effectIdHex)
        {
            List<ItemEffect> effects = GenerateAllEffect();
           ItemEffect? item = effects.FirstOrDefault(c => c.AddHexId == effectIdHex);
            item ??= effects.FirstOrDefault(c=> c.RemHexId == effectIdHex);

            return item;
        }
        /// <summary>
        /// Move the index of one Dictionary Item
        /// </summary>
        /// <param name="oldIndex"></param>
        /// <param name="newIndex"></param>
        /// <param name="dic"></param>
        /// <returns></returns>
        public static Dictionary<ItemEffect, string[]> Move(int oldIndex, int newIndex, Dictionary<ItemEffect, string[]> dic)
        {
            Dictionary<ItemEffect, string[]> newDictionnary = new();

            ItemEffect oldIndexEffect = dic.Keys.ElementAt(newIndex);
            string[] oldIndexArgs = dic.Values.ElementAt(newIndex);

            ItemEffect newIndexEffect = dic.Keys.ElementAt(oldIndex);
            string[] newIndexArgs = dic.Values.ElementAt(oldIndex);

            for(int i = 0; i < dic.Keys.Count; i++)
            {
                if(i == oldIndex)
                {
                    newDictionnary.Add(oldIndexEffect, oldIndexArgs);
                }
                else if (i == newIndex)
                {
                    newDictionnary.Add(newIndexEffect, newIndexArgs);
                }
                else
                {
                    newDictionnary.Add(dic.Keys.ElementAt(i), dic.Values.ElementAt(i));
                }
            }

            return newDictionnary;
        }
        /// <summary>
        /// Returns true if it's a weapon and false if it's not a weapon
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public static bool IsWeapon(ItemsType type)
        {
            switch(type.Id)
            {
                case 2:
                case 3:
                case 4:
                case 5:
                case 6:
                case 7:
                case 8:
                case 19:
                case 20:
                case 21:
                case 22:
                case 83:
                case 99:
                case 102:
                case 113:
                    return true;
                default: return false;
            }
        }
        /// <summary>
        /// Returns All Items Type
        /// </summary>
        /// <returns></returns>
        public static List<ItemsType> GetItemsTypes()
        {
            List<ItemsType> itemsTypes = new()
            {
                new ItemsType
                {
                    Id = 1,
                    Name = "Amulette"
                },
                new ItemsType
                {
                    Id = 2,
                    Name = "Arc"
                },
                new ItemsType
                {
                    Id = 3,
                    Name = "Baguette"
                },
                new ItemsType
                {
                    Id = 4,
                    Name = "Bâton"
                },
                new ItemsType
                {
                    Id = 5,
                    Name = "Dague"
                },
                new ItemsType
                {
                    Id = 6,
                    Name = "Epée"
                },
                new ItemsType
                {
                    Id = 7,
                    Name = "Marteau"
                },
                new ItemsType
                {
                    Id = 8,
                    Name = "Pelle"
                },
                new ItemsType
                {
                    Id = 9,
                    Name = "Anneau"
                },
                new ItemsType
                {
                    Id = 10,
                    Name = "Ceinture"
                },
                new ItemsType
                {
                    Id = 11,
                    Name = "Botte"
                },
                new ItemsType
                {
                    Id = 12,
                    Name = "Potion"
                },
                new ItemsType
                {
                    Id = 13,
                    Name = "Parchemin d'expérience"
                },
                new ItemsType
                {
                    Id = 14,
                    Name = "Objet de dons"
                },
                new ItemsType
                {
                    Id = 15,
                    Name = "Ressource"
                },
                new ItemsType
                {
                    Id = 16,
                    Name = "Chapeau"
                },
                new ItemsType
                {
                    Id = 17,
                    Name = "Cape"
                },
                new ItemsType
                {
                    Id = 18,
                    Name = "Famillier"
                },
                new ItemsType
                {
                    Id = 19,
                    Name = "Hache"
                },
                new ItemsType
                {
                    Id = 20,
                    Name = "Outil"
                },
                new ItemsType
                {
                    Id = 21,
                    Name = "Pioche"
                },
                new ItemsType
                {
                    Id = 22,
                    Name = "Faux"
                },
                new ItemsType
                {
                    Id = 23,
                    Name = "Dofus"
                },
                new ItemsType
                {
                    Id = 24,
                    Name = "Objet de Quête"
                },
                new ItemsType
                {
                    Id = 25,
                    Name = "Document"
                },
                new ItemsType
                {
                    Id = 26,
                    Name = "Potion de Forgemagie"
                },
                new ItemsType
                {
                    Id = 27,
                    Name = "Objet de Mutation"
                },
                new ItemsType
                {
                    Id = 28,
                    Name = "Nourritue boost"
                },
                new ItemsType
                {
                    Id = 29,
                    Name = "Bénédiction"
                },
                new ItemsType
                {
                    Id = 30,
                    Name = "Malédiction"
                },
                new ItemsType
                {
                    Id = 31,
                    Name = "Roleplay Buffs"
                },
                new ItemsType
                {
                    Id = 32,
                    Name = "Personnage suiveur"
                },
                new ItemsType
                {
                    Id = 33,
                    Name = "Pain"
                },
                new ItemsType
                {
                    Id = 34,
                    Name = "Céréale"
                },
                new ItemsType
                {
                    Id = 35,
                    Name = "Fleur"
                },
                new ItemsType
                {
                    Id = 36,
                    Name = "Plante"
                },
                new ItemsType
                {
                    Id = 37,
                    Name = "Bière"
                },
                new ItemsType
                {
                    Id = 38,
                    Name = "Bois"
                },
                new ItemsType
                {
                    Id = 39,
                    Name = "Minerai"
                },
                new ItemsType
                {
                    Id = 40,
                    Name = "Alliage"
                },
                new ItemsType
                {
                    Id = 41,
                    Name = "Poisson"
                },
                new ItemsType
                {
                     Id = 42,
                     Name = "Friandise"
                },
                new ItemsType
                {
                    Id = 43,
                    Name = "Potion d'oubli de sort"
                },
                new ItemsType
                {
                    Id = 44,
                    Name = "Potion d'oubli de métier"
                },
                new ItemsType
                {
                    Id = 45,
                    Name = "Potion d'oubli de maîtrise"
                },
                new ItemsType
                {
                    Id = 46,
                    Name = "Fruit"
                },
                new ItemsType
                {
                    Id = 47,
                    Name = "Os"
                },
                new ItemsType
                {
                    Id = 48,
                    Name = "Poudre"
                },
                new ItemsType
                {
                    Id = 49,
                    Name = "Poisson comestible"
                },
                new ItemsType
                {
                    Id = 50,
                    Name = "Pierre précieuse"
                },
                new ItemsType
                {
                    Id = 51,
                    Name = "Pierre brute"
                },
                new ItemsType
                {
                    Id = 52,
                    Name = "Farine"
                },
                new ItemsType
                {
                     Id = 53,
                     Name = "Plume"
                },
                new ItemsType
                {
                    Id = 54,
                    Name = "Poil"
                },
                new ItemsType
                {
                    Id = 55,
                    Name = "Etoffe"
                },
                new ItemsType
                {
                    Id = 56,
                    Name = "Cuir"
                },
                new ItemsType
                {
                     Id = 57,
                     Name = "Laine"
                },
                new ItemsType
                {
                    Id = 58,
                    Name = "Graine"
                },
                new ItemsType
                {
                    Id = 59,
                    Name = "Peau"
                },
                new ItemsType
                {
                    Id = 60,
                    Name = "Huile"
                },
                new ItemsType
                {
                    Id = 61,
                    Name = "Peluche"
                },
                new ItemsType
                {
                    Id = 62,
                    Name = "Poisson vidé"
                },
                new ItemsType
                {
                    Id = 63,
                    Name = "Viande"
                },
                new ItemsType
                {
                    Id = 64,
                    Name = "Viande conservée"
                },
                new ItemsType
                {
                    Id = 65,
                    Name = "Queue"
                },
                new ItemsType
                {
                    Id = 66,
                    Name = "Métaria"
                },
                new ItemsType
                {
                     Id = 68,
                     Name = "Légume"
                },
                new ItemsType
                {
                    Id = 69,
                    Name = "Viande comestible"
                },
                new ItemsType
                {
                    Id = 70,
                    Name = "Teinture"
                },
                new ItemsType
                {
                    Id = 71,
                    Name = "Matériel d'alchimie"
                },
                new ItemsType
                {
                    Id = 72,
                    Name = "Oeuf de Familier"
                },
                new ItemsType
                {
                    Id = 73,
                    Name = "Maîtrise"
                },
                new ItemsType
                {
                    Id = 74,
                    Name = "Fée d'artifice"
                },
                new ItemsType
                {
                    Id = 75,
                    Name = "Parchemin de Sort"
                },
                new ItemsType
                {
                    Id = 76,
                    Name = "Parchemin de caractéristique"
                },
                new ItemsType
                {
                    Id = 77,
                    Name = "Certificat de mise en chanil"
                },
                new ItemsType
                {
                    Id = 78,
                    Name = "Rune de forgemagie"
                },
                new ItemsType
                {
                    Id = 79,
                    Name = "Boisson"
                },
                new ItemsType
                {
                    Id = 80,
                    Name = "Objet de mission"
                },
                new ItemsType
                {
                    Id = 81,
                    Name = "Sac à dos"
                },
                new ItemsType
                {
                    Id = 82,
                    Name = "Bouclier"
                },
                new ItemsType
                {
                    Id = 83,
                    Name = "Pierre d'âme"
                },
                new ItemsType
                {
                    Id = 84,
                    Name = "Clefs"
                },
                new ItemsType
                {
                    Id = 85,
                    Name = "Pierre d'âme pleine"
                },
                new ItemsType
                {
                    Id = 86,
                    Name = "Potion d'oubli percepteur"
                },
                new ItemsType
                {
                    Id = 87,
                    Name = "Parchemin de recherche"
                },
                new ItemsType
                {
                    Id = 88,
                    Name = "Pierre magique"
                },
                new ItemsType
                {
                    Id = 89,
                    Name = "Cadeaux"
                },
                new ItemsType
                {
                    Id = 90,
                    Name = "Fantôme de Familier"
                },
                new ItemsType
                {
                     Id = 91,
                     Name = "Dragodinde"
                },
                new ItemsType
                {
                    Id = 92,
                    Name = "Bouftou"
                },
                new ItemsType
                {
                    Id = 93,
                    Name = "Objet d'élevage"
                },
                new ItemsType
                {
                    Id = 94,
                    Name = "Objet utilisable"
                },
                new ItemsType
                {
                    Id = 95,
                    Name = "Planche"
                },
                new ItemsType
                {
                    Id = 96,
                    Name = "Ecorce"
                },
                new ItemsType
                {
                    Id = 97,
                    Name = "Certificat de monture"
                },
                new ItemsType
                {
                    Id = 98,
                    Name = "Racine"
                },
                new ItemsType
                {
                     Id = 99,
                     Name = "Filet de capture"
                },
                new ItemsType
                {
                    Id = 100,
                    Name = "Sac de ressources"
                },
                new ItemsType
                {
                    Id = 102,
                    Name = "Arbalète"
                },
                new ItemsType
                {
                    Id = 103,
                    Name = "Patte"
                },
                new ItemsType
                {
                    Id = 104,
                    Name = "Aile"
                },
                new ItemsType
                {
                    Id = 105,
                    Name = "Oeuf"
                },
                new ItemsType
                {
                    Id = 106,
                    Name = "Oreille"
                },
                new ItemsType
                {
                    Id = 107,
                    Name = "Carapace"
                },
                new ItemsType
                {
                    Id = 108,
                    Name = "Bourgeon"
                },
                new ItemsType
                {
                    Id = 109,
                    Name = "Oeil"
                },
                new ItemsType
                {
                    Id = 110,
                    Name = "Gelée"
                },
                new ItemsType
                {
                    Id = 111,
                    Name = "Coquille"
                },
                new ItemsType
                {
                    Id = 112,
                    Name = "Prisme"
                },
                new ItemsType
                {
                    Id = 113,
                    Name = "Objet Vivant"
                },
                new ItemsType
                {
                    Id = 114,
                    Name = "Arme magique"
                },
                new ItemsType
                {
                    Id = 115,
                    Name = "Fragment d'âme de Shushu"
                },
                new ItemsType
                {
                    Id = 116,
                    Name = "Potion de familier"
                },
                new ItemsType
                {
                    Id = 119,
                    Name = "Carte commune"
                },
                new ItemsType
                {
                    Id = 120,
                    Name = "Carte rare"
                },
                new ItemsType
                {
                    Id = 121,
                    Name = "Carte épique"
                },
                new ItemsType
                {
                    Id = 122,
                    Name = "Carte ultime"
                },
                new ItemsType
                {
                    Id = 123,
                    Name = "Paquet de cartes"
                },
                new ItemsType
                {
                    Id = 124,
                    Name = "Pierre d'âme de gardien de donjon"
                },
                new ItemsType
                {
                    Id = 125,
                    Name = "Pierre d'âle d'Archi-monstre"
                },
                new ItemsType
                {
                    Id = 126,
                    Name = "Toniques"
                },
                new ItemsType
                {
                    Id = 127,
                    Name = "[Réservé]"
                }
            };
            return itemsTypes;
        }

        public static int GetLevelsForSpell(Sorts spell)
        {
            int count = 0;
            if(!string.IsNullOrEmpty(spell.Lvl1))
            {
                count++;
            }
            if (!string.IsNullOrEmpty(spell.Lvl2))
            {
                count++;
            }
            if (!string.IsNullOrEmpty(spell.Lvl3))
            {
                count++;
            }
            if (!string.IsNullOrEmpty(spell.Lvl4))
            {
                count++;
            }
            if (!string.IsNullOrEmpty(spell.Lvl5))
            {
                count++;
            }
            if (!string.IsNullOrEmpty(spell.Lvl6))
            {
                count++;
            }
            return count;
        }

        public static List<string> ParseMobGradesInfos(List<MobGrade> mobGrades)
        {
            List<string> finalString;
            string grade = "";
            string stats = "";
            string statsInfos = "";
            string spells = "";
            string points = "";
            string pdvs = "";
            string inits = "";
            string exps = "";

            for (int i = 0; i < mobGrades.Count; i++)
            {
                statsInfos = mobGrades[i].Dommages + ";" + mobGrades[i].DommagesPer + ";" + mobGrades[i].Soins + ";" + mobGrades[i].Creatures;
                if (i == mobGrades.Count - 1)
                {
                    grade += mobGrades[i].Level + "@" + mobGrades[i].ResNeutre + ";" + mobGrades[i].ResTerre + ";" + mobGrades[i].ResFeu + ";" + mobGrades[i].ResEau + ";" + mobGrades[i].ResAir + ";" + mobGrades[i].EsqPa + ";" + mobGrades[i].EsqPm;
                    stats += mobGrades[i].Force + "," + mobGrades[i].Sagesse + "," + mobGrades[i].Intelligence + "," + mobGrades[i].Chance + "," + mobGrades[i].Agilite;
                    for (int h = 0; h < mobGrades[i].Sorts?.Count; h++)
                    {
                        Sorts? spell = mobGrades[i]?.Sorts?[h];
                        int level = mobGrades[i].SortsLevels![h];
                        if (spell != null)
                        {
                            if (h == mobGrades[i].Sorts?.Count - 1)
                            {
                                spells += spell.Id + "@" + level;
                            }
                            else
                            {
                                spells += spell.Id + "@" + level + ";";
                            }
                        }
                    }
                    points += mobGrades[i].Pa + ";" + mobGrades[i].Pm;
                    pdvs += mobGrades[i].Vitalite;
                    inits += mobGrades[i].Initiative;
                    exps += mobGrades[i].Experience;
                }
                else
                {
                    grade += mobGrades[i].Level + "@" + mobGrades[i].ResNeutre + ";" + mobGrades[i].ResTerre + ";" + mobGrades[i].ResFeu + ";" + mobGrades[i].ResEau + ";" + mobGrades[i].ResAir + ";" + mobGrades[i].EsqPa + ";" + mobGrades[i].EsqPm + "|";
                    stats += mobGrades[i].Force + "," + mobGrades[i].Sagesse + "," + mobGrades[i].Intelligence + "," + mobGrades[i].Chance + "," + mobGrades[i].Agilite + "|";
                    for(int h = 0;h < mobGrades[i].Sorts?.Count; h++)
                    {
                        Sorts? spell = mobGrades[i]?.Sorts?[h];
                        int level = mobGrades[i].SortsLevels![h];
                        if (spell != null)
                        {
                            if (h == mobGrades[i].Sorts?.Count - 1)
                            {
                                spells += spell.Id + "@" + level + "|";
                            }
                            else
                            {
                                spells += spell.Id + "@" + level + ";";
                            }
                        }
                    }
                    points += mobGrades[i].Pa + ";" + mobGrades[i].Pm + "|";
                    pdvs += mobGrades[i].Vitalite + "|";
                    inits += mobGrades[i].Initiative + "|";
                    exps += mobGrades[i].Experience + "|";
                }
            }
            finalString = new()
            {
                grade,
                stats,
                statsInfos,
                spells,
                points,
                pdvs,
                inits,
                exps
            };

            return finalString;
        }

        public static string GenerateGradeMonstersSwf(Monsters monsters, bool isInvocation)
        {
            StringBuilder sb = new StringBuilder();
            string[] grades = monsters.Grades!.Split('|');
            string[] points = monsters.Points!.Split('|');
            string[] pdvs = monsters.Pdvs!.Split('|');
            if (isInvocation)
            {
                for (int i = 0; i < grades.Length; i++)
                {
                    int level = Convert.ToInt32(grades[i].Split('@')[0]);
                    string[] gradesDetails = grades[i].Split('@')[1].Split(';');
                    int Pa = Convert.ToInt32(points[i].Split(';')[0]);
                    int Pm = Convert.ToInt32(points[i].Split(';')[1]);
                    if (i == grades.Length - 1)
                    {
                        sb.Append("g")
                            .Append(i + 1)
                            .Append(":{l:")
                            .Append(level)
                            .Append(",r:[")
                            .Append(gradesDetails[0])
                            .Append(',')
                            .Append(gradesDetails[1])
                            .Append(',')
                            .Append(gradesDetails[2])
                            .Append(',')
                            .Append(gradesDetails[3])
                            .Append(',')
                            .Append(gradesDetails[4])
                            .Append(',')
                            .Append(gradesDetails[5])
                            .Append(',')
                            .Append(gradesDetails[6])
                            .Append("],lp:")
                            .Append(pdvs[i])
                            .Append(",ap:")
                            .Append(Pa)
                            .Append(",mp:")
                            .Append(Pm)
                            .Append("}};");
                    }
                    else
                    {
                        sb.Append("g")
                            .Append(i + 1)
                            .Append(":{l:")
                            .Append(level)
                            .Append(",r:[")
                            .Append(gradesDetails[0])
                            .Append(',')
                            .Append(gradesDetails[1])
                            .Append(',')
                            .Append(gradesDetails[2])
                            .Append(',')
                            .Append(gradesDetails[3])
                            .Append(',')
                            .Append(gradesDetails[4])
                            .Append(',')
                            .Append(gradesDetails[5])
                            .Append(',')
                            .Append(gradesDetails[6])
                            .Append("],lp:")
                            .Append(pdvs[i])
                            .Append(",ap:")
                            .Append(Pa)
                            .Append(",mp:")
                            .Append(Pm)
                            .Append("},");
                    }
                }
            }
            else
            {
                for (int i = 0; i < grades.Length; i++)
                {
                    int level = Convert.ToInt32(grades[i].Split('@')[0]);
                    string[] gradesDetails = grades[i].Split('@')[1].Split(';');
                    if (i == grades.Length - 1)
                    {
                        sb.Append("g")
                            .Append(i + 1)
                            .Append(":{l:")
                            .Append(level)
                            .Append(",r:[")
                            .Append(gradesDetails[0])
                            .Append(',')
                            .Append(gradesDetails[1])
                            .Append(',')
                            .Append(gradesDetails[2])
                            .Append(',')
                            .Append(gradesDetails[3])
                            .Append(',')
                            .Append(gradesDetails[4])
                            .Append(',')
                            .Append(gradesDetails[5])
                            .Append(',')
                            .Append(gradesDetails[6])
                            .Append("]}};");
                    }
                    else
                    {
                        sb.Append("g")
                            .Append(i + 1)
                            .Append(":{l:")
                            .Append(level)
                            .Append(",r:[")
                            .Append(gradesDetails[0])
                            .Append(',')
                            .Append(gradesDetails[1])
                            .Append(',')
                            .Append(gradesDetails[2])
                            .Append(',')
                            .Append(gradesDetails[3])
                            .Append(',')
                            .Append(gradesDetails[4])
                            .Append(',')
                            .Append(gradesDetails[5])
                            .Append(',')
                            .Append(gradesDetails[6])
                            .Append("]},");
                    }
                }
            }
            return sb.ToString();
        }

        public static List<Effects> GenerateAllPossibleSpellEffect()
        {
            List<Effects> list = new()
            {
                new Effects()
                {
                    EffectId = 4,
                    Name = "Téléporte à une distance de Min cases maximum."
                },
                new Effects()
                {
                    EffectId = 5,
                    Name = "Fait reculer de Min case(s)"
                },
                new Effects()
                {
                    EffectId = 6,
                    Name = "Fait avancer de Min case(s)"
                },
                new Effects()
                {
                    EffectId = 8,
                    Name = "Echange les place de 2 joueurs"
                },
                new Effects()
                {
                    EffectId = 9,
                    Name = "Esquive Min% des coups en reculant de Max case(s)"
                },
                new Effects()
                {
                    EffectId = 50,
                    Name = "Porter un joueur",
                },
                new Effects()
                {
                    EffectId = 51,
                    Name = "Jeter un joueur"
                },
                new Effects()
                {
                    EffectId = 77,
                    Name = "Vole Min à Max PM",
                    ImagePath = "pm"
                },
                new Effects()
                {
                    EffectId = 78,
                    Name = "Ajoute +Min PM",
                    ImagePath = "pm"
                },
                new Effects()
                {
                    EffectId = 79,
                    Name = "Min% dommages subis xMax, sinon soigné de xMax"
                },
                new Effects()
                {
                    EffectId = 81,
                    Name = "PDV rendus : Min à Max"
                },
                new Effects()
                {
                    EffectId = 82,
                    Name = "Vole Min à Max PDV (fixe)"
                },
                new Effects()
                {
                    EffectId = 84,
                    Name = "Vole Min à Max PA",
                    ImagePath = "pa"
                },
                new Effects()
                {
                    EffectId = 85,
                    Name = "Dommages : Min à Max% de la vie de l\'attaquant (eau)",
                    ImagePath = "DoEau"
                },
                new Effects()
                {
                    EffectId = 86,
                    Name = "Dommages : Min à Max% de la vie de l\'attaquant (terre)",
                    ImagePath = "DoTerre"
                },
                new Effects()
                {
                    EffectId = 87,
                    Name = "Dommages : Min à Max% de la vie de l\'attaquant (air)",
                    ImagePath = "DoAir"
                },
                new Effects()
                {
                    EffectId = 88,
                    Name = "Dommages : Min à Max% de la vie de l\'attaquant (feu)",
                    ImagePath = "DoFeu"
                },
                new Effects()
                {
                    EffectId = 89,
                    Name = "Dommages : Min à Max% de la vie de l\'attaquant (neutre)",
                    ImagePath = "DoNeutre"
                },
                new Effects()
                {
                    EffectId = 90,
                    Name = "Donne Min à Max % de sa vie",
                    ImagePath = "vita"
                },
                new Effects()
                {
                    EffectId = 91,
                    Name = "Vole Min à Max PDV (eau)",
                    ImagePath = "DoEau"
                },
                new Effects()
                {
                    EffectId = 92,
                    Name = "Vole Min à Max PDV (terre)",
                    ImagePath = "DoTerre"
                },
                new Effects()
                {
                    EffectId = 93,
                    Name = "Vole Min à Max PDV (air)",
                    ImagePath = "DoAir"
                },
                new Effects()
                {
                    EffectId = 94,
                    Name = "Vole Min à Max PDV (feu)",
                    ImagePath = "DoFeu"
                },
                new Effects()
                {
                    EffectId = 95,
                    Name = "Vole Min à Max PDV (neutre)",
                    ImagePath = "DoNeutre"
                },
                new Effects()
                {
                    EffectId = 96,
                    Name = "Dommages : Min à Max (eau)",
                    ImagePath = "DoEau"
                },
                new Effects()
                {
                    EffectId = 97,
                    Name = "Dommages : Min à Max (terre)",
                    ImagePath = "DoTerre"
                },
                new Effects()
                {
                    EffectId = 98,
                    Name = "Dommages : Min à Max (air)",
                    ImagePath = "DoAir"
                },
                new Effects()
                {
                    EffectId = 99,
                    Name = "Dommages : Min à Max (feu)",
                    ImagePath = "DoFeu"
                },
                new Effects()
                {
                    EffectId = 100,
                    Name = "Dommages : Min à Max (neutre)",
                    ImagePath = "DoNeutre"
                },
                new Effects()
                {
                    EffectId = 101,
                    Name = "PA perdus à la cible : Min à Max",
                    ImagePath = "pa"
                },
                new Effects()
                {
                    EffectId = 105,
                    Name = "Dommages réduits de  Min à Max"
                },
                new Effects()
                {
                    EffectId = 106,
                    Name = "Renvoie un sort de niveau Min maximum"
                },
                new Effects()
                {
                    EffectId = 107,
                    Name = "Dommages retournés : Min à Max",
                    ImagePath = "DoPer"
                },
                new Effects()
                {
                    EffectId = 108,
                    Name = "PDV rendus : Min à Max",
                    ImagePath = "soin"
                },
                new Effects()
                {
                    EffectId = 109,
                    Name = "Dommages pour le lanceur : Min à Max",
                    ImagePath = "DoPer"
                },
                new Effects()
                {
                    EffectId = 110,
                    Name = "+Min à Max en vie",
                    ImagePath = "vita"
                },
                new Effects()
                {
                    EffectId = 111,
                    Name = "+Min à Max PA",
                    ImagePath = "pa"
                },
                new Effects()
                {
                    EffectId = 112,
                    Name = "+Min à Max de dommages",
                    ImagePath = "DoPer"
                },
                new Effects()
                {
                    EffectId = 113,
                    Name = "Double les dommages ou rend  Min à Max PDV",
                    ImagePath = "DoPer"
                },
                new Effects()
                {
                    EffectId = 114,
                    Name = "Multiplie les dommages par Min",
                    ImagePath = "DoPer"
                },
                new Effects()
                {
                    EffectId = 115,
                    Name = "Min à Max aux coups critiques",
                    ImagePath = "crit"
                },
                new Effects()
                {
                    EffectId = 116,
                    Name = "-Min à -Max à la portée",
                    ImagePath = "po"
                },
                new Effects()
                {
                    EffectId = 117,
                    Name = "+Min à Max à la portée",
                    ImagePath = "po"
                },
                new Effects()
                {
                    EffectId = 118,
                    Name = "+Min à Max en force",
                    ImagePath = "force"
                },
                new Effects()
                {
                    EffectId = 119,
                    Name = "+Min à Max en agilité ",
                    ImagePath = "agi"
                },
                new Effects()
                {
                    EffectId = 120,
                    Name = "Ajoute +Min à Max PA",
                    ImagePath = "pa"
                },
                new Effects()
                {
                    EffectId = 121,
                    Name = "+Min à Max de dommages",
                    ImagePath = "DoPer"
                },
                new Effects()
                {
                    EffectId = 122,
                    Name = "+Min à Max aux échecs critiques",
                    ImagePath = "crit"
                },
                new Effects()
                {
                    EffectId = 123,
                    Name = "+Min à Max à la chance",
                    ImagePath = "eau"
                },
                new Effects()
                {
                    EffectId = 124,
                    Name = "+Min à Max en sagesse",
                    ImagePath = "sagesse"
                },
                new Effects()
                {
                    EffectId = 125,
                    Name = "+Min à Max en vitalité",
                    ImagePath = "vita"
                },
                new Effects()
                {
                    EffectId = 126,
                    Name = "+Min à Max en intelligence",
                    ImagePath = "intel"
                },
                new Effects()
                {
                    EffectId = 127,
                    Name = "PM perdus : Min à Max",
                    ImagePath = "pm"
                },
                new Effects()
                {
                    EffectId = 128,
                    Name = "+Min à Max PM",
                    ImagePath = "pm"
                },
                new Effects()
                {
                    EffectId = 130,
                    Name = "Vole  Min à Max d\'or"
                },
                new Effects()
                {
                    EffectId = 131,
                    Name = "Min PA utilisés font perdre Max PDV"
                    ,
                    ImagePath = "pa"
                },
                new Effects()
                {
                    EffectId = 132,
                    Name = "Enlève les envoûtements"
                },
                new Effects()
                {
                    EffectId = 133,
                    Name = "PA perdus pour le lanceur : Min à Max"
                    ,
                    ImagePath = "pa"
                },
                new Effects()
                {
                    EffectId = 134,
                    Name = "PM perdus pour le lanceur : Min à Max"
                    ,
                    ImagePath = "pm"
                },
                new Effects()
                {
                    EffectId = 135,
                    Name = "Portée du lanceur réduite de : Min à Max"
                    ,
                    ImagePath = "po"
                },
                new Effects()
                {
                    EffectId = 136,
                    Name = "Portée du lanceur augmentée de : Min à Max",
                    ImagePath = "po"
                },
                new Effects()
                {
                    EffectId = 137,
                    Name = "Dommages physiques du lanceur augmentés de : Min à Max",
                    ImagePath = "DoPer"
                },
                new Effects()
                {
                    EffectId = 138,
                    Name = "Augmente les dommages de Min à Max%",
                    ImagePath = "DoPer"
                },
                new Effects()
                {
                    EffectId = 139,
                    Name = "Rend Min à Max points d\'énergie"
                },
                new Effects()
                {
                    EffectId = 140,
                    Name = "Fait passer le tour suivant"
                },
                new Effects()
                {
                    EffectId = 141,
                    Name = "Tue la cible"
                },
                new Effects()
                {
                    EffectId = 142,
                    Name = "+Min à Max aux dommages physiques",
                    ImagePath = "DoPer"
                },
                new Effects()
                {
                    EffectId = 143,
                    Name = "PDV rendus : Min à Max",
                    ImagePath = "soin"
                },
                new Effects()
                {
                    EffectId = 144,
                    Name = "Dommages : Min à Max (non boostés)",
                    ImagePath = "Doper"
                },
                new Effects()
                {
                    EffectId = 145,
                    Name = "-Min à Max aux dommages",
                    ImagePath = "DoPer"
                },
                new Effects()
                {
                    EffectId = 146,
                    Name = "Change les paroles"
                },
                new Effects()
                {
                    EffectId = 147,
                    Name = "Ressuscite un allié "
                },
                new Effects()
                {
                    EffectId = 148,
                    Name = "Quelqu\'un vous suit !"
                },
                new Effects()
                {
                    EffectId = 149,
                    Name = "Change l\'apparence"
                },
                new Effects()
                {
                    EffectId = 150,
                    Name = "Rend le personnage invisible"
                },
                new Effects()
                {
                    EffectId = 152,
                    Name = "-Min à -Max en chance",
                    ImagePath = "eau"
                },
                new Effects()
                {
                    EffectId = 153,
                    Name = "-Min à -Max en vitalité",
                    ImagePath = "vita"
                },
                new Effects()
                {
                    EffectId = 154,
                    Name = "-Min à -Max en agilité",
                    ImagePath = "agi"
                },
                new Effects()
                {
                    EffectId = 155,
                    Name = "-Min à -Max en intelligence",
                    ImagePath = "intel"
                },
                new Effects()
                {
                    EffectId = 156,
                    Name = "-Min à -Max en sagesse",
                    ImagePath = "sagesse"
                },
                new Effects()
                {
                    EffectId = 157,
                    Name = "-Min à -Max en force",
                    ImagePath = "force"
                },
                new Effects()
                {
                    EffectId = 158,
                    Name = "Augmente le poids portable de Min à Max pods",
                    ImagePath = "Pods"
                },
                new Effects()
                {
                    EffectId = 159,
                    Name = "Réduit le poids portable de Min à Max pods",
                    ImagePath = "Pods"
                },
                new Effects()
                {
                    EffectId = 160,
                    Name = "+Min à Max % de chance d\'esquiver les pertes de PA",
                    ImagePath = "pa"
                },
                new Effects()
                {
                    EffectId = 161,
                    Name = "+Min à Max % de chance d\'esquiver les pertes de PM",
                    ImagePath = "pm"
                },
                new Effects()
                {
                    EffectId = 162,
                    Name = "-Min à Max % de chance d\'esquiver les pertes de PA",
                    ImagePath = "pa"
                },
                new Effects()
                {
                    EffectId = 163,
                    Name = "-Min à Max % de chance d\'esquiver les pertes de PM",
                    ImagePath = "pm"
                },
                new Effects()
                {
                    EffectId = 164,
                    Name = "Dommages réduits de Min%",
                    ImagePath = "DoPer"
                },
                new Effects()
                {
                    EffectId = 165,
                    Name = "Augmente les dommages (Min) de Max%",
                    ImagePath = "DoPer"
                },
                new Effects()
                {
                    EffectId = 166,
                    Name = "PA retournés : Min à Max",
                    ImagePath = "pa"
                },
                new Effects()
                {
                    EffectId = 168,
                    Name = "-Min à -Max PA",
                    ImagePath = "pa"
                },
                new Effects()
                {
                    EffectId = 169,
                    Name = "-Min à -Max PM",
                    ImagePath = "pa"
                },
                new Effects()
                {
                    EffectId = 171,
                    Name = "-Min à Max aux coups critiques",
                    ImagePath = "crit"
                },
                new Effects()
                {
                    EffectId = 172,
                    Name = "Réduction magique diminué de Min à Max"
                },
                new Effects()
                {
                    EffectId = 173,
                    Name = "Réduction physique diminué de Min à Max"
                },
                new Effects()
                {
                    EffectId = 174,
                    Name = "+Min à Max en initiative",
                    ImagePath = "ini"
                },
                new Effects()
                {
                    EffectId = 175,
                    Name = "-Min à Max en initiative",
                    ImagePath = "ini"
                },
                new Effects()
                {
                    EffectId = 176,
                    Name = "+Min à Max en prospection",
                    ImagePath = "pp"
                },
                new Effects()
                {
                    EffectId = 177,
                    Name = "-Min à Max en prospection",
                    ImagePath = "pp"
                },
                new Effects()
                {
                    EffectId = 178,
                    Name = "+Min à Max de soins",
                    ImagePath = "soin"
                },
                new Effects()
                {
                    EffectId = 179,
                    Name = "-Min à Max de soins",
                    ImagePath = "soin"
                },
                new Effects()
                {
                    EffectId = 180,
                    Name = "Crée un double du lanceur de sort",
                    ImagePath = "invoc"
                },
                new Effects()
                {
                    EffectId = 181,
                    Name = "Invoque : Min",
                    ImagePath = "invoc"
                },
                new Effects()
                {
                    EffectId = 182,
                    Name = "+Min à Max créatures invocables",
                    ImagePath = "invoc"
                },
                new Effects()
                {
                    EffectId = 183,
                    Name = "Réduction magique de Min à Max"
                },
                new Effects()
                {
                    EffectId = 184,
                    Name = "Réduction physique de Min à Max"
                },
                new Effects()
                {
                    EffectId = 185,
                    Name = "Invoque une créature statique",
                    ImagePath = "invoc"
                },
                new Effects()
                {
                    EffectId = 186,
                    Name = "Diminue les dommages de Min à Max%"
                },
                new Effects()
                {
                    EffectId = 188,
                    Name = "Changer l\'alignement"
                },
                new Effects()
                {
                    EffectId = 194,
                    Name = "Gagner Min à Max kamas"
                },
                new Effects()
                {
                    EffectId = 197,
                    Name = "Transforme en Min"
                },
                new Effects()
                {
                    EffectId = 201,
                    Name = "Pose un objet au sol"
                },
                new Effects()
                {
                    EffectId = 202,
                    Name = "Dévoile tous les objets invisibles"
                },
                new Effects()
                {
                    EffectId = 206,
                    Name = "Ressuscite la cible"
                },
                new Effects()
                {
                    EffectId = 210,
                    Name = "Min à Max % de résistance à la terre",
                    ImagePath = "ReTerre"
                },
                new Effects()
                {
                    EffectId = 211,
                    Name = "Min à Max % de résistance à l\'eau",
                    ImagePath = "ReEau"
                },
                new Effects()
                {
                    EffectId = 212,
                    Name = "Min à Max % de résistance à l\'air",
                    ImagePath = "ReAir"
                },
                new Effects()
                {
                    EffectId = 213,
                    Name = "Min à Max % de résistance au feu",
                    ImagePath = "ReFeu"
                },
                new Effects()
                {
                    EffectId = 214,
                    Name = "Min à Max % de résistance neutre",
                    ImagePath = "ReNeutre"
                },
                new Effects()
                {
                    EffectId = 215,
                    Name = "Min à Max % de faiblesse face à la terre",
                    ImagePath = "ReTerre"
                },
                new Effects()
                {
                    EffectId = 216,
                    Name = "Min à Max % de faiblesse face à l\'eau",
                    ImagePath = "ReEau"
                },
                new Effects()
                {
                    EffectId = 217,
                    Name = "Min à Max % de faiblesse face à l\'air",
                    ImagePath = "ReAir"
                },
                new Effects()
                {
                    EffectId = 218,
                    Name = "Min à Max % de faiblesse face au feu",
                    ImagePath = "ReFeu"
                },
                new Effects()
                {
                    EffectId = 219,
                    Name = "Min à Max % de faiblesse neutre",
                    ImagePath = "ReNeutre"
                },
                new Effects()
                {
                    EffectId = 220,
                    Name = "Renvoie Min à Max dommages"
                },
                new Effects()
                {
                    EffectId = 221,
                    Name = "Qu\'y a-t-il là dedans ?"
                },
                new Effects()
                {
                    EffectId = 222,
                    Name = "Qu\'y a-t-il là dedans ?"
                },
                new Effects()
                {
                    EffectId = 225,
                    Name = "+Min à Max de dommages aux pièges"
                },
                new Effects()
                {
                    EffectId = 226,
                    Name = "+Min à Max% de dommages aux pièges"
                },
                new Effects()
                {
                    EffectId = 229,
                    Name = "Récupère une monture !"
                },
                new Effects()
                {
                    EffectId = 230,
                    Name = "+Min en énergie perdue"
                },
                new Effects()
                {
                    EffectId = 240,
                    Name = "+Min à Max de résistance à la terre",
                    ImagePath = "ReTerre"
                },
                new Effects()
                {
                    EffectId = 241,
                    Name = "+Min à Max de résistance à l\'eau",
                    ImagePath = "ReEau"
                },
                new Effects()
                {
                    EffectId = 242,
                    Name = "+Min à Max de résistance à l\'air",
                    ImagePath = "ReAir"
                },
                new Effects()
                {
                    EffectId = 243,
                    Name = "+Min à Max de résistance au feu",
                    ImagePath = "ReFeu"
                },
                new Effects()
                {
                    EffectId = 244,
                    Name = "+Min à Max de résistance neutre",
                    ImagePath = "ReNeutre"
                },
                new Effects()
                {
                    EffectId = 245,
                    Name = "-Min à Max de résistance à la terre",
                    ImagePath = "ReTerre"
                },
                new Effects()
                {
                    EffectId = 246,
                    Name = "-Min à Max de résistance à l\'eau",
                    ImagePath = "ReEau"
                },
                new Effects()
                {
                    EffectId = 247,
                    Name = "-Min à Max de résistance à l\'air",
                    ImagePath = "ReAir"
                },
                new Effects()
                {
                    EffectId = 248,
                    Name = "-Min à Max de résistance au feu",
                    ImagePath = "ReFeu"
                },
                new Effects()
                {
                    EffectId = 249,
                    Name = "-Min à Max de résistance neutre",
                    ImagePath = "ReNeutre"
                },
                new Effects()
                {
                    EffectId = 250,
                    Name = "Min à Max % de res. terre face aux combattants ",
                    ImagePath = "ReTerre"
                },
                new Effects()
                {
                    EffectId = 251,
                    Name = "Min à Max % de res. eau face aux combattants",
                    ImagePath = "ReEau"
                },
                new Effects()
                {
                    EffectId = 252,
                    Name = "Min à Max % de res. air face aux combattants",
                    ImagePath = "ReAir"
                },
                new Effects()
                {
                    EffectId = 253,
                    Name = "Min à Max % de res. feu face aux combattants",
                    ImagePath = "ReFeu"
                },
                new Effects()
                {
                    EffectId = 254,
                    Name = "Min à Max % de res. neutre face aux combattants",
                    ImagePath = "ReNeutre"
                },
                new Effects()
                {
                    EffectId = 255,
                    Name = "Min à Max % de faiblesse terre face aux combattants",
                    ImagePath = "ReTerre"
                },
                new Effects()
                {
                    EffectId = 256,
                    Name = "Min à Max % de faiblesse eau face aux combattants",
                    ImagePath = "ReEau"
                },
                new Effects()
                {
                    EffectId = 257,
                    Name = "Min à Max % de faiblesse air face aux combattants",
                    ImagePath = "ReAir"
                },
                new Effects()
                {
                    EffectId = 258,
                    Name = "Min à Max % de faiblesse feu face aux combattants",
                    ImagePath = "ReFeu"
                },
                new Effects()
                {
                    EffectId = 259,
                    Name = "Min à Max % de faiblesse neutre face aux combattants",
                    ImagePath = "ReNeutre"
                },
                new Effects()
                {
                    EffectId = 260,
                    Name = "+Min à Max de res. terre face aux combattants ",
                    ImagePath = "ReTerre"
                },
                new Effects()
                {
                    EffectId = 261,
                    Name = "+Min à Max de res. eau face aux combattants ",
                    ImagePath = "ReEau"
                },
                new Effects()
                {
                    EffectId = 262,
                    Name = "+Min à Max de res. air face aux combattants",
                    ImagePath = "ReAir"
                },
                new Effects()
                {
                    EffectId = 263,
                    Name = "+Min à Max de res. feu aux combattants",
                    ImagePath = "ReFeu"
                },
                new Effects()
                {
                    EffectId = 264,
                    Name = "+Min à Max de res. neutre aux combattants",
                    ImagePath = "ReNeutre"
                },
                new Effects()
                {
                    EffectId = 265,
                    Name = "Dommages réduits de Min à Max",
                    ImagePath = "DoPer"
                },
                new Effects()
                {
                    EffectId = 266,
                    Name = "Min à Max vol de chance",
                    ImagePath = "eau"
                },
                new Effects()
                {
                    EffectId = 267,
                    Name = "Min{~1~2 à -}Max vol de vitalité",
                    ImagePath = "vita"
                },
                new Effects()
                {
                    EffectId = 268,
                    Name = "Min à Max vol d\'agilité ",
                    ImagePath = "agi"
                },
                new Effects()
                {
                    EffectId = 269,
                    Name = "Min à Max vol d\'intelligence",
                    ImagePath = "intel"
                },
                new Effects()
                {
                    EffectId = 270,
                    Name = "Min à Max vol de sagesse",
                    ImagePath = "sagesse"
                },
                new Effects()
                {
                    EffectId = 271,
                    Name = "Min à Max vol de force",
                    ImagePath = "force"
                },
                new Effects()
                {
                    EffectId = 275,
                    Name = "Dommages : Min à Max% de la vie manquante de l\'attaquant (eau)",
                    ImagePath = "DoEau"
                },
                new Effects()
                {
                    EffectId = 276,
                    Name = "Dommages : Min à Max% de la vie manquante de l\'attaquant (terre)",
                    ImagePath = "DoTerre"
                },
                new Effects()
                {
                    EffectId = 277,
                    Name = "Dommages : Min à Max% de la vie manquante de l\'attaquant (air)",
                    ImagePath = "Doair"
                },
                new Effects()
                {
                    EffectId = 278,
                    Name = "Dommages : Min à Max% de la vie manquante de l\'attaquant (feu)",
                    ImagePath = "DoFeu"
                },
                new Effects()
                {
                    EffectId = 279,
                    Name = "Dommages : Min à Max% de la vie manquante de l\'attaquant (neutre)",
                    ImagePath = "DoNeutre"
                },
                new Effects()
                {
                    EffectId = 281,
                    Name = "Augmente la portée du sort Min de #3",
                    ImagePath = "po"
                },
                new Effects()
                {
                    EffectId = 282,
                    Name = "Rend la portée du sort Min modifiable",
                    ImagePath = "po"
                },
                new Effects()
                {
                    EffectId = 283,
                    Name = "+#3 de dommages sur le sort Min"
                },
                new Effects()
                {
                    EffectId = 284,
                    Name = "+#3 de soins sur le sort Min"
                },
                new Effects()
                {
                    EffectId = 285,
                    Name = "Réduit de #3 le coût en PA du sort Min"
                },
                new Effects()
                {
                    EffectId = 286,
                    Name = "Réduit de #3 le délai de relance du sort Min"
                },
                new Effects()
                {
                    EffectId = 287,
                    Name = "+#3 aux CC sur le sort Min"
                },
                new Effects()
                {
                    EffectId = 288,
                    Name = "Désactive le lancer en ligne du sort Min"
                },
                new Effects()
                {
                    EffectId = 289,
                    Name = "Désactive la ligne de vue du sort Min"
                },
                new Effects()
                {
                    EffectId = 290,
                    Name = "Augmente de #3 le nombre de lancer maximal par tour du sort Min"
                },
                new Effects()
                {
                    EffectId = 291,
                    Name = "Augmente de #3 le nombre de lancer maximal par cible du sort Min"
                },
                new Effects()
                {
                    EffectId = 292,
                    Name = "Fixe à #3 le délai de relance du sort Min"
                },
                new Effects()
                {
                    EffectId = 293,
                    Name = "Augmente les dégâts de base du sort Min de #3"
                },
                new Effects()
                {
                    EffectId = 294,
                    Name = "Diminue la portée du sort Min de #3"
                },
                new Effects()
                {
                    EffectId = 310,
                    Name = "null"
                },
                new Effects()
                {
                    EffectId = 320,
                    Name = "Vole Min à Max PO",
                    ImagePath = "po"
                },
                new Effects()
                {
                    EffectId = 333,
                    Name = "Change une couleur"
                },
                new Effects()
                {
                    EffectId = 335,
                    Name = "Change l\'apparence"
                },
                new Effects()
                {
                    EffectId = 400,
                    Name = "Pose un piège de rang Min"
                },
                new Effects()
                {
                    EffectId = 401,
                    Name = "Pose un glyphe de rang Min"
                },
                new Effects()
                {
                    EffectId = 402,
                    Name = "Pose un glyphe de rang Min"
                },
                new Effects()
                {
                    EffectId = 405,
                    Name = "Tue et remplace par une invocation"
                },
                new Effects()
                {
                    EffectId = 406,
                    Name = "[wip]Enlève les effets du sort %1"
                },
                new Effects()
                {
                    EffectId = 513,
                    Name = "Pose un prisme"
                },
                new Effects()
                {
                    EffectId = 600,
                    Name = "Téléporte au point de sauvegarde"
                },
                new Effects()
                {
                    EffectId = 601,
                    Name = "null"
                },
                new Effects()
                {
                    EffectId = 602,
                    Name = "Enregistre sa position"
                },
                new Effects()
                {
                    EffectId = 603,
                    Name = "Apprend le métier Min"
                },
                new Effects()
                {
                    EffectId = 604,
                    Name = "Apprend le sort Min"
                },
                new Effects()
                {
                    EffectId = 605,
                    Name = "+Min à Max points d\' XP",
                    ImagePath = "XP"
                },
                new Effects()
                {
                    EffectId = 606,
                    Name = "+Min à Max en sagesse",
                    ImagePath = "sagesse"
                },
                new Effects()
                {
                    EffectId = 607,
                    Name = "+Min à Max en force",
                    ImagePath = "force"
                },
                new Effects()
                {
                    EffectId = 608,
                    Name = "+Min à Max en chance",
                    ImagePath = "eau"
                },
                new Effects()
                {
                    EffectId = 609,
                    Name = "+Min à Max en agilité",
                    ImagePath = "agi"
                },
                new Effects()
                {
                    EffectId = 610,
                    Name = "+Min à Max en vitalité",
                    ImagePath = "vita"
                },
                new Effects()
                {
                    EffectId = 611,
                    Name = "+Min à Max en intelligence",
                    ImagePath = "intel"
                },
                new Effects()
                {
                    EffectId = 612,
                    Name = "+Min à Max points de caractéristique"
                },
                new Effects()
                {
                    EffectId = 613,
                    Name = "+Min à Max points de sort"
                },
                new Effects()
                {
                    EffectId = 614,
                    Name = "+ Min d\'XP dans le métier Max"
                },
                new Effects()
                {
                    EffectId = 615,
                    Name = "Fait oublier le métier de Min"
                },
                new Effects()
                {
                    EffectId = 616,
                    Name = "Fait oublier un niveau du sort Min"
                },
                new Effects()
                {
                    EffectId = 620,
                    Name = "Consulter Min"
                },
                new Effects()
                {
                    EffectId = 621,
                    Name = "Invoque : #3 (grade Min)"
                },
                new Effects()
                {
                    EffectId = 622,
                    Name = "Téléporte chez soi"
                },
                new Effects()
                {
                    EffectId = 623,
                    Name = "Invoque : Min"
                },
                new Effects()
                {
                    EffectId = 624,
                    Name = "Fait oublier un niveau du sort Min"
                },
                new Effects()
                {
                    EffectId = 625,
                    Name = "null"
                },
                new Effects()
                {
                    EffectId = 626,
                    Name = "null"
                },
                new Effects()
                {
                    EffectId = 627,
                    Name = "Reproduit la carte d\'origine"
                },
                new Effects()
                {
                    EffectId = 628,
                    Name = "Invoque : Min"
                },
                new Effects()
                {
                    EffectId = 631,
                    Name = "null"
                },
                new Effects()
                {
                    EffectId = 640,
                    Name = "Ajoute Min points d\'honneur"
                },
                new Effects()
                {
                    EffectId = 641,
                    Name = "Ajoute Min points de déshonneur"
                },
                new Effects()
                {
                    EffectId = 642,
                    Name = "Retire Min points d\'honneur"
                },
                new Effects()
                {
                    EffectId = 643,
                    Name = "Retire Min points de déshonneur"
                },
                new Effects()
                {
                    EffectId = 645,
                    Name = "Ressuscite les alliés présents sur la carte"
                },
                new Effects()
                {
                    EffectId = 646,
                    Name = "PDV rendus : Min à Max"
                },
                new Effects()
                {
                    EffectId = 647,
                    Name = "Libère les âmes des ennemis"
                },
                new Effects()
                {
                    EffectId = 648,
                    Name = "Libère une âme ennemie"
                },
                new Effects()
                {
                    EffectId = 649,
                    Name = "Faire semblant d\'être Min"
                },
                new Effects()
                {
                    EffectId = 654,
                    Name = "null"
                },
                new Effects()
                {
                    EffectId = 666,
                    Name = "Pas d\'effet supplémentaire"
                },
                new Effects()
                {
                    EffectId = 669,
                    Name = "Incarnation de niveau Min"
                },
                new Effects()
                {
                    EffectId = 670,
                    Name = "Dommages : Min à Max% de la vie de l\'attaquant (neutre)"
                },
                new Effects()
                {
                    EffectId = 671,
                    Name = "Dommages : Min à Max% de la vie de l\'attaquant (neutre)"
                },
                new Effects()
                {
                    EffectId = 672,
                    Name = "Dommages : Min à Max% de la vie de l\'attaquant (neutre)"
                },
                new Effects()
                {
                    EffectId = 699,
                    Name = "Lier son métier : Min"
                },
                new Effects()
                {
                    EffectId = 700,
                    Name = "Change l\'élément de frappe"
                },
                new Effects()
                {
                    EffectId = 701,
                    Name = "Puissance : Min à Max"
                },
                new Effects()
                {
                    EffectId = 702,
                    Name = "+Min à Max point de durabilité "
                },
                new Effects()
                {
                    EffectId = 705,
                    Name = "Min% capture d\'âme de puissance #3"
                },
                new Effects()
                {
                    EffectId = 706,
                    Name = "Min% de proba de capturer une monture"
                },
                new Effects()
                {
                    EffectId = 710,
                    Name = "Coût supplémentaire"
                },
                new Effects()
                {
                    EffectId = 715,
                    Name = "Min : #3"
                },
                new Effects()
                {
                    EffectId = 716,
                    Name = "Min : #3"
                },
                new Effects()
                {
                    EffectId = 717,
                    Name = "Min : #3"
                },
                new Effects()
                {
                    EffectId = 720,
                    Name = "Nombre de victimes : Min"
                },
                new Effects()
                {
                    EffectId = 724,
                    Name = "Afficher le titre : « Min » "
                },
                new Effects()
                {
                    EffectId = 725,
                    Name = "Renommer la guilde : #4"
                },
                new Effects()
                {
                    EffectId = 730,
                    Name = "Téléporte au prisme allié le plus proche"
                },
                new Effects()
                {
                    EffectId = 731,
                    Name = "Agresse les joueurs de l\'alignement ennemi automatiquement"
                },
                new Effects()
                {
                    EffectId = 740,
                    Name = ""
                },
                new Effects()
                {
                    EffectId = 741,
                    Name = "null"
                },
                new Effects()
                {
                    EffectId = 742,
                    Name = "null"
                },
                new Effects()
                {
                    EffectId = 750,
                    Name = "Bonus aux chances de capture : Min à Max%"
                },
                new Effects()
                {
                    EffectId = 751,
                    Name = "Bonus à l\'xp de la dragodinde : Min à Max%"
                },
                new Effects()
                {
                    EffectId = 760,
                    Name = "Disparaît en se déplaçant"
                },
                new Effects()
                {
                    EffectId = 765,
                    Name = "Echange les places de 2 joueurs"
                },
                new Effects()
                {
                    EffectId = 770,
                    Name = "Confusion horaire : Min à Max degrés"
                },
                new Effects()
                {
                    EffectId = 771,
                    Name = "Confusion horaire : Min à Max Pi/2"
                },
                new Effects()
                {
                    EffectId = 772,
                    Name = "Confusion horaire : Min à Max Pi/4"
                },
                new Effects()
                {
                    EffectId = 773,
                    Name = "Confusion contre horaire : Min à Max degrés"
                },
                new Effects()
                {
                    EffectId = 774,
                    Name = "Confusion contre horaire : Min à Max Pi/2"
                },
                new Effects()
                {
                    EffectId = 775,
                    Name = "Confusion contre horaire : Min à Max Pi/4"
                },
                new Effects()
                {
                    EffectId = 776,
                    Name = "+Min à Max% de dégâts subis permanents"
                },
                new Effects()
                {
                    EffectId = 780,
                    Name = "Invoque le dernier allié mort avec Min à Max % de ses PDV"
                },
                new Effects()
                {
                    EffectId = 781,
                    Name = "Minimise les effets aléatoires"
                },
                new Effects()
                {
                    EffectId = 782,
                    Name = "Maximise les effets aléatoires"
                },
                new Effects()
                {
                    EffectId = 783,
                    Name = "Pousse jusqu\'à la case visée"
                },
                new Effects()
                {
                    EffectId = 784,
                    Name = "Retour à la position de départ"
                },
                new Effects()
                {
                    EffectId = 785,
                    Name = "null"
                },
                new Effects()
                {
                    EffectId = 786,
                    Name = "Soigne sur attaque"
                },
                new Effects()
                {
                    EffectId = 787,
                    Name = "Min"
                },
                new Effects()
                {
                    EffectId = 788,
                    Name = "Châtiment de Min sur #3 tour(s)"
                },
                new Effects()
                {
                    EffectId = 789,
                    Name = "null"
                },
                new Effects()
                {
                    EffectId = 790,
                    Name = "null"
                },
                new Effects()
                {
                    EffectId = 791,
                    Name = "Prépare Min à Max parchemins pour mercenaire [wait]"
                },
                new Effects()
                {
                    EffectId = 795,
                    Name = "Arme de chasse"
                },
                new Effects()
                {
                    EffectId = 800,
                    Name = "Points de vie : Min"
                },
                new Effects()
                {
                    EffectId = 805,
                    Name = "Reçu le : Min"
                },
                new Effects()
                {
                    EffectId = 806,
                    Name = "Corpulence : Min"
                },
                new Effects()
                {
                    EffectId = 807,
                    Name = "Dernier repas : Min"
                },
                new Effects()
                {
                    EffectId = 808,
                    Name = "A mangé le : Min"
                },
                new Effects()
                {
                    EffectId = 810,
                    Name = "Taille : Min poces"
                },
                new Effects()
                {
                    EffectId = 811,
                    Name = "Tour(s) restant(s) : Min"
                },
                new Effects()
                {
                    EffectId = 812,
                    Name = "Résistance : Min / #3"
                },
                new Effects()
                {
                    EffectId = 813,
                    Name = "null"
                },
                new Effects()
                {
                    EffectId = 814,
                    Name = "Min"
                },
                new Effects()
                {
                    EffectId = 815,
                    Name = "null"
                },
                new Effects()
                {
                    EffectId = 816,
                    Name = "null"
                },
                new Effects()
                {
                    EffectId = 825,
                    Name = "Téléporte"
                },
                new Effects()
                {
                    EffectId = 856,
                    Name = "Voir la collection de cartes"
                },
                new Effects()
                {
                    EffectId = 857,
                    Name = "[NO_TRAD]"
                },
                new Effects()
                {
                    EffectId = 905,
                    Name = "Lance un combat contre Min"
                },
                new Effects()
                {
                    EffectId = 930,
                    Name = "Augmente la sérénité, diminue l\'agressivité "
                },
                new Effects()
                {
                    EffectId = 931,
                    Name = "Augmente l\'agressivité, diminue la sérénité "
                },
                new Effects()
                {
                    EffectId = 932,
                    Name = "Augmente l\'endurance"
                },
                new Effects()
                {
                    EffectId = 933,
                    Name = "Diminue l\'endurance"
                },
                new Effects()
                {
                    EffectId = 934,
                    Name = "Augmente l\'amour"
                },
                new Effects()
                {
                    EffectId = 935,
                    Name = "Diminue l\'amour"
                },
                new Effects()
                {
                    EffectId = 936,
                    Name = "Accelère la maturité "
                },
                new Effects()
                {
                    EffectId = 937,
                    Name = "Ralentit la maturité "
                },
                new Effects()
                {
                    EffectId = 939,
                    Name = "Augmente les capacités d\'un familier Min"
                },
                new Effects()
                {
                    EffectId = 940,
                    Name = "Capacités accrues"
                },
                new Effects()
                {
                    EffectId = 945,
                    Name = "Donner un gène à une monture"
                },
                new Effects()
                {
                    EffectId = 946,
                    Name = "Retirer temporairement un objet d\'élevage"
                },
                new Effects()
                {
                    EffectId = 947,
                    Name = "Récupérer un objet d\'enclos"
                },
                new Effects()
                {
                    EffectId = 948,
                    Name = "Objet pour enclos"
                },
                new Effects()
                {
                    EffectId = 949,
                    Name = "Monter/Descendre d\'une monture"
                },
                new Effects()
                {
                    EffectId = 950,
                    Name = "Etat Min"
                },
                new Effects()
                {
                    EffectId = 951,
                    Name = "Enlève l\'état \'Min\'"
                },
                new Effects()
                {
                    EffectId = 960,
                    Name = "Alignement : Min"
                },
                new Effects()
                {
                    EffectId = 961,
                    Name = "Grade : Min"
                },
                new Effects()
                {
                    EffectId = 962,
                    Name = "Niveau : Min"
                },
                new Effects()
                {
                    EffectId = 963,
                    Name = "Créé depuis : Min jour(s)"
                },
                new Effects()
                {
                    EffectId = 964,
                    Name = "Nom : #4"
                },
                new Effects()
                {
                    EffectId = 969,
                    Name = "Apparence : Min"
                },
                new Effects()
                {
                    EffectId = 970,
                    Name = "null"
                },
                new Effects()
                {
                    EffectId = 971,
                    Name = "null"
                },
                new Effects()
                {
                    EffectId = 972,
                    Name = "null"
                },
                new Effects()
                {
                    EffectId = 973,
                    Name = "null"
                },
                new Effects()
                {
                    EffectId = 974,
                    Name = "null"
                },
                new Effects()
                {
                    EffectId = 983,
                    Name = "Échangeable dès le : Min"
                },
                new Effects()
                {
                    EffectId = 984,
                    Name = "null"
                },
                new Effects()
                {
                    EffectId = 985,
                    Name = "Modifié par : #4"
                },
                new Effects()
                {
                    EffectId = 986,
                    Name = "Prépare Min à Max parchemins"
                },
                new Effects()
                {
                    EffectId = 987,
                    Name = "Appartient à : #4"
                },
                new Effects()
                {
                    EffectId = 988,
                    Name = "Fabriqué par : #4"
                },
                new Effects()
                {
                    EffectId = 989,
                    Name = "Recherche : #4"
                },
                new Effects()
                {
                    EffectId = 990,
                    Name = "#4"
                },
                new Effects()
                {
                    EffectId = 994,
                    Name = "!! Certificat invalide !!"
                },
                new Effects()
                {
                    EffectId = 995,
                    Name = "Consulter la fiche de la monture"
                },
                new Effects()
                {
                    EffectId = 996,
                    Name = "Appartient à : #4"
                },
                new Effects()
                {
                    EffectId = 997,
                    Name = "Nom : #4"
                },
                new Effects()
                {
                    EffectId = 998,
                    Name = "Validité : Minj Maxh #3m"
                },
                new Effects()
                {
                    EffectId = 999,
                    Name = "null"
                },
                new Effects()
                {
                    EffectId = 2001,
                    Name = "Gagner Min à Max kamas"
                },
                new Effects()
                {
                    EffectId = 2008,
                    Name = "Augmente les dommages finaux de Min à Max%"
                },
                new Effects()
                {
                    EffectId = 2009,
                    Name = "Diminue les dommages finaux de Min à Max%"
                },
                new Effects()
                {
                    EffectId = 2010,
                    Name = "+Min à Max charge(s)"
                },
                new Effects()
                {
                    EffectId = 2011,
                    Name = "-Min à -Max charge(s)"
                },
                new Effects()
                {
                    EffectId = 2050,
                    Name = "Gain d\'XP : équivalent du niveau 1 à Min (+Max%)"
                },
                new Effects()
                {
                    EffectId = 2100,
                    Name = "PA perdus : Min à Max"
                },
                new Effects()
                {
                    EffectId = 2101,
                    Name = "Contient une carte Tragic The Gardening"
                },
                new Effects()
                {
                    EffectId = 2102,
                    Name = "Ajoute la carte au classeur"
                },
                new Effects()
                {
                    EffectId = 2107,
                    Name = "Contient une carte Tragic The Gardening"
                },
                new Effects()
                {
                    EffectId = 2111,
                    Name = "Diminue de Min le renvoi de dommages"
                },
                new Effects()
                {
                    EffectId = 2112,
                    Name = "-Min à Max créatures invocables"
                },
                new Effects()
                {
                    EffectId = 2113,
                    Name = "-Min à Max de dommages aux pièges"
                },
                new Effects()
                {
                    EffectId = 2114,
                    Name = "-Min à Max% de dommages aux pièges"
                },
                new Effects()
                {
                    EffectId = 2116,
                    Name = "Bonus supplémentaires :"
                },
                new Effects()
                {
                    EffectId = 2117,
                    Name = "Pas de bonus !"
                },
                new Effects()
                {
                    EffectId = 2118,
                    Name = "-Min à Max en vie"
                }

            };
            return list;
        }

        public static List<States> GetAllStates()
        {
            List<States> list = new()
            {
                new States()
                {
                    Id = 0,
                    Name = "Neutre"
                },
                new States()
                {
                    Id = 1,
                    Name = "Saoul"
                },
                new States()
                {
                    Id = 2,
                    Name = "Chercheur d\'âmes"
                },
                new States()
                {
                    Id = 3,
                    Name = "Porteur"
                },
                new States()
                {
                    Id = 4,
                    Name = "Peureux"
                },
                new States()
                {
                    Id = 5,
                    Name = "Désorienté"
                },
                new States()
                {
                    Id = 6,
                    Name = "Enraciné"
                },
                new States()
                {
                    Id = 7,
                    Name = "Pesanteur"
                },
                new States()
                {
                    Id = 8,
                    Name = "Porté"
                },
                new States()
                {
                    Id = 9,
                    Name = "Motivation Sylvestre"
                },
                new States()
                {
                    Id = 10,
                    Name = "Apprivoisement"
                },
                new States()
                {
                    Id = 11,
                    Name = "Chevauchant"
                },
                new States()
                {
                    Id = 12,
                    Name = "Pas sage"
                },
                new States()
                {
                    Id = 13,
                    Name = "Vraiment pas sage"
                },
                new States()
                {
                    Id = 14,
                    Name = "Enneigé"
                },
                new States()
                {
                    Id = 15,
                    Name = "Eveillé"
                },
                new States()
                {
                    Id = 16,
                    Name = "Fragilisé"
                },
                new States()
                {
                    Id = 17,
                    Name = "Séparé"
                },
                new States()
                {
                    Id = 18,
                    Name = "Gelé"
                },
                new States()
                {
                    Id = 19,
                    Name = "Fissuré"
                },
                new States()
                {
                    Id = 26,
                    Name = "Endormi"
                },
                new States()
                {
                    Id = 27,
                    Name = "Léopardo"
                },
                new States()
                {
                    Id = 28,
                    Name = "Libre"
                },
                new States()
                {
                    Id = 29,
                    Name = "Glyphe impaire"
                },
                new States()
                {
                    Id = 30,
                    Name = "Glyphe paire"
                },
                new States()
                {
                    Id = 31,
                    Name = "Encre primaire"
                },
                new States()
                {
                    Id = 32,
                    Name = "Encre secondaire"
                },
                new States()
                {
                    Id = 33,
                    Name = "Encre tertiaire"
                },
                new States()
                {
                    Id = 34,
                    Name = "Encre quaternaire"
                },
                new States()
                {
                    Id = 35,
                    Name = "Envie de tuer"
                },
                new States()
                {
                    Id = 36,
                    Name = "Envie de paralyser"
                },
                new States()
                {
                    Id = 37,
                    Name = "Envie de maudire"
                },
                new States()
                {
                    Id = 38,
                    Name = "Envie d\'empoisonner"
                },
                new States()
                {
                    Id = 39,
                    Name = "Flou"
                },
                new States()
                {
                    Id = 40,
                    Name = "Corrompu"
                },
                new States()
                {
                    Id = 41,
                    Name = "Silencieux"
                },
                new States()
                {
                    Id = 42,
                    Name = "Affaibli"
                },
                new States()
                {
                    Id = 43,
                    Name = "[wait] OVNI"
                },
                new States()
                {
                    Id = 44,
                    Name = "[wait] Pas contente"
                },
                new States()
                {
                    Id = 46,
                    Name = "[wait] Contente"
                },
                new States()
                {
                    Id = 47,
                    Name = "[wait] Mauvaise humeur"
                },
                new States()
                {
                    Id = 48,
                    Name = "Confus"
                },
                new States()
                {
                    Id = 49,
                    Name = "Goulifié"
                },
                new States()
                {
                    Id = 50,
                    Name = "Altruiste"
                },
                new States()
                {
                    Id = 51,
                    Name = "[wip]Châtiment agile"
                },
                new States()
                {
                    Id = 52,
                    Name = "[wip]Châtiment osé"
                },
                new States()
                {
                    Id = 53,
                    Name = "[wip]Châtiment spirituel"
                },
                new States()
                {
                    Id = 54,
                    Name = "[wip]Châtiment vitalesque"
                },
                new States()
                {
                    Id = 55,
                    Name = "Retraité"
                },
                new States()
                {
                    Id = 56,
                    Name = "[wip]Invulnérable"
                },
                new States()
                {
                    Id = 57,
                    Name = "Compte à rebours - 2"
                },
                new States()
                {
                    Id = 58,
                    Name = "Compte à rebours - 1"
                },
                new States()
                {
                    Id = 60,
                    Name = "Dévoué"
                },
                new States()
                {
                    Id = 61,
                    Name = "Bagarreur"
                },
                new States()
                {
                    Id = 63,
                    Name = "[wip]Lourd"
                },
                new States()
                {
                    Id = 64,
                    Name = "[wip]Glyphe nom provisoire"
                },
                new States()
                {
                    Id = 65,
                    Name = "[wip]Rayonnement bloqué"
                },
                new States()
                {
                    Id = 66,
                    Name = "[wip]Rayonnement 1 joueur"
                },
                new States()
                {
                    Id = 67,
                    Name = "[wip]Rayonnement 2 joueur"
                },
                new States()
                {
                    Id = 68,
                    Name = "[wip]Rayonnement 3 joueur"
                },
                new States()
                {
                    Id = 69,
                    Name = "[wip]Rayonnement 4 joueur"
                },
                new States()
                {
                    Id = 70,
                    Name = "[wip]Rayonnement 1 boss"
                },
                new States()
                {
                    Id = 71,
                    Name = "[wip]Rayonnement 2 boss"
                },
                new States()
                {
                    Id = 72,
                    Name = "[wip]Rayonnement 3 boss"
                },
                new States()
                {
                    Id = 73,
                    Name = "Entourbé"
                }
            };
            return list;
        }
        public static List<Zones> GetZones()
        {
            List<Zones> zones = new()
            {
                new Zones()
                {
                    ZoneCode = "Pa",
                    Name = "Case",
                    IconPath = "case"
                },
                new Zones()
                {
                    ZoneCode = "T",
                    Name = "Ligne Horizontale",
                    IconPath = "ligneHori"
                },
                new Zones()
                {
                    ZoneCode = "X",
                    Name = "Croix",
                    IconPath = "croix"
                },
                new Zones()
                {
                    ZoneCode = "L",
                    Name = "Lancer en ligne",
                    IconPath = "ligne"
                },
                new Zones()
                {
                    ZoneCode = "C",
                    Name = "Cercle",
                    IconPath = "cercle"
                }
            };
            return zones;
        }
        public static List<Colors> GetGlypheColors()
        {
            List<Colors> colors = new()
            {
                new Colors()
                {
                    Id = -1,
                    Name = "None"
                },
                new Colors()
                {
                    Id = 0,
                    Name = "Blanc"
                },
                new Colors()
                {
                    Id = 2,
                    Name = "Rouge Clair"
                },
                new Colors()
                {
                    Id = 3,
                    Name = "Bleu Clair"
                },
                new Colors()
                {
                    Id = 4,
                    Name = "Rouge"
                },
                new Colors()
                {
                    Id = 5,
                    Name = "Vert"
                },
                new Colors()
                {
                    Id = 6,
                    Name = "Bleu"
                },
                new Colors()
                { 
                    Id = 7,
                    Name = "Piège Sournois"
                },
                new Colors()
                {
                    Id = 8,
                    Name = "Piège de Masse"
                },
                new Colors()
                {
                    Id = 9,
                    Name = "Piege Empoisonnée"
                },
                new Colors()
                {
                    Id = 10,
                    Name = "Piège d'immo (Vert)"
                },
                new Colors()
                {
                    Id = 11,
                    Name = "Piège de Silence (Bleu)"
                },
                new Colors()
                {
                    Id = 12,
                    Name = "Piège Répulsif (Blanc)"
                },
                new Colors()
                {
                    Id = 13,
                    Name = "Piège Mortel"
                }
            };
            return colors;
        }

        public static List<SpellTypes> GetSpellTypes()
        {
            List<SpellTypes> spellTypes = new() 
            { 
                new SpellTypes() 
                {
                    Id = -1,
                    Name = "Tous Types"
                },
                new SpellTypes()
                {
                    Id = 0,
                    Name = "Classe"
                },
                new SpellTypes()
                {
                    Id = 1,
                    Name = "Elémentaire"
                },
                new SpellTypes()
                {
                    Id = 2,
                    Name = "Invocation"
                },
                new SpellTypes()
                {
                    Id = 3,
                    Name = "Maîtrise"
                },
                new SpellTypes()
                {
                    Id = 4,
                    Name = "Spécial"
                }
            };
            return spellTypes;
        }
        public static bool IsSummonEffect(Effects effect)
        {
            if (effect == null)
            {
                return false;
            }
            else
            {
                return effect.EffectId == 180 || effect.EffectId == 181 || effect.EffectId == 185;
            }
        }
        public static bool IsGlypheEffect(Effects effect)
        {
            if (effect == null)
            {
                return false;
            }
            else
            {
                return effect.EffectId == 401 || effect.EffectId == 402;
            }
        }
        public static bool IsTrapEffect(Effects effect)
        {
            if(effect == null)
            {
                return false;
            }
            else
            {
                return effect.EffectId == 400;
            }
        }

        public static bool IsEffectWithOnlyOneArgs(Effects effect)
        {
            if(effect == null)
            {
                return false;
            }
            else
            {
                return effect.EffectId == 4 || effect.EffectId == 5 || effect.EffectId == 6;
            }
        }
        public static bool IsSpecialEffectWithoutArgs(Effects effect)
        {
            if(effect == null)
            {
                return false;
            }
            else
            {
                return effect.EffectId == 8 || effect.EffectId == 50 || effect.EffectId == 51;
            }
        }
    }
}
