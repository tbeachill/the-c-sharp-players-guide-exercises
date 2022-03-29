namespace TheFinalBattle
{
    internal class TrueProgrammer : Character
    {
        public override string Name { get; set; }
        public TrueProgrammer()
        {
            Console.WriteLine("What is your name? ");
            Name = Console.ReadLine();
        }
    }
}
