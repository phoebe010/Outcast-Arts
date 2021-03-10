using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour{

    public float speed;
    public float jumpForce;
    private float moveInput;

    //variables for ladder movement
    private float inputVertical;
    public float distance;
    public LayerMask whatIsLadder;
    private bool isClimbing;

    private Rigidbody2D rb;
    Rigidbody2D myRigidBody;

    private bool facingRight = true;

    private bool isGrounded;
    public Transform groundCheck;
    public float checkRadius;
    public LayerMask whatIsGround;

    private int extraJumps;
    public int extraJumpsValue;


    void Start(){
        extraJumps = extraJumpsValue;
        rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate(){

        //checks to see if player is touching the ground
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, checkRadius, whatIsGround);

        //moves player left and right with arrow keys (add "Raw" after "GetAxis" to make movement more snappy)
        moveInput = Input.GetAxisRaw("Horizontal");
        Debug.Log(moveInput);
        rb.velocity = new Vector2(moveInput * speed, rb.velocity.y);

        //flips character based on which way they are moving
        if (facingRight == false && moveInput > 0){
            Flip();
        } else if(facingRight == true && moveInput < 0){
            Flip();
        }

        //checks to see if player is in contact with ladder
        RaycastHit2D hitInfo = Physics2D.Raycast(transform.position, Vector2.up, distance, whatIsLadder);

        if(hitInfo.collider != null){
            if (Input.GetKeyDown(KeyCode.UpArrow)){
                isClimbing = true;
            }
        } else{
            isClimbing = false;
        }

        if(isClimbing == true){
            inputVertical = Input.GetAxisRaw("Vertical");
            rb.velocity = new Vector2(rb.velocity.x, inputVertical * speed);
            rb.gravityScale = 0;
        }
        else{
            rb.gravityScale = 5;
        }
    }

    void Update(){

        if(isGrounded == true){
            extraJumps = extraJumpsValue;
        }

        if(Input.GetKeyDown(KeyCode.Space) && extraJumps > 0){
            rb.velocity = Vector2.up * jumpForce;
            extraJumps--;
        } else if(Input.GetKeyDown(KeyCode.Space) && extraJumps == 0 && isGrounded == true){
            rb.velocity = Vector2.up * jumpForce;
        }
    }

    void Flip(){

        facingRight = !facingRight;
        Vector3 Scaler = transform.localScale;
        Scaler.x *= -1;
        transform.localScale = Scaler;
    }
   
   
}
