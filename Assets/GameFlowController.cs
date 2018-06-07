using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class GameFlowController : MonoBehaviour {
    public List<Transform> lanes;
    public List<Transform> defaultPoints;
    public List<Transform> switchedPoints;
    public GameObject defaultButtons;
    public GameObject switchedButtons;
    public bool switched = false;
    public ShipController ship;
    public float switchDelay = 0.2f;
    public float minSwitchTime;
    public float maxSwitchTime;
    float switchTimer;
    float timer;
    public GameObject switchCanvas;
    public IEnumerator Switch () {
        ship.canMove = false;
        yield return new WaitForSeconds (switchDelay);
        if (!switched) {
            switched = true;
            defaultButtons.SetActive (false);
            for (int i = 0; i < lanes.Count; i++) {
                ship.transform.parent = ship.points[ship.currentLane];
                lanes[i].transform.DOMove (new Vector3 (switchedPoints[i].position.x, switchedPoints[i].position.y, lanes[i].transform.transform.position.z), 0.2f);
                lanes[i].transform.DORotateQuaternion (switchedPoints[i].rotation, 0.2f).OnComplete (() => { switchedButtons.SetActive (true); ship.transform.parent = null; });
            }
        } else {
            switched = false;
            switchedButtons.SetActive (false);
            for (int i = 0; i < lanes.Count; i++) {
                ship.transform.parent = ship.points[ship.currentLane];
                lanes[i].transform.DOMove (new Vector3 (defaultPoints[i].position.x, defaultPoints[i].position.y, lanes[i].transform.transform.position.z), 0.2f);
                lanes[i].transform.DORotateQuaternion (defaultPoints[i].rotation, 0.2f).OnComplete (() => { defaultButtons.SetActive (true); ship.transform.parent = null; });
            }
        }
        yield return new WaitForSeconds (0.2f);
        ship.canMove = true;
    }

    void Update () {
#if UNITY_EDITOR
        if (Input.GetKeyDown (KeyCode.Space)) {
            StartCoroutine (Switch ());
        }
#endif
        timer += Time.deltaTime;
        if (timer >= switchTimer) {
            StartSwitch ();
            timer = 0;
            switchTimer  = Random.Range(minSwitchTime, maxSwitchTime);
        }
    }

    private void Start() {
        switchTimer  = Random.Range(minSwitchTime, maxSwitchTime);
    }
    void StartSwitch () {
        switchCanvas.SetActive (true);
        StartCoroutine (Switch ());
    }
}