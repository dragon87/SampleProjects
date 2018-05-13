using System;
using EscapeGameConsole.Factories;
using EscapeGameConsole.GameElements;
using EscapeGameConsole.Services;

namespace EscapeGameConsole.GameManagers
{
	public class GameSessionManager
	{
		readonly GameMap _gameMap;
		readonly string _username;
		readonly IScoringService _scoringService;

		public GameSessionManager(string username, DifficultyLevel difficultyLevel)
		{
			_username = username;
			_gameMap = GameMapFactory.GetGameMap(difficultyLevel);         

            //In real world it will be injected via a DI container.
			_scoringService = new ConsoleScoringService();
		}

		public void SimulateRound()
		{
			Random random = new Random();
			Tuple<int, int> gameConditions = _gameMap.GetGameConditions();
			//Simulate a player behavior by generating random moving decisions 
			//until either the player dies or all the monster have been destroyed
			while (gameConditions.Item1 > 0 && gameConditions.Item2 > 0)
			{
				_gameMap.Render();
				_gameMap.MovePlayer((Direction)random.Next(1, 5));

				//Re-evaluate map
				gameConditions = _gameMap.GetGameConditions();
			}

			_gameMap.Render();

			if (gameConditions.Item1 > 0)
			{
				_scoringService.Persist(_username, gameConditions.Item1);
			}
			else
			{
				Console.WriteLine("Game over!");
			}
		}
	}
}

