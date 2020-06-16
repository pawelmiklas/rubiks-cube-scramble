using System;
using System.Collections.Generic;
using System.Linq;

namespace rubiks_cube_scramble
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Scoreboard> scoreboard3 = new List<Scoreboard>();
            List<Scoreboard> scoreboard2 = new List<Scoreboard>();
            
            scoreboard3.Add(new Scoreboard { Scramble = "U2 L B2 R U R2 U' F2 R2 B R2 L2 D", Time = "51.33"});
            scoreboard3.Add(new Scoreboard { Scramble = "B L R2 D2 U2 R' U D B L B D' L U'", Time = "11.12"});
            scoreboard3.Add(new Scoreboard { Scramble = "D' B' R' B' R' U D2 L2 U R2 U' F2", Time = "31.33"});
            
            scoreboard2.Add(new Scoreboard { Scramble = "U2 L B2 R2 U' F2 R2 B", Time = "7.64"});
            scoreboard2.Add(new Scoreboard { Scramble = "B L R2 D2 U2 B D' L U'", Time = "8.41"});
            scoreboard2.Add(new Scoreboard { Scramble = "D' B' R' B' R R2 U' F2", Time = "9.53"});
            
            while (true)
            {
                Console.Clear();
                Console.WriteLine("===========================================");
                Console.WriteLine("1. Scoreboard for 3x3x3");
                Console.WriteLine("2. Scoreboard for 2x2x2");
                Console.WriteLine("3. Timer with scramble for 3x3x3");
                Console.WriteLine("4. Timer with scramble for 2x2x2");
                Console.WriteLine("===========================================");
                Console.WriteLine("Pick your option..");
                
                ConsoleKey key;
                key = Console.ReadKey(true).Key;

                if (key == ConsoleKey.D1)
                {
                    bool isNotCorrectKey = true;
                    while (isNotCorrectKey)
                    {
                        Console.Clear();
                        List<Scoreboard> sortedScoreboard3 = scoreboard3.OrderBy(o => o.Time).ToList();
                        
                        Console.WriteLine("===========================================");
                        for (int i = 0; i < sortedScoreboard3.Count; i++)
                        {
                            Console.WriteLine($"{i + 1}. Time: {sortedScoreboard3[i].Time}, Scramble: {sortedScoreboard3[i].Scramble}");
                        }
                        Console.WriteLine("===========================================");
                        
                        Console.WriteLine("Type 'e' if you want back to menu");
                        key = Console.ReadKey(true).Key;
                        if (key == ConsoleKey.E)
                        {
                            isNotCorrectKey = false;
                        }
                    }
                } else if (key == ConsoleKey.D2)
                {
                    bool isNotCorrectKey = true;
                    while (isNotCorrectKey)
                    {
                        Console.Clear();
                        List<Scoreboard> sortedScoreboard2 = scoreboard2.OrderBy(o => o.Time).ToList();

                        Console.WriteLine("===========================================");
                        for (int i = 0; i < sortedScoreboard2.Count; i++)
                        {
                            Console.WriteLine($"{i + 1}. Time: {sortedScoreboard2[i].Time}, Scramble: {sortedScoreboard2[i].Scramble}");
                        }
                        Console.WriteLine("===========================================");
                        
                        Console.WriteLine("Type 'e' if you want back to menu");
                        key = Console.ReadKey(true).Key;
                        if (key == ConsoleKey.E)
                        {
                            isNotCorrectKey = false;
                        }
                    }
                } else if (key == ConsoleKey.D3)
                {
                    Scramble scramble = new Scramble();
                    string newStramble = scramble.GenerateScramble();
                    Console.WriteLine($"newStramble: { newStramble }");
                    Console.ReadKey();
                } else if (key == ConsoleKey.D4)
                {
                    Console.WriteLine("4");
                }
            }
        }
    }
}