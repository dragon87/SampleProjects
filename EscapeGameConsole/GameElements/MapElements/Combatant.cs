namespace EscapeGameConsole.GameElements
{
	public abstract class Combatant : GameElement
	{
		protected Combatant(int initialLife) : base(initialLife)
		{
		}

        public void TakePunch(int intensity)
		{
			Life -= intensity;
		}

        public void Reward(int life)
		{
			Life += life;
		}
	}
}