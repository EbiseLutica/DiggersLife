namespace DiggersLife
{
	[System.Serializable]
	public class ChunkNotPreparedException : System.Exception
	{
		public ChunkNotPreparedException() { }
		public ChunkNotPreparedException(string message) : base(message) { }
		public ChunkNotPreparedException(string message, System.Exception inner) : base(message, inner) { }
		protected ChunkNotPreparedException(
			System.Runtime.Serialization.SerializationInfo info,
			System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
	}
}
