﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    Rigidbody2D rb;

    [SerializeField] float moveSpeed;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    

    void Update()
    {
        if(transform.position.x < -15f)
        {
            Destroy(gameObject);
        }
    }

    private void FixedUpdate() //better for physics
    {
        rb.velocity = Vector2.left * moveSpeed;
    }

}
