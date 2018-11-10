using System;
using DesignPattern.AbstractFactory.Colors;
using DesignPattern.AbstractFactory.Enums;
using DesignPattern.AbstractFactory.interfaces;

namespace DesignPattern.AbstractFactory.Factories
{
    public class ColorFactory:AbstractFactory
    {
        public override IColor GetColor(ColorType colorType)
        {
            IColor color = null;
            switch (colorType)
            {
                case ColorType.Blue:
                    color= new Blue();
                    break;
                case ColorType.Green:
                    color =new Green();
                    break;
                case ColorType.Red:
                    color = new Red();
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(colorType), colorType, null);
            }

            return color;
        }

        public override IShape GetShape(ShapeType shapeType)
        {
            return null;
        }
    }
}
