using UnityEngine;
using System.Collections;

/// <summary>
/// Destroy this object when it leaves the boundary box.
/// </summary>
public class DestroyOnBoundary : MonoBehaviour {

    /// <summary>
    /// Destroy the object if it leaves the boundary box.
    /// </summary>
    /// <param name="other">Another collider. No behavior if the collider
    /// if not tagged "Boundary".</param>
    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Boundary"))
        {
            Destroy(gameObject);
        }
    }
}
