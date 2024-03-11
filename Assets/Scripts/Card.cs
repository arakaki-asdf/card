using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using UniRx.Triggers;
using Cysharp.Threading.Tasks;
using System;

public class Card : MonoBehaviour
{
	public bool hasBeenPlayed;
	public int handIndex;

	public ParticleObject effect;
	public AnimatorObject hollowCircle;

	private Animator anim;
	private Animator camAnim;

	private void Start()
	{
		anim = GetComponent<Animator>();
		camAnim = Camera.main.GetComponent<Animator>();

		// this.UpdateAsObservable()
		// 	.Where(_ => Input.GetMouseButtonDown(0))
		// 	.Subscribe(_ => PlayPerticle().Forget())
		// 	.AddTo(this);
	}

	void OnMouseDown()
	{
		PlayPerticle();
	}

	private void PlayPerticle()
	{
		if (!hasBeenPlayed)
		{
			GameManager.Instance.cardPoolGenerator.PlayAnimator(transform.position).Forget();
			// Instantiate(hollowCircle, transform.position, Quaternion.identity);
			
			camAnim.SetTrigger("shake");
			anim.SetTrigger("move");

			transform.position += Vector3.up * 3f;
			hasBeenPlayed = true;
			GameManager.Instance.availableCardSlots[handIndex] = true;

			MoveToDiscardPile(0.5f).Forget();
		}
	}

	private async UniTask MoveToDiscardPile(float waitSeconds)
	{
		await UniTask.Delay(TimeSpan.FromSeconds(waitSeconds));

		// Instantiate(effect, transform.position, Quaternion.identity);
		GameManager.Instance.discardPile.Add(this);
		gameObject.SetActive(false);

		await GameManager.Instance.cardPoolGenerator.PlayParticle(transform.position);
	}
}
