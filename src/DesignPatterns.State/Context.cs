using System;

namespace DesignPatterns.State
{
    public class Context
    {
        private static IState state;

        public void SetState(IState state) => Context.state = state;

        public IState GetState() => state;
    }
}