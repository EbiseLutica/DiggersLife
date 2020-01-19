using DotFeather;

namespace DiggersLife
{
	public interface IRandomTicker
	{
		void OnRandomTick(VectorInt location, int blockState, IBlockEntity? blockEntity);
	}
}
