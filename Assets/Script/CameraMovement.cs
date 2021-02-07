using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public GameObject Player;
    private Vector3 _offset;
    [SerializeField] float _lerpSpeed = 0.1f;

    void Start()
    {
        _offset = transform.position - Player.transform.position;
    }
    void FixedUpdate()
    {
        var desiredPosition = Player.transform.position + _offset;

        var posZ = Mathf.Lerp(transform.position.z, desiredPosition.z, _lerpSpeed);

        desiredPosition.z = posZ;

        transform.position = desiredPosition;
    }
}
