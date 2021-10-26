using System.Collections;
using System.Collections.Generic;
using TicTacToe.UI.Interfaces;
using UnityEngine;
using Zenject;

namespace TicTacToe.UI
{
    public class LevelLoaderView : MonoBehaviour, ILevelLoaderView
    {
//    [Inject] private LevelLoaderController _view;

        public void Init()
        {
        }

        public void Show()
        {
            Debug.Log("Show");
        }

        public void Hide()
        {
            Debug.Log("Hide");
        }
    }
}
