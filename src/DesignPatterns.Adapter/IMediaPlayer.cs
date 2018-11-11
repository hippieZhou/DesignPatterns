using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPatterns.Adapter
{
    public  interface IMediaPlayer
    {
        void Play(AudioType audioType, string fileName);
    }
}
