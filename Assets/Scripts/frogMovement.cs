using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class frogMovement : MonoBehaviour
{
    Rigidbody2D _rigidbody2d;
    private float horizontal;
    private float jumpHeight = 10f;
    private float speed = 5f;

    Animator _animator;
    // Start is called before the first frame update
    void Start()
    {
        _rigidbody2d = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        horizontal = Input.GetAxis("Horizontal");
        if (Input.GetButtonDown("Jump") && Mathf.Abs(_rigidbody2d.velocity.y) < 0.01f)
        {
            _rigidbody2d.AddForce(new Vector2(0, jumpHeight), ForceMode2D.Impulse);
            FindObjectOfType<AudioManager>().Play("jump");
        }
    }

    private void FixedUpdate()
    {
        transform.position += new Vector3(horizontal, 0, 0) * Time.deltaTime * speed;
        _animator.SetFloat("directionX", horizontal);
    }
}