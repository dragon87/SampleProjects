using EscapeGameConsole.GameElements;
using EscapeGameConsole.GameManagers;

namespace EscapeGameConsole
{
	class Program
    {
#pragma warning disable RECS0154 // Parameter is never used
		static void Main(string[] args)
#pragma warning restore RECS0154 // Parameter is never used
		{
			GameSessionManager gameSession = new GameSessionManager("Dragos",
			                                                        DifficultyLevel.Medium);

			gameSession.SimulateRound();
        }
    }
}
