using TicTacToe.Controllers;
using TicTacToe.Controllers.Interfaces;
using TicTacToe.UI.Interfaces;
using UnityEngine;
using Zenject;

namespace TicTacToe.Installers
{
    public class GameInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.Bind<ILevelLoaderViewController>().To<LevelLoaderViewController>().AsSingle().NonLazy();
        }
    }
}