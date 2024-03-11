using System.Collections;
using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using TMPro;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class AnimatorObject : MonoBehaviour
{
    private Animator _animator;

    void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    public async UniTask PlayAnimation(Vector3 position)
    {
        transform.position = position;
        var currentState = _animator.GetCurrentAnimatorStateInfo(0);
        var stateHash = currentState.fullPathHash;
        var normalizedYime = currentState.normalizedTime;
        _animator.Play(stateHash);
        await UniTask.WaitUntil(() => _animator.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1f); 
    }
}
