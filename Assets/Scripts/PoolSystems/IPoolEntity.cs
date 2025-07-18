using System;
using UnityEngine;

public interface IPoolEntity
{
    Action<IPoolEntity> OnDespawn { get; set; }

    void SetActive(bool active);

    void Reset();
}
