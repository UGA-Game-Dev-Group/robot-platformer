using UnityEngine;
using UnityEngine.UI;
using System.Collections;

/// <summary>
/// Handle score keeping and updating the GUI.
/// </summary>
public class ScoreController : MonoBehaviour {
    /// <summary>
    /// Store for the current score of the game.
    /// </summary>
    private static int score = 0;

    /// <summary>
    /// Set the GUI text to the correct score.
    /// </summary>
    public void Awake()
    {
        UpdateText();
    }

    /// <summary>
    /// Add points to the score.
    /// </summary>
    /// <param name="i">The number of points to add.</param>
    public void AddScore(int i)
    {
        score += i;
        UpdateText();
    }

    /// <summary>
    /// Set the score to a specified value.
    /// </summary>
    /// <param name="i">Score to set.</param>
    public void SetScore(int i)
    {
        score = i;
        UpdateText();
    }

    /// <summary>
    /// Update the GUI text.
    /// </summary>
    private void UpdateText()
    {
        GetComponent<Text>().text = "Score: " + score;
    }
}
