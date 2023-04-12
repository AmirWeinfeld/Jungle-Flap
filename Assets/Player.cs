using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Player : MonoBehaviour
{
    public Rigidbody2D rb;
    public float JumpForce = 10f, rotationSpeed = 10f, maxVelocity = -15;
    public TextMeshProUGUI score, deathScore, deathHighScore;
    private bool started = false;

    //HighScore

    //public Sprite[] skySprites;

    public Rigidbody2D[] allRBs;
    public PipeSpawner pipeSpawner;

    public GameObject restartButton, ScoreMenu, explosion, pauseButton;

    private bool isDead = false;

    private void FixedUpdate()
    {
        if(rb.velocity.y < maxVelocity)
        {
            rb.velocity = Vector2.up * maxVelocity;
        }
    }

    public void Jump()
    {
        if (!started)
        {
            started = true;
            pauseButton.SetActive(true);
        }
        rb.velocity = Vector2.up * JumpForce;
    }

    // Update is called once per frame
    void Update ()
    {
        // Input and Controlls:
        /*if (Input.touchCount > 0)
        {
            if (Input.GetTouch(0).phase == TouchPhase.Began && !isDead)//Input.GetKeyDown(KeyCode.Space)
            {
                if (!started)
                {
                    started = true;
                }
                rb.velocity = Vector2.up * JumpForce;
            }
        }*/

        // Visual Effects:
        if (rb.velocity.y < JumpForce/2 && started && Time.timeScale == 1)// -JumpForce)
        {
            if(transform.rotation.z > -0.8f)// -0.656)
            {
                transform.Rotate(0, 0, -rotationSpeed);
            }
        }
        else if(!isDead && Time.timeScale == 1)
        {
            transform.rotation = new Quaternion(0, 0, 0, 0); // TODO: Add Tilt
        }

        if (!started)
        {
            ChangePosition();
            rb.velocity = Vector3.zero;
        }
    }

    private float x = 0;
    void ChangePosition()
    {
        transform.position = new Vector3(transform.position.x, Mathf.Sin(x) / 4, 0);
        x += Time.deltaTime * 3;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "addScore")
        {
            score.text = (int.Parse(score.text) + 1).ToString();
            return;
        }

        if (!isDead)
        {
            rb.velocity = Vector2.zero;
        }

        isDead = true;

        if(pipeSpawner != null)
        {
            pipeSpawner.Stop();
        }

        foreach (Rigidbody2D tempRB in allRBs)
        {
            tempRB.bodyType = RigidbodyType2D.Static;
        }

        if (collision.gameObject.tag == "Ground")
        {
            rb.bodyType = RigidbodyType2D.Static;

            explosion.transform.position = transform.position;
            explosion.SetActive(true);
            gameObject.GetComponent<SpriteRenderer>().color = new Color(0, 0, 0, 0);
        }

        int scoreInt = int.Parse(score.text);
        int highScoreInt = PlayerPrefs.GetInt("HighScore");
        if (highScoreInt < scoreInt)
        {
            PlayerPrefs.SetInt("HighScore", int.Parse(score.text));
            deathHighScore.text = scoreInt.ToString();
        }
        else
        {
            deathHighScore.text = highScoreInt.ToString();
        }

        pauseButton.SetActive(false);

        ScoreMenu.SetActive(true);

        deathScore.text = score.text;

        score.alpha = 0;

        restartButton.SetActive(true);
    }
}
