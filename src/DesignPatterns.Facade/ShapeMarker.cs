using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPatterns.Facade
{
    public class ShapeMarker
    {
        private IShape circle;
        private IShape rectangle;
        private IShape square;

        public ShapeMarker()
        {
            circle = new Circle();
            rectangle = new Rectangle();
            square = new Square();
        }

        public void DrawCircle() => circle.Draw();
        public void DrawRectangle() => rectangle.Draw();
        public void DrawSquare() => square.Draw();
    }
}
