
using TicTacToe.Controllers.Interfaces;
using TicTacToe.UI;
using UnityEngine;
using Zenject;
// ReSharper disable ClassNeverInstantiated.Global

namespace TicTacToe.Controllers
{
   public class LevelLoaderViewController : ILevelLoaderViewController
   {
      [Inject] private LevelLoaderView _view;

      public void ShowMainLoadScreen()
      {
         Debug.Log("One");
      }

      public void ShowStartBattleScreen()
      {
         Debug.Log("One");
      }

      public void ShowEndBattleScreen()
      {
         Debug.Log("One");
      }
   } 
}