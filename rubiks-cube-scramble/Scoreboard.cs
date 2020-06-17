using System;
using System.Collections.Generic;
using System.Linq;

namespace rubiks_cube_scramble
{
    public class Scoreboard
    {
        private List<ScoreboardItems> scoreboard3 = new List<ScoreboardItems>()
        {
            new ScoreboardItems() { Scramble = "U2 L B2 R U R2 U' F2 R2 B R2 L2 D", Time = "00:51.33" },
            new ScoreboardItems() { Scramble = "B L R2 D2 U2 R' U D B L B D' L U'", Time = "00:11.12" },
            new ScoreboardItems() { Scramble = "D' B' R' B' R' U D2 L2 U R2 U' F2", Time = "00:31.33" },
        };
        
        private List<ScoreboardItems> scoreboard2 = new List<ScoreboardItems>()
        {
            new ScoreboardItems() { Scramble = "U2 L B2 R2 U' F2 R2 B", Time = "00:7.64" },
            new ScoreboardItems() { Scramble = "B L R2 D2 U2 B D' L U''", Time = "00:8.41" },
            new ScoreboardItems() { Scramble = "D' B' R' B' R R2 U' F2", Time = "00:9.53" },
        };

         public List<ScoreboardItems> Scoreboard3
         {
             get { return scoreboard3;  }
             set
             {
                 scoreboard3 = scoreboard3.Concat(value).ToList();
             }
         }
         
         public List<ScoreboardItems> Scoreboard2
         {
             get { return scoreboard2; }
             set
             {
                 scoreboard2 = scoreboard2.Concat(value).ToList();
             }
         }
    }
    public class ScoreboardItems
    {
        public string Time { get; set; }
        public string Scramble { get; set; }
    }
}