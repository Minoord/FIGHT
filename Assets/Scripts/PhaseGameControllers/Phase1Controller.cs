using System;
using System.Threading.Tasks;
using Application.Statemachine;
using CameraSystem;
using PlayerControllers;
using UnityEngine;
using WaveSpawnSystem;

public class Phase1Controller : MonoBehaviour
{
    [SerializeField] private CameraManager _cameraManager;
    [SerializeField] private CutSceneEntity _cuteSceneEntity1;
    [SerializeField] private CutSceneEntity _cuteSceneEntity2;
    [SerializeField] private PhaseInfo _phaseInfo;

    private bool _movePlayer;
    private Vector3 _endPosition;
    
    private void Start()
    {
        _cameraManager.NextCameraPoint();
        _cameraManager.OnPointReached += StartCutScene;
    }

    private void Update()
    {
        if (_movePlayer)
        {
            PlayerController.Instance.transform.position = Vector3.MoveTowards(PlayerController.Instance.transform.position, _endPosition, 2 * Time.deltaTime);
            
            float distancePos = Vector3.Distance(PlayerController.Instance.transform.position, _endPosition);
            if (distancePos < 0.1f)
            {
                _movePlayer = false;
            }
        }
    }

    private async void StartCutScene()
    {
        _cameraManager.OnPointReached -= StartCutScene;
        // Play Animation 1
        //Wait for animation
        // Play animation 2
        //Wait for animation
        _endPosition = _cuteSceneEntity1.transform.position;
        PlayerController.Instance.ShootForCutScene(_endPosition);
        _movePlayer = true;
        CutSceneEntity.OnDied += OnSecondCutSceneStart;
    }

    private async void OnSecondCutSceneStart()
    {
        await Task.Delay(1000);
        _cameraManager.NextCameraPoint();
        // Play shock animation for 2 
        PlayerController.Instance.ShootForCutScene(_cuteSceneEntity2.transform.position);
        CutSceneEntity.OnDied += OnThirdCutSceneStart;
        // await animation
    }

    private void OnThirdCutSceneStart()
    {
        _cameraManager.NextCameraPoint();
        PlayerController.Instance.Init();
        WaveSpawner.Instance.StartPhase(_phaseInfo);
    }
}
