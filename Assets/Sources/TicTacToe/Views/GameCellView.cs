using Sirenix.OdinInspector;
using Sources.TicTacToe.Models;
using TicTacToe.Controllers;
using TicTacToe.Controllers.Interfaces;
using UnityEngine;
using UnityEngine.EventSystems;
using Zenject;

namespace TicTacToe.Views
{
    public class GameCellView : SerializedMonoBehaviour, IGameCellView, IPointerClickHandler
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

        public class Factory : PlaceholderFactory<GameCellView>
        {
        }

        public void OnPointerClick(PointerEventData eventData)
        {
            _gameController.OnCellClick(Model);
        }
    }
}