using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CameraSwitch : MonoBehaviour
{
    [SerializeField]
    private GameObject[] _cameras;
    private int currentCameras;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.R))
        {
            currentCameras++;
            if(currentCameras >= _cameras.Length)
            {
                currentCameras = 0;
            }
            SwitchCameras();
            CurrentCamera();
        }
    }

    public void SwitchCameras()
    {
        foreach (var c in _cameras)
        {
            if(c.GetComponent<CinemachineVirtualCamera>())
            {
                c.GetComponent<CinemachineVirtualCamera>().Priority = 10;
            }
        }
    }

    public void CurrentCamera()
    {
        if (_cameras[currentCameras].GetComponent<CinemachineVirtualCamera>())
        {
            _cameras[currentCameras].GetComponent<CinemachineVirtualCamera>().Priority = 15;
        }
    }
}
