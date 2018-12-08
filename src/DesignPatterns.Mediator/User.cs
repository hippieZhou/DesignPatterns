using System;

namespace DesignPatterns.Mediator
{
    public class User
    {
        private string name;
        public User(string name)
        {
            this.name = name;
        }
        internal object GetName()
        {
            return this.name;
        }

        public void SetName(string name)
        {
            this.name = name;
        }

        public void SendMessage(string message)
        {
            ChatRoom.ShowMessage(this, message);
        }
    }
}