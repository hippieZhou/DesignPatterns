using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPatterns.Template
{
    public class Football : Game
    {
        public override void StartPlay()
        {
            Console.WriteLine("Football Game Started.Enjog the game");
        }

        public override void Initialize()
        {
            Console.WriteLine("Football Game Initialized.Start playing.");
        }

        public override void EndPlay()
        {
            Console.WriteLine("Football Game Finished.");
        }
    }
}
