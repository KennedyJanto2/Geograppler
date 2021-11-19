using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class anime : MonoBehaviour
{
    private Animator anim;
    private bool isGrounded;
    public Transform groundCheck;
    public float checkRadius;
    public LayerMask whatIsGround;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if((Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D)) && isGrounded){
            anim.SetBool("isRunning", true);
        }
        else{
            anim.SetBool("isRunning", false);
        }

        if(Input.GetKeyDown(KeyCode.Space)){
            anim.SetTrigger("takeOf");
        }
        
        if(isGrounded){
            anim.SetBool("isJumping", false);
        }
        else{
            anim.SetBool("isJumping", true);
        }
    }

    void FixedUpdate(){
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, checkRadius, whatIsGround);
    }
}
