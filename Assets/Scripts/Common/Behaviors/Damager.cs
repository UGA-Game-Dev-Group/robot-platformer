using UnityEngine;
using System.Collections;

/// <summary>
/// Handle the behavior of an object that can damage Damagables.
/// </summary>
public class Damager : MonoBehaviour {
    /// <summary>
    /// Amount of damage to deal.
    /// </summary>
    public int damage;
    /// <summary>
    /// Is the object destroyed when it deals damage? Use this for projectiles and other temporary objects.
    /// </summary>
    public bool destroyedOnDamage;

    /// <summary>
    /// Get the amount of damage to deal. If required, destroy this object.
    /// </summary>
    /// <returns>The integer amount of damage to deal.</returns>
    public int GetDamage()
    {
        if (destroyedOnDamage)
        {
            Destroy(gameObject);
        }
        return damage;
    }
}
