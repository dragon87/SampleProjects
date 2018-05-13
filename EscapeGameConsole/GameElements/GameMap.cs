using System;

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

			switch (direction)
			{
				case Direction.North:
					{
						if (currentPlayerLocation.Item1 == 0)
						{
							Console.WriteLine($"Invalid move: {direction}");
							return;
						}

						_player.Visit(_gameElements[currentPlayerLocation.Item1 - 1,
													currentPlayerLocation.Item2]);

						break;
					}

				case Direction.South:
					{
						if (currentPlayerLocation.Item1 == _mapSize - 1)
						{
							Console.WriteLine($"Invalid move: {direction}");
							return;
						}

						_player.Visit(_gameElements[currentPlayerLocation.Item1 + 1,
													currentPlayerLocation.Item2]);

						break;
					}

				case Direction.West:
					{
						if (currentPlayerLocation.Item2 == 0)
						{
							Console.WriteLine($"Invalid move: {direction}");
							return;
						}

						_player.Visit(_gameElements[currentPlayerLocation.Item1,
													currentPlayerLocation.Item2 - 1]);

						break;
					}

				case Direction.East:
					{
						if (currentPlayerLocation.Item2 == _mapSize - 1)
						{
							Console.WriteLine($"Invalid move: {direction}");
							return;
						}

						_player.Visit(_gameElements[currentPlayerLocation.Item1,
													currentPlayerLocation.Item2 + 1]);

						break;
					}

				default:
					throw new Exception("Diagonal move not supported.");
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