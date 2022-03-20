/*
 * A game in which the player has to navigate a dark cavern by description of senses
 * find the fountain of objects, activate it, then return to the cavern entrance
 * while avoiding obstacles.
*/

namespace TheFountainOfObjects
{
    public abstract class PlayerMove
    {
        // base class for player movement

        public abstract void Move(Player player);
    }


    public class MoveNorth : PlayerMove
    {
        // move the player north

        public override void Move(Player player)
        {
            if (player.Y < player.MapBound)
            {
                player.Y += 1;
            }
            else
            {
                Console.WriteLine("You cant move any further in that direction.");
            }
        }
    }


    public class MoveEast : PlayerMove
    {
        // move the player east

        public override void Move(Player player)
        {
            if (player.X < player.MapBound)
            {
                player.X += 1;
            }
            else
            {
                Console.WriteLine("You cant move any further in that direction.");
            }
        }
    }


    public class MoveSouth : PlayerMove
    {
        // move the player south

        public override void Move(Player player)
        {
            if (player.Y > 0)
            {
                player.Y -= 1;
            }
            else
            {
                Console.WriteLine("You cant move any further in that direction.");
            }
        }
    }


    public class MoveWest : PlayerMove
    {
        // move the player west

        public override void Move(Player player)
        {
            if (player.X > 0)
            {
                player.X -= 1;
            }
            else
            {
                Console.WriteLine("You cant move any further in that direction.");
            }
        }
    }
}
