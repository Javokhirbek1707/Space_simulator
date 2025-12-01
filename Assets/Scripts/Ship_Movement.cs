using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ship_Movement : MonoBehaviour
{
    [SerializeField]
    private GameObject _ship;
    [SerializeField]
    private float _rotationSpeed;
    [SerializeField]
    private float _currentSpeed;
    [SerializeField]
    private GameObject _spaceShip;
    
    void Start()
    {
        _spaceShip.SetActive(false);
    }

   
    void Update()
    {
        ShipMovement();
        SpeedAccelerator();
    }
    private void ShipMovement()
    {
        float pitch = _rotationSpeed * Time.deltaTime * Input.GetAxis("Pitch");
        float yaw = _rotationSpeed * Time.deltaTime * Input.GetAxis("Horizontal");
        float roll = _rotationSpeed * Time.deltaTime * Input.GetAxis("Roll");

        transform.Rotate(pitch, yaw, roll);
    }

    private void SpeedAccelerator()
    {
        if (Input.GetKey(KeyCode.T))
        {
            _currentSpeed++;
            if (_currentSpeed > 4)
            {
                _currentSpeed = 4;
            }
        }
        if (Input.GetKey(KeyCode.G))
        {
            _currentSpeed--;
            if (_currentSpeed < 1)
            {
                _currentSpeed = 1;
            }
        }

        transform.position += transform.right * _currentSpeed * Time.deltaTime;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Trigger")
        {
            _spaceShip.SetActive(true);
            Debug.Log("Working");
        }
    }
}
