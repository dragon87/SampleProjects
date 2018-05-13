using System;
using EscapeGameConsole.GameElements;

namespace EscapeGameConsole.Factories
{
	public static class DirectionFactory
	{
		public static MoveResult GetNextLocation(Tuple<int, int> currentPlayerLocation,
													  Direction direction, uint mapSize)
		{
			switch (direction)
			{
				case Direction.North:
					{
						if (currentPlayerLocation.Item1 == 0)
						{
							return new MoveResult
							{ 
								IsValid = false 
							};
						}                  

						return new MoveResult
						{
							IsValid = true,
							FutureLocation = new Tuple<int, int>(currentPlayerLocation.Item1 - 1,
																 currentPlayerLocation.Item2)
						};
					}

				case Direction.South:
					{
						if (currentPlayerLocation.Item1 == mapSize - 1)
						{
							return new MoveResult
                            {
                                IsValid = false
                            };
						}

						return new MoveResult
                        {
                            IsValid = true,
                            FutureLocation = new Tuple<int, int>(currentPlayerLocation.Item1 + 1,
                                                                 currentPlayerLocation.Item2)
                        };
					}

				case Direction.West:
					{
						if (currentPlayerLocation.Item2 == 0)
						{
							return new MoveResult
                            {
                                IsValid = false
                            };
						}

						return new MoveResult
						{
							IsValid = true,
							FutureLocation = new Tuple<int, int>(currentPlayerLocation.Item1,
																 currentPlayerLocation.Item2 - 1)
						};
					}

				case Direction.East:
					{
						if (currentPlayerLocation.Item2 == mapSize - 1)
						{
							return new MoveResult
                            {
                                IsValid = false
                            };
						}                  

						return new MoveResult
                        {
                            IsValid = true,
                            FutureLocation = new Tuple<int, int>(currentPlayerLocation.Item1,
                                         currentPlayerLocation.Item2 + 1)
                        };
					}

				default:
					throw new Exception("Diagonal move not supported.");
			}
		}
	}

	public class MoveResult
	{
		public bool IsValid { get; set; }

		public Tuple<int, int> FutureLocation { get; set; }
	}
}
