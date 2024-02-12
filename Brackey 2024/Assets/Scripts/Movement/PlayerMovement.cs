using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerMovement : MonoBehaviour
{

    public Rigidbody2D rb;
    public float moveSpeed;
    public float moveX, moveY;
    private Vector2 moveDirection;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    //good for processing inputs
    void Update()
    {
        ProcessInputs();
    }


    //best to be used for physics calculations
    private void FixedUpdate()
    {
        Move();
    }

    void ProcessInputs()
    {
        //strictly gets 0 or 1
        moveX = Input.GetAxisRaw("Horizontal");
        moveY = Input.GetAxisRaw("Vertical");

        //normalized so that regardless of direction player moves at same speed
        moveDirection = new Vector2(moveX, moveY).normalized;
    }

    void Move()
    {
        rb.velocity = new Vector2(moveDirection.x * moveSpeed, moveDirection.y * moveSpeed);  
    }
}
