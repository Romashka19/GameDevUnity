using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineRendererTest : MonoBehaviour
{
    [SerializeField] Transform[] points;
    [SerializeField] LineRenderController line;
    // Start is called before the first frame update
    void Start()
    {
        line.SetUpLine(points);
    }

}
