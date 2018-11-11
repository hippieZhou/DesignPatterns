using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace DesignPatterns.Adapter
{
    public class MediaAdapter:IMediaPlayer
    {
        private IAdvancedMediaPlayer advancedMediaPlayer;

        public MediaAdapter(AudioType audioType)
        {
            switch (audioType)
            {
                case AudioType.VLC:
                    advancedMediaPlayer = new VlcPlayer();
                    break;
                case AudioType.MP4:
                    advancedMediaPlayer = new Mp4Player();
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(audioType), audioType, null);
            }
        }

        public void Play(AudioType audioType, string fileName)
        {
            switch (audioType)
            {
                case AudioType.VLC:
                    advancedMediaPlayer.PlayVlc(fileName);
                    break;
                case AudioType.MP4:
                    advancedMediaPlayer.PlayMp4(fileName);
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(audioType), audioType, null);
            }
        }
    }
}
