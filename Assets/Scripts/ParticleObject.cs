using System;
using Cysharp.Threading.Tasks;
using UniRx;
using UnityEngine;

[RequireComponent(typeof(ParticleSystem))]
public class ParticleObject : MonoBehaviour
{
    private ParticleSystem particle;

    void Awake()
    {
        particle = GetComponent<ParticleSystem>();
    }

    public async UniTask PlayParticle(Vector3 position)
    {
        transform.position = position;
        particle.Play();
        await UniTask.Delay(TimeSpan.FromSeconds(particle.main.startLifetimeMultiplier));
        particle.Stop();
    }
}
