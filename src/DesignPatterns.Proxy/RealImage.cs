using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPatterns.Proxy
{
    public class RealImage : IImage
    {
        private string fileName;
        public RealImage(string fileName)
        {
            this.fileName = fileName;
            LoadFromDisk();
        }

        public void Display() => Console.WriteLine($"Displaying:{fileName}");
        private void LoadFromDisk() => Console.WriteLine($"Loading:{fileName}");
    }
}
