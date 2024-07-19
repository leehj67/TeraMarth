using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.XR.Interaction.Toolkit;

public class DropBlock : MonoBehaviour
{
    private XRGrabInteractable grabInteractable;
    private GameObject clonedObject;
    private bool isClonedObjectGrabbed = false;
    private Vector3 tempPos;
    private Quaternion tempRot;
    private Vector3 tempSca;
    public int itemCode = 0;

    void Start()
    {
        grabInteractable = GetComponent<XRGrabInteractable>();
        grabInteractable.selectEntered.AddListener(OnGrab);
        grabInteractable.selectExited.AddListener(OnRelease);
        tempPos = transform.position;
        tempRot = transform.rotation;
        tempSca = transform.localScale;
    }

    private void OnGrab(SelectEnterEventArgs args)
    {
        GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
        transform.rotation = Quaternion.Euler(transform.rotation.x-90, transform.rotation.y, transform.rotation.z);
        isClonedObjectGrabbed = true;

    }

    private void OnRelease(SelectExitEventArgs args)
    {
        transform.position = tempPos;
        transform.rotation = tempRot;
        transform.localScale = tempSca;
        GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;
        isClonedObjectGrabbed = false;
        
        //Destroy(gameObject, 0.2f);
        
    }
}
