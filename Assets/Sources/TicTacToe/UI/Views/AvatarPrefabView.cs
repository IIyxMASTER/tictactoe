using System.Runtime.InteropServices;
using Sources.TicTacToe.UI.Controllers.Interfaces;
using Sources.TicTacToe.UI.Views.Interfaces;
using Sources.TicTacToe.Views.Interfaces;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using Zenject;

namespace Sources.TicTacToe.UI.Views
{
    public class AvatarPrefabView : MonoBehaviour, IAvatarPrefabView, IPointerClickHandler
    {
        [Inject] private IOptionsView _optionsView;
        [SerializeField] private Image _spriteRenderer;

        private string _id;
        public RectTransform Transform => transform as RectTransform;

        public void SetSprite(Sprite sprite, string id)
        {
            _spriteRenderer.sprite = sprite;
            _id = id;
        }


        public void OnPointerClick(PointerEventData eventData)
        {
            _optionsView.SelectAvatar(_id);
        }
    }

    public class AvatarViewFactory : PlaceholderFactory<IAvatarPrefabView>
    {
    }
}