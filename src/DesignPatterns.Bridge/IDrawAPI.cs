using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPatterns.Bridge
{
    public interface IDrawAPI
    {
        void DrawCircle(int radius, int x, int y);
    }
}
