using UnityEngine;
using System.Collections;

/// <summary>
/// Adds the ability to be damaged to this 2D object.
/// </summary>
public class Damageable2D : MonoBehaviour {
    /// <summary>
    /// Starting amount of hit points this object has.
    /// </summary>
    public int startHealth = 1;
    /// <summary>
    /// Objects with tags found in this array are able to damage this object.
    /// </summary>


    /// <summary>
    /// Detect a hit with an object that can damage this one, save the tag, then deal damage.
    /// </summary>
    /// <param name="other"></param>
    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.tag == "Enemy")
        {
            Debug.Log("Player collided");
        }
    }
}
