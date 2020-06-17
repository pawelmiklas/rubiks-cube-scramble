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
            Stopwatch stopwatch = new Stopwatch();
            
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
                    case 2: TimerScramblePage(stopwatch); selectedMenuItem = -1; break;
                    case 3: TimerScramblePage(stopwatch); selectedMenuItem = -1; break;
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

        static void TimerScramblePage(Stopwatch stopwatch)
        {
            bool isNotCorrectKey = true;
            bool isCounterActive = false;
            Scramble scramble = new Scramble();
            string newStramble = scramble.GenerateScramble();
            
            while (isNotCorrectKey)
            {
                Console.Clear();
                Console.WriteLine($"newStramble: {newStramble}");
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
                    isCounterActive = false;
                    Console.WriteLine(stopwatchElapsed.ToString("mm\\:ss\\.ff"));
                    Console.ReadKey();
                }
            }
        }
    }
}
