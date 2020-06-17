using System;
using System.Collections.Generic;
using System.Linq;

namespace rubiks_cube_scramble
{
    class Program
    {
        static void Main(string[] args)
        {
            int selectedMenuItem = -1;
            bool isScoreboard = true;
            Menu menu = new Menu();
            
            do
            {
                Console.Clear();

                switch (selectedMenuItem)
                {
                    case -1: MainMenu(menu, ref selectedMenuItem); break;
                    case 0: Scoreboard3Page(); selectedMenuItem = -1; break;
                    case 1: Scoreboard2Page(); selectedMenuItem = -1; break;
                    case 2: TimerScramble3Page(); selectedMenuItem = -1; break;
                    case 3: TimerScramble2Page(); selectedMenuItem = -1; break;
                }

                // if (key == ConsoleKey.D1)
                // {
                //     bool isNotCorrectKey = true;
                //     while (isNotCorrectKey)
                //     {
                //         Console.Clear();
                //         List<Scoreboard> sortedScoreboard3 = scoreboard3.OrderBy(o => o.Time).ToList();
                //
                //         Console.WriteLine("===========================================");
                //         for (int i = 0; i < sortedScoreboard3.Count; i++)
                //         {
                //             Console.WriteLine(
                //                 $"{i + 1}. Time: {sortedScoreboard3[i].Time}, Scramble: {sortedScoreboard3[i].Scramble}");
                //         }
                //
                //         Console.WriteLine("===========================================");
                //
                //         Console.WriteLine("Type 'e' if you want back to menu");
                //         key = Console.ReadKey(true).Key;
                //         if (key == ConsoleKey.E)
                //         {
                //             isNotCorrectKey = false;
                //         }
                //     }
                // }
                // else if (key == ConsoleKey.D2)
                // {
                //     bool isNotCorrectKey = true;
                //     while (isNotCorrectKey)
                //     {
                //         Console.Clear();
                //         List<Scoreboard> sortedScoreboard2 = scoreboard2.OrderBy(o => o.Time).ToList();
                //
                //         Console.WriteLine("===========================================");
                //         for (int i = 0; i < sortedScoreboard2.Count; i++)
                //         {
                //             Console.WriteLine(
                //                 $"{i + 1}. Time: {sortedScoreboard2[i].Time}, Scramble: {sortedScoreboard2[i].Scramble}");
                //         }
                //
                //         Console.WriteLine("===========================================");
                //
                //         Console.WriteLine("Type 'e' if you want back to menu");
                //         key = Console.ReadKey(true).Key;
                //         if (key == ConsoleKey.E)
                //         {
                //             isNotCorrectKey = false;
                //         }
                //     }
                // }
                // else if (key == ConsoleKey.D3)
                // {
                //     Scramble scramble = new Scramble();
                //     string newStramble = scramble.GenerateScramble();
                //     Console.WriteLine($"newStramble: {newStramble}");
                //     Console.ReadKey();
                // }
                // else if (key == ConsoleKey.D4)
                // {
                //     Console.WriteLine("4");
                // }
            } while (isScoreboard);
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

        static void Scoreboard3Page()
        {
            bool isNotCorrectKey = true;
            while (isNotCorrectKey)
            {
                Console.Clear();
                Scoreboard scoreboard = new Scoreboard();
                List<ScoreboardItems> sortedScoreboard3 = scoreboard.Scoreboard3.OrderBy(o => o.Time).ToList();

                for (int i = 0; i < sortedScoreboard3.Count; i++)
                {
                    Console.WriteLine($"{i + 1}. Time: {sortedScoreboard3[i].Time}, Scramble: {sortedScoreboard3[i].Scramble}");
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

        static void Scoreboard2Page()
        {
        
        }

        static void TimerScramble3Page()
        {
        
        }

        static void TimerScramble2Page()
        {
        
        }
    }
    
}
