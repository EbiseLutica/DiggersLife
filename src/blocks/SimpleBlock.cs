using DotFeather;

namespace DiggersLife
{
	/// <summary>
	/// 無機能ブロックを表します。
	/// </summary>
	public class SimpleBlock : Block
	{
		public override Resource? Texture => texture;

		public override int Hardness => hardness;

		public override AppropriateTools AppropriateTool => appropriateTool;

		public override Rectangle Collision => collision;

		public override string UnlocalizedName => unlocalizedName;

		public override void OnInteract(VectorInt location, int blockState, IBlockEntity? blockEntity) { }

		public override void OnBreak(VectorInt location, int blockState, IBlockEntity? blockEntity) { }

		public SimpleBlock SetTexture(Resource? t)
		{
			texture = t;
			return this;
		}

		public SimpleBlock SetHardness(int h)
		{
			hardness = h;
			return this;
		}

		public SimpleBlock SetAppropriateTools(AppropriateTools a)
		{
			appropriateTool = a;
			return this;
		}

		public SimpleBlock SetCollision(Rectangle c)
		{
			collision = c;
			return this;
		}

		public SimpleBlock SetUnlocalizedName(string u)
		{
			unlocalizedName = u;
			return this;
		}

		private Resource? texture = null;
		private int hardness = 0;
		private AppropriateTools appropriateTool = AppropriateTools.None;
		private Rectangle collision = new Rectangle(0, 0, 16, 16);
		private string unlocalizedName = "";
	}
}
