using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.XR.Interaction.Toolkit;

public enum Category
{
    None,
    vegitable,
    animal
}

public class DropBlock : MonoBehaviour
{
    private XRGrabInteractable grabInteractable;
    private Vector3 tempPos;
    private Quaternion tempRot;
    private Vector3 tempSca;
    public VRObjectRay vror;
    public SelectedItem selItem;
    public int itemCode = 0;
    public Category category;

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
        transform.rotation = Quaternion.Euler(transform.rotation.x+90, transform.rotation.y, transform.rotation.z);
        selItem.setItem(itemCode, category);
    }

    private void OnRelease(SelectExitEventArgs args)
    {
        transform.position = tempPos;
        transform.rotation = tempRot;
        transform.localScale = tempSca;
        GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;
        vror.setCondition(true);
    }
}
