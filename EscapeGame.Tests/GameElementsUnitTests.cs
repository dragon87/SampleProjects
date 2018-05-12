using EscapeGameConsole.GameElements;
using Xunit;

namespace EscapeGame.Tests
{
	public class GameElementsUnitTests
    {
        [Fact]
        public void ConsumedGameElementIsLifeless()
        {
			//Given a game element
			EmptyCell emptyCell = new EmptyCell();
			int remainingLife = 0;

            //When it is consumed by main character of the game
			emptyCell.MarkAsConsumed();

			//Then is should no longer have life (it should not provide
			//additional value if is being visited second time)
			Assert.Equal(remainingLife, emptyCell.Life);
        }

        [Fact]
        public void GameElementKnowsToRenderItselfAsString()
		{
			//Given a game element
			BigMonster bigMonster = new BigMonster();
			string expected = "BigMonster / 10;";

			//When it is rendered
			string actual = bigMonster.Render();

            //Then is should present its name and its remaining life
			Assert.Equal(expected, actual);
		}

        [Fact]
        public void PunchedCombatantHasLifeDroppedOff()
		{
			//Given a combatant
			Combatant combatant = new Monster();
			int expectedRemainingLife = 2;
			int punchIntensity = 3;

			//When it takes a punch
			combatant.TakePunch(punchIntensity);

			//Then its life drops off
			Assert.Equal(expectedRemainingLife, combatant.Life);
		}
    }
}