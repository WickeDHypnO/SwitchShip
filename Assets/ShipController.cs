using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class ShipController : MonoBehaviour
{

    public List<Transform> points;
    public bool canMove = true;
    public int currentLane = 0;

    public void MoveToPoint(int index)
    {
        if (canMove)
        {
            currentLane = index;
            transform.DOMove(points[index].position, 0.2f);
            transform.DORotateQuaternion(points[index].rotation, 0.2f);
        }
    }
}
