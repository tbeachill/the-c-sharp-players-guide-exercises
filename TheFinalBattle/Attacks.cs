namespace TheFinalBattle
{
    public interface IAttack
    {
        public string Name { get; }
        public int Damage();
    }


    public class Punch : IAttack
    {
        public string Name => "PUNCH";
        public int Damage() => 1;
    }


    public class BoneCrunch : IAttack
    {
        public string Name => "BONE CRUNCH";
        Random r = new Random();
        public int Damage() => r.Next(2);
    }
}
