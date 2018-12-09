using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPatterns.Observer
{
    public class Subject
    {
        private List<Observer> observers = new List<Observer>();

        private int state;
        public int GetState() => this.state;

        public void SetState(int state)
        {
            this.state = state;
            NitifyAllObservers();
        }

        public void Attach(Observer observer)
        {
            observers.Add(observer);
        }

        private void NitifyAllObservers()
        {
            foreach (var observer in observers)
            {
                observer.Update();
            }
        }
    }
}
