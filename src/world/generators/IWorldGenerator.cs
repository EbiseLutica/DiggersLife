using DotFeather;

namespace DiggersLife
{
	public interface IWorldGenerator
	{
		int Generate(VectorInt position, int seed);

		int Generate(int x, int y, int seed);
	}
}