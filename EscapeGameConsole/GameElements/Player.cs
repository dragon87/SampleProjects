namespace EscapeGameConsole.GameElements
{
	public class Player : Combatant
	{
		GameElement _host;

		int _toxicPotionCount;

		public Player(GameElement host = null, 
		              int initialLife = Constants.PlayerLife)
			: base(initialLife)
		{
			_host = host;
		}

		public void Visit(GameElement gameElement)
		{
			_host = gameElement;

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
			//Player is greedy when it owns toxic potion.
			if (_toxicPotionCount > 0)
			{
				_toxicPotionCount--;
				Life += monster.Life;

				return;
			}

			FightManager.Combat(this, monster, Constants.MonsterMaxDamage, 
			                    Constants.MonsterReward);         
		}

		private void Visit(BigMonster bigMonster)
		{
			FightManager.Combat(this, bigMonster, Constants.BigMonsterMaxDamage, 
			                    Constants.BigMonsterReward);
		}
	}
}