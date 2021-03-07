using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{

    [SerializeField] float jumpForce;
    [SerializeField] float speed;
    [SerializeField] ParticleSystem particle;

    private Rigidbody _rb;
    private float _distToGround;
    public Collider Coll;


    private void Start()
    {
        _rb = GetComponent<Rigidbody>();

        _distToGround = Coll.bounds.extents.y;
    }

    private void FixedUpdate()
    {
        if (GameController.Instance.CanMove)
        {
            transform.Translate(Vector3.left * Time.deltaTime * speed);
        }

        if (Input.GetKey(KeyCode.Space) && IsGrounded() && GameController.Instance.CanMove)
        {
            _rb.velocity = new Vector3(_rb.velocity.x, jumpForce, _rb.velocity.z);
        }
        
    }

    private bool IsGrounded()
    {
        return Physics.Raycast(transform.position, -Vector3.up, _distToGround + 0.1f);
    }

    private void OnCollisionEnter(Collision coll)
    {
        if (coll.gameObject.tag == "Obstacle")
        {
            particle.Play();

            GameController.Instance.CanMove = false;
            Debug.Log(Menu.PlayerName.ToString()+" is dead \n" + GameController.Instance.UIController.Distance.text );

        }

        if (coll.gameObject.tag == "Finish")
        {
            GameController.Instance.CanMove = false;
            Debug.Log("!!!!!!WIN!!!!!!");
        }
    }

    
}
