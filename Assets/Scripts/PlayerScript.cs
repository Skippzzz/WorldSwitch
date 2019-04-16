using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerScript : MonoBehaviour
{

    //SoundTest part
    public AudioClip jumpSound;
    public AudioClip hazardCollision;
    //--------------
   

    //
    public float speed = 5f;
    private float moveInput;
    public Vector2 jumpHeight = new Vector2(0, 5.5f);

    private Rigidbody2D rb;

    private bool facingRight = true;

    private bool isGrounded;
    public Transform groundCheck;
    public float checkRadius = 0.2f;
    public LayerMask whatIsGround;

    public float fallForce = 1.2f;

    static public bool isCollidingX;
    static public bool isCollidingY;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        isCollidingX = false;
        isCollidingY = false;
    }

    void FixedUpdate()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, checkRadius, whatIsGround);

        moveInput = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(moveInput * speed, rb.velocity.y);

        if (facingRight == false && moveInput > 0) { Flip(); }
        else if (facingRight == true && moveInput < 0) { Flip(); }
    }

    private void Update()
    {
        //Allows character to jump a specified amount of times
        if (Input.GetButtonDown("Jump") && isGrounded == true)
        {
            rb.AddForce(jumpHeight, ForceMode2D.Impulse);

            //SoundTest part
            SoundManager.instance.PlaySingle(jumpSound);
            //--------------
        }

        //Apply extra gravity to fall
        if (rb.velocity.y < 0)  //checks if character is falling
        {
            rb.velocity += Vector2.up * Physics2D.gravity.y * (fallForce - 1) * Time.deltaTime;
        }
    }

    //Flips the direction the character is facing to match the direction the characer is moving
    void Flip()
    {
        facingRight = !facingRight;
        Vector3 Scalar = transform.localScale;
        Scalar.x *= -1;
        transform.localScale = Scalar;
    }

    //Checks if player enters the collision box of anything with the tag "Hazard" if it does the level restarts
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Hazard")
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            //SoundTest part
            SoundManager.instance.PlaySingle(hazardCollision);
            //--------------
        }

        if (collision.gameObject.tag == "CameraBorderX")
        {
            isCollidingX = true;
        }

        if (collision.gameObject.tag == "CameraBorderY")
        {
            isCollidingY = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "CameraBorderX")
        {
            isCollidingX = false;
        }

        if (collision.gameObject.tag == "CameraBorderY")
        {
            isCollidingY = false;
        }
    }
}

