using UnityEngine;
using System.Collections;

/// <summary>
/// Script to control bounce pad behavior.
/// </summary>
public class BouncePad : MonoBehaviour {
    /// <summary>
    /// The amount of force to apply.
    /// </summary>
    public float bounceForce = 10;

    public void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Triggered!");
        Vector3 forceVector = new Vector3(0, bounceForce, 0);
        GameObject collisionObject = other.transform.gameObject;
        if (collisionObject != null && collisionObject.CompareTag("Player"))
        {
            collisionObject.GetComponent<Rigidbody2D>().AddForce(forceVector);
        }
    }
}
