namespace TheFinalBattle
{
    public class Battle
    {
        public Party Heroes { get; }
        public Party Monsters { get; }

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
                        party.Player.ChooseAction(this, character).Run(this, character);
                    }
                }
            }
        }

        public Party GetEnemyParty(Character character) => Heroes.Members.Contains(character) ? Monsters : Heroes;
    }
}
