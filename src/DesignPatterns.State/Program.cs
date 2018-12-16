using System;

namespace DesignPatterns.State
{
    class Program
    {
        static void Main(string[] args)
        {
            Context context = new Context();
            IState startState = new StartState();
            startState.DoAction(context);

            Console.WriteLine(context.GetState().ToString());

            IState stopState = new StopState();
            stopState.DoAction(context);
            Console.WriteLine(context.GetState().ToString());

            Console.ReadKey();
        }
    }
}
