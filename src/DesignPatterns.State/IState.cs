using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPatterns.State
{
    public interface IState
    {
        void DoAction(Context context);
    }
}
