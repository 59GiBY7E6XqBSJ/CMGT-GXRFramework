using GXPEngine;

namespace GXPEngine.Framework
{
	public class GXRUIButton : GXRUIElement
	{
		// External GXP variables
		protected EasyDraw button;

		protected EasyDraw buttonText;

		// Internal GXR variables
		protected private bool hasPlayed;

		protected private Colour _colour;
		protected private Colour _textColour;

		private string _font;
		private int _fontSize;

		protected private CenterMode _shapeAlignHorizontal;
		protected private CenterMode _shapeAlignVertical;

		protected private CenterMode _textAlignHorizontal;
		protected private CenterMode _textAlignVertical;

		public GXRUIButton(float x, float y, int width, int height, string text,
			Colour colour = null,
			Colour textColour = null,
			string font = "",
			int fontSize = 16,
			CenterMode alignH = CenterMode.Center,
			CenterMode alignV = CenterMode.Center,
			CenterMode textAlignH = CenterMode.Center,
			CenterMode textAlignV = CenterMode.Center) : base(x, y, width, height)
		{
			MyGame myGame = (MyGame)Game.main;
			if (myGame != null)
			{
				button = new EasyDraw(width + 1, height + 1);

				button.ShapeAlign(alignH, alignV);
				button.SetOrigin(button.width / 2, button.height / 2);

				button.StrokeWeight(0.0f);
				button.Stroke(0, 0, 0, 0);

				if (colour != null)
				{
					button.Fill(colour._r, colour._g, colour._b, colour._a);
				}
				else
				{
					button.Fill(50, 50, 50);
				}

				button.Rect(button.width / 2, button.height / 2, width, height);

				button.SetXY(x, y);

				myGame.AddChild(button);

				buttonText = new EasyDraw(width + 1, height + 1);

				buttonText.TextAlign(textAlignV, textAlignH);
				buttonText.SetOrigin(buttonText.width / 2, buttonText.height / 2);

				buttonText.TextSize(8);

				if (textColour != null)
				{
					buttonText.Fill(textColour._r, textColour._g, textColour._b, textColour._a);
				}
				else
				{
					buttonText.Fill(255, 255, 255);
				}

				if (font != "")
				{
					System.Drawing.Font testFont = Utils.LoadFont(font, fontSize);

					buttonText.TextFont(testFont);
				}

				buttonText.Text(text);

				buttonText.SetXY(0, 1);

				button.AddChild(buttonText);

				_text = text;

				_colour = colour;
				_textColour = textColour;

				_font = font;
				_fontSize = fontSize;

				_shapeAlignHorizontal = alignH;
				_shapeAlignVertical = alignV;
				_textAlignVertical = textAlignV;
				_textAlignHorizontal = textAlignH;
			}
		}

		/**
		 * Determines whether the button is pressed or not.
		 *
		 * @return true or false boolean depending on if the button is pressed or not.
		*/
		public bool IsPressed()
		{
			MyGame myGame = (MyGame)Game.main;
			if (myGame != null)
			{

			}

			return false;
		}

		public override void SetPosition(Vec2 position)
		{
			base.SetPosition(position);

			MyGame myGame = (MyGame)Game.main;
			if (myGame != null)
			{
				if (button != null)
				{
					button.SetXY(position.x, position.y);
				}
			}
		}

		public override void SetSize(int width, int height)
		{
			base.SetSize(width, height);

			MyGame myGame = (MyGame)Game.main;
			if (myGame != null)
			{
				if (button != null)
				{
					if (buttonText != null)
                    {
						button.RemoveChild(buttonText);
					}

					myGame.Remove(button);

					button = new EasyDraw(width + 1, height + 1);

					button.ShapeAlign(_shapeAlignHorizontal, _shapeAlignVertical);
					button.SetOrigin(button.width / 2, button.height / 2);

					button.StrokeWeight(0.0f);
					button.Stroke(0, 0, 0, 0);

					if (_colour != null)
					{
						button.Fill(_colour._r, _colour._g, _colour._b, _colour._a);
					}
					else
					{
						button.Fill(50, 50, 50);
					}

					button.Rect(button.width / 2, button.height / 2, width, height);

					button.SetXY(position.x, position.y);

					myGame.AddChild(button);

					buttonText = new EasyDraw(width + 1, height + 1);

					buttonText.TextAlign(_textAlignVertical, _textAlignHorizontal);
					buttonText.SetOrigin(buttonText.width / 2, buttonText.height / 2);

					buttonText.TextSize(8);

					if (_textColour != null)
					{
						buttonText.Fill(_textColour._r, _textColour._g, _textColour._b, _textColour._a);
					}
					else
					{
						buttonText.Fill(255, 255, 255);
					}

					if (_font != "")
					{
						System.Drawing.Font testFont = Utils.LoadFont(_font, _fontSize);

						buttonText.TextFont(testFont);
					}

					buttonText.Text(_text);

					buttonText.SetXY(0, 1);

					button.AddChild(buttonText);
				}
			}
		}
	}
}
