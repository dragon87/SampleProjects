using System;
using EscapeGameConsole.GameElements;
using Xunit;

namespace EscapeGame.Tests
{
	public class GameMapFactoryUnitTests
	{
		[Fact]
		public void GameMapFactoryEasyLevelReturnsProperStuff()
		{
			//Arrange
			GameMap gameMap;

			//Act
			gameMap = GameMapFactory.GetGameMap(DifficultyLevel.Low);

			//Assert + manual debug inspect
			Assert.NotNull(gameMap);
		}

		[Fact]
		public void NewHardGameMapHasNineLivingMonstersAndOnePlayerWithFullTenLife()
		{
			//Arrange
			GameMap gameMap = GameMapFactory.GetGameMap(DifficultyLevel.High);
            
			//Act
			Tuple<int, int> gameConditions = gameMap.GetGameConditions();

			//Assert
			Assert.Equal(10, gameConditions.Item1);
			Assert.Equal(9, gameConditions.Item2);
		}
	}
}