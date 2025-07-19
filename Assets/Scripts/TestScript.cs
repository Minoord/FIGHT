using System;
using CameraSystem;
using CameraSystem.CameraPoints;
using UnityEngine;
using WaveSpawnSystem;

public class TestScript : MonoBehaviour
{
    [SerializeField] private CameraManager _cameraManager;
    [SerializeField] private BasicCameraPoint _cameraPoint;
    [SerializeField] private PhaseInfo _phase;

    private void Start()
    {
        WaveSpawner.Instance.StartPhase(_phase);
    }

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
