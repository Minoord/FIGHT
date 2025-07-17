using System.Collections.Generic;
using CameraSystem.CameraPoints;
using UnityEngine;

namespace CameraSystem
{
    public class CameraManager : MonoBehaviour
    {
        [SerializeField] private Camera _camera;
        [SerializeField] private List<BasicCameraPoint> _cameraPoints;
        
        private ICameraPoint _nextPoint;
        
        private int _currentPointIndex;
        private bool _isLerping;
        private List<ICameraPoint> _cameraPointsQueue = new();

        private void Start()
        {
            if (_cameraPoints == null || _cameraPoints.Count == 0)
            {
                Debug.LogError("No camera points assigned, please assign one in the inspector.");
                enabled = false;
                return;
            }
            
            ICameraPoint firstPoint = _cameraPoints[_currentPointIndex];
            
            _camera.transform.position = firstPoint.Transform.position;
            _camera.transform.rotation = firstPoint.Transform.rotation;
            _camera.fieldOfView = firstPoint.FOV;
        }

        private void Update()
        {
            if (!_isLerping && _cameraPointsQueue.Count > 0)
            {
                _nextPoint = _cameraPointsQueue[0];
                _cameraPointsQueue.RemoveAt(0);
                
                _isLerping = true;
                
            }

            if (_isLerping)
            {
                SetCameraValues();
            }
        }

        public void NextCameraPoint()
        {
            if (_currentPointIndex >= _cameraPoints.Count - 1)
            {
                return;
            }
            
            _currentPointIndex++;
            _cameraPointsQueue.Add(_cameraPoints[_currentPointIndex]);
        }

        public void NextCameraPoint(ICameraPoint nextPoint)
        {
            _cameraPointsQueue.Add(nextPoint);
        }

        private void SetCameraValues()
        {
            Transform currentTransform = _camera.transform;
            Transform nextTransform = _nextPoint.Transform;
            float time = _nextPoint.TransitionSpeed * Time.deltaTime;
            
            _camera.transform.position = Vector3.Lerp(currentTransform.position, nextTransform.position, time);
            _camera.transform.rotation = Quaternion.Lerp(currentTransform.rotation, nextTransform.rotation, time);
            
            _camera.fieldOfView = Mathf.Lerp(_camera.fieldOfView, _nextPoint.FOV, _nextPoint.FOVTransitionSpeed* Time.deltaTime);

            if (currentTransform.position != nextTransform.position ||
                currentTransform.rotation != nextTransform.rotation ||
                Mathf.Abs(_nextPoint.FOV - _camera.fieldOfView) > 0.01f)
            {
                return;
            }
            
            _isLerping = false;
            _nextPoint = null;
        }
    }
}
