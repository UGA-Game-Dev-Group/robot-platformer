using UnityEngine;

/// <summary>
/// Don't destroy this object on reload.
/// </summary>
public class PersistThroughReset : MonoBehaviour {
    
    /// <summary>
    /// Set the object to not be destroyed.
    /// </summary>
    void OnAwake()
    {
        DontDestroyOnLoad(this);
    }
}
