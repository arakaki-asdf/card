using System.Collections;
using System.Collections.Generic;
using UniRx.Toolkit;
using UnityEngine;

/// <summary>
/// パーティクルプール
/// https://qiita.com/KeichiMizutani/items/fc22a6037447d840adc2
/// </summary>
public class ParticlePool : ObjectPool<ParticleObject>
{
    readonly ParticleObject _prefab;
    readonly Transform _parentTransform;

    public ParticlePool(Transform transform, ParticleObject prefab)
    {
        _parentTransform = transform;
        _prefab = prefab;
    }

    protected override ParticleObject CreateInstance()
    {
        return Object.Instantiate(_prefab, _parentTransform, true);
    }
}
