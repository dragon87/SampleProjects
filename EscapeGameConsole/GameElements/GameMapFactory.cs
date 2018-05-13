using System;

namespace EscapeGameConsole.GameElements
{
	public static class GameMapFactory
	{
		public static GameMap GetGameMap(DifficultyLevel difficultyLevel)
		{
			switch (difficultyLevel)
			{
				case DifficultyLevel.Low:
					{
						Random random = new Random();

						int monsterCount = 2;
						int toxicPotionCount = 0;
						int healingPotionCount = random.Next(0, 2);

						GameElement[,] gameElements = CreateGameElements(Constants.LowLevelMapSize,
																		 monsterCount,
																		 toxicPotionCount,
																		 healingPotionCount);
						Player player = new Player(gameElements[Constants.LowLevelMapSize - 1, 0]);

						return new GameMap(player, gameElements,
										   Constants.LowLevelMapSize);
					}

				case DifficultyLevel.Medium:
					{
						Random random = new Random();

						int monsterCount = 5;
						int toxicPotionCount = random.Next(0, 2);
						int healingPotionCount = random.Next(0, 3);

						GameElement[,] gameElements = CreateGameElements(Constants.MediumLevelMapSize,
																		 monsterCount,
																		 toxicPotionCount,
																		 healingPotionCount);
						Player player = new Player(gameElements[Constants.MediumLevelMapSize - 1, 0]);

						return new GameMap(player, gameElements,
										   Constants.MediumLevelMapSize);
					}

				case DifficultyLevel.High:
					{
						Random random = new Random();

						int monsterCount = 8;
						int toxicPotionCount = random.Next(0, 3);
						int healingPotionCount = random.Next(0, 5);

						GameElement[,] gameElements = CreateGameElements(Constants.HighLevelMapSize,
																		 monsterCount,
																		 toxicPotionCount,
																		 healingPotionCount);
						Player player = new Player(gameElements[Constants.HighLevelMapSize - 1, 0]);

						return new GameMap(player, gameElements,
										   Constants.HighLevelMapSize);
					}

				default:
					throw new Exception("Invalid game map configuration.");
			}
		}

		static GameElement[,] CreateGameElements(int mapSize,
														 int monsterCount,
														 int toxicPotionCount,
														 int healingPotionCount)
		{
			Random random = new Random();

			int emptyCellCount = mapSize * mapSize - monsterCount -
                            toxicPotionCount - healingPotionCount - 2;

            GameElement[,] gameElements = new GameElement[mapSize, mapSize];
			//Predefined Player and Big Monster
            gameElements[mapSize - 1, 0] = new EmptyCell(0);
            gameElements[mapSize - 1, mapSize - 1] = new BigMonster();

			while (monsterCount > 0 || toxicPotionCount > 0 ||
				  healingPotionCount > 0 || emptyCellCount > 0)
			{
				int matrixIndex = random.Next(1, mapSize * mapSize);

				if (gameElements[(matrixIndex - 1) / mapSize,
								 (matrixIndex - 1) % mapSize] != null)
				{
					continue;
				}

				if (monsterCount > 0)
				{
					gameElements[(matrixIndex - 1) / mapSize,
								 (matrixIndex - 1) % mapSize] = new Monster();

					monsterCount--;
					continue;
				}

				if (toxicPotionCount > 0)
				{
					gameElements[(matrixIndex - 1) / mapSize,
								 (matrixIndex - 1) % mapSize] = new ToxicPotion();

					toxicPotionCount--;
					continue;
				}

				if (healingPotionCount > 0)
				{
					gameElements[(matrixIndex - 1) / mapSize,
								 (matrixIndex - 1) % mapSize] = new HealingPotion();

					healingPotionCount--;
					continue;
				}

				if (emptyCellCount > 0)
                {
                    gameElements[(matrixIndex - 1) / mapSize,
					             (matrixIndex - 1) % mapSize] = new EmptyCell();

					emptyCellCount--;
                    continue;
                }
			}

			return gameElements;
		}
	}
}