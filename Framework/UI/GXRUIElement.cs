using GXPEngine;

namespace GXPEngine.Framework
{
    public class GXRUIElement : GXRObject
    {
        // Internal GXR variables
        protected private int _width, _height;

        protected private string _text;

        public GXRUIElement(float x, float y, int width, int height)
        {
            position.x = x;
            position.y = y;

            _width = width;
            _height = height;
        }

        public virtual void SetSize(int width, int height)
        {
            _width = width;
            _height = height;
        }
    }
}
