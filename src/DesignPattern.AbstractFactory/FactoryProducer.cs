using System;
using DesignPattern.AbstractFactory.Enums;
using DesignPattern.AbstractFactory.Factories;

namespace DesignPattern.AbstractFactory
{
    public class FactoryProducer
    {
        public static Factories.AbstractFactory GetFactory(ProducerType producerType)
        {
            switch (producerType)
            {
                case ProducerType.Shape:
                    return new ShapeFactory();
                case ProducerType.Color:
                    return new ColorFactory();
                default:
                    throw new ArgumentOutOfRangeException(nameof(producerType), producerType, null);
            }
        }
    }
}
