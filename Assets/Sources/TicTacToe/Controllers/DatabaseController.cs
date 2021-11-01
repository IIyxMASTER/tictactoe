using System.Runtime.InteropServices;
using Sources.TicTacToe.Controllers.Interfaces;
using UnityEngine;

namespace Sources.TicTacToe.Controllers
{
    public delegate void ChangeOptionValueEvent();

    public class DatabaseController : IDatabaseController
    {
        class Options
        {
            public const string PlayerName = "PlayerName";
            public const string PlayerAvatar = "PlayerAvatar";
            public const string SoundVolume = "SoundVolume";
        }

        public string PlayerAvatar
        {
            get => PlayerPrefs.GetString(Options.PlayerAvatar);
            set
            {
                Debug.Log(value);
                PlayerPrefs.SetString(Options.PlayerAvatar, value);
                OnChangeAvatar?.Invoke();
            }
        }

        
        public string PlayerName
        {
            get => PlayerPrefs.GetString(Options.PlayerName);
            set
            {
                Debug.Log(value);
                PlayerPrefs.SetString(Options.PlayerName,value);
                OnChangeName?.Invoke();
            }
        }

        public float SoundVolume
        {
            get => PlayerPrefs.GetFloat(Options.SoundVolume);
            set
            {
                Debug.Log(value);
                PlayerPrefs.SetFloat(Options.SoundVolume, value);
                OnChangeSoundVolume?.Invoke();
            }
        }

        public event ChangeOptionValueEvent OnChangeName;
        public event ChangeOptionValueEvent OnChangeSoundVolume;
        public Sprite GetAvatar(string id)
        {
            var sprite = Resources.Load<Sprite>($"Avatars/{id}");
            return sprite;
        }

        public event ChangeOptionValueEvent OnChangeAvatar;
    }
}