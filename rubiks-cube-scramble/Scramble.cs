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

            int counter = 0;
            
            // generate random scramble
            while (counter < 15)
            {
                // get single random wall turn
                Random randomTurnNumber = new Random();
                int randomTurn = randomTurnNumber.Next(_turns.Count);
                
                // get single random modifier
                Random randomModifierNumber = new Random();
                int randomModifier = randomModifierNumber.Next(_modifiers.Count);

                // concat wall turn with modifier and add to list
                string preparedSingleScramble = _turns[randomTurn] + _modifiers[randomModifier];

                if (counter == 0)
                {
                    _scramble.Add(preparedSingleScramble);
                    counter++;
                } else if (counter > 0 && _turns[randomTurn] != _scramble[counter - 1].Substring(0,1))
                {
                    // add wall turn if previous turn is different
                    _scramble.Add(preparedSingleScramble);
                    counter++;
                }
            }

            return String.Join(" ", _scramble);
        }
    }
}