using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class frogMovement : MonoBehaviour
{
    
<<<<<<< Updated upstream
=======
    
>>>>>>> Stashed changes
    Rigidbody2D _rigidbody2d;
    private float horizontal;
    private float jumpHeight = 8f;
    private float speed = 5f;
    
    private bool jumped = false;
    private bool doubleJumped = false;
    private bool falling = false;
    private bool hurt = false;
 
    private float hurtTime;



    Animator _animator;
    // Start is called before the first frame update
    void Awake()
    {
        _rigidbody2d = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
  
    }

    // Update is called once per frame
    void Update()
    {
<<<<<<< Updated upstream
=======
        
>>>>>>> Stashed changes
        //cheching for movement 
        horizontal = Input.GetAxis("Horizontal");
        
        
        if (Input.GetButtonDown("Jump"))
        {
            //Double jump
            if(jumped || (falling && !doubleJumped))
            {
                _rigidbody2d.velocity = Vector3.zero;
                _rigidbody2d.AddForce(new Vector2(0, jumpHeight), ForceMode2D.Impulse);
                FindObjectOfType<AudioManager>().Play("DoubleJump");
                StartCoroutine(doubleJump());
                jumped = false;
                doubleJumped = true;
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
            doubleJumped = false;
            _animator.SetBool("onGround", true);
        }
        falling = (localVel.y < 0 ? true : false);


    }

    private void FixedUpdate()
    {
        transform.position += new Vector3(horizontal, 0, 0) * Time.deltaTime * speed;
    }

    public void slowMovement()
    {
        speed /= 2;
        jumpHeight /= 1.5f;
        hurt = true;
        hurtTime = Time.time;
    }

    public void applyForceX(float force)
    {
        _rigidbody2d.AddForce(new Vector2(force, 0), ForceMode2D.Impulse);
    }

    private IEnumerator doubleJump()
    {
        _animator.SetBool("doubleJump", true);
        _animator.Play("doubleJump");
        yield return new WaitForSeconds(0.3f);

        _animator.SetBool("doubleJump", false);
    }
}