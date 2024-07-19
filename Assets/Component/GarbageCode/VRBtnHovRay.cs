using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VRBtnHovRay : MonoBehaviour
{
    public static VRBtnHovRay instance;

    public Transform rightHand;

    public string TagName;
    public TopTabManager topTabMan;
    public Material hovMaterial;

    private Material temp = null;
    private GameObject prev = null;
    bool lockprev = false;

    void Start()
    {
        
    }

    void Update()
    {
        Ray ray = new Ray(rightHand.position, rightHand.forward);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit) && hit.collider.CompareTag(TagName))
        {
            if (lockprev || hit.collider.GetComponent<TopTabClass>().selected) return;

            prev = hit.collider.gameObject;
            temp = hit.collider.GetComponent<Renderer>().material;
            hit.collider.GetComponent<Renderer>().material = hovMaterial;
            lockprev = true;

        }
        else
        {
            if (prev == null) return;
            prev.GetComponent<Renderer>().material = temp;
            prev = null;
            lockprev = false;
        }
    }
}
