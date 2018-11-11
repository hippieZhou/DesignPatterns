> 见名知其意，适配器可用于对多个不兼容接口提供适配桥梁

## 介绍

适配器模式属于结构型模式。在现实世界中，这个模式适用的较为广泛，比如 DIY 一些电子产品，主要元器件提供的是标准接口，那么无论我们购买什么品牌的元器件，最终都能组装起来正常运行。

## 类图描述

![](https://img2018.cnblogs.com/blog/749711/201811/749711-20181111151958480-2013878598.png)

由上图可知，我们通过定义  **IAdvancedMediaPlayer** 接口来约束 **Mp4Player** 和 **VlcPlayer** 的播放行为。然后定义一个 适配器 **MediaAdapter** 来管理创建具体的某种类型的播放。**AudioPlayer** 为已支持的播放类型，然后在其内部通过调用适配器达到支持扩展类型的播放功能。

## 代码实现

1、定义扩展接口和受支持的类型

```C#
public interface IAdvancedMediaPlayer
{
    void PlayVlc(string fileNmae);
    void PlayMp4(string fileNmae);
}

public enum AudioType
{
    MP3,
    VLC,
    MP4,
    Unknown
}
```

2、定义具体类型的播放类

```C#
public class Mp4Player:IAdvancedMediaPlayer
{
    public void PlayVlc(string fileNmae)
    {
    }

    public void PlayMp4(string fileNmae)
    {
        Console.WriteLine($"Playing mp4 file.Name:{fileNmae}");
    }
}

public class VlcPlayer:IAdvancedMediaPlayer
{
    public void PlayVlc(string fileNmae)
    {
        Console.WriteLine($"Playing vlc file.Name:{fileNmae}");
    }

    public void PlayMp4(string fileNmae)
    {
    }
}
```

3、定义适配器

```C#
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
```

4、使用适配器

```C#
public  interface IMediaPlayer
{
    void Play(AudioType audioType, string fileName);
}

public class AudioPlayer:IMediaPlayer
{
    private IMediaPlayer mediaAdapter;
    public void Play(AudioType audioType, string fileName)
    {
        switch (audioType)
        {
            case AudioType.MP3:
                Console.WriteLine($"Playing mp3 file. Name:{fileName}");
                break;
            case AudioType.VLC:
            case AudioType.MP4:
                mediaAdapter = new MediaAdapter(audioType);
                mediaAdapter.Play(audioType, fileName);
                break;
            default:
                Console.WriteLine($"Invalid media.{audioType} format not supported");
                break;
        }
    }
}
```

5、上层调用

```C#
class Program
{
    static void Main(string[] args)
    {
        IMediaPlayer audioPlayer = new AudioPlayer();
        audioPlayer.Play(AudioType.MP3, "beyond the horizon.mp3");
        audioPlayer.Play(AudioType.MP4, "alone.mp4");
        audioPlayer.Play(AudioType.VLC, "far far away.vlc");
        audioPlayer.Play(AudioType.Unknown, "mind me.avi");

        Console.ReadKey();
    }
}
```

## 总结

适配器的使用一般是在已有的业务逻辑上进行扩展而来的，可以将任何没有关联的类联系起来，提高了代码的复用。但是在一个系统要从全局出发，不能过多的使用，否则会使系统非常混乱。