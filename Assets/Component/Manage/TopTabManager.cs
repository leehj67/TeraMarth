using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TopTabManager : MonoBehaviour
{
    public GameObject[] topTabs;
    public Material selectedMaterial;
    public Material unselectedMaterial;

    // Start is called before the first frame update
    void OnEnable()
    {
        for (int i = 0;  i < topTabs.Length; ++i)
        {
            if (topTabs[i].GetComponent<TopTabClass>().selected)
            {
                topTabs[i].GetComponent<Renderer>().material = selectedMaterial;
            }
            else
            {
                topTabs[i].GetComponent<Renderer>().material = unselectedMaterial;
            }
            
        }
    }

    // Update is called once per frame
    /*
    void Update()
    {
        
    }
    */
}
