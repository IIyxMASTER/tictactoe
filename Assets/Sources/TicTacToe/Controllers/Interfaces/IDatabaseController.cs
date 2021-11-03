using Sources.TicTacToe.Options;
using UnityEngine;

namespace Sources.TicTacToe.Controllers.Interfaces
{
    public interface IDatabaseController
    {
        void Initialize();
        StringOptionParam PlayerAvatar { get; set; }
        StringOptionParam PlayerName { get; set; }
        FloatOptionParam SoundVolume { get; set; }
        IntOptionParam PlayerScores { get; set; }
        IntOptionParam PlayerVictories { get; set; }
        Sprite GetAvatar(string id);
        Sprite GetPlayerAvatar();
    }
}