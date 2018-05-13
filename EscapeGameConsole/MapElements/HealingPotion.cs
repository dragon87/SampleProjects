using EscapeGameConsole.GameElements;

namespace EscapeGameConsole.MapElements
{
	public class HealingPotion : GameElement
	{
		public HealingPotion(int initialLife = Constants.HealingPotionLife) 
			: base(initialLife)
		{
		}
	}
}