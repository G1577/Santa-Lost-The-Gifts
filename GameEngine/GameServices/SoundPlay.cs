using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Media.Core;
using Windows.Media.Playback;

namespace GameEngine.GameServices
{
    public static class SoundPlay
    {
        public static MediaPlayer _mediaPlayer = new MediaPlayer();//נגן מוזיקה
        public static bool IsOn { get; set; } = true;
        private static double _volume = 0.1;

        public static void Play(string reference)
        {
            if (IsOn)
            {
                _mediaPlayer.Source = MediaSource.CreateFromUri(new Uri($"ms-appx:///Assets/Sounds/{reference}"));
                _mediaPlayer.Volume = _volume;
                _mediaPlayer.Play();
            }
        }
        public static void Pause()
        {
            _mediaPlayer.Pause();
            IsOn = false;
        }
    }
}
