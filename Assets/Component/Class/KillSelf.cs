using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillSelf : MonoBehaviour
{
    public void killSelf()
    {
        gameObject.SetActive(false);
    }
}
