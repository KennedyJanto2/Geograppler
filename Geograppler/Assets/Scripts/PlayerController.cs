using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed;
    public float jumpForce;
    private float moveInput;
    
    private Rigidbody2D rb;

    private bool isGrounded;
    public Transform groundCheck;
    public float checkRadius;
    public LayerMask whatIsGround;
    bool jumpRequest;

    private int extraJumps;
    public int extraJumpsValue;

    public float dashSpeed;
    public float startDashTime;

    private float dashTime;
    private int direction;


    // Start is called before the first frame update
    void Start()
    {
        dashTime = startDashTime;
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        moveInput = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(moveInput * speed, rb.velocity.y);

        if (isGrounded){
            extraJumps = extraJumpsValue;
        }

        if(Input.GetButtonDown("Jump") && extraJumps > 0){
            jumpRequest = true;
            extraJumps--;
        }
        else if(Input.GetButtonDown("Jump") && isGrounded == true && extraJumps == 0){
            rb.velocity = Vector2.up*jumpForce;
        }

        if (direction == 0 ){
            if(Input.GetKeyDown(KeyCode.LeftShift)){
                if(transform.localScale.x == -1){
                    direction = 1;
                }
                else if(transform.localScale.x == 1)
                {
                    direction = 2;
                }
            }
        }
        else{
            if(dashTime <= 0){
                direction = 0;
                dashTime = startDashTime;
                rb.velocity = Vector2.zero;
            }
            else
            {
                dashTime -= Time.deltaTime;
                if(direction == 1)
                {
                    rb.velocity = Vector2.left * dashSpeed;
                }
                else if(direction == 2)
                {
                    rb.velocity = Vector2.right * dashSpeed;
                }
            }
        }

    }

    void FixedUpdate()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, checkRadius, whatIsGround);

        if(jumpRequest){
            rb.velocity = Vector2.up*jumpForce;
            jumpRequest = false;
        }
    }
}
