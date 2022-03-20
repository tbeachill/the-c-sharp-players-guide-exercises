/*
 * A game in which the player has to navigate a dark cavern by description of senses
 * find the fountain of objects, activate it, then return to the cavern entrance
 * while avoiding obstacles.
*/

namespace TheFountainOfObjects
{
    public class MapFeature
    {
        // represents a feature present in a room

        public string Name = "Empty";
        public string Description = "You can't see anything.";
        public bool IsEnabled = false;

        public virtual void Interact()
        {
            Console.WriteLine("There is nothing to interact with.");
        }
    }


    public class FountainOfObjects : MapFeature
    {
        public new string Name = "Fountain";
        public new string Description = "The fountain of objects is here!";
        public new bool IsEnabled = false;

        public override void Interact()
        {
            // turn the fountain of objects on or off

            if (IsEnabled == false)
            {
                IsEnabled = true;
                Console.WriteLine("You hear rushing waters from the Fountain of Objects. It has been enabled.");
            }
            else
            {
                IsEnabled = false;
                Console.WriteLine("The water stops rushing from the Fountain of Objects. It has been disabled.");
            }
        }
    }


    public class Entrance : MapFeature
    {
        public new string Name = "Entrance";
        public new string Description = "You see light coming from the cavern entrance.";
    }


    public class BottomlessPit : MapFeature
    {
        public new string Name = "Pit";
        public new string Description = "You fall into a bottomless pit.";
    }
}
