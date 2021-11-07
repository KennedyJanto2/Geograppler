using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BodyFlip : MonoBehaviour
{
    private float moveInput;
    private bool facingRight = true;

    void Update(){
        moveInput = Input.GetAxis("Horizontal");
    }

    void FixedUpdate()
    {
        if(facingRight == false && moveInput > 0){
            Flip();
        }
        else if(facingRight == true && moveInput <0){
            Flip();
        }
    }
    void Flip()
    {
        facingRight = !facingRight;
        Vector3 Scaler = transform.localScale;
        Scaler.x *= -1;
        transform.localScale = Scaler;

    }
    
}
