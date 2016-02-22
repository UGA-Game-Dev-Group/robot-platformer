using UnityEngine;
using System.Collections;

/// <summary>
/// Watches for the player to enter its collider. When the player does,
/// triggers a Trap object.
/// </summary>
public class TrapTrigger : MonoBehaviour {
    public FallingTrap trap;

	void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Trigger Entered!");
        if(other.gameObject.tag.CompareTo("Player") == 0)
        {
            trap.Trigger();
        }
    }
}