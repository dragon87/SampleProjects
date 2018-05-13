using System;

namespace EscapeGameConsole.GameElements
{
	public class GameMap
	{
		Player _player;
		GameElement[,] _gameElements;
		uint _mapSize;

		public GameMap(Player player, GameElement[,] gameElements, 
		               uint mapSize)
		{
			_player = player;
			_gameElements = gameElements;
			_mapSize = mapSize;
		}

		public void MovePlayer(Direction direction)
		{
			//TODO: add implementation
			//based on the direction, get next host and make player visit 
			//that element.
			//validate if direction is valid (stays on the map).
		}

		public void Render()
		{
			for (uint i = 0; i < _mapSize; i++)
			{
				for (uint j = 0; j < _mapSize; j++)
				{
					_gameElements[i, j].Render();
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
					if (_gameElements[i, j] is Monster)
					{
						livingMonsterCount++;
					}
				}
			}

			return new Tuple<int, int>(_player.Life, livingMonsterCount);
		}
	}
}