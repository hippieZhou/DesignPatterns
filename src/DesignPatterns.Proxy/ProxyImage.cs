using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPatterns.Proxy
{
    public class ProxyImage : IImage
    {
        private RealImage realImage;
        private string fileName;
        public ProxyImage(string fileName)
        {
            this.fileName = fileName;
        }

        public void Display()
        {
            if (realImage == null)
            {
                realImage = new RealImage(fileName);
            }
            realImage.Display();
        }
    }
}
