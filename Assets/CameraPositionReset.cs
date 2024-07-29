using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraPositionReset : MonoBehaviour
{
    // Start is called before the first frame update
  void Start()
    {
        Recenter();
    }

    public void Recenter()
    {
        // Oculus SDK를 통한 사용자 뷰 재설정
        OVRManager.display.RecenterPose();
    }
}
