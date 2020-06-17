using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace rubiks_cube_scramble
{
    class Program
    {
        static void Main(string[] args)
        {
            int selectedMenuItem = -1;
            Menu menu = new Menu();
            Scoreboard scoreboard = new Scoreboard();
            Scramble scramble = new Scramble();
            
            // scoreboard.Scoreboard3 = new List<ScoreboardItems>()
            // {
            //     new ScoreboardItems() { Scramble = "U2 L B2 R U R2 U' F2 R2 B R2 L2 D", Time = "00:51.33" },
            // };

            do
            {
                Console.Clear();

                switch (selectedMenuItem)
                {
                    case -1: MainMenu(menu, ref selectedMenuItem); break;
                    case 0:
                        ScoreboardPage(scoreboard.Scoreboard3);
                        selectedMenuItem = -1;
                        break;
                    case 1: 
                        ScoreboardPage(scoreboard.Scoreboard2);
                        selectedMenuItem = -1;
                        break;
                    case 2:
                        Stopwatch stopwatch = new Stopwatch();
                        // scoreboard.Scoreboard3 = new List<ScoreboardItems>()
                        // {
                        //     TimerScramblePage(scramble, stopwatch)
                        // };
                        TimerScramblePage(scramble, stopwatch, scoreboard, true); 
                        selectedMenuItem = -1;
                        break;
                    case 3: 
                        Stopwatch stopwatch2 = new Stopwatch();
                        // scoreboard.Scoreboard2 = new List<ScoreboardItems>()
                        // {
                        //     TimerScramblePage(scramble, stopwatch2)
                        // };
                        TimerScramblePage(scramble, stopwatch2, scoreboard, false); 
                        selectedMenuItem = -1; break;
                }
            } while (true);
        }

        static void MainMenu(Menu menu, ref int selectedMenuItem)
        {
            for (int i = 0; i < menu.MainMenu.Count; i++)
            {
                Console.ResetColor();
                if (menu.SelectedIndex == i)
                {
                    Console.ForegroundColor = ConsoleColor.DarkGreen;
                    Console.WriteLine(menu.MainMenu[i].name);
                }
                else
                {
                    Console.WriteLine(menu.MainMenu[i].name);
                }
            }

            ConsoleKey key;
            key = Console.ReadKey(true).Key;

            switch (key)
            {
                case ConsoleKey.UpArrow: menu.MoveUp(); break;
                case ConsoleKey.DownArrow: menu.MoveDown(); break;
                case ConsoleKey.Enter: selectedMenuItem = menu.SelectedIndex; break;
            }
        }

        static void ScoreboardPage(List <ScoreboardItems> scoreboard)
        {
            bool isNotCorrectKey = true;
            while (isNotCorrectKey)
            {
                Console.Clear();
                List<ScoreboardItems> sortedScoreboard = scoreboard.OrderBy(o => o.Time).ToList();
            
                for (int i = 0; i < sortedScoreboard.Count; i++)
                {
                    Console.WriteLine($"{i + 1}. Time: {sortedScoreboard[i].Time}, Scramble: {sortedScoreboard[i].Scramble}");
                }
            
                Console.WriteLine("Type 'e' if you want back to menu");
                
                ConsoleKey key;
                key = Console.ReadKey(true).Key;
                if (key == ConsoleKey.E)
                {
                    isNotCorrectKey = false;
                }
            }
        }

        // scoreboarditems
        static void TimerScramblePage(Scramble scramble, Stopwatch stopwatch, Scoreboard scoreboard, bool isBigCube)
        {
            Console.ResetColor();
            bool isNotCorrectKey = true;
            bool isCounterActive = false;
            string newScramble = scramble.GenerateScramble();
            // Console.WriteLine($"isNotCorrectKey {isNotCorrectKey}");

            while (isNotCorrectKey)
            {
                Console.Clear();
                // Console.WriteLine($"isNotCorrectKey {isNotCorrectKey}");
                Console.WriteLine($"newScramble: {newScramble}");
                Console.WriteLine("Press space for start timer");

                if (isCounterActive)
                {
                    Console.WriteLine("Time counting..");
                }

                ConsoleKey key;
                key = Console.ReadKey(true).Key;

                TimeSpan stopwatchElapsed = stopwatch.Elapsed;

                if (key == ConsoleKey.Spacebar && Convert.ToInt32(stopwatchElapsed.TotalMilliseconds) == 0)
                {
                    stopwatch.Start();
                    isCounterActive = true;
                }
                else if (key == ConsoleKey.Spacebar && Convert.ToInt32(stopwatchElapsed.TotalMilliseconds) > 0)
                {
                    stopwatch.Stop();
                    string formattedStopwatch = stopwatchElapsed.ToString("mm\\:ss\\.ff");
                    isCounterActive = false;
                    
                    // TODO colors
                    Console.WriteLine($"Your time is: {formattedStopwatch}");
                    Console.WriteLine("Type 'e' to return to the menu. Type 'r' to get new scramble");
                    
                    ConsoleKey newKey;
                    newKey = Console.ReadKey(true).Key;
                    
                    if (isBigCube)
                    {
                        scoreboard.Scoreboard3 = new List<ScoreboardItems>()
                        {
                            new ScoreboardItems() {Scramble = newScramble, Time = formattedStopwatch }
                        };
                    }
                    else
                    {
                        scoreboard.Scoreboard2 = new List<ScoreboardItems>()
                        {
                            new ScoreboardItems() {Scramble = newScramble, Time = formattedStopwatch }
                        };
                    }

                    if (newKey == ConsoleKey.E)
                    {
                        isNotCorrectKey = false;
                        // Console.WriteLine("Kliknięto E");
                        Console.ReadKey();
                    } else if (newKey == ConsoleKey.R)
                    {
                        Scramble newScrambleClass = new Scramble();
                        Stopwatch newStopwatch = new Stopwatch();
                        TimerScramblePage(newScrambleClass, newStopwatch, scoreboard, isBigCube);
                    }
                }
            }
        }
    }
}
