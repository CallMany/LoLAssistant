﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace LoLAssistant.Classes.LiveMatch
{
    public class Spells
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Key { get; set; }
        public string Description { get; set; }
        public int SummonerLevel { get; set; }
    }
    public class SummonerSpells
    {
        public static List<Spells> GetSpells(string region, string apiKey) 
        {
            List<Spells> SpellsCollection = new List<Spells>();
            WebClient Client = new WebClient();
            Stream Data = Client.OpenRead("https://global.api.pvp.net/api/lol/static-data/eune/v1.2/summoner-spell?api_key=" + apiKey);
            StreamReader Reader = new StreamReader(Data);
            string Result = Reader.ReadLine();
            Result = Result.Replace("{", string.Empty);
            Result = Result.Replace("}", "|");
            Result = Result.Replace("\"", string.Empty);
            Result = Result.Replace(":", "|");
            Result = Result.Replace("id", string.Empty);
            Result = Result.Replace("description", string.Empty);
            Result = Result.Replace("name", string.Empty);
            Result = Result.Replace("key", string.Empty);
            Result = Result.Replace("summonerLevel", string.Empty);
            Result = Result.Replace(",|", "|");
            Result = Result.Replace("Turret|", "Turret:");
            Result = Result.Replace("|||", string.Empty);
            Result = Result.Replace("||", "|");
            Result = Result.Remove(0, Result.IndexOf("data") + 5);
            string[] words = Result.Split('|');



            Spells [] spell = new Spells[128];
            int y = 0;
            int x = 0;
            int z = 0;
            foreach (string word in words)
            {
                if(y == 1)
                {
                    spell[z] = new Spells();
                }
                switch (y)
                {
                    case 0:
                        break;
                    case 1:
                        spell[z].Name = words[x];
                        break;
                    case 2:
                        spell[z].Description = words[x];
                        break;
                    case 3:
                        spell[z].SummonerLevel = int.Parse(words[x]);
                        break;
                    case 4:
                        spell[z].Id = int.Parse(words[x]);
                        break;
                    case 5:
                        spell[z].Key = words[x];
                        break;
                }
                if (y == 5)
                {
                    y = -1;
                    SpellsCollection.Add(spell[z]);
                    z++;
                }
                y++;
                x++;
            }
            return SpellsCollection;
        }
    }
}
/*
{
   "data": {
      "SummonerBoost": {
         "id": 1,   4
         "description": "Removes all disables and summoner spell debuffs affecting your champion and lowers the duration of incoming disables by 65% for 3 seconds.",   2
         "name": "Cleanse",  1
         "key": "SummonerBoost",   5
         "summonerLevel": 6   3
      },
      "SummonerTeleport": {
         "id": 12,
         "description": "After channeling for 3.5 seconds, teleports your champion to target allied structure, minion, or ward.",
         "name": "Teleport",
         "key": "SummonerTeleport",
         "summonerLevel": 6
      },
      "SummonerPoroRecall": {
         "id": 30,
         "description": "Quickly travel to the Poro King's side.",
         "name": "To the King!",
         "key": "SummonerPoroRecall",
         "summonerLevel": 1
      },
      "SummonerDot": {
         "id": 14,
         "description": "Ignites target enemy champion, dealing 70-410 true damage (depending on champion level) over 5 seconds, grants you vision of the target, and reduces healing effects on them for the duration.",
         "name": "Ignite",
         "key": "SummonerDot",
         "summonerLevel": 10
      },
      "SummonerHaste": {
         "id": 6,
         "description": "Your champion can move through units and has 27% increased Movement Speed for 10 seconds",
         "name": "Ghost",
         "key": "SummonerHaste",
         "summonerLevel": 1
      },
      "SummonerSnowball": {
         "id": 32,
         "description": "Throw a snowball in a straight line at your enemies. If it hits an enemy, they become marked and your champion can quickly travel to the marked target as a follow up.",
         "name": "Mark",
         "key": "SummonerSnowball",
         "summonerLevel": 1
      },
      "SummonerHeal": {
         "id": 7,
         "description": "Restores 90-345 Health (depending on champion level) and grants 30% Movement Speed for 1 second to you and target allied champion. This healing is halved for units recently affected by Summoner Heal.",
         "name": "Heal",
         "key": "SummonerHeal",
         "summonerLevel": 1
      },
      "SummonerSmite": {
         "id": 11,
         "description": "Deals 390-1000 true damage (depending on champion level) to target epic or large monster or enemy minion.",
         "name": "Smite",
         "key": "SummonerSmite",
         "summonerLevel": 10
      },
      "SummonerExhaust": {
         "id": 3,
         "description": "Exhausts target enemy champion, reducing their Movement Speed and Attack Speed by 30%, their Armor and Magic Resist by 10, and their damage dealt by 40% for 2.5 seconds.",
         "name": "Exhaust",
         "key": "SummonerExhaust",
         "summonerLevel": 4
      },
      "SummonerPoroThrow": {
         "id": 31,
         "description": "Throw a Poro at your enemies. If it hits, you can quickly travel to your target as a follow up.",
         "name": "Poro Toss",
         "key": "SummonerPoroThrow",
         "summonerLevel": 1
      },
      "SummonerMana": {
         "id": 13,
         "description": "Restores 40% of your champion's maximum Mana. Also restores allies for 40% of their maximum Mana",
         "name": "Clarity",
         "key": "SummonerMana",
         "summonerLevel": 1
      },
      "SummonerClairvoyance": {
         "id": 2,
         "description": "Reveals a small area of the map for your team for 5 seconds.",
         "name": "Clairvoyance",
         "key": "SummonerClairvoyance",
         "summonerLevel": 8
      },
      "SummonerBarrier": {
         "id": 21,
         "description": "Shields your champion for 115-455 (depending on champion level) for 2 seconds.",
         "name": "Barrier",
         "key": "SummonerBarrier",
         "summonerLevel": 4
      },
      "SummonerFlash": {
         "id": 4,
         "description": "Teleports your champion a short distance toward your cursor's location.",
         "name": "Flash",
         "key": "SummonerFlash",
         "summonerLevel": 8
      },
      "SummonerOdinGarrison": {
         "id": 17,
         "description": "Allied Turret: Grants massive regeneration for 8 seconds. Enemy Turret: Reduces damage dealt by 80% for 8 seconds.",
         "name": "Garrison",
         "key": "SummonerOdinGarrison",
         "summonerLevel": 1
      }
   },
   "type": "summoner",
   "version": "5.22.3"
}
*/
