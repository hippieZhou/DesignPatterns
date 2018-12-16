using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace DesignPatterns.State
{
    public class StartState : IState
    {
        public void DoAction(Context context)
        {
            Console.WriteLine("Player is in start state");
            context.SetState(this);
        }

        public override string ToString()
        {
            return "Start State";
        }
    }
}
