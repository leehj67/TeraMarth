using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyEffects : MonoBehaviour
{
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
