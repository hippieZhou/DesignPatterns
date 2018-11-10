using System.Collections.Generic;
using System.Linq;


namespace DesignPatterns.ProtoType
{
    public class ShapeCache
    {
        private  static  HashSet<Shape> shapeMap = new HashSet<Shape>();

        public static Shape GetShape(string shapeId)
        {
            var cachedShape = shapeMap.FirstOrDefault(p => p.GetId() == shapeId);
            return (Shape) cachedShape?.Clone();
        }

        public static void LoadCache()
        {
            Circle circle = new Circle();
            circle.SetId("1");
            shapeMap.Add(circle);


            Square square = new Square();
            square.SetId("2");
            shapeMap.Add(square);

            Rectangle rectangle = new Rectangle();
            rectangle.SetId("3");
            shapeMap.Add(rectangle);
        }
    }
}
