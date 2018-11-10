using System;
using DesignPattern.AbstractFactory.Enums;
using DesignPattern.AbstractFactory.interfaces;
using DesignPattern.AbstractFactory.Shapes;

namespace DesignPattern.AbstractFactory.Factories
{
    public class ShapeFactory:AbstractFactory
    {
        public override IColor GetColor(ColorType colorType)
        {
            return null;
        }

        public override IShape GetShape(ShapeType shapeType)
        {
            IShape shape = null;
            switch (shapeType)
            {
                case ShapeType.Circle:
                    shape = new Circle();
                    break;
                case ShapeType.Rectangle:
                    shape = new Rectangle();
                    break;
                case ShapeType.Square:
                    shape = new Square();
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(shapeType), shapeType, null);
            }
            return shape;
        }
    }
}
