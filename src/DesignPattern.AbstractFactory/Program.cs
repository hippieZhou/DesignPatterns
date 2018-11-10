using System;
using DesignPattern.AbstractFactory.Enums;
using DesignPattern.AbstractFactory.interfaces;

namespace DesignPattern.AbstractFactory
{
    class Program
    {
        static void Main(string[] args)
        {
            Factories.AbstractFactory shapeFactory = FactoryProducer.GetFactory(ProducerType.Shape);
            IShape shape = shapeFactory.GetShape(ShapeType.Circle);
            shape.Draw();

            Factories.AbstractFactory colorFactory = FactoryProducer.GetFactory(ProducerType.Color);
            IColor color = colorFactory.GetColor(ColorType.Red);
            color.Fill();

            Console.ReadKey();
        }
    }
}
