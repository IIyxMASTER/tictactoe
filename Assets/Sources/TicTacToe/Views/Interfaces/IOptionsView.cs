using Sources.TicTacToe.UI.Views.Interfaces;
using UnityEngine;

namespace Sources.TicTacToe.Views.Interfaces
{
    public interface IOptionsView
    {
        void ShowView();
        void HideView();

        void ShowMainMenuPage();
        void ShowAvatarSelectionPage();
        void AddAvatar(IAvatarPrefabView avatar);

        void ApplyAvatarSettings();
        void ExitAvatarSetting();
        void ApplyMainMenuSettings();
        void ExitMainMenuSettings();
        
        void SelectAvatar(string id);

        void SetAvatar(Sprite avatar);
        void SetPlayerName(string name);
        void SetVolumeValue(float value);
    }
}