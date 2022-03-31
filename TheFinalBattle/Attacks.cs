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


    public class Unraveling : IAttack
    {
        public string Name => "UNRAVELING";
        Random r = new Random();

        public int Damage() => r.Next(3);
    }


    public class Slash : IAttack
    {
        public string Name => "SLASH";

        public int Damage() => 2;
    }


    public class Stab : IAttack
    {
        public string Name => "STAB";

        public int Damage() => 1;
    }
}
