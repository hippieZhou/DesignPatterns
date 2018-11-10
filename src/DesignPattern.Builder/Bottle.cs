using System;
using System.Collections.Generic;
using System.Text;
using DesignPattern.Builder.Interfaces;

namespace DesignPattern.Builder
{
    class Bottle:IPacking
    {
        public string Pack() => "Bottle";
    }
}
