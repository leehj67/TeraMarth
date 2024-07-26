using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyLife : MonoBehaviour
{
    public float lifeTime;
    private float curT = 0;

    void Update()
    {
        curT += Time.deltaTime;
        if (curT > lifeTime)
        {
            Destroy(gameObject);
        }
        
    }
}
