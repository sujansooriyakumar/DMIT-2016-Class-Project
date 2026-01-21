using UnityEngine;
using Unity.Cinemachine;

public class CameraController : MonoBehaviour
{
    CinemachinePositionComposer positionComposer;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        positionComposer = GetComponent<CinemachinePositionComposer>();
        positionComposer.Lookahead.IgnoreY = true;
    }

  
}
