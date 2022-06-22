using GXPEngine;

namespace GXPEngine.Framework
{
    public class GXRUIText : GXRUIElement
    {
        // External GXP variables
        protected EasyDraw label;

        // Internal GXR variables
        protected private Colour _colour;

        private string _font;
        private int _fontSize;

        protected private CenterMode _textAlignHorizontal;
        protected private CenterMode _textAlignVertical;

        public GXRUIText(float x, float y, int width, int height, string text,
            Colour colour = null,
            string font = "",
            int fontSize = 16,
            CenterMode textAlignH = CenterMode.Center,
            CenterMode textAlignV = CenterMode.Center) : base(x, y, width, height)
        {
            MyGame myGame = (MyGame)Game.main;
            if (myGame != null)
            {
                //! Text
                label = new EasyDraw(width + 1, height + 1);

                label.TextAlign(textAlignV, textAlignH);
                label.SetOrigin(label.width / 2, label.height / 2);

                label.TextSize(8);

                if (colour != null)
                {
                    label.Fill(colour._r, colour._g, colour._b, colour._a);
                }
                else
                {
                    label.Fill(255, 255, 255);
                }

                if (font != "")
                {
                    System.Drawing.Font testFont = Utils.LoadFont(font, fontSize);

                    label.TextFont(testFont);
                }

                label.Text(text);

                label.SetXY(x, y);

                myGame.AddChild(label);

                _text = text;

                _colour = colour;

                _font = font;
                _fontSize = fontSize;

                _textAlignVertical = textAlignV;
                _textAlignHorizontal = textAlignH;
            }
        }

        public override void SetPosition(Vec2 position)
        {
            base.SetPosition(position);

            MyGame myGame = (MyGame)Game.main;
            if (myGame != null)
            {
                if (label != null)
                {
                    label.SetXY(position.x, position.y);
                }
            }
        }

        public override void SetSize(int width, int height)
        {
            base.SetSize(width, height);

            MyGame myGame = (MyGame)Game.main;
            if (myGame != null)
            {
                if (label != null)
                {
                    myGame.Remove(label);

                    label = new EasyDraw(width + 1, height + 1);

                    label.TextAlign(_textAlignVertical, _textAlignHorizontal);
                    label.SetOrigin(label.width / 2, label.height / 2);

                    label.TextSize(8);

                    if (_colour != null)
                    {
                        label.Fill(_colour._r, _colour._g, _colour._b, _colour._a);
                    }
                    else
                    {
                        label.Fill(255, 255, 255);
                    }

                    if (_font != "")
                    {
                        System.Drawing.Font testFont = Utils.LoadFont(_font, _fontSize);

                        label.TextFont(testFont);
                    }

                    label.Text(_text);

                    label.SetXY(position.x, position.y);

                    myGame.AddChild(label);
                }
            }
        }

        public void SetText(string text)
        {
            MyGame myGame = (MyGame)Game.main;
            if (myGame != null)
            {
                if (label != null)
                {
                    label.Remove();

                    myGame.Remove(label);

                    label = new EasyDraw((int)_width + 1, (int)_height + 1);

                    label.TextAlign(_textAlignVertical, _textAlignHorizontal);
                    label.SetOrigin(label.width / 2, label.height / 2);

                    label.TextSize(8);

                    if (_colour != null)
                    {
                        label.Fill(_colour._r, _colour._g, _colour._b, _colour._a);
                    }
                    else
                    {
                        label.Fill(255, 255, 255);
                    }

                    if (_font != "")
                    {
                        System.Drawing.Font testFont = Utils.LoadFont(_font, _fontSize);

                        label.TextFont(testFont);
                    }

                    label.Text(text);

                    label.SetXY(position.x, position.y);

                    myGame.AddChild(label);
                }
            }
        }

        public override void ForceRemove()
        {
            this.label.Remove();

            MyGame myGame = (MyGame)Game.main;
            if (myGame != null)
            {
                myGame.Remove(label);
            }

            this.Remove();
        }
    }
}
