namespace DesignPattern.Builder.Interfaces
{
    public interface IItem
    {
        string Name();
         IPacking Packing();
        float Price();
    }
}
