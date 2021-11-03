using Sources.TicTacToe.Controllers;
using Sources.TicTacToe.Controllers.Interfaces;
using Sources.TicTacToe.UI.Controllers;
using Sources.TicTacToe.UI.Controllers.Interfaces;
using Sources.TicTacToe.UI.Views;
using Sources.TicTacToe.UI.Views.Interfaces;
using Sources.TicTacToe.Views;
using Sources.TicTacToe.Views.Interfaces;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

#pragma warning disable 0649
namespace Sources.TicTacToe.Installers
{
    public class GameInstaller : MonoInstaller
    {
        public GameObject CellPrefab;
        public GameObject AvatarPrefab;
        public Button ButtonPrefab;

        [SerializeField] private Sprite _alertSprite;

        public override void InstallBindings()
        {
            Container.Bind<Sprite>().WithId("AlertSprite").FromInstance(_alertSprite);
            Container.Bind<ILevelLoaderController>().To<LevelLoaderController>().AsSingle();
            Container.Bind<IOptionsUIController>().To<OptionsController>().AsSingle()
                .OnInstantiated<IOptionsUIController>(
                    (context, controller) => controller.LoadAvatars()
                );
            Container.Bind<ICameraController>().To<CameraController>().AsSingle();
            Container.Bind<IMainMenuController>().To<MainMenuController>().AsSingle()
                .OnInstantiated<IMainMenuController>(
                    ((context, controller) => { controller.SubscribeOnInputEvents(); })
                );
            Container.Bind<IGameController>().To<GameController>().AsSingle()
                .OnInstantiated<IGameController>((context, gameController) => { gameController.StartGame(); })
                .NonLazy();

            Container.BindFactory<IGameCellView, GameCellViewFactory>().FromComponentInNewPrefab(CellPrefab);
            Container.BindFactory<IAvatarPrefabView, AvatarViewFactory>().FromComponentInNewPrefab(AvatarPrefab);
            Container.BindFactory<Button, ButtonFactory>().FromComponentInNewPrefab(ButtonPrefab);

            Container.Bind<IGameFieldController>().To<GameFieldController>().AsSingle()
                .OnInstantiated<IGameFieldController>(
                    (context, controller) =>
                    {
                        controller.CreateCells();
                        controller.SetCellSize(4);
                        controller.SetCellPadding(0.5f);
                        controller.Format();
                        controller.HideView();
                    });
            Container.Bind<IDatabaseController>().To<DatabaseController>().AsSingle()
                .OnInstantiated<IDatabaseController>(
                    (context, controller) => { controller.Initialize(); })
                .NonLazy();
            Container.Bind<IGameUIController>().To<GameUIController>().AsSingle().NonLazy();
            Container.Bind<IMessageBoxController>().To<MessageBoxController>().AsSingle().NonLazy();
            Container.Bind<IEndGameController>().To<EndGameController>().AsSingle().NonLazy();
        }
    }
}