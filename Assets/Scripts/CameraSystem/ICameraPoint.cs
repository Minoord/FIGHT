using UnityEngine;

namespace CameraSystem
{
    public interface ICameraPoint
    {
        Transform Transform { get; }
        float FOV { get; }
        float TransitionSpeed { get; }
        float FOVTransitionSpeed { get; }
    }
}
