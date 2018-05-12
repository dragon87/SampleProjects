using System;

namespace EscapeGameConsole.GameElements
{
	public static class FightManager
	{
		public static void Combat(Combatant firstPlayer, Combatant secondPlayer,
								 int damageThreshold, int firstPlayerReward)
		{
			Random random = new Random();
			//Take turns.
			while (firstPlayer.Life > 0 && secondPlayer.Life > 0)
			{
				//First players hits first.
				secondPlayer.TakePunch(random.Next(1,
											damageThreshold + 1));
				if (secondPlayer.Life > 0)
				{
					firstPlayer.TakePunch(random.Next(1,
											 damageThreshold + 1));
				}
			}
			if (firstPlayer.Life > 0)
			{
				firstPlayer.Reward(firstPlayerReward);
			}
		}
	}
}
