using System;
using System.IO;
using System.Text;

namespace DiggersLife
{
	public class Chunk
	{
		public short[,] Blocks { get; }
		public byte[,] Blockstates { get; }

		public Chunk(int offset, IWorldGenerator generator)
		{
			Blockstates = new byte[16, 256];
			Blocks = new short[16, 256];
			for (var x = 0; x < 16; x++)
			{
				for (var y = 0; y < 256; y++)
				{
					Blocks[x, y] = generator.Generate(x + offset, y);
				}
			}
		}

		public Chunk(short[,] blocks, byte[,] states) => (Blocks, Blockstates) = (blocks, states);

		public void SaveTo(string path)
		{
			using var writer = new BinaryWriter(File.OpenWrite(path), Encoding.UTF8);

			// Magic Number
			writer.Write("DCF".ToCharArray());

			// Write data
			for (var y = 0; y < 256; y++)
			{
				for (var x = 0; x < 16; x++)
				{
					writer.Write(Blocks[x, y]);
					writer.Write(Blockstates[x, y]);
				}
			}
		}

		public static Chunk LoadFrom(string path)
		{
			using var reader = new BinaryReader(File.OpenRead(path));

			// Magic Number
			if (new string(reader.ReadChars(3)) != "DCF")
			{
				throw new InvalidOperationException("Invalid File Format");
			}

			var blocks = new short[16, 256];
			var states = new byte[16, 256];

			// Read data
			for (var y = 0; y < 256; y++)
			{
				for (var x = 0; x < 16; x++)
				{
					blocks[x, y] = reader.ReadInt16();
					states[x, y] = reader.ReadByte();
				}
			}

			return new Chunk(blocks, states);
		}
	}
}
