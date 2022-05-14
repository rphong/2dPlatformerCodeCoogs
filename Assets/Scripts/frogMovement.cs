using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class frogMovement : MonoBehaviour
{
    Rigidbody2D _rigidbody2d;
    private float horizontal;
    private float jumpHeight = 8f;
    private float speed = 5f;

    private bool jumped = false;
    private bool hurt = false;
    private float hurtTime;

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
        if (Input.GetButtonDown("Jump"))
        {
            //Double jump
            if(jumped)
            {
                _rigidbody2d.AddForce(new Vector2(0, jumpHeight), ForceMode2D.Impulse);
                jumped = false;
            }
            //Single jump
            if (Mathf.Abs(_rigidbody2d.velocity.y) < 0.01f)
            {
                _rigidbody2d.AddForce(new Vector2(0, jumpHeight), ForceMode2D.Impulse);
                FindObjectOfType<AudioManager>().Play("jump");
                _animator.SetBool("onGround", false);
                jumped = true;
            }
        }

        //.75s after player is hurt, return to normal speed
        if (hurt && Time.time - hurtTime > 0.75f)
        {
            speed *= 2;
            jumpHeight *= 1.5f;
            hurt = false;
        }

        //Animating jump/fall
        _animator.SetFloat("velocityX", Mathf.Abs(horizontal));

        //Animating left/right facing
        if (Mathf.Abs(horizontal) > .1f)
            _animator.SetFloat("directionX", horizontal);

        //Checking if character is on ground
        var localVel = transform.InverseTransformDirection(_rigidbody2d.velocity);
        _animator.SetFloat("velocityY", localVel.y);
        if (Mathf.Abs(localVel.y) < .1f)
        {
            jumped = false;
            _animator.SetBool("onGround", true);
        }
    }

    private void FixedUpdate()
    {
        transform.position += new Vector3(horizontal, 0, 0) * Time.deltaTime * speed;
    }

    public void stopMovement()
    {
        speed /= 2;
        jumpHeight /= 1.5f;
        hurt = true;
        hurtTime = Time.time;
    }
}