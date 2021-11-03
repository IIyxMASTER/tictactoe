using Sources.TicTacToe.Controllers.Interfaces;
using Sources.TicTacToe.UI.Controllers.Interfaces;
using Sources.TicTacToe.UI.Views;
using Sources.TicTacToe.Views.Interfaces;
using UnityEngine;
using Zenject;

#pragma warning disable 0649

namespace Sources.TicTacToe.UI.Controllers
{
    public class OptionsController : IOptionsUIController
    {
        [Inject] private IOptionsView _optionsView;
        [Inject] private AvatarViewFactory _avatarViewFactory;

        [Inject] private IDatabaseController _database;
        [Inject] private IMessageBoxController _messageBoxController;

        public void ShowView()
        {
            if (_database.PlayerAvatar.Value != "")
            {
                DatabaseOnOnChangeAvatar();
            }

            DatabaseOnOnChangeSoundVolume();
            DatabaseOnOnChangeName();
            _optionsView.ShowView();
        }

        private void DatabaseOnOnChangeSoundVolume()
        {
            Volume = _database.SoundVolume.Value;
            _optionsView.SetVolumeValue(Volume);
        }

        private void DatabaseOnOnChangeName()
        {
            PlayerName = _database.PlayerName.Value;
            _optionsView.SetPlayerName(PlayerName);
        }

        private void DatabaseOnOnChangeAvatar()
        {
            PlayerAvatar = _database.PlayerAvatar.Value;
            var sprite = _database.GetAvatar(PlayerAvatar);
            _optionsView.SetAvatar(sprite);
        }

        public void HideView()
        {
            _optionsView.HideView();
        }

        public void LoadAvatars()
        {
            var sprites = Resources.LoadAll<Sprite>("Avatars");
            foreach (var sprite in sprites)
            {
                var avatar = _avatarViewFactory.Create();
                avatar.SetSprite(sprite, sprite.name);
                _optionsView.AddAvatar(avatar);
            }
        }

        public void ApplySettings()
        {
            _messageBoxController.ShowYesNoBox("Вы хотите сохранить настройки?",
                () =>
                {
                    _database.PlayerAvatar.Value = PlayerAvatar;
                    _database.PlayerName.Value = PlayerName;
                    _database.SoundVolume.Value = Volume;
                    
                    _messageBoxController.ShowInfoBox("Настройки сохранены!", "Ок", () =>
                    {
                        _optionsView.HideView();
                        _messageBoxController.HideView();
                    });
                },
                () => { });
        }

        public void ApplyAvatar()
        {
            var sprite = _database.GetAvatar(PlayerAvatar);
            _optionsView.SetAvatar(sprite);
            _optionsView.ShowMainMenuPage();
        }

        public string PlayerName { get; set; }
        public float Volume { get; set; }
        public string PlayerAvatar { get; set; }
    }
}