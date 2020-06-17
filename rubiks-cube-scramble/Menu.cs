using System;
using System.Collections.Generic;

namespace rubiks_cube_scramble
{
    public class Menu
    {
        private List<MenuItems> mainMenu = new List<MenuItems>()
        {
            new MenuItems() { name = "1. Scoreboard for 3x3x3" },
            new MenuItems() { name = "2. Scoreboard for 2x2x2" },
            new MenuItems() { name = "3. Timer with scramble for 3x3x3" },
            new MenuItems() { name = "4. Timer with scramble for 2x2x2" }, 
        };

        public int SelectedIndex { get; set; } = 0;
        
        public List<MenuItems> MainMenu
        {
            get => mainMenu;
            set => mainMenu = value;
        }
        
        public void MoveUp () => SelectedIndex = Math.Max (SelectedIndex - 1, 0);
        public void MoveDown () => SelectedIndex = Math.Min (SelectedIndex + 1, mainMenu.Count - 1);
    }

    public class MenuItems
    {
        public string name { get; set; }
    }
}
