using System;

namespace DesignPatterns.ProtoType
{
    public class Rectangle:Shape
    {
        public Rectangle() => type = "Rectangle";
        public override void Draw()
        {

            Console.WriteLine("I am a Rectangle");
        }
        public override object Clone()
        {
            Rectangle obj = new Rectangle();
            obj.type = type;
            obj.SetId(this.GetId());
            return obj;

        }
    }
}
