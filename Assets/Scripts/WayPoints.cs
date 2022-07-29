using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WayPoints : MonoBehaviour
{
    public Transform[] points;
    private void Awake()
    {
        points = new Transform[transform.childCount]; // mang bang so phan tu con o trong
        for(int i = 0; i< points.Length; i++)
        {
            points[i] = transform.GetChild(i);

        }
    }
}
