using System.Collections.Generic;
using System.Linq;

namespace DiggersLife
{
	public static class Blocks
	{
		public static bool Register(Block block) => Register(block, true);

		public static Block Air = new SimpleBlock()
			.SetHardness(Block.UnbreakableHardness)
			.SetCollision(Rectangle.Empty)
			.SetUnlocalizedName(Block.CreateName("air"));

		public static Block Grass = new SimpleBlock()
			.SetTexture(new Resource("grass"))
			.SetHardness(3)
			.SetAppropriateTools(AppropriateTools.Shovel)
			.SetUnlocalizedName(Block.CreateName("grass"));

		public static Block Bedrock = new SimpleBlock()
			.SetTexture(new Resource("bedrock"))
			.SetHardness(Block.UnbreakableHardness)
			.SetUnlocalizedName(Block.CreateName("bedrock"));

		public static Block Dirt = new SimpleBlock()
			.SetTexture(new Resource("dirt"))
			.SetHardness(3)
			.SetAppropriateTools(AppropriateTools.Shovel)
			.SetUnlocalizedName(Block.CreateName("dirt"));

		public static Block Stone = new SimpleBlock()
			.SetTexture(new Resource("dirt"))
			.SetHardness(3)
			.SetAppropriateTools(AppropriateTools.Pickaxe)
			.SetUnlocalizedName(Block.CreateName("dirt"));

		public static Block CobbleStone = new SimpleBlock()
			.SetTexture(new Resource("dirt"))
			.SetHardness(3)
			.SetAppropriateTools(AppropriateTools.Pickaxe)
			.SetUnlocalizedName(Block.CreateName("dirt"));

		public static Block BlockOf(int id) => blocks[id];

		public static int IdOf(Block block) => blockIntMap[block];

		public static int ToId(this Block theBlock) => IdOf(theBlock);

		public static Block ToBlock(this int theId) => BlockOf(theId);

		internal static void Init()
		{
			Register(Air, false);
			Register(Stone, false);
			Register(Dirt, false);
			Register(Grass, false);
			Register(CobbleStone, false);
			Register(Bedrock, false);
			SyncMaps();
		}

		private static bool Register(Block block, bool sync)
		{
			if (blocks.Contains(block))
			{
				return false;
			}
			blocks.Add(block);
			if (sync)
			{
				SyncMaps();
			}
			return true;
		}

		private static void SyncMaps()
		{
			blockIntMap.Clear();
			foreach (var (b, i) in blocks.Select((b, i) => (b, i)))
			{
				blockIntMap[b] = i;
			}
		}

		private static readonly List<Block> blocks = new List<Block>();

		private static readonly Dictionary<Block, int> blockIntMap = new Dictionary<Block, int>();
	}
}