using System;
using UnityEngine;

public class CutSceneEntity : MonoBehaviour
{
    public static Action OnDied;

    private void OnDestroy()
    {
        OnDied?.Invoke();
    }
}
