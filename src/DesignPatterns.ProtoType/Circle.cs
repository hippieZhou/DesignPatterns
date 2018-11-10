using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPatterns.ProtoType
{
    public class Circle:Shape
    {
        public Circle() => type = "Circle";
        public override void Draw()
        {
            Console.WriteLine("I am a Circle");
        }
        public override object Clone()
        {
            Circle obj = new Circle();
            obj.type = type;
            obj.SetId(this.GetId());
            return obj;
        }
    }
}
