using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using DotFeather;

namespace DiggersLife
{
	public class World
	{
		public const string WorldTypeNormal = "normal";
		public const string WorldTypeFlat = "flat";
		public const string WorldTypeExtreme = "extreme";
		public const string WorldTypeSky = "sky";

		public string Name { get; }

		public int Seed { get; }

		public string WorldType { get; } = WorldTypeNormal;

		public IWorldGenerator Generator { get; }

		public Dictionary<int, Chunk> Chunks { get; } = new Dictionary<int, Chunk>();

		public VectorInt WorldSpawn { get; set; }

		public Block this[int x, int y]
		{
			get
			{
				var chunk = GetChunk(x / 16) ?? throw new ChunkNotPreparedException();
				return chunk.Blocks[x % 16, y].ToBlock();
			}
			set
			{
				var chunk = GetOrCreateChunk(x / 16);
				chunk.Blocks[x & 16, y] = value.ToId();
			}
		}

		public World(string name, string worldType, int seed, VectorInt worldSpawn)
		{
			Name = name;
			WorldType = worldType;
			WorldSpawn = worldSpawn;
			Seed = seed;
			Generator = worldType switch
			{
				WorldTypeFlat => new FlatWorldGenerator(64),
				_ => throw new NotImplementedException(),
			};
		}

		public Chunk? GetChunk(int offset) => Chunks.ContainsKey(offset) ? Chunks[offset] : null;

		public Chunk GetOrCreateChunk(int offset)
		{
			return GetChunk(offset) ?? InitializeChunk(offset);
		}

		/// <summary>
		/// 強制的にチャンクを再生成します。
		/// </summary>
		public Chunk InitializeChunk(int offset)
		{
			return Chunks[offset] = new Chunk(offset, Generator);
		}

		/// <summary>
		/// 全てのチャンクデータを読み込みます。
		/// </summary>
		public void LoadAllChunks()
		{
			var chunkFiles = Directory.EnumerateFiles(Path.Combine(GenerateWorldPath(Name), "chunks"), "*.dcf");
			foreach (var path in chunkFiles)
			{
				var offset = int.Parse(Path.GetFileNameWithoutExtension(path));
				Chunks[offset] = Chunk.LoadFrom(path);
			}
		}

		public string GenerateWorldPath(string name) => Path.Combine("worlds", HttpUtility.UrlEncode(name));
		public string GenerateChunkPath(string name, int offset) => Path.Combine(GenerateWorldPath(name), "chunks", offset + ".dcf");
	}
}
