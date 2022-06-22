using GXPEngine;
using GXPEngine.Core;

using System.Collections.Generic;

namespace GXPEngine.Framework
{
    public class GXRObject : GameObject
    {
        public static List<GXRObject> _objects = new List<GXRObject>();

        public GXRObject()
        {
            _objects.Add(this);
        }

        ~GXRObject()
        {
            _objects.Remove(this);
        }

        /**
		 * Updates the object.
		*/
        public virtual void Update()
        {

        }

        public virtual void SetPosition(Vec2 position)
        {
            x = position.x;
            y = position.y;
        }

        public virtual Vec2 GetPosition()
        {
            return position;
        }

        public virtual void ForceRemove()
        {

        }
    }
}
