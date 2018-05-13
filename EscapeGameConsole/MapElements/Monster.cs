using EscapeGameConsole.GameElements;

namespace EscapeGameConsole.MapElements
{
	public class Monster : Combatant
	{
		public Monster(int initialLife = Constants.MonsterLife) 
			: base(initialLife)
		{
		}
	}
}