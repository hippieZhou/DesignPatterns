using System;
using System.Collections.Generic;
using System.Text;
using DesignPattern.Builder.Interfaces;

namespace DesignPattern.Builder
{
    public abstract class Burger:IItem
    {
        public abstract string Name();

        public IPacking Packing()
        {
            return  new Wrapper();
        }

        public abstract float Price();
    }
}
