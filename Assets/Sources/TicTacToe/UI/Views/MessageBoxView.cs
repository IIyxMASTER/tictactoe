using System;
using System.Collections.Generic;
using Sources.TicTacToe.UI.Controllers.Interfaces;
using Sources.TicTacToe.UI.Views.Interfaces;
using Sources.TicTacToe.Views;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Zenject;
#pragma warning disable 0649

namespace Sources.TicTacToe.UI.Views
{
    public class MessageBoxView : MonoBehaviour, IMessageBoxView
    {
        [Inject] private IMessageBoxController _messageBoxController;
        [Inject] private ButtonFactory _messageBoxButtonFactory;
        [SerializeField] private Canvas _canvas;
        [SerializeField] private Transform _buttonsRoot;
        [SerializeField] private TMP_Text _informationText;

        private List<Button> _buttons = new List<Button>();


        public RectTransform RectTransform => transform as RectTransform;

        public void ShowView()
        {
            _canvas.enabled = true;
        }

        public void HideView()
        {
            _canvas.enabled = false;
        }

        public void SetInformationText(string text)
        {
            _informationText.text = text;
        }


        public void AddButton(string text, Action onClick)
        {
            var button = _messageBoxButtonFactory.Create();
            button.onClick.AddListener(delegate
            {
                onClick();
            });
            button.GetComponentInChildren<TMP_Text>().text = text;
            button.transform.SetParent(_buttonsRoot);
            button.transform.localScale = Vector3.one;
            _buttons.Add(button);
        }

        public void Flush()
        {
            for (var i = 0; i < _buttons.Count; i++)
            {
                var button = _buttons[i];
                GameObject.Destroy(button.gameObject);
            }

            _buttons.Clear();
        }
    }


    public class ButtonFactory : PlaceholderFactory<Button>
    {
    }
}