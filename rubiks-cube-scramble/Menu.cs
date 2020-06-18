using System;
using System.Collections.Generic;

namespace rubiks_cube_scramble
{
    public class Menu
    {
        // getter and setter for selected index of menu item
        public int SelectedIndex { get; private set; }
        
        // main menu list
        public List<MenuItems> MainMenu { get; } = new List<MenuItems>()
        {
            new MenuItems() { Name = "1. Scoreboard for 3x3x3" },
            new MenuItems() { Name = "2. Scoreboard for 2x2x2" },
            new MenuItems() { Name = "3. Timer with scramble for 3x3x3" },
            new MenuItems() { Name = "4. Timer with scramble for 2x2x2" }, 
        };

        // change selected index to smaller if MoveUp is invoked
        public void MoveUp () => SelectedIndex = Math.Max (SelectedIndex - 1, 0);
        // change selected index to larger if MoveDown is invoked
        public void MoveDown () => SelectedIndex = Math.Min (SelectedIndex + 1, MainMenu.Count - 1);
    }

    public class MenuItems
    {
        public string Name { get; set; }
    }
}
