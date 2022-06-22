using System;

namespace GXPEngine.Framework
{
    public class Colour
    {
        public Int16 _r, _g, _b, _a;

        public Colour(Int16 r, Int16 g, Int16 b, Int16 a = 255)
        {
            _r = r;
            _g = g;
            _b = b;
            _a = a;
        }

        public void SetColour(Int16 r, Int16 g, Int16 b, Int16 a = 255)
        {
            _r = r;
            _g = g;
            _b = b;
            _a = a;
        }

        public Colour GetColour()
        {
            return this;
        }

        public int GetR()
        {
            return _r;
        }

        public int GetG()
        {
            return _g;
        }

        public int GetB()
        {
            return _b;
        }

        public int GetA()
        {
            return _a;
        }

		public float Hue()
	    {
	    	if (_r == _g && _g == _b)
	    	{
	    		return 0.0f;
	    	}
    
	    	float r = _r / 255.0f;
	    	float g = _g / 255.0f;
	    	float b = _b / 255.0f;
    
	    	float max = r > g ? r : g > b ? g : b,
	    		  min = r < g ? r : g < b ? g : b;
	    	float delta = max - min;
	    	float hue = 0.0f;
    
	    	if (r == max)
	    	{
	    		hue = (g - b) / delta;
	    	}
	    	else if (g == max)
	    	{
	    		hue = 2 + (b - r) / delta;
	    	}
	    	else if (b == max)
	    	{
	    		hue = 4 + (r - g) / delta;
	    	}
	    	hue *= 60;
    
	    	if (hue < 0.0f)
	    	{
	    		hue += 360.0f;
	    	}

	    	return hue;
	    }

		public float Saturation()
	    {
	    	float r = _r / 255.0f;
	    	float g = _g / 255.0f;
	    	float b = _b / 255.0f;
    
	    	float max = r > g ? r : g > b ? g : b,
	    		  min = r < g ? r : g < b ? g : b;
	    	float l, s = 0;
    
	    	if (max != min)
	    	{
	    		l = (max + min) / 2;
	    		if (l <= 0.5f)
	    			s = (max - min) / (max + min);
	    		else
	    			s = (max - min) / (2 - max - min);
	    	}

	    	return s;
	    }
    
	    public float Brightness()
	    {
	    	float r = _r / 255.0f;
	    	float g = _g / 255.0f;
	    	float b = _b / 255.0f;
    
	    	float max = r > g ? r : g > b ? g : b,
	    		  min = r < g ? r : g < b ? g : b;

	    	return (max + min) / 2;
	    }
    }
}
