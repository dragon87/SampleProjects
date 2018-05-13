namespace EscapeGameConsole.GameElements
{
	public enum Direction
	{
		North = 1, //Up
		South = 2, //Down,
		West = 3, //Left
		Easr = 4, //Right
	}

    public enum DifficultyLevel
	{
		Low,
        Medium,
        High
	}

	public static class Constants
	{
		public const int EmptyCellInitialLife = 1;

		public const int ToxicPotionLife = 1;
		public const int HealingPotionLife = 10;

		public const int MonsterLife = 5;
		public const int BigMonsterLife = 10;

		public const int PlayerLife = 10;

		public const int MonsterMaxDamage = 3;
		public const int MonsterReward = 5;

		public const int BigMonsterMaxDamage = 5;
		public const int BigMonsterReward = 10;

		public const int LowLevelMapSize = 3;
		public const int MediumLevelMapSize = 4;
		public const int HighLevelMapSize = 5;
	}
}