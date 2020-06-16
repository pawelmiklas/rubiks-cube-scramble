using System;
using System.Collections.Generic;

namespace rubiks_cube_scramble
{
    public class Scramble
    {
        private List<string> turns = new List<string>(new string[] {"U", "D", "R", "L", "F", "B"} );
        private List<string> modifiers = new List<string>(new string[] {"", "'", "2"} );
        private List<string> scramble = new List<string>();

        public string GenerateScramble()
        {
            for (int i = 0; i < 15; i++)
            {
                Random randomTurnNumber = new Random();
                int randomTurn = randomTurnNumber.Next(turns.Count);
                
                Random randomModifierNumber = new Random();
                int randomModifier = randomModifierNumber.Next(modifiers.Count);

                string preparedSingleScramble = turns[randomTurn] + modifiers[randomModifier];
                scramble.Add(preparedSingleScramble);
            }

            return String.Join(" ", scramble);
        }
    }
}