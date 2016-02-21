using UnityEngine;
using System.Collections;

/// <summary>
/// Handles scoreable behavior for an object.
/// </summary>
public class Scoreable : MonoBehaviour {

    /// <summary>
    /// Declaration of different methods of scoring.
    /// </summary>
    /// <remarks>Fixed scoreables apply a single score value each time. 
    /// RandomRange scoreables randomly choose an integer value between a min and max.
    /// SteppedRange scoreables randomly choose an integer value from the pointSteps array.</remarks>
    public enum ScoreType { Fixed, RandomRange, SteppedRange };

    /// <summary>
    /// The scoring method.
    /// </summary>
    /// <remarks>Defaults to Fixed.</remarks>
    public ScoreType mode = ScoreType.Fixed;
    /// <summary>
    /// Point value assigned for Fixed scoreables.
    /// </summary>
    public int fixedPointValue = 10;
    /// <summary>
    /// Lower bound for RandomRange scoreables (inclusive).
    /// </summary>
    public int randomPointValueMin = 0;
    /// <summary>
    /// Upper bound for RandomRange scoreables (inclusive).
    /// </summary>
    public int randomPointValueMax = 0;
    /// <summary>
    /// Array of possible point steps awarded by this scoreable.
    /// </summary>
    public int[] pointSteps;
    /// <summary>
    /// Store for the scoreController.
    /// </summary>
    public ScoreController scoreController;

    public void Start()
    {
        scoreController = GameObject.FindGameObjectWithTag("ScoreController").GetComponent<ScoreController>();
    }
    /// <summary>
    /// Award the score for the scoreable.
    /// </summary>
    public void Score()
    {
        if(scoreController == null)
        {
            Debug.Log("Score Controller not found.");
            return;
        }
        int pointValue = 0;
        switch (mode)
        {
            case ScoreType.Fixed:
                pointValue = fixedPointValue;
                break;
            case ScoreType.RandomRange:
                pointValue = Random.Range(randomPointValueMin, randomPointValueMax+1);
                break;
            case ScoreType.SteppedRange:
                pointValue = pointSteps[Random.Range(0, pointSteps.Length)];
                break;
        }
        scoreController.AddScore(pointValue);
    }
}
