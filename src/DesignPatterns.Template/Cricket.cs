using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPatterns.Template
{
    public class Cricket : Game
    {
        public override void EndPlay()
        {
            Console.WriteLine("Cricket Game Finished");
        }

        public override void Initialize()
        {
            Console.WriteLine("Cricket Game Initialized!Start palying");
        }

        public override void StartPlay()
        {
            Console.WriteLine("Cricket Game Started.Enjoy the game");
        }
    }
}
