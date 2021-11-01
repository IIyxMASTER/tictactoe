using Sources.TicTacToe.Controllers.Interfaces;
using Sources.TicTacToe.UI.Controllers.Interfaces;
using Sources.TicTacToe.UI.Views;
using Sources.TicTacToe.Views.Interfaces;
using UnityEngine;
using Zenject;
using Zenject.ReflectionBaking.Mono.Cecil;

namespace Sources.TicTacToe.UI.Controllers
{
    public class OptionsController : IOptionsUIController
    {
        [Inject] private IOptionsView _optionsView;
        [Inject] private AvatarViewFactory _avatarViewFactory;
        [Inject] private IDatabaseController _database;
        
        public void ShowView()
        {
            if (_database.PlayerAvatar != "")
            {
                DatabaseOnOnChangeAvatar();
            }

            DatabaseOnOnChangeSoundVolume();
            DatabaseOnOnChangeName();
            _optionsView.ShowView();
        }

        private void DatabaseOnOnChangeSoundVolume()
        {
            Volume = _database.SoundVolume;
            _optionsView.SetVolumeValue(Volume);
        }

        private void DatabaseOnOnChangeName()
        {
            PlayerName = _database.PlayerName;
            _optionsView.SetPlayerName(PlayerName);
        }

        private void DatabaseOnOnChangeAvatar()
        {
            PlayerAvatar = _database.PlayerAvatar;
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
            _database.PlayerAvatar = PlayerAvatar;
            _database.PlayerName = PlayerName;
            _database.SoundVolume = Volume;
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