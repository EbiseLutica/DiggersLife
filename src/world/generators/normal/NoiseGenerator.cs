using System;
using DotFeather;

namespace DiggersLife
{
	/// <summary>
	/// パーリンノイズの生成機能を提供します。
	/// </summary>
	public class NoiseGenerator
	{
		/// <summary>
		/// シード値を取得します。
		/// </summary>
		/// <value></value>
		public int Seed { get; private set; }

		/// <summary>
		/// 乱数生成器を取得します。
		/// </summary>
		public Random Random => random;

#pragma warning disable CS8618
		/// <summary>
		/// シード値を指定して、<see cref="NoiseGenerator"/> の新しいインスタンスを初期化します。
		/// </summary>
		/// <param name="seed">シード値。<see langword="null"/> であれば、現在の日時を用いて初期化します。</param>
		public NoiseGenerator(int? seed = null)
		{
			Randomize(seed);
		}

		/// <summary>
		/// ノイズジェネレーターを指定したシード値で初期化します。
		/// </summary>
		/// <param name="seed"></param>
		public void Randomize(int? seed = null)
		{
			Seed = seed ?? (int)(DateTime.Now.Ticks % int.MaxValue);
			random = new Random(Seed);
			randomTable = new Vector[randomTableSize];
			for (int i = 0; i < randomTableSize; i++)
			{
				randomTable[i] = random.NextVectorFloat() * 2.0f - Vector.One;
			}

			permX = new int[randomTableSize];
			permY = new int[randomTableSize];
			permZ = new int[randomTableSize];
			permW = new int[randomTableSize];
			for (int i = 0; i < randomTableSize; i++)
			{
				permX[i] = i;
				permY[i] = i;
				permZ[i] = i;
				permW[i] = i;
			}
			shuffle(permX);
			shuffle(permY);
			shuffle(permZ);
			shuffle(permW);
		}

		/// <summary>
		/// ノイズを生成します。
		/// </summary>
		/// <param name="x">X座標。</param>
		public float Generate(float x)
		{
			x = MathF.Abs(x);
			int xi = (int)x;
			float f = x - xi;

			float g0 = GetGradient(xi);
			float g1 = GetGradient(xi + 1);

			float p0 = f;
			float p1 = f - 1f;

			float v0 = g0 * p0;
			float v1 = g1 * p1;

			return DFMath.EaseInOut(f, v0, v1);
		}

		private void shuffle(int[] array)
		{
			int len = array.Length;
			for (int i = 0; i < len; i++)
			{
				int j = (int)((float)random.NextDouble() * len);
				int temp = array[i];
				array[i] = array[j];
				array[j] = temp;
			}
		}

		private float GetGradient(int x)
		{
			return randomTable[permX[x % randomTableSize]].X;
		}

		private int randomTableSize = 256;
		private Vector[] randomTable;
		private Random random;
		private int[] permX;
		private int[] permY;
		private int[] permZ;
		private int[] permW;
	}
}