using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using UnityEngine.Playables;
public class CutSceenTrigger : MonoBehaviour
{
    [SerializeField] 
    private CinemachineVirtualCamera _camera;
    [SerializeField]
    private PlayableDirector _director;

    void Start()
    {
        _director = GetComponent<PlayableDirector>();
    }

   
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            _director.Play();
            _camera.GetComponent<CinemachineVirtualCamera>().Priority = 50;
        }
    }
}
