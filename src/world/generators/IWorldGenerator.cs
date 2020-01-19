using DotFeather;

namespace DiggersLife
{
	public interface IWorldGenerator
	{
		int Generate(VectorInt position, int seed);

		int Generate(int x, int y, int seed);
	}

	public class FlatWorldGenerator : IWorldGenerator
	{
		public int Generate(VectorInt position, int seed) => Generate(position.X, position.Y, seed);

		public int Generate(int x, int y, int seed)
		{
			// x と seed は生成に無関係
			return y < 60
		}
	}
}