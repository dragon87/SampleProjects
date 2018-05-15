using System;
using System.Collections.Generic;
using System.Linq;
using Api.Models;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
	[Route("api/[controller]")]
	public class GamesController : Controller
	{
		Game[] _games = {
			new Game {Id = 1, Username = "dragos", Score = 100, Date = new DateTime(2010, 1, 1) },
			new Game {Id = 2, Username = "mihai", Score = 200, Date = new DateTime(2011, 1, 1) },
			new Game {Id = 3, Username = "vasile", Score = 300, Date = new DateTime(2012, 1, 1) },
			new Game {Id = 4, Username = "dragos", Score = 150, Date = new DateTime(2005, 1, 1) }
		};

		// GET api/games
		public IEnumerable<Game> Get(SortingParams sortingParams = null)
			=> this.SortAndReturn<Game>(_games, sortingParams);

		// GET api/games/dragos
		[HttpGet("{username}")]
		public IEnumerable<Game> Get(string username, SortingParams sortingParams = null)
			=> this.SortAndReturn<Game>(_games.Where(x => x.Username == username), sortingParams);

		// PUT api/games/5
		[HttpPut("{id}")]
		public void Put(int id, [FromBody]string newUsername)
			=> _games.First(x => x.Id == id).Username = newUsername;

		// DELETE api/games/dragos
		[HttpDelete("{username}")]
		public void Delete(string username)
		{
			List<Game> gamesAsList = new List<Game>(_games);
			gamesAsList.RemoveAll(x => x.Username == username);

			_games = gamesAsList.ToArray();
		}

		private IEnumerable<T> SortAndReturn<T>(IEnumerable<T> source,
											 SortingParams sortingParams)
		{
			return !string.IsNullOrEmpty(sortingParams.SortBy)
						  ? source.AsQueryable().Sort(sortingParams.SortBy)
							  : source;
		}
	}
}