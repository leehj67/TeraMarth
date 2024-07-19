using System.Collections;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit.Inputs;

public class SitDownUp : MonoBehaviour
{
    public Transform player; // 플레이어(카메라 리그)
    public Transform chairSitPosition; // 의자에 앉는 위치를 설정
    public GameObject screen; // 인게임 스크린

    private bool isSitting = false;

    public void SitDown()
    {
        player.position = new Vector3(chairSitPosition.position.x,
            chairSitPosition.position.y, chairSitPosition.position.z);
        player.rotation = chairSitPosition.rotation;
        InputActionManager act = player.GetComponentInChildren<InputActionManager>();
        CapsuleCollider cap = player.GetComponentInChildren<CapsuleCollider>();
        Rigidbody rig = player.GetComponentInChildren<Rigidbody>();
        if (act != null)
        {
            act.enabled = false;
        }
        if (cap != null)
        {
            cap.enabled = false;
        }
        if (rig != null)
        {
            rig.useGravity = false;
        }
        screen.SetActive(true);
        StartCoroutine(WaitForIt());
    }

    IEnumerator WaitForIt()
    {
        yield return new WaitForSeconds(0.5f);
        isSitting = true;
    }

    void Update()
    {
        if (OVRInput.GetDown(OVRInput.Button.Two))
        {
            if (isSitting)
            {
                InputActionManager act = player.GetComponentInChildren<InputActionManager>();
                CapsuleCollider cap = player.GetComponentInChildren<CapsuleCollider>();
                Rigidbody rig = player.GetComponentInChildren<Rigidbody>();
                if (act != null)
                {
                    act.enabled = true;
                }
                if (cap != null)
                {
                    cap.enabled = true;
                }
                if (rig != null)
                {
                    rig.useGravity = true;
                }
                screen.SetActive(false);
                isSitting = false;
            }
        }
    }

}
