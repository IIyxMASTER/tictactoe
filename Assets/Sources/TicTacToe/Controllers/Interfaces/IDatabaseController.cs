using UnityEngine;

namespace Sources.TicTacToe.Controllers.Interfaces
{
    public interface IDatabaseController
    {
        string PlayerAvatar { get; set; }
        event ChangeOptionValueEvent OnChangeAvatar;
        string PlayerName { get; set; }
        event ChangeOptionValueEvent OnChangeName;
        float SoundVolume { get; set; }
        event ChangeOptionValueEvent OnChangeSoundVolume;

        Sprite GetAvatar(string id);
    }
}