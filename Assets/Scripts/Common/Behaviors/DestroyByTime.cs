using UnityEngine;
using System.Collections;

/// <summary>
/// Destroy this object after a given lifespan.
/// </summary>
public class DestroyByTime : MonoBehaviour {
    /// <summary>
    /// Life span in seconds.
    /// </summary>
    public float lifeSpan = float.PositiveInfinity;

    /// <summary>
    /// Set the object to be destroyed after the specified number of seconds.
    /// </summary>
	void Start () {
        Destroy(gameObject, lifeSpan);
	}
}
