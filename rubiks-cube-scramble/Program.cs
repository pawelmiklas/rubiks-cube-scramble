using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace rubiks_cube_scramble
{
    enum MenuItemsNames
    {
        MainMenu = -1,
        ScoreboardPageRegular = 0,
        ScoreboardPage = 1,
        TimerScramblePageRegular = 2,
        TimerScramblePage = 3,
    }

    class Program
    {
        static void Main()
        {
            int selectedMenuItem = (int) MenuItemsNames.MainMenu;
            Menu menu = new Menu();
            Scoreboard scoreboard = new Scoreboard();
            Scramble scramble = new Scramble();
            
            do
            {
                Console.Clear();

                // show current menu item
                switch (selectedMenuItem)
                {
                    // main menu page
                    case (int)MenuItemsNames.MainMenu:
                        MainMenu(menu, ref selectedMenuItem);
                        break;
                    // scoreboard page for 3x3x3 cube
                    case (int)MenuItemsNames.ScoreboardPageRegular:
                        ScoreboardPage(scoreboard.Scoreboard3);
                        selectedMenuItem = (int)MenuItemsNames.MainMenu;
                        break;
                    // scoreboard page for 2x2x2 cube
                    case (int)MenuItemsNames.ScoreboardPage: 
                        ScoreboardPage(scoreboard.Scoreboard2);
                        selectedMenuItem = (int)MenuItemsNames.MainMenu;
                        break;
                    // timer and scramble for 3x3x3 cube
                    case (int)MenuItemsNames.TimerScramblePageRegular:
                        Stopwatch stopwatch = new Stopwatch();
                        TimerScramblePage(scramble, stopwatch, scoreboard, true); 
                        selectedMenuItem = (int)MenuItemsNames.MainMenu;
                        break;
                    // timer and scramble for 2x2x2 cube
                    case (int)MenuItemsNames.TimerScramblePage: 
                        Stopwatch stopwatch2 = new Stopwatch();
                        TimerScramblePage(scramble, stopwatch2, scoreboard, false); 
                        selectedMenuItem = (int)MenuItemsNames.MainMenu;
                        break;
                }
            } while (true);
        }

        static void MainMenu(Menu menu, ref int selectedMenuItem)
        {
            // generate menu items
            for (int i = 0; i < menu.MainMenu.Count; i++)
            {
                Console.ResetColor();
                if (menu.SelectedIndex == i)
                {
                    // assign green color to active menu item
                    Console.ForegroundColor = ConsoleColor.DarkGreen;
                    Console.WriteLine(menu.MainMenu[i].Name);
                }
                else
                {
                    Console.WriteLine(menu.MainMenu[i].Name);
                }
            }

            // get key from user
            ConsoleKey key;
            key = Console.ReadKey(true).Key;

            // menu navigation - control by arrows
            switch (key)
            {
                // arrow up - move up 
                case ConsoleKey.UpArrow: menu.MoveUp(); break;
                // arrow down - move down 
                case ConsoleKey.DownArrow: menu.MoveDown(); break;
                // enter - select menu item
                case ConsoleKey.Enter: selectedMenuItem = menu.SelectedIndex; break;
            }
        }

        static void ScoreboardPage(List <ScoreboardItems> scoreboard)
        {
            bool exit = false;
            while (!exit)
            {
                Console.Clear();
                // get new scoreboard and sort it asc by time
                List<ScoreboardItems> sortedScoreboard = scoreboard.OrderBy(o => o.Time).ToList();
            
                // generate scoreboard with time and scramble
                for (int i = 0; i < sortedScoreboard.Count; i++)
                {
                    Console.WriteLine($"{i + 1}. Time: {sortedScoreboard[i].Time}, Scramble: {sortedScoreboard[i].Scramble}");
                }
            
                Console.WriteLine("Type 'e' if you want back to menu");
                
                // read console key from user - if key is "e" go back to menu
                ConsoleKey key;
                key = Console.ReadKey(true).Key;
                if (key == ConsoleKey.E)
                {
                    exit = true;
                }
            }
        }

        static void TimerScramblePage(Scramble scramble, Stopwatch stopwatch, Scoreboard scoreboard, bool isRegularCube)
        {
            Console.ResetColor();
            bool exit = false;
            bool isCounterActive = false;
            // generate new scramble
            string newScramble = scramble.GenerateScramble();

            while (!exit)
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

                // convert time to milliseconds
                TimeSpan stopwatchElapsed = stopwatch.Elapsed;
                int timeInMilliseconds = Convert.ToInt32(stopwatchElapsed.TotalMilliseconds);

                if (key == ConsoleKey.Spacebar && timeInMilliseconds == 0)
                {
                    // start counting time
                    stopwatch.Start();
                    isCounterActive = true;
                }
                else if (key == ConsoleKey.Spacebar && timeInMilliseconds > 0) 
                {
                    // stop counting time
                    stopwatch.Stop();
                    // get formatted time
                    string formattedStopwatch = stopwatchElapsed.ToString("mm\\:ss\\.ff");
                    isCounterActive = false;
                    
                    Console.WriteLine($"Your time is: {formattedStopwatch}");
                    Console.WriteLine("Type 'e' to return to the menu. Type 'r' to get new scramble");
                    
                    ConsoleKey newKey;
                    newKey = Console.ReadKey(true).Key;
                    
                    // add result time with scramble to specific list
                    if (newKey == ConsoleKey.E || newKey == ConsoleKey.R)
                    {
                        if (isRegularCube)
                        {
                            // assign new item to scoreboard3
                            scoreboard.Scoreboard3 = new List<ScoreboardItems>()
                            {
                                new ScoreboardItems() {Scramble = newScramble, Time = formattedStopwatch }
                            };
                        }
                        else
                        {
                            // assign new item to scoreboard2
                            scoreboard.Scoreboard2 = new List<ScoreboardItems>()
                            {
                                new ScoreboardItems() {Scramble = newScramble, Time = formattedStopwatch }
                            };
                        }
                    }

                    if (newKey == ConsoleKey.E)
                    {
                        // go back to menu if key is equal 'e'
                        exit = true;
                    } else if (newKey == ConsoleKey.R)
                    {
                        // if key is equal 'r' invoke TimerScramblePage with new scramble and stopwatch
                        Scramble newScrambleClass = new Scramble();
                        Stopwatch newStopwatch = new Stopwatch();
                        exit = true;
                        TimerScramblePage(newScrambleClass, newStopwatch, scoreboard, isRegularCube);
                    }
                }
            }
        }
    }
}
