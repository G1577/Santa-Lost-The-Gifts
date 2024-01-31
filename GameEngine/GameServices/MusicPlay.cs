using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Windows.Media.Core;
using Windows.Media.MediaProperties;
using Windows.Media.Playback;

namespace GameEngine.GameServices
{
    public static class MusicPlay
    {
        public static MediaPlayer _mediaPlayer = new MediaPlayer();//נגן מוזיקה
        public static bool isOn { get; set; } = false;
        private static double _volume = 0.3; // the init value

        public static double Volume
        {
            set
            {
                _volume = value / 100;
                _mediaPlayer.Volume = _volume;
            }
            get
            {
                return _volume * 100;
            }
        }
        public static void Play(string reference)
        {
            if (!isOn)
            {
                _mediaPlayer.Source = MediaSource.CreateFromUri(new Uri($"ms-appx:///Assets/Music/{reference}"));
                _mediaPlayer.IsLoopingEnabled = true;
                _mediaPlayer.Play();
                isOn = true;
            }
        }

        public static void Pause()
        {
            _mediaPlayer.Pause();
            isOn = false;
        }
        public static void Resume()
        {
            _mediaPlayer.Play();
            isOn = true;
        }
        public static void ChangeVolume(double volume)
        {
            _mediaPlayer.Volume = volume / 100;
        }
    }
}
