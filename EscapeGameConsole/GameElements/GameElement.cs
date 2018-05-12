using System;

namespace EscapeGameConsole.GameElements
{
	public abstract class GameElement
    {
		public int Life { get; protected set; }

        public GameElement(int initialLife)
        {
			Life = initialLife;
        }

        public void MarkAsConsumed()
		{
			Life = 0;
		}
        
        public string Render()
		{
			return $"{this.GetType().Name} / {Life};";
		}
    }
}
