namespace DiggersLife
{
	public class Chunk
	{
		public int Left { get; private set; }

		public int[,] Blocks { get; } = new int[16, 256];

		public Chunk(int left, IWorldGenerator generator)
		{
			Left = left;
			for (var x = 0; x < 16; x++)
			{
				for (var y = 0; y < 256; y++)
				{
					Blocks[x, y] = generator.Generate(x + left, y);
				}
			}
		}

		public Chunk(int left, int[,] blocks) => (Left, Blocks) = (left, blocks);
	}
}
