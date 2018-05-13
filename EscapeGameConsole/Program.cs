using EscapeGameConsole.GameElements;

namespace EscapeGameConsole
{
	class Program
    {
#pragma warning disable RECS0154 // Parameter is never used
		static void Main(string[] args)
#pragma warning restore RECS0154 // Parameter is never used
		{
			GameSession gameSession = new GameSession("Dragos",
			                                          DifficultyLevel.High);

			gameSession.SimulateRound();
        }
    }
}
