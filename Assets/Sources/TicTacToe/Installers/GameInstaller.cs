using TicTacToe.Controllers;
using TicTacToe.Controllers.Interfaces;
using TicTacToe.UI.Interfaces;
using TicTacToe.Views;
using UnityEngine;
using Zenject;

namespace TicTacToe.Installers
{
    public class GameInstaller : MonoInstaller
    {
        public GameObject CellPrefab;
        public override void InstallBindings()
        {
            Container.Bind<ILevelLoaderController>().To<LevelLoaderController>().AsSingle().NonLazy();
            Container.Bind<ICameraController>().To<CameraController>().AsSingle().NonLazy();
            Container.Bind<IGameController>().To<GameController>().AsSingle().NonLazy();
            Container.BindFactory<GameCellView, GameCellView.Factory>().FromComponentInNewPrefab(CellPrefab);
            Container.Bind<IGameFieldController>().To<GameFieldController>().AsSingle()
                .OnInstantiated<IGameFieldController>(
                    (context, controller) =>
                    {
                        controller.CreateCells();
                        controller.SetCellSize(4);
                        controller.SetCellPadding(0.5f);
                        controller.Format();
                    }).NonLazy();
        }
    }
}