/*
 * A game in which the player has to navigate a dark cavern by description of senses
 * find the fountain of objects, activate it, then return to the cavern entrance
 * while avoiding obstacles.
*/

namespace TheFountainOfObjects
{
    public class Player
    {
        public int X { get; set; } = 0;
        public int Y { get; set; } = 0;
        public int MapBound { get; set; }

        public void Move(PlayerMove command)
        {
            command.Move(this);
        }
    }
}
