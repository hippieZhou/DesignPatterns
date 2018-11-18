using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPatterns.Decorator
{
    public class RedShapleDecorator : ShapeDecorator
    {
        public RedShapleDecorator(IShape decoratedShape) : base(decoratedShape)
        {
        }

        public override void Draw()
        {
            this.decoratedShape.Draw();
            setRedBorder(this.decoratedShape);
        }

        private void setRedBorder(IShape decoratedShape)
        {
            Console.WriteLine("Border Color:Red");
        }
    }
}
