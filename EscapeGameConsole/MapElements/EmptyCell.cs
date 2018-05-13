using EscapeGameConsole.GameElements;

namespace EscapeGameConsole.MapElements
{
	public class EmptyCell : GameElement
	{
		public EmptyCell(int initialLife = Constants.EmptyCellInitialLife) 
			: base(initialLife)
		{
		}
	}
}