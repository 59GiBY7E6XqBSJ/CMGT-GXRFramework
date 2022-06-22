using GXPEngine;

namespace GXPEngine.Framework
{
    public class GXRUIRect : GXRUIElement
    {
		// External GXP variables
		public EasyDraw rect;

		// Internal GXR variables
		protected private Colour _colour;

		protected private CenterMode _shapeAlignHorizontal;
		protected private CenterMode _shapeAlignVertical;

		public GXRUIRect(float x, float y, int width, int height,
			Colour colour = null,
			CenterMode alignH = CenterMode.Center,
			CenterMode alignV = CenterMode.Center) : base(x, y, width, height)
		{
			MyGame myGame = (MyGame)Game.main;
			if (myGame != null)
			{
				rect = new EasyDraw(width + 1, height + 1);

				rect.ShapeAlign(alignH, alignV);
				rect.SetOrigin(rect.width / 2, rect.height / 2);

				rect.StrokeWeight(0.0f);
				rect.Stroke(0, 0, 0, 0);

				if (colour != null)
				{
					rect.Fill(colour._r, colour._g, colour._b, colour._a);
				}
				else
				{
					rect.Fill(50, 50, 50);
				}

				rect.Rect(rect.width / 2, rect.height / 2, width, height);

				rect.SetXY(x, y);

				myGame.AddChild(rect);

				_colour = colour;

				_shapeAlignHorizontal = alignH;
				_shapeAlignVertical = alignV;
			}
		}

		public void SetRotation(float rotation)
		{
			MyGame myGame = (MyGame)Game.main;
			if (myGame != null)
			{
				if (rect != null)
				{
					rect.rotation = rotation;
				}
			}
		}

		public override void SetPosition(Vec2 position)
		{
			base.SetPosition(position);

			MyGame myGame = (MyGame)Game.main;
			if (myGame != null)
			{
				if (rect != null)
                {
					rect.SetXY(position.x, position.y);
				}
			}
		}

		public override void SetSize(int width, int height)
		{
			base.SetSize(width, height);

			MyGame myGame = (MyGame)Game.main;
			if (myGame != null)
			{
				if (rect != null)
				{
					myGame.Remove(rect);

					rect = new EasyDraw(width + 1, height + 1);

					rect.ShapeAlign(_shapeAlignHorizontal, _shapeAlignVertical);
					rect.SetOrigin(rect.width / 2, rect.height / 2);

					rect.StrokeWeight(0.0f);
					rect.Stroke(0, 0, 0, 0);

					if (_colour != null)
					{
						rect.Fill(_colour._r, _colour._g, _colour._b, _colour._a);
					}
					else
					{
						rect.Fill(50, 50, 50);
					}

					rect.Rect(rect.width / 2, rect.height / 2, width, height);

					rect.SetXY(position.x, position.y);

					myGame.AddChild(rect);
				}
			}
		}
	}
}
