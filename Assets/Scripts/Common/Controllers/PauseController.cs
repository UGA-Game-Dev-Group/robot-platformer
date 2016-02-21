using UnityEngine;
using System.Collections;

/// <summary>
/// Handle the pause behavior.
/// </summary>
public class PauseController : MonoBehaviour {
    /// <summary>
    /// Store for the paused state.
    /// </summary>
    private bool paused;
	
    /// <summary>
    /// Pause or unpause the game on update.
    /// </summary>
	void Update () {
        if (Input.GetButtonDown("Cancel")){
            if (paused)
            {
                Time.timeScale = 1.0f;
            }
            else
            {
                Time.timeScale = 0.0f;
            }
            paused = !paused;
        }
    }
}
