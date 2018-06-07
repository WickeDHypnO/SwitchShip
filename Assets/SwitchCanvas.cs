using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class SwitchCanvas : MonoBehaviour {

	private void OnEnable() {
		GetComponent<CanvasGroup>().alpha = 1;
		GetComponent<CanvasGroup>().DOFade(0,1f).OnComplete(()=>gameObject.SetActive(false));
	}
}
