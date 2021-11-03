using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class RemovePlayerPrefs : MonoBehaviour
{
    [MenuItem("Tools/TicTacToe/Cleat Player Prefs")]
    static void DeleteAll()
    {
        PlayerPrefs.DeleteAll();
    }
}
