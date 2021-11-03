using System.Linq;
using System.Runtime.InteropServices;
using Sources.TicTacToe.Controllers.Interfaces;
using Sources.TicTacToe.Options;
using UnityEngine;

#pragma warning disable 0649

namespace Sources.TicTacToe.Controllers
{
    public delegate void ChangeOptionValueEvent();

    public class DatabaseController : IDatabaseController
    {
        

        public void Initialize()
        {
            PlayerAvatar = new StringOptionParam("PlayerAvatar");
            PlayerName = new StringOptionParam("PlayerName");
            PlayerScores = new IntOptionParam("PlayerScores");
            SoundVolume = new FloatOptionParam("GameSoundVolume");
            PlayerVictories = new IntOptionParam("PlayerVictories");
        }


        public StringOptionParam PlayerAvatar { get; set; }


        public StringOptionParam PlayerName { get; set; }
        public FloatOptionParam SoundVolume { get; set; }
        public IntOptionParam PlayerScores { get; set; }
        public IntOptionParam PlayerVictories { get; set; }

        public Sprite GetAvatar(string id)
        {
            var sprite = Resources.Load<Sprite>($"Avatars/{id}");
            return sprite;
        }

        public Sprite GetPlayerAvatar()
        {
            return GetAvatar(PlayerAvatar.Value);
        }
    }
}