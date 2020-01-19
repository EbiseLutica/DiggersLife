using DotFeather;

namespace DiggersLife
{
	/// <summary>
	/// 全てのブロックの基底クラスです。
	/// </summary>
	public abstract class Block
	{
		public static readonly int UnbreakableHardness = -1;

		public abstract Resource? Texture { get; }

		public abstract int Hardness { get; }

		public abstract AppropriateTools AppropriateTool { get; }

		public virtual Rectangle Collision => new Rectangle(0, 0, 16, 16);

		public abstract string UnlocalizedName { get; }

		public abstract void OnInteract(VectorInt location, int blockState, IBlockEntity? blockEntity);

		public abstract void OnBreak(VectorInt location, int blockState, IBlockEntity? blockEntity);

		internal static string CreateName(string name) => "diggerslife.blocks." + name;
	}
}