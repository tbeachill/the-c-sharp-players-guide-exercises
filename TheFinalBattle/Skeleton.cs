namespace TheFinalBattle
{
    public class Skeleton : Character
    {
        public override string Name { get; } = "SKELETON";
        public override IAttack StandardAttack { get; } =  new BoneCrunch();
    }
}
