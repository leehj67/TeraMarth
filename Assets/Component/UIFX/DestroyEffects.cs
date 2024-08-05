using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyEffects : MonoBehaviour
{
    public AudioClip[] clip;

    public void play(int index)
    {
        if (clip[index] != null)
        {
            GetComponent<AudioSource>().PlayOneShot(clip[index], 0.8f);
        }
    }

    IEnumerator destroyObjects(GameObject ef)
    {
        yield return new WaitForSeconds(2.0f);

        if (ef != null)
        {
            Destroy(ef);
            ef = null;
        }
    }

    public void destroyEffects(GameObject ef)
    {
        StartCoroutine(destroyObjects(ef));
    }
}
