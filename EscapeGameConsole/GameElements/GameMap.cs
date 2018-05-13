using System;
using EscapeGameConsole.Factories;
using EscapeGameConsole.MapElements;

namespace EscapeGameConsole.GameElements
{
	public class GameMap
	{
		Player _player;
		readonly GameElement[,] _gameElements;
		readonly uint _mapSize;

		public GameMap(Player player, GameElement[,] gameElements,
					   uint mapSize)
		{
			_player = player;
			_gameElements = gameElements;
			_mapSize = mapSize;
		}

		public void MovePlayer(Direction direction)
		{
			Tuple<int, int> currentPlayerLocation = 
				this.GetElementLocation(_player.Host);

			MoveResult moveResult = DirectionFactory.GetNextLocation(currentPlayerLocation,
																	direction, _mapSize);

			if (moveResult.IsValid)
			{
				_player.Visit(_gameElements[moveResult.FutureLocation.Item1,
											moveResult.FutureLocation.Item2]);
			}
			else
			{
				Console.WriteLine($"Invalid move: {direction}");
			}
		}

		public void Render()
		{
			for (uint i = 0; i < _mapSize; i++)
			{
				for (uint j = 0; j < _mapSize; j++)
				{
					if (_player.Host != _gameElements[i, j])
					{
						Console.Write(_gameElements[i, j].Render());
					}
					else
					{
						Console.Write(_player.Render());
					}
				}

				Console.WriteLine();
			}

			Console.WriteLine();
		}

		/// <summary>
		/// Gets the game conditions.
		/// </summary>
		/// <returns>The game conditions: player life score plus number of
		/// living monsters.</returns>
		public Tuple<int, int> GetGameConditions()
		{
			int livingMonsterCount = 0;

			for (int i = 0; i < _mapSize; i++)
			{
				for (int j = 0; j < _mapSize; j++)
				{
					if (_gameElements[i, j] is Monster 
					    && 
					    _gameElements[i, j].Life > 0)
					{
						livingMonsterCount++;
					}
				}
			}

			return new Tuple<int, int>(_player.Life, livingMonsterCount);
		}

		Tuple<int, int> GetElementLocation(GameElement gameElement)
		{
			for (int i = 0; i < _mapSize; i++)
            {
                for (int j = 0; j < _mapSize; j++)
                {
					if (_gameElements[i, j] == gameElement)
                    {
						return new Tuple<int, int>(i, j);
                    }
                }
            }

			return null;
		}
	}
}