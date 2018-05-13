using System;

namespace Api.Models
{
	public class Game
    {
		public int Id { get; set; }
		public string Username { get; set; }
		public int Score { get; set; }
		public DateTime Date { get; set; }
    }
}