namespace TheFinalBattle
{
    public class ComputerPlayer : IPlayer
    {
        // Generate a random action to perform
        public IAction ChooseAction(Battle battle, Character character)
        {
            Random r = new Random();
            IAction action;
            IAttack attack = character.StandardAttack;

            // Select a target randomly
            int targetIndex = r.Next(battle.GetEnemyParty(character).Members.Count);
            Character target = battle.GetEnemyParty(character).Members[targetIndex];

            // Select a random action to perform
            Random random = new Random();
            action = random.Next(1) switch
            {
                0 => new AttackAction(attack, target),
                //1 => new DoNothingAction()
            };

            return action;
        }
    }
}
