using DotFeather;

namespace DiggersLife
{
	public struct Rectangle
	{
		public static readonly Rectangle Empty = new Rectangle();

		public VectorInt Position { get; set; }

		public VectorInt Size { get; set; }

		public int X
		{
			get => Position.X;
			set => Position = new VectorInt(value, Position.Y);
		}

		public int Y
		{
			get => Position.Y;
			set => Position = new VectorInt(Position.X, value);
		}

		public int Width
		{
			get => Size.X;
			set => Size = new VectorInt(value, Size.Y);
		}

		public int Height
		{
			get => Size.Y;
			set => Size = new VectorInt(Size.X, value);
		}

		public int Left => X;

		public int Top => Y;

		public int Right => X + Width;

		public int Bottom => Y + Height;

		public Rectangle(VectorInt position, VectorInt size) => (Position, Size) = (position, size);

		public Rectangle(int x, int y, int width, int height)
			: this(new VectorInt(x, y), new VectorInt(width, height)) { }
	}
}
