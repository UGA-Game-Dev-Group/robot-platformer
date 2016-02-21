using UnityEngine;
using UnityEngine.UI;
using System.Collections;

/// <summary>
/// Controlls the level text on the GUI.
/// </summary>
public class LevelTextController : MonoBehaviour {
    /// <summary>
    /// Update the GUI text.
    /// </summary>
    public void UpdateText(int level)
    {
        GetComponent<Text>().text = "Level " + level;
    }
}
