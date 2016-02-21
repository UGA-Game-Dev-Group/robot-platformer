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
    public string[] damageTags;

    /// <summary>
    /// Tag of the last object that hit this one. Used to determine whether destruction should be scored or not.
    /// </summary>
    private string lastHitTag;

    /// <summary>
    /// Detect a hit with an object that can damage this one, save the tag, then deal damage.
    /// </summary>
    /// <param name="other"></param>
    void OnTriggerEnter2D(Collider2D other)
    {
        if(System.Array.IndexOf(damageTags, other.tag) < 0){
            //This object can't be damaged by other.
            return;
        }

        Damager damager = other.gameObject.GetComponent<Damager>();
        if(damager == null)
        {
            //other is not a damager
            return;
        }

        Debug.Log("Damage collision.");
        lastHitTag = other.tag;
        Damage(damager.GetDamage());
    }

    /// <summary>
    /// Damage this object. Default damage is 1.
    /// </summary>
    public void Damage()
    {
        Damage(1);
    }

    /// <summary>
    /// If damage is specified, deal that much. Then, check for death.
    /// </summary>
    /// <param name="amount">The amount of damage dealt.</param>
    public void Damage(int amount)
    {
        startHealth -= amount;
        CheckForDeath();
    }

    /// <summary>
    /// Check for health of 0 or less, then handle it.
    /// </summary>
    /// <remarks>If health is 0 or less, score the kill if necessary, 
    /// play the explosion (if available), and destroy the object. Othewise, 
    /// update the material.</remarks>
    void CheckForDeath()
    {
        if (startHealth <= 0)
        {
            Scoreable scoreable = GetComponent<Scoreable>();
            if (scoreable != null && lastHitTag.CompareTo("Player") == 0)
            {
                scoreable.Score();
            }
            Destroy(gameObject);
        }
    }
}
