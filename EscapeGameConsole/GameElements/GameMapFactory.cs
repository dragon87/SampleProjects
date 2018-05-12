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
						//TODO: 3x3 map
						return new GameMap(new Player(), null, 
						                   Constants.LowLevelMapSize);
					}

				case DifficultyLevel.Medium:
                    {
						//TODO: 4x4 map
						return new GameMap(new Player(), null, 
						                   Constants.MediumLevelMapSize);
                    }

				case DifficultyLevel.High:
                    {
						//TODO: 5x5 map
						return new GameMap(new Player(), null, 
						                   Constants.HighLevelMapSize);
                    }
			}

			throw new System.Exception("Invalid game map configuration.");
		}
	}
}
