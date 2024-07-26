using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlShuttle : MonoBehaviour
{
    public GameObject shuttle;
    public float speed = 7;
    public float corr = 1.61f;

    public Transform rightHand;
    public string tagWallName;
    public string tagTargetName;
    public Transform crossHair;
    public float defaultSize = 2.0f;
    public float crossHairDistance = 87.0f;

    public float spm = 200;
    public float bulletSpeed = 100;
    public GameObject bullets;

    private Rigidbody rb;
    private Vector2 thumbstick;

    private bool tagTarget;
    private float changedScale;

    private float curT = 0;
    
    void Start()
    {
        rb = shuttle.GetComponent<Rigidbody>();
    }

    private void OnDisable()
    {
        crossHair.gameObject.SetActive(false);
    }

    void moveController()
    {
        if(rb != null)
        {
            thumbstick = OVRInput.Get(OVRInput.Axis2D.PrimaryThumbstick);
            rb.velocity = new Vector2(thumbstick.x * speed * corr, thumbstick.y * speed);
        }
    }

    void traceCrossHair()
    {
        RaycastHit[] hits = Physics.RaycastAll(rightHand.position, rightHand.forward, Mathf.Infinity);
        tagTarget = false;
        
        foreach (RaycastHit hit in hits)
        {
            if (hit.collider.CompareTag(tagTargetName))
            {
                crossHair.gameObject.SetActive(true);
                crossHair.rotation = Quaternion.LookRotation(rightHand.forward);
                crossHair.position = hit.point;
                changedScale = (hit.point - rightHand.position).magnitude / crossHairDistance;
                crossHair.localScale = new Vector3(defaultSize * changedScale, defaultSize * changedScale, 0.02f);
                tagTarget = true;
                break;
            }
            else if (hit.collider.CompareTag(tagWallName))
            {
                crossHair.gameObject.SetActive(true);
                crossHair.rotation = Quaternion.LookRotation(rightHand.forward);
                crossHair.position = rightHand.position + rightHand.forward.normalized * crossHairDistance;
                crossHair.localScale = new Vector3(defaultSize, defaultSize, 0.02f);
                tagTarget = true;
            }  
        }
        if (!tagTarget)
        {
            crossHair.gameObject.SetActive(false);
        }
    }

    void shooting()
    {
        if (crossHair.gameObject.activeSelf && OVRInput.Get(OVRInput.Button.SecondaryIndexTrigger) && curT > 60 / spm)
        {
            GameObject bullet = Instantiate(bullets, shuttle.transform.position + new Vector3(0, 0, 3), Quaternion.identity);
            bullet.GetComponent<Rigidbody>().velocity = (crossHair.position - bullet.transform.position).normalized * bulletSpeed;
            bullet.transform.rotation = Quaternion.LookRotation(bullet.GetComponent<Rigidbody>().velocity) * Quaternion.Euler(90, 0, 0);
            curT = 0;
        }
    }

    void Update()
    {
        curT += Time.deltaTime;
        moveController();
        traceCrossHair();
        shooting();
    }
}
