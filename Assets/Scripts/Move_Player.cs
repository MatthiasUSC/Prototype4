using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move_Player : MonoBehaviour
{
    private Rigidbody2D rb;

    public float moveSpeed;
    private float speedMilestoneCount;
    public float speedMultiplier;
    public float speedIncreaseMilestone;

    public float jumpForce;
    private bool isGrounded;
    public Transform feetPos;
    public float checkRadius;
    public LayerMask whatIsGround;

    public float slowDownOnCollision;

    private float jumpTimeCounter;
    public float jumpTime;
    private bool isJumping;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x > speedMilestoneCount)
        {
            speedMilestoneCount += speedIncreaseMilestone;
            if(isSlowingDown == false){ // Should only speed up when not in invunerability state after collision
                moveSpeed = moveSpeed * speedMultiplier;
            }
            
        }

        rb.velocity = new Vector2(moveSpeed, rb.velocity.y);

        isGrounded = Physics2D.OverlapCircle(feetPos.position, checkRadius, whatIsGround);

        if ( isGrounded == true && Input.GetKeyDown(KeyCode.Space) )
        {
            isJumping = true;
            jumpTimeCounter = jumpTime;
            rb.velocity =  new Vector2(moveSpeed, jumpForce);
        }

        if ( Input.GetKey(KeyCode.Space) && isJumping == true )
        {
            if(jumpTimeCounter > 0)
            {
                rb.velocity = new Vector2(moveSpeed, jumpForce);
                jumpTimeCounter -= Time.deltaTime;
            }
            else
            {
                isJumping = false;
            }
            
        }

        if(Input.GetKey(KeyCode.Space)){
            rb.gravityScale = 15;
        } else{
            rb.gravityScale = 5;
        }

        if( Input.GetKeyUp(KeyCode.Space) )
        {
            isJumping = false;
        }
    }

    bool isSlowingDown = false;
    IEnumerator slowDown(){
        Color orig = GetComponent<SpriteRenderer>().color;
        moveSpeed *= slowDownOnCollision;
        GetComponent<SpriteRenderer>().color = Color.red;
        yield return new WaitForSeconds(3.0f);
        GetComponent<SpriteRenderer>().color = orig;
        isSlowingDown = false;
    }

    void OnTriggerEnter2D(Collider2D col){
        if(isSlowingDown == false){
            isSlowingDown = true;
            StartCoroutine(slowDown());
        }
    }
}
