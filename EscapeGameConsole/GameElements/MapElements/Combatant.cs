namespace EscapeGameConsole.GameElements
{
	public abstract class Combatant : GameElement
	{
		public Combatant(int initialLife) : base(initialLife)
		{
		}

        public void TakePunch(int intensity)
		{
			Life -= intensity;
		}
	}
}