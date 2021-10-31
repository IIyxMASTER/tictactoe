using Sources.TicTacToe.UI.Controllers.Interfaces;
using Sources.TicTacToe.UI.Views.Interfaces;
using UnityEngine;
using UnityEngine.EventSystems;
using Zenject;

namespace Sources.TicTacToe.UI.Views
{
    public class AvatarPrefabView : MonoBehaviour, IAvatarPrefabView, IPointerClickHandler
    {
        [Inject] private IOptionsUIController _optionsUIController;
        [SerializeField] private SpriteRenderer _spriteRenderer;

        private string _id;
        public void SetSprite(Sprite sprite, string id)
        {
            _spriteRenderer.sprite = sprite;
            _id = id;
        }


        public void OnPointerClick(PointerEventData eventData)
        {
            _optionsUIController.SelectAvatar(_id);
        }
        
        public class Factory : PlaceholderFactory<AvatarPrefabView>
        {
        }
    }
}