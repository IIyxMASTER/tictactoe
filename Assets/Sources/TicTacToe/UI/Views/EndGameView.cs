using System.Collections.Generic;
using MEC;
using Sources.TicTacToe.UI.Controllers;
using Sources.TicTacToe.UI.Controllers.Interfaces;
using Sources.TicTacToe.UI.Views.Interfaces;
using Sources.TicTacToe.Views;
using TicTacToe.Extensions;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Zenject;
#pragma warning disable 0649
namespace Sources.TicTacToe.UI.Views
{
    public class EndGameView : MonoBehaviour, IEndGameView
    {
        [Inject] private IEndGameController _endGameController;
        [SerializeField] private Canvas _canvas;
        [SerializeField] private TMP_Text _resultLabel;
        [SerializeField] private TMP_Text _scoresLabel;
        [SerializeField] private GameObject _avatarBackground;
        [SerializeField] private Image _avatarImage;
        [SerializeField] private GameObject _scoresGameObject;
        [SerializeField] private GameObject _buttonsRoot;

        private int _startScores = 0;
        private int _endScores = 0;

        public void ShowView()
        {
            _canvas.enabled = true;
        }

        public void HideView()
        {
            _canvas.enabled = false;
        }

        public void SetResultText(string result)
        {
            _resultLabel.text = result;
        }

        public void SetScores(int from, int to)
        {
            _startScores = from;
            _endScores = to;
        }

        public void SetAvatar(Sprite avatar)
        {
            _avatarImage.sprite = avatar;
        }

        public void Animate()
        {
            Timing.RunCoroutine(ShowAnimation());
        }

        public void GoToMainMenu()
        {
            _endGameController.GoToMainMenu();
        }

        public void Restart()
        {
            _endGameController.Restart();
        }

        IEnumerator<float> ShowAnimation()
        {
            _avatarBackground.SetActive(false);
            _scoresGameObject.SetActive(false);
            _buttonsRoot.SetActive(false);
            ShowView();
            yield return Timing.WaitForSeconds(1);
            _avatarBackground.SetActive(true);
            yield return Timing.WaitForSeconds(1);
            _scoresGameObject.SetActive(true);

            var scoresAnimationTime = 2f;
            yield return scoresAnimationTime.AsTimeProcess(normalTime =>
            {
                int scoresValue = (int) Mathf.Lerp(_startScores, _endScores, normalTime);
                _scoresLabel.text = scoresValue.ToString();
            });
            _scoresLabel.text = _endScores.ToString();
            _buttonsRoot.SetActive(true);
        }
    }
}