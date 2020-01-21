using DotFeather;

namespace DiggersLife
{
	public class NormalWorldGenerator : IWorldGenerator
	{
		public NormalWorldGenerator(int? seed = null)
		{
			noise = new NoiseGenerator(seed);
		}

		public short Generate(VectorInt position) => Generate(position.X, position.Y);

		public short Generate(int x, int y)
		{
			var n = 60 - noise.Generate(x / 16f) * 128;
			return (
				y == 0 ? Blocks.Bedrock :
				y < n - 3 ? Blocks.Stone :
				y < n ? Blocks.Dirt :
				y == n ? Blocks.Grass : Blocks.Air
			).ToId();
		}

		private NoiseGenerator noise;
	}
}
