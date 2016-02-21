using UnityEngine;
using System.Collections;

/// <summary>
/// Handles 3D strafing behavior.
/// </summary>
public class Strafer : MonoBehaviour {
    /// <summary>
    /// Strafe velocity, in 3D.
    /// </summary>
    public Vector3 strafeVelocity;
    /// <summary>
    /// Maximum magnitude of displacement before reversing direction.
    /// </summary>
    public float maximumDisplacement;

    /// <summary>
    /// Store for the current displacement of the object.
    /// </summary>
    private Vector3 strafeDisplacement = new Vector3(0.0f, 0.0f, 0.0f);
	
    /// <summary>
    /// If the displacement is too great, reverse the velocity. 
    /// Then, move the object.
    /// </summary>
	void FixedUpdate () {
        if (strafeDisplacement.magnitude >= maximumDisplacement)
        {
            strafeVelocity *= -1;
        }
        strafeDisplacement += strafeVelocity * Time.deltaTime;
        gameObject.transform.position += strafeVelocity * Time.deltaTime;
	}

    /// <summary>
    /// Add additional velocity to this object's strafe.
    /// </summary>
    /// <param name="deltaV">The change in velocity.</param>
    public void AddStrafeVelocity(Vector3 deltaV)
    {
        strafeVelocity += deltaV;
    }
}
