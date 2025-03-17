using UnityEngine;
using Fusion;

public class PlayerSetup : NetworkBehaviour
{
    public void SetupCamera()
    {
        if (Object.HasInputAuthority)
        {
            //CameraFollow cameraFollow = FindObjectOfType<CameraFollow>();
            CameraFollow cameraFollow = FindFirstObjectByType<CameraFollow>();
            if (cameraFollow != null)
            {
                cameraFollow.AssignCamera(transform);
            }
        }
    }
}
