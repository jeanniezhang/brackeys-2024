using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.Rendering.Universal;
using UnityEditor.Experimental.GraphView;

public class PlayerMovement : MonoBehaviour
{

    public Rigidbody2D rb;
    public float moveSpeed;
    public float sensitivity = 70.0f;
    public float adjustmentFactor = 5.0f;
    private float moveX, moveY;
    private Quaternion rotation;
    private Vector2 direction;
    private Vector2 moveDirection;
    public bool canMove;

    // Start is called before the first frame update
    void Start()
    {
        canMove = true;
    }

    //good for processing inputs
    void Update()
    {
        ProcessInputs();

    }


    //best to be used for physics calculations
    private void FixedUpdate()
    {
       if (canMove) Move();
    }

    void ProcessInputs()
    {
        //strictly gets 0 or 1
        moveX = Input.GetAxisRaw("Horizontal");
        moveY = Input.GetAxisRaw("Vertical");

        //used for changing player rotation based on mouse
        direction = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        rotation = Quaternion.AngleAxis(angle, Vector3.forward);

        //normalized so that regardless of direction player moves at same speed
        moveDirection = new Vector2(moveX, moveY).normalized;
    }


    //NOTE: in inspector set rigidbody to interpolate, otherwise you get stuttery movement
    void Move()
    {
        rb.velocity = new Vector2(moveDirection.x * moveSpeed / adjustmentFactor, moveDirection.y * moveSpeed / adjustmentFactor);
        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, sensitivity * Time.deltaTime);
    }

}
