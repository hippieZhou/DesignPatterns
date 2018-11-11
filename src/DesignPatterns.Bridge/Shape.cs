using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPatterns.Bridge
{
    public abstract class Shape
    {
        protected IDrawAPI drawAPI;

        protected Shape(IDrawAPI drawAPI) => this.drawAPI = drawAPI;

        public abstract void Draw();
    }
}
