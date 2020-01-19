using System;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using DotFeather;

namespace DiggersLife
{
	public class MainScene : Scene
	{
		public override void OnStart(Router router, GameBase game, System.Collections.Generic.Dictionary<string, object> args)
		{
			g = new Graphic();
			BackgroundColor = Color.DeepSkyBlue;
			noise = new NoiseGenerator();
			Render(game);

			Root.Add(g);
		}

		private void Render(GameBase game)
		{
			var pv = 0f;
			var root = game.Height - 128;
			g.Clear();
			Enumerable
				.Range(0, game.Width)
				.Select(v => noise.Generate(v / x) * y)
				.Select((v, i) => (v, i))
				.ToList()
				.ForEach(vi =>
				{
					var (v, i) = vi;
					if (v < 0)
					{
						// Draw water
						g.Rect(i, root, i + 1, root - (int)pv, Color.Blue);
					}
					else
					{
						// Draw grass
						g.Pixel(i, root - (int)pv - 1, Color.GreenYellow);
					}
					// Draw land
					g.Rect(i, root - (int)pv, i + 1, root - (int)pv + 6, Color.Chocolate);
					g.Rect(i, root - (int)pv + 6, i + 1, game.Height, Color.Gray);
					pv = v;
				});
		}

		public override void OnUpdate(Router router, GameBase game, DFEventArgs e)
		{
			if (DFKeyboard.Up.IsKeyDown)
			{
				y += 8;
				Render(game);
			}
			if (DFKeyboard.Down.IsKeyDown)
			{
				y -= 8;
				Render(game);
			}
			if (DFKeyboard.Left.IsKeyDown)
			{
				x /= 2;
				Render(game);
			}
			if (DFKeyboard.Right.IsKeyDown)
			{
				x *= 2;
				Render(game);
			}
			if (DFKeyboard.Space.IsKeyDown)
			{
				noise.Randomize();
				Render(game);
			}
		}

		private Graphic g;
		private float x = 16f, y = 64;
		private NoiseGenerator noise;
	}
}