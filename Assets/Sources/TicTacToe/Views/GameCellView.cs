using Sources.TicTacToe.Controllers.Interfaces;
using Sources.TicTacToe.Models;
using Sources.TicTacToe.Views.Interfaces;
using UnityEngine;
using UnityEngine.EventSystems;
using Zenject;
#pragma warning disable 0649

namespace Sources.TicTacToe.Views
{
    public class GameCellView : MonoBehaviour, IGameCellView, IPointerClickHandler
    {
        [SerializeField] private IGameController _gameController;

        [SerializeField] private SpriteRenderer crossRenderer;
        [SerializeField] private SpriteRenderer circleRenderer;
        private Cell _model;

        public Cell Model
        {
            get => _model;
            set
            {
                _model = value;
                switch (_model.Status)
                {
                    case Cell.CellStatus.Player:
                        circleRenderer.gameObject.SetActive(false);
                        crossRenderer.gameObject.SetActive(true);
                        break;
                    case Cell.CellStatus.AI:

                        circleRenderer.gameObject.SetActive(true);
                        crossRenderer.gameObject.SetActive(false);
                        break;
                    default:
                        circleRenderer.gameObject.SetActive(false);
                        crossRenderer.gameObject.SetActive(false);
                        break;
                }
            }
        }

        public void SetPosition(Vector3 position) => transform.localPosition = position;
        public void SetSize(Vector3 size) => transform.localScale = size;

        public void SetParent(Transform parent) => transform.SetParent(parent);

        [Inject]
        public void Construct(IGameController controller)
        {
            _gameController = controller;
        }

        

        public void OnPointerClick(PointerEventData eventData)
        {
            _gameController.OnCellClick(Model);
        }
    }
    public class GameCellViewFactory : PlaceholderFactory<IGameCellView>
    {
    }
}