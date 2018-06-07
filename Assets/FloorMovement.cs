using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class FloorMovement : MonoBehaviour {

	public Transform nextFloor;
	public float maxZPosition;
	public float speed;
	public bool moveAtStart = false;

	void FixedUpdate () {
				if(transform.position.z <= maxZPosition)
		{
			transform.position = new Vector3(nextFloor.transform.position.x, nextFloor.transform.position.y, nextFloor.transform.position.z + 99);
		}
		transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z - speed);
	}
}
