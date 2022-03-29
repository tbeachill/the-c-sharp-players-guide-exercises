namespace TheFinalBattle
{
    public class ComputerPlayer : IPlayer
    {
        // Generate a random action to perform
        public IAction ChooseAction(Battle battle, Character character)
        {
            IAction action;

            IAttack attack = character.StandardAttack;
            Character target = battle.GetEnemyParty(character).Members[0];

            // Select a random action to perform
            Random random = new Random();
            action = random.Next(0,2) switch
            {
                0 => new DoNothingAction(),
                1 => new AttackAction(attack, target)
            };

            Thread.Sleep(500);
            return action;
        }
    }
}
