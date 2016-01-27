using UnityEngine;

/// <summary>
/// Handles tiling behavior for backgrounds.
/// </summary>
[RequireComponent(typeof(SpriteRenderer))]
public class Tiling : MonoBehaviour {
    /// <summary>
    /// Minimum distance to not have a buddy.
    /// </summary>
    public int offset = 2;
    /// <summary>
    /// Do we have a tile to the right?
    /// </summary>
    public bool hasBuddyRight = false;
    /// <summary>
    /// Do we have a tile to the left?
    /// </summary>
    public bool hasBuddyLeft = false;
    public bool reverseScale = false;
    public GameObject backgroundPrefab;
    public Parallax parallax;

    private float spriteWidth = 0.0f;
    private Camera mainCamera;

    /// <summary>
    /// Grab the main camera on awake.
    /// </summary>
    void Awake()
    {
        Debug.Log("New buddy loaded." + backgroundPrefab);
        mainCamera = Camera.main;
    }

	// Use this for initialization
	void Start () {
        SpriteRenderer sRenderer = GetComponent<SpriteRenderer>();
        spriteWidth = sRenderer.sprite.bounds.size.x;
	}
	
	/// <summary>
    /// Check to see if a tile is needed and construct it if so.
    /// </summary>
	void Update () {
        if(!hasBuddyLeft || !hasBuddyRight)
        {
            //Get the buddy positions
            float camHorizontalExtent = 
                mainCamera.orthographicSize * Screen.width / Screen.height;
            float edgeVisiblePositionRight = 
                (transform.position.x + spriteWidth / 2) - camHorizontalExtent;
            float edgeVisiblePositionLeft =
                (transform.position.x - spriteWidth / 2) + camHorizontalExtent;

            //Instantiate the buddies
            if(mainCamera.transform.position.x >= edgeVisiblePositionRight - offset && !hasBuddyRight)
            {
                MakeNewBuddy(1);
                hasBuddyRight = true;
            } else if (mainCamera.transform.position.x <= edgeVisiblePositionLeft + offset && !hasBuddyLeft)
            {
                MakeNewBuddy(-1);
                hasBuddyLeft = true;
            } 
        }
	}

    /// <summary>
    /// Create a new buddy on the left or right side.
    /// </summary>
    /// <param name="rightOrLeft">-1 for left side, 1 for right side</param>
    void MakeNewBuddy (int rightOrLeft)
    {
        Vector3 newPosition = new Vector3(
            transform.position.x + spriteWidth * rightOrLeft,
            transform.position.y,
            transform.position.z);
        GameObject newBuddy = Instantiate(backgroundPrefab, newPosition, transform.rotation) as GameObject;
        if(parallax != null)
        {
            parallax.AddBackground(newBuddy.transform);
        }
        if (reverseScale)
        {
            newBuddy.transform.localScale = new Vector3(newBuddy.transform.localScale.x * -1, 1, 1);
        }

        newBuddy.transform.parent = transform.parent;
        if (rightOrLeft > 0)
        {
            newBuddy.GetComponent<Tiling>().hasBuddyLeft = true;
        } else
        {
            newBuddy.GetComponent<Tiling>().hasBuddyRight = true;
        }
    }
}
