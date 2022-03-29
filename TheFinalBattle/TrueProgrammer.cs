namespace TheFinalBattle
{
    // The player's character
    public class TrueProgrammer : Character
    {
        public override string Name { get; set; }

        // Get name from the player
        public TrueProgrammer()
        {
            do
            {
                Console.WriteLine("What is your name? ");
                Name = Console.ReadLine();
            }
            while (Name == "");
        }
    }
}
