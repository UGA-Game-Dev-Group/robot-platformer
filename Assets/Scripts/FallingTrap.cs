using System.Collections;
using UnityEngine;

/// <summary>
/// Behavior script for traps that fall and optionally reset.
/// </summary>
public class FallingTrap : MonoBehaviour {
    /// <summary>
    /// Does the object reset?
    /// </summary>
    public bool reset;
    /// <summary>
    /// Time in seconds before the object resets.
    /// </summary>
    public float resetDelay;

    /// <summary>
    /// Does the object teleport back to its original position?
    /// </summary>
    public bool teleportReset;
    /// <summary>
    /// Gravity scale to fall with.
    /// </summary>
    public float gravity;
    /// <summary>
    /// Speed at which the object moves back to its original position.
    /// </summary>
    public float resetSpeed;

    /// <summary>
    /// Is the object currently triggered?
    /// </summary>
    private bool triggered;
    /// <summary>
    /// Store for the object's Rigidbody
    /// </summary>
    private Rigidbody2D rb;
    /// <summary>
    /// Store for the object's original position.
    /// </summary>
    private Vector2 initialPosition;
    /// <summary>
    /// Is the object currently resetting?
    /// </summary>
    private bool resetting;

    /// <summary>
    /// Store important values.
    /// </summary>
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        initialPosition = rb.transform.position;
    }

    /// <summary>
    /// 
    /// </summary>
    void FixedUpdate()
    {
        //In this case, the object is currently resetting.
        if (resetting)
        {
            rb.position = Vector3.Lerp(rb.position, initialPosition, Time.deltaTime * resetSpeed);
        }
        //The object is home. Reset all of the default values.
        if ((rb.position - initialPosition).magnitude < 0.5f && resetting)
        {
            resetting = false;
            triggered = false;
            Debug.Log("Trap Reset!");
        }
    }         

    /// <summary>
    /// Here, we set the trap to fall. If it should reset, start that process.
    /// </summary>
    public void Trigger()
    {
        if (triggered) {
            return;
        }

        triggered = true;
        rb.gravityScale = gravity;
        if (reset)
        {
            StartCoroutine("Reset");
        }
    }

    /// <summary>
    /// Reset the object, or start the reset movement if called for.
    /// </summary>
    /// <returns></returns>
    private IEnumerator Reset()
    {
        Debug.Log("Waiting to reset.");
        yield return new WaitForSeconds(resetDelay);
        if (teleportReset)
        {
            rb.transform.position = initialPosition;
        } else
        {
            resetting = true;
        }
        rb.gravityScale = 0f;
        Debug.Log("Reset");
    }
}
