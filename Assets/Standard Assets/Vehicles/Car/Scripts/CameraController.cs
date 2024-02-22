using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CameraController : MonoBehaviour
{
    public CinemachineVirtualCamera virtualCameraLeft;
    public CinemachineVirtualCamera virtualCameraRight;

    private void Start()
    {
        virtualCameraLeft.enabled = false;
        virtualCameraRight.enabled = false;
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha9))
        {
            enableCamera(virtualCameraLeft);
            disableCamera(virtualCameraRight);
        }

        if (Input.GetKeyDown(KeyCode.Alpha0))
        {
            enableCamera(virtualCameraRight);
            disableCamera(virtualCameraLeft);
        }
    }
    private void enableCamera(CinemachineVirtualCamera virtualCamera)
    {
        virtualCamera.enabled = !virtualCamera.enabled;
    }
    private void disableCamera(CinemachineVirtualCamera virtualCamera)
    {
        virtualCamera.enabled = false;
    }
}
