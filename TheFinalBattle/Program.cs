namespace TheFinalBattle
{
    public class Program
    {
        public static void Main()
        {
            // Create party with a player and a list of party members
            Party heroes = new Party(new HumanPlayer(), new List<Character> { new TrueProgrammer() });
            Party monsters = new Party(new ComputerPlayer(), new List<Character> { new Skeleton() });

            Battle battle = new Battle(heroes, monsters);
            battle.Run();
        }
    }
}
