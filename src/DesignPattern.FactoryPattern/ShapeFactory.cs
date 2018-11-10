using System;
using System.Collections.Generic;
using System.Text;
using DesignPattern.FactoryPattern;

namespace DesignPattern.FactoryPattern
{
    public enum ShapeType
    {
        Circle,
        Rectangle,
        Square,
    }

    public class ShapeFactory
    {
        public IShape GetShape(ShapeType shapeType)
        {
            IShape shape = null;
            switch (shapeType)
            {
                case ShapeType.Circle:
                    shape = new Circle();
                    break;
                case ShapeType.Rectangle:
                    shape  = new Rectangle();
                    break;
                case ShapeType.Square:
                    shape = new Square();
                    break;
            }
            return shape;
        }
    }
}
