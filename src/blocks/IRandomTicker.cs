using DotFeather;

namespace DiggersLife
{
	public interface IRandomTicker
	{
		void OnRandomTick(VectorInt location, byte blockState, IBlockEntity? blockEntity);
	}
}
