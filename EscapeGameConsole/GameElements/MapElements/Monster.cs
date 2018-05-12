namespace EscapeGameConsole.GameElements
{
	public class Monster : Combatant
	{
		public Monster(int initialLife = Constants.MonsterLife) 
			: base(initialLife)
		{
		}
	}
}