using System;
using System.Collections.Generic;

namespace rubiks_cube_scramble
{
    public class Menu
    {
        public int SelectedIndex { get; private set; } = 0;
        
        public List<MenuItems> MainMenu { get; set; } = new List<MenuItems>()
        {
            new MenuItems() { Name = "1. Scoreboard for 3x3x3" },
            new MenuItems() { Name = "2. Scoreboard for 2x2x2" },
            new MenuItems() { Name = "3. Timer with scramble for 3x3x3" },
            new MenuItems() { Name = "4. Timer with scramble for 2x2x2" }, 
        };

        public void MoveUp () => SelectedIndex = Math.Max (SelectedIndex - 1, 0);
        public void MoveDown () => SelectedIndex = Math.Min (SelectedIndex + 1, MainMenu.Count - 1);
    }

    public class MenuItems
    {
        public string Name { get; set; }
    }
}
