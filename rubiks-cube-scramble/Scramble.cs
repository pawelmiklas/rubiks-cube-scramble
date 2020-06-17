using System;
using System.Collections.Generic;

namespace rubiks_cube_scramble
{
    public class Scramble
    {
        private readonly List<string> _turns = new List<string>(new string[] {"U", "D", "R", "L", "F", "B"} );
        private readonly List<string> _modifiers = new List<string>(new string[] {"", "'", "2"} );
        private readonly List<string> _scramble = new List<string>();

        public string GenerateScramble()
        {
            _scramble.Clear();
            
            for (int i = 0; i < 15; i++)
            {
                Random randomTurnNumber = new Random();
                int randomTurn = randomTurnNumber.Next(_turns.Count);
                
                Random randomModifierNumber = new Random();
                int randomModifier = randomModifierNumber.Next(_modifiers.Count);

                string preparedSingleScramble = _turns[randomTurn] + _modifiers[randomModifier];
                _scramble.Add(preparedSingleScramble);
            }

            return String.Join(" ", _scramble);
        }
    }
}