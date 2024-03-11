using UnityEngine;
using UniRx;
using UniRx.Triggers;
using Cysharp.Threading.Tasks;
using UniRx.Toolkit;
using System;

public class CardPoolGenerator : MonoBehaviour
{
    [SerializeField] ParticleObject _particlePrefab;
    [SerializeField] AnimatorObject _animatorPrefab;

    ParticlePool _particlePool;
    AnimatorPool _animatorPool;

    void Awake()
    {
        _particlePool = new ParticlePool(transform, _particlePrefab);
        _animatorPool = new AnimatorPool(transform, _animatorPrefab);
    }

    void Destroy()
    {
        _particlePool.Dispose();
        _animatorPool.Dispose();
    }

    public void Play<T>() where T : UnityEngine.Component
    {
        // var pool = new ObjectPool<T>();
    }


    public async UniTask PlayParticle(Vector3 position)
    {
        var effect = _particlePool.Rent();
        await effect.PlayParticle(position);
        _particlePool.Return(effect);
    }

    public async UniTask PlayAnimator(Vector3 position)
    {
        var animator = _animatorPool.Rent();
        await animator.PlayAnimation(position);
        _animatorPool.Return(animator);
    }
}