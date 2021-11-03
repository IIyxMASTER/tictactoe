using Sources.TicTacToe.Controllers.Interfaces;
using Sources.TicTacToe.UI.Controllers.Interfaces;
using Sources.TicTacToe.UI.Views.Interfaces;
using Sources.TicTacToe.Views.Interfaces;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Zenject;
#pragma warning disable 0649
namespace Sources.TicTacToe.Views
{
    public class OptionsView : MonoBehaviour, IOptionsView
    {
        [Inject] private IOptionsUIController _optionsUIController;
        [SerializeField] private Canvas _canvas;
        [SerializeField] private GameObject _mainMenuTransform;
        [SerializeField] private GameObject _avatarMenuTransform;
        [SerializeField] private Transform _contentGameObject;
        [SerializeField] private Image _avatarImage;
        [SerializeField] private Slider _volumeSlider;
        [SerializeField] private TMP_InputField _playerLabel;
        [SerializeField] private TMP_Text _soundVolumeText;

        public void ShowView()
        {
            _avatarImage.enabled = _avatarImage.sprite != null;

            _canvas.enabled = true;

            ShowMainMenuPage();
        }

        public void HideView()
        {
            _canvas.enabled = false;
        }


        public void ShowMainMenuPage()
        {
            _mainMenuTransform.SetActive(true);
            _avatarMenuTransform.SetActive(false);
        }

        public void ShowAvatarSelectionPage()
        {
            _mainMenuTransform.SetActive(false);
            _avatarMenuTransform.SetActive(true);
        }

        public void AddAvatar(IAvatarPrefabView avatar)
        {
            avatar.Transform.SetParent(_contentGameObject);
            avatar.Transform.localScale = Vector3.one;
        }

        public void ApplyAvatarSettings()
        {
            _optionsUIController.PlayerAvatar = _avatarId;
            _avatarImage.enabled = true;
            _optionsUIController.ApplyAvatar();
        }

        public void ExitAvatarSetting()
        {
            ShowMainMenuPage();
        }

        public void ApplyMainMenuSettings()
        {
            _optionsUIController.PlayerName = _playerLabel.text;
            _optionsUIController.Volume = _volumeSlider.value;
            _optionsUIController.PlayerAvatar = _avatarId;
            _optionsUIController.ApplySettings();
        }

        public void ExitMainMenuSettings()
        {
            HideView();
        }


        private string _avatarId;

        public void SelectAvatar(string id)
        {
            _avatarId = id;
        }

        public void SetAvatar(Sprite avatar)
        {
            _avatarImage.enabled = true;
            _avatarImage.sprite = avatar;
            _avatarId = _optionsUIController.PlayerAvatar;
        }

        public void SetPlayerName(string name)
        {
            _playerLabel.text = name;
        }

        public void OnChangeVolumeValue(float value)
        {
            _soundVolumeText.text = ((int) (value * 100f)).ToString();
        }

        public void SetVolumeValue(float value)
        {
            _volumeSlider.value = value;
            OnChangeVolumeValue(value);
        }
    }
}