using DotFeather;

namespace DiggersLife
{
	public interface IWorldGenerator
	{
		short Generate(VectorInt position);

		short Generate(int x, int y);
	}
}