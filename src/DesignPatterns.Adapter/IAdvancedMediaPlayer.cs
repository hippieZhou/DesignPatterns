using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPatterns.Adapter
{
    public interface IAdvancedMediaPlayer
    {
        void PlayVlc(string fileNmae);
        void PlayMp4(string fileNmae);
    }
}
