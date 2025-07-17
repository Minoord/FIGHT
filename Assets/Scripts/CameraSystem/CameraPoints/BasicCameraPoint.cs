using UnityEngine;

namespace CameraSystem.CameraPoints
{
    public class BasicCameraPoint : MonoBehaviour, ICameraPoint
    {
        [SerializeField] private float _fieldOfView;
        [SerializeField] private float _transitionSpeed;
        [SerializeField] private float _fovTransitionSpeed;

        public Transform Transform => transform;
        public float FOV => _fieldOfView;
        public float TransitionSpeed => _transitionSpeed;
        public float FOVTransitionSpeed => _fovTransitionSpeed;
    }
}