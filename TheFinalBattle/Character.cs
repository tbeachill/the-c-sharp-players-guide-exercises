namespace TheFinalBattle
{ 
    // Base class for different character types
    public abstract class Character
    {
        public abstract string Name { get; set; }

        public Character()
        {
            Name = "UNKNOWN";
        }

        // perform the selected action for that turn
        public void Action()
        {
            Console.WriteLine($"{Name} did nothing.");
        }
    }
}
