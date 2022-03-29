namespace TheFinalBattle
{
    public interface IAttack
    {
        string Name { get; }
    }

    public class Punch : IAttack
    {
        public string Name => "PUNCH";
    }

    public class BoneCrunch : IAttack
    {
        public string Name => "BONE CRUNCH";
    }
}
