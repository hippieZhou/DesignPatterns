using DesignPattern.Builder.Interfaces;

namespace DesignPattern.Builder
{
    public abstract class ColdDrink:IItem
    {
        public abstract string Name();

        public IPacking Packing()
        {
            return  new Bottle();
        }

        public abstract float Price();
    }
}
