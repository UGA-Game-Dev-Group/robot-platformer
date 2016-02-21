using UnityEngine;
using System.Collections.Generic;

/// <summary>
/// Handles background parallax behavior.
/// 
/// This is a suitable script to handle parallax behavior on a 2D game.
/// </summary>
public class Parallax : MonoBehaviour {
    /// <summary>
    /// All parallaxed elements
    /// </summary>
    public List<Transform> backgrounds;
    /// <summary>
    /// Amount to smooth parallax
    /// </summary>
    public float smoothing = 1.0f;
    /// <summary>
    /// Differential between camera and backgrounds
    /// </summary>
    private List<float> parallaxScales;
    /// <summary>
    /// Reference to the camera's transform
    /// </summary>
    private Transform mainCamera;
    /// <summary>
    /// Store for the camera's frame in the previous frame
    /// </summary>
    private Vector3 previousCamPosition;

    void Awake()
    {
        mainCamera = Camera.main.transform;
    }

    void Start()
    {
        previousCamPosition = mainCamera.position;
        parallaxScales = new List<float>();
        for(int i = 0; i < backgrounds.Count; i++)
        {
            parallaxScales.Add(backgrounds[i].position.z * -1);
        }
    }

	void Update ()
    {
        //Parallax is the opposite of the camera movement * scale
        for (int i = 0; i < backgrounds.Count; i++)
        {
            //Calculate new position
            float parallax = (previousCamPosition.x - mainCamera.position.x) * parallaxScales[i];
            float backgroundTargetPosX = backgrounds[i].position.x + parallax;
            Vector3 backgroundTargetPosition = new Vector3(
                backgroundTargetPosX,
                backgrounds[i].position.y,
                backgrounds[i].position.z
                );

            //Shift the background
            backgrounds[i].position = Vector3.Lerp(backgrounds[i].position, backgroundTargetPosition, smoothing * Time.deltaTime);
        }

        previousCamPosition = mainCamera.position;
    }

    public void AddBackground(Transform transform)
    {
        backgrounds.Add(transform);
        parallaxScales.Add(transform.position.z * -1);
    }
}
