using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ground : MonoBehaviour {
    public Rigidbody2D rb;
    public float speed = 2.5f;
    public Vector2 spawnPoint;

    private void Start()
    {
        rb.velocity = Vector2.left * speed;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "groundEnd")
        {
            transform.position = spawnPoint;
        }
    }
}
