using Sources.TicTacToe.Controllers;
using Sources.TicTacToe.Controllers.Interfaces;
using Sources.TicTacToe.UI.Controllers;
using Sources.TicTacToe.UI.Controllers.Interfaces;
using Sources.TicTacToe.Views;
using UnityEngine;
using Zenject;

namespace Sources.TicTacToe.Installers
{
    public class GameInstaller : MonoInstaller
    {
        public GameObject CellPrefab;

        public override void InstallBindings()
        {
            Container.Bind<ILevelLoaderController>().To<LevelLoaderController>().AsSingle().NonLazy();
            Container.Bind<ICameraController>().To<CameraController>().AsSingle().NonLazy();
            Container.Bind<IMainMenuController>().To<MainMenuController>().AsSingle().NonLazy(); 
            Container.Bind<IGameController>().To<GameController>().AsSingle()
                .OnInstantiated<IGameController>((context, gameController) => { gameController.StartGame(); })
                .NonLazy();
            Container.BindFactory<GameCellView, GameCellView.Factory>().FromComponentInNewPrefab(CellPrefab);
            Container.Bind<IGameFieldController>().To<GameFieldController>().AsSingle()
                .OnInstantiated<IGameFieldController>(
                    (context, controller) =>
                    {
                        controller.CreateCells();
                        controller.SetCellSize(4);
                        controller.SetCellPadding(0.5f);
                        controller.Format();
                        controller.HideView();
                    }).NonLazy();
        }
    }
}