using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pipe : MonoBehaviour
{
    public Rigidbody2D rb;
    public float speed = 4f;

    // Use this for initialization
    void Start ()
    {
        gameObject.SetActive(false);
    }

    private void OnEnable()
    {
        rb.velocity = Vector2.left * speed;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "pipeEnd")
        {
            gameObject.SetActive(false);    
        }
    }
}
