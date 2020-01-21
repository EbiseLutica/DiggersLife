using DotFeather;

namespace DiggersLife
{
	public class FlatWorldGenerator : IWorldGenerator
	{
		public int Height { get; }

		public FlatWorldGenerator(int height = 64) => Height = height;

		public short Generate(VectorInt position) => Generate(position.X, position.Y);

		public short Generate(int x, int y) =>
		(
			y == 0 ? Blocks.Bedrock :
			y < Height - 3 ? Blocks.Stone :
			y < Height ? Blocks.Dirt :
			y == Height ? Blocks.Grass : Blocks.Air
		).ToId();
	}
}
