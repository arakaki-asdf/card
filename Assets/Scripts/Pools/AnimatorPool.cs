using System.Collections;
using System.Collections.Generic;
using UniRx.Toolkit;
using UnityEngine;

/// <summary>
/// パーティクルプール
/// https://qiita.com/KeichiMizutani/items/fc22a6037447d840adc2
/// </summary>
public class AnimatorPool : ObjectPool<AnimatorObject>
{
    readonly AnimatorObject _prefab;
    readonly Transform _parentTransform;

    public AnimatorPool(Transform transform, AnimatorObject prefab)
    {
        _parentTransform = transform;
        _prefab = prefab;
    }

    protected override AnimatorObject CreateInstance()
    {
        return Object.Instantiate(_prefab, _parentTransform, true);
    }
}
