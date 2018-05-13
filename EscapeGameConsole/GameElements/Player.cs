using EscapeGameConsole.GameManagers;
using EscapeGameConsole.MapElements;

namespace EscapeGameConsole.GameElements
{
	public class Player : Combatant
	{
		public GameElement Host { get; private set; }

		int _toxicPotionCount;

		public Player(GameElement host = null, 
		              int initialLife = Constants.PlayerLife)
			: base(initialLife)
		{
			Host = host;
		}

		public void Visit(GameElement gameElement)
		{
			Host = gameElement;

			if (gameElement.Life > 0)
			{
				Visit((dynamic)gameElement);
			}

			if (Life > 0)
			{
				gameElement.MarkAsConsumed();
			}
		}

		void Visit(EmptyCell emptyCell)
		{
			Life += emptyCell.Life;
		}
        
		void Visit(ToxicPotion toxicPotion)
        {
			_toxicPotionCount += toxicPotion.Life;
        }

		void Visit(HealingPotion healingPotion)
		{
			if (Life > healingPotion.Life)
			{
				return;
			}

			Life = healingPotion.Life;
		}

		void Visit(Monster monster)
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

		void Visit(BigMonster bigMonster)
		{
			FightManager.Combat(this, bigMonster, Constants.BigMonsterMaxDamage, 
			                    Constants.BigMonsterReward);
		}
	}
}