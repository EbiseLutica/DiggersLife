using DotFeather;

namespace DiggersLife
{
	public interface IWorldGenerator
	{
		int Generate(VectorInt position);

		int Generate(int x, int y);
	}
}