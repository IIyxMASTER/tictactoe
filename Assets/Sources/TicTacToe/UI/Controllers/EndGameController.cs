using System.Collections.Generic;
using MEC;
using Sources.TicTacToe.Controllers;
using Sources.TicTacToe.Controllers.Interfaces;
using Sources.TicTacToe.UI.Controllers.Interfaces;
using Sources.TicTacToe.UI.Views.Interfaces;
using Sources.TicTacToe.Views;
using Zenject;

#pragma warning disable 0649

namespace Sources.TicTacToe.UI.Controllers
{
    public class EndGameController : IEndGameController
    {
        [Inject] private IEndGameView _endGameView;
        [Inject] private IDatabaseController _databaseController;
        [Inject] private IGameController _gameController;
        [Inject] private IGameFieldController _gameFieldController;
        [Inject] private ILevelLoaderController _levelLoaderController;
        [Inject] private IMainMenuController _mainMenuController;
        [Inject] private IGameUIController _gameUIController;

        public void ShowView()
        {
            _endGameView.ShowView();
        }

        public void HideView()
        {
            _endGameView.HideView();
        }

        public void DisplayVictory(int oldScores, int newScores)
        {
            DisplayWithText("<bounce>Victory!</bounce>", oldScores, newScores);
        }

        public void DisplayDraw(int scores)
        {
            DisplayWithText("<pend>Draw</pend>", scores, scores);
        }
        void DisplayWithText(string result, int oldScores, int newScores)
        {
            _endGameView.SetResultText(result);
            _endGameView.SetScores(oldScores, newScores);

            var avatar = _databaseController.GetAvatar(_databaseController.PlayerAvatar.Value);
            _endGameView.SetAvatar(avatar);
            _endGameView.Animate();
        }

        public void DisplayDefeat(int oldScores, int newScores)
        {
            DisplayWithText("<pend>Defeat</pend>", oldScores, newScores);
        }

        public void GoToMainMenu()
        {
            Timing.RunCoroutine(GoToMainMenuAnimation());
        }

        IEnumerator<float> GoToMainMenuAnimation()
        {
            yield return Timing.WaitUntilDone(_levelLoaderController.PlayChangeSceneAnimationWithFakeAction(
                onHide: () =>
                {
                    HideView();
                    _gameFieldController.HideView();
                    _gameUIController.Hide();
                },
                onLoad: () =>
                {
                    _mainMenuController.ShowView();
                },
                fakeActions: new[]
                {
                    "Загружаем главное меню"
                },
                animationSpriteId: 0
            ));
        }
        IEnumerator<float> AnimationRestart()
        {
            HideView();
            int spriteId = 1;
            yield return Timing.WaitUntilDone(_levelLoaderController.PlayChangeSceneAnimationWithFakeAction(
                onHide: null,
                onLoad: () => { _gameController.Init(); },
                fakeActions: new[]
                {
                    "Уговариваем AI на еще один матч", "Слушаем отказ", "Применяем санкции",
                    "Благодарим AI за сотрудничество"
                },
                animationSpriteId: spriteId
            ));
        }

        public void Restart()
        {
            Timing.RunCoroutine(AnimationRestart());
        }
    }
}