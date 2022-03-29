namespace TheFinalBattle
{
    public class Program
    {
        public static void Main()
        {
            Party heroes = new Party(new TrueProgrammer());
            Party monsters = new Party(new Skeleton());

            Battle battle = new Battle(heroes, monsters);
            battle.Run();
        }
    }
}
