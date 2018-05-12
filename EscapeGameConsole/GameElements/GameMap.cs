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

		public Tuple<int, int> GetGameConditions()
		{
			return new Tuple<int, int>(1, 1);
		}
	}
}