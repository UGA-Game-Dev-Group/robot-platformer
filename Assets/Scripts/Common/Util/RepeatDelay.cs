using UnityEngine;
using System.Collections;

[System.Serializable]
public class RepeatDelay
{
    public bool autoStart = true;
    public bool autoRepeat = false;
    public float startDelayMin = 1.0f;
    public float startDelayMax = 5.0f;
    public float repeatDelayMin = 1.0f;
    public float repeatDelayMax = 5.0f;
}
