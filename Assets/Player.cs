using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] float moveSpeed;
    [SerializeField] Rigidbody2D rb;
    [SerializeField] Vector2 moveDir;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        
    }

    private void InputManager()
    {
        float moveX = Input.GetAxis("Horizontal");
        float moveY = Input.GetAxis("Vertical");

        moveDir = new Vector2(moveX, moveY).normalized;
    }

    private void Move()
    {

    }
}
