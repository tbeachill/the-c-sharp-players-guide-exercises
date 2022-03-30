namespace TheFinalBattle
{
    public class Program
    {
        public static void Main()
        {
            // Create party with a player and a list of party members
            Party heroes = new Party(new HumanPlayer(), new List<Character> { new TrueProgrammer() }, new List<Item> { new HealthPotion(), new HealthPotion(), new HealthPotion() });
            Party monsters_1 = new Party(new ComputerPlayer(), new List<Character> { new Skeleton() }, new List<Item> { new HealthPotion() });
            Party monsters_2 = new Party(new ComputerPlayer(), new List<Character> { new Skeleton(), new Skeleton() }, new List<Item> { new HealthPotion() });
            Party boss = new Party(new ComputerPlayer(), new List<Character> { new UncodedOne() }, new List<Item> { new HealthPotion() });

            // Loop through battles with each enemy party
            foreach (Party monsterParty in new Party[] {monsters_1, monsters_2, boss})
            {
                Battle battle = new Battle(heroes, monsterParty);

                if (!battle.Run())
                {
                    Console.WriteLine("The heroes have lost. The Uncoded One has prevailed!");
                    break;
                }
                else
                {
                    Console.WriteLine("The heroes have won this round.");
                }
            }

            // If all battles have been played and there are still heroes alive, the heroes have won
            if (heroes.Members.Count > 0)
                Console.WriteLine("The heroes have won. The Uncoded One is deafeated!");
        }
    }
}
