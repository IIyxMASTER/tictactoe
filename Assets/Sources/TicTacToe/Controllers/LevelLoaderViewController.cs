
using TicTacToe.Controllers.Interfaces;
using UnityEngine;
using Zenject;

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
   } public class LevelLoaderViewController2 : ILevelLoaderViewController
   {
      [Inject] private LevelLoaderView _view;

      public void ShowMainLoadScreen()
      {
         Debug.Log("two");
      }

      public void ShowStartBattleScreen()
      {
         Debug.Log("two");
      }

      public void ShowEndBattleScreen()
      {
         Debug.Log("two");
      }
   }
}