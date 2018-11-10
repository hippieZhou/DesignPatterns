using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPatterns.ProtoType
{
    public class Square:Shape
    {
        public Square() => type = "Square";
        public override void Draw()
        {
            Console.WriteLine("I am a Square");
        }
        public override object Clone()
        {
            Square obj = new Square();
            obj.type = type;
            obj.SetId(this.GetId());
            return obj;
        }
    }
}
