namespace TheFinalBattle
{ 
    // Base class for different character types
    public abstract class Character
    {
        public abstract string Name { get; }
        public abstract IAttack StandardAttack { get; }
    }
}
