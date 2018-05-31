using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class RelativeBounce : MonoBehaviour {

	Vector3 nextPosition;
	public float movementRandomRange;
	public float rotationRandomRange;
	public float moveTime = 1f;
	void Start () {
		NextBouncePosition();
	}

	void NextBouncePosition()
	{
		nextPosition = new Vector3(Random.Range(-movementRandomRange, movementRandomRange),Random.Range(-movementRandomRange, movementRandomRange),0);
		transform.DOLocalMove(nextPosition, moveTime).OnComplete(NextBouncePosition).SetEase(Ease.Linear);
		transform.DOLocalRotate(new Vector3(0, 0,Random.Range(-rotationRandomRange, rotationRandomRange)), moveTime, RotateMode.Fast);
	}

}
