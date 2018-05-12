namespace EscapeGameConsole.GameElements
{
	public class Player : Combatant
	{
		GameElement _host;

		int _toxicPotionCount;

		public Player(GameElement host, int initialLife = 10) 
			: base(initialLife)
		{
			_host = host;
		}

		public void Visit(GameElement gameElement)
		{
			Visit((dynamic)gameElement);

			if (Life > 0)
			{
				gameElement.MarkAsConsumed();
			}
		}

		private void Visit(EmptyCell emptyCell)
		{
			Life += emptyCell.Life;
		}
        
		private void Visit(ToxicPotion toxicPotion)
        {
			_toxicPotionCount += toxicPotion.Life;
        }

		private void Visit(HealingPotion healingPotion)
		{
			if (Life > healingPotion.Life)
			{
				return;
			}

			Life = healingPotion.Life;
		}

		private void Visit(Monster monster)
		{
			if (_toxicPotionCount > 0)
			{
				_toxicPotionCount--;
				return;
			}
            
			//TODO: Call FightManager to resolve the dispute
		}

		private void Visit(BigMonster bigMonster)
		{
			//TODO: Call FightManager to resolve the dispute
		}
	}
}