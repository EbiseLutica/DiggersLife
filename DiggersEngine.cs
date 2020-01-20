namespace DiggersLife
{
	public static class DiggersEngine
	{
		public static World? CurrentWorld { get; }

		public static void Init()
		{
			Blocks.Init();
		}
	}
}
