﻿using static System.Console;

namespace EscapeGameConsole.Services
{
	public interface IScoringService
	{
		void Persist(string username, int score);
	}

	public class ConsoleScoringService : IScoringService
	{
		public void Persist(string username, int score)
			=>
                WriteLine($"{username} - {score}");
	}
}