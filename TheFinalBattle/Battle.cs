namespace TheFinalBattle
{
    internal class Battle
    {
        public Party Heroes { get; set; }
        public Party Monsters { get; set; }

        public Battle(Party heroes, Party monsters)
        {
            Heroes = heroes;
            Monsters = monsters;
        }

        // Run the battle through to completion
        public void Run()
        {
            while (true)
            {
                foreach (Party party in new[] { Heroes, Monsters })
                {
                    foreach (Character character in party.Members)
                    {
                        Console.WriteLine();
                        Console.WriteLine($"It is {character.Name}'s turn.");
                        character.Action();
                        Thread.Sleep(1000);
                    }
                }
            }
        }
    }
}
