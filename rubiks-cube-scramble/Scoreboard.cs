using System;
using System.Collections.Generic;
using System.Linq;

namespace rubiks_cube_scramble
{
    public class Scoreboard
    {
        // list with result for 3x3x3 cube + some sample data
        private List<ScoreboardItems> _scoreboard3 = new List<ScoreboardItems>()
        {
            new ScoreboardItems() { Scramble = "U2 L B2 R U R2 U' F2 R2 B R2 L2 D", Time = "00:51.33" },
            new ScoreboardItems() { Scramble = "B L R2 D2 U2 R' U D B L B D' L U'", Time = "00:11.12" },
            new ScoreboardItems() { Scramble = "D' B' R' B' R' U D2 L2 U R2 U' F2", Time = "00:31.33" },
        };
        
        // list with result for 2x2x2 cube + some sample data
        private List<ScoreboardItems> _scoreboard2 = new List<ScoreboardItems>()
        {
            new ScoreboardItems() { Scramble = "U2 L B2 R2 U' F2 R2 B", Time = "00:7.64" },
            new ScoreboardItems() { Scramble = "B L R2 D2 U2 B D' L U''", Time = "00:8.41" },
            new ScoreboardItems() { Scramble = "D' B' R' B' R R2 U' F2", Time = "00:9.53" },
        };

        // properties for Scoreboard3 + setter for concat new value
         public List<ScoreboardItems> Scoreboard3
         {
             get => _scoreboard3;
             set => _scoreboard3 = _scoreboard3.Concat(value).ToList();
         }
         
         // properties for Scoreboard2 + setter for concat new value
         public List<ScoreboardItems> Scoreboard2
         {
             get => _scoreboard2;
             set => _scoreboard2 = _scoreboard2.Concat(value).ToList();
         }
    }
    public class ScoreboardItems
    {
        public string Time { get; set; }
        public string Scramble { get; set; }
    }
}