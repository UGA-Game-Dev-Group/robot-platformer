using UnityEngine;
using System.Collections;


public class Shooter : MonoBehaviour
{
    public GameObject shot;
    public Transform shotSpawn;
    public RepeatDelay auto;

    void Start()
    {
        if (auto.autoRepeat)
        {
            StartCoroutine("ShootCycle", Random.Range(auto.startDelayMin, auto.startDelayMax));
        }
    }

    public void Shoot()
    {
        AudioSource shotSound = GetComponent<AudioSource>();
        if(shotSound != null)
        {
            shotSound.Play();
        }
        Instantiate(shot, shotSpawn.position, shotSpawn.rotation);
    }

    IEnumerator ShootCycle()
    {
        yield return new WaitForSeconds(Random.Range(auto.startDelayMin, auto.startDelayMax));

        while (true)
        {
            Shoot();
            yield return new WaitForSeconds(Random.Range(auto.repeatDelayMin, auto.repeatDelayMax));
        }
    }
}
