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
                        GetComponent<SpriteRenderer>().color = Color.green;
                        break;
                    case Cell.CellStatus.AI:
                        GetComponent<SpriteRenderer>().color = Color.red;
                        break;
                    default:
                        GetComponent<SpriteRenderer>().color = Color.white;
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