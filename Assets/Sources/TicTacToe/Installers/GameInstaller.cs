using TicTacToe.Controllers;
using TicTacToe.Controllers.Interfaces;
using TicTacToe.UI.Interfaces;
using UnityEngine;
using Zenject;

public class GameInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        Container.Bind<ILevelLoaderViewController>().To<LevelLoaderViewController2>().AsSingle().NonLazy();
    }
    
}
