using DotFeather;

namespace DiggersLife
{
	class Entry
	{
		static void Main(string[] args)
		{
			DiggersEngine.Init();
			new RoutingGameBase<MainScene>(640, 480, "DiggersLife", 60).Run();
		}
	}
}
