using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private Vector2 moveDirection;
    [SerializeField] private float speed;
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Animator anim;

    void Update()
    {
        Movement();
        Animate();
    }

    public void Movement()

    {
        float movex = Input.GetAxisRaw("Horizontal");
        float movey = Input.GetAxisRaw("Vertical");

        moveDirection = new Vector2(movex, movey).normalized;

        rb.velocity = new Vector2(moveDirection.x * speed, moveDirection.y * speed);
    }
    public void Animate()
    {
        anim.SetFloat("MoveX", moveDirection.x);
        anim.SetFloat("MoveY", moveDirection.y);
    }

}