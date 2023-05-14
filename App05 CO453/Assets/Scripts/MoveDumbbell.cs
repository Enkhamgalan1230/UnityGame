using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveDumbbell : MonoBehaviour
{
    private Rigidbody2D rb;
    private BoxCollider2D coll;
    [SerializeField] private float jumpForce = 8f;
    [SerializeField] private LayerMask jumpableGround;


    private void Start()

    {
        rb = GetComponent<Rigidbody2D>();
        coll = GetComponent<BoxCollider2D>();
    }


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {

            rb.velocity = new Vector3(rb.velocity.x, jumpForce, 0);



        }

    }
}
