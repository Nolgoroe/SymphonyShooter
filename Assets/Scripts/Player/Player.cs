using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] float moveSpeed;
    [SerializeField] Rigidbody2D rb;
    [SerializeField] Vector2 moveDir;

    [SerializeField] Vector2 latestMoveDir;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        latestMoveDir = new Vector2(1, 0); ///make sure that knife shoots correctly even if we do not move.
    }

    void Update()
    {
        InputManager();
    }
    private void FixedUpdate()
    {
        Move();
    }

    private void InputManager()
    {
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");

        moveDir = new Vector2(moveX, moveY).normalized;


        if(moveDir.x != 0)
        {
            latestMoveDir = new Vector2(moveDir.x, 0);
        }

        if(moveDir.y != 0)
        {
            latestMoveDir = new Vector2(0, moveDir.y);
        }

        if(moveDir.x != 0 && moveDir.y != 0)
        {
            latestMoveDir = new Vector2(moveDir.x, moveDir.y);
        }
    }

    private void Move()
    {
        rb.velocity = new Vector2 (moveDir.x * moveSpeed, moveDir.y * moveSpeed);
    }






    public Vector2 ReturnCurrentMoveDirection()
    {
        return moveDir;
    }
    public Vector2 ReturnLatestMoveDirection()
    {
        return latestMoveDir;
    }
}
