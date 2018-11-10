using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPatterns.ProtoType
{
    public abstract class Shape : ICloneable
    {
        private string id;
        protected string type;
        public abstract void Draw();

        public string GetId() => id;
        public string GetType() => type;

        public void SetId(string id) => this.id = id;

        public new object MemberwiseClone() => base.MemberwiseClone();
        public abstract object Clone();
    }
}
