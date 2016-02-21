using UnityEngine;
using System.Collections;

/// <summary>
/// Handles uniform motion in three dimensions.
/// </summary>
public class Mover : MonoBehaviour {
    /// <summary>
    /// The starting motion of the object.
    /// </summary>
    public Vector3 velocity;

    /// <summary>
    /// Update the position of the object.
    /// </summary>
    void FixedUpdate()
    {
        transform.position += velocity * Time.deltaTime;
    }
}
