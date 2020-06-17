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
                        TimerScramblePage(scramble, stopwatch, scoreboard, true); 
                        selectedMenuItem = -1;
                        break;
                    case 3: 
                        Stopwatch stopwatch2 = new Stopwatch();
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
                    Console.WriteLine(menu.MainMenu[i].Name);
                }
                else
                {
                    Console.WriteLine(menu.MainMenu[i].Name);
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

        static void TimerScramblePage(Scramble scramble, Stopwatch stopwatch, Scoreboard scoreboard, bool isBigCube)
        {
            Console.ResetColor();
            bool isNotCorrectKey = true;
            bool isCounterActive = false;
            string newScramble = scramble.GenerateScramble();

            while (isNotCorrectKey)
            {
                Console.Clear();
                Console.WriteLine($"newScramble: {newScramble}");
                Console.WriteLine("Press space for start timer");

                if (isCounterActive)
                {
                    Console.WriteLine("Time counting..");
                }

                ConsoleKey key;
                key = Console.ReadKey(true).Key;

                TimeSpan stopwatchElapsed = stopwatch.Elapsed;
                int timeInMilliseconds = Convert.ToInt32(stopwatchElapsed.TotalMilliseconds);

                if (key == ConsoleKey.Spacebar && timeInMilliseconds == 0)
                {
                    stopwatch.Start();
                    isCounterActive = true;
                }
                else if (key == ConsoleKey.Spacebar && timeInMilliseconds > 0)
                {
                    stopwatch.Stop();
                    string formattedStopwatch = stopwatchElapsed.ToString("mm\\:ss\\.ff");
                    isCounterActive = false;
                    
                    Console.WriteLine($"Your time is: {formattedStopwatch}");
                    Console.WriteLine("Type 'e' to return to the menu. Type 'r' to get new scramble");
                    
                    ConsoleKey newKey;
                    newKey = Console.ReadKey(true).Key;
                    if (newKey == ConsoleKey.E || newKey == ConsoleKey.R)
                    {
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
                    }

                    if (newKey == ConsoleKey.E)
                    {
                        isNotCorrectKey = false;
                    } else if (newKey == ConsoleKey.R)
                    {
                        Scramble newScrambleClass = new Scramble();
                        Stopwatch newStopwatch = new Stopwatch();
                        isNotCorrectKey = false;
                        TimerScramblePage(newScrambleClass, newStopwatch, scoreboard, isBigCube);
                    }
                }
            }
        }
    }
}
