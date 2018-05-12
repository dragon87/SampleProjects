using EscapeGameConsole.GameElements;
using Xunit;

namespace EscapeGame.Tests
{
	public class PlayerUnitTests
    {
		[Fact]
        public void PlayerVisitsEmptyCellLifeSoars()
        {
			//Given a player
			Player player = new Player(null);
			int expectedLife = 11;

			//When it visits an empty cell
			player.Visit(new EmptyCell());

			//Then its life soars by 1
			Assert.Equal(expectedLife, player.Life);
        }      
    }
}