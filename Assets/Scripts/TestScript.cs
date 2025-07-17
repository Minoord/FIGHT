using System;
using CameraSystem;
using CameraSystem.CameraPoints;
using UnityEngine;

public class TestScript : MonoBehaviour
{
    [SerializeField] private CameraManager _cameraManager;
    [SerializeField] private BasicCameraPoint _cameraPoint;
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            _cameraManager.NextCameraPoint();
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            _cameraManager.NextCameraPoint(_cameraPoint);
        }
    }
}
