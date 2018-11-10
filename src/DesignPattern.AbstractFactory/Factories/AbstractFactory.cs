using DesignPattern.AbstractFactory.Enums;
using DesignPattern.AbstractFactory.interfaces;

namespace DesignPattern.AbstractFactory.Factories
{
    public abstract class AbstractFactory
    {
        public abstract IColor GetColor(ColorType colorType);

        public abstract IShape GetShape(ShapeType shapeType);
    }
}
