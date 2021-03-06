﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineRenderController : MonoBehaviour
{
    [SerializeField] LineRenderer lineRenderer;
    private Transform[] points;

    public void SetUpLine(Transform[] points)
    {
        lineRenderer.positionCount = points.Length;
        this.points = points;
    }

    // Update is called once per frame
    void Update()
    {
        for(int i = 0; i< points.Length; i++)
        {
            lineRenderer.SetPosition(i, points[i].position);
        }
    }
}
