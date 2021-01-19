using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public GameObject Cube;
    public Vector3 Direction;
    public float MaxDistance = 5;
    public float rotateSpeed = 1;
    public float growPoint = 0.001f;
    private float _sign = 1;

    private void Update()
    {
        Cube.transform.position += _sign * Direction * Time.deltaTime;
        if (MaxDistance <= Cube.transform.position.magnitude)
        {
            _sign *= -1;
        }
            transform.localScale = new Vector3(transform.localScale.x,transform.localScale.y + growPoint ,transform.localScale.z);
        
        transform.Rotate(0, rotateSpeed * Time.deltaTime, 0, Space.World);
        
    }

}
