using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    private Rigidbody2D rb2d;
    private SpriteRenderer ballColor;
    public float xInitialForce;
    public float yInitialForce;
    // Start is called before the first frame update
    void Start()
    {
        ballColor = GetComponent<SpriteRenderer>();
        rb2d = GetComponent<Rigidbody2D>();
        RestartGame();
    }

    void Update()
    {
        BallDirection();
    }
    void ResetBall()
    {
        transform.position = Vector2.zero;
        rb2d.velocity = Vector2.zero;
    }
    void BallDirection()
    {
        if (rb2d.velocity[0] > 0)
        {
            transform.gameObject.tag = "BallFromPlayer1";
            ballColor.color = Color.green;
        }
        else if (rb2d.velocity[0] < 0)
        {
            transform.gameObject.tag = "BallFromPlayer2";
            ballColor.color = Color.magenta;
        }
        else
        {
            ballColor.color = Color.white;
        }
    }
    void PushBall()
    {
      
        float yRandomInitialForce = Random.Range(-yInitialForce,yInitialForce);
        float randomDirection = Random.Range(0, 2);
       
        if (randomDirection < 1.0f)
        {
            rb2d.AddForce(new Vector2(-xInitialForce,
            yRandomInitialForce));
        }
        else 
        {
            rb2d.AddForce(new Vector2(xInitialForce,
            yRandomInitialForce));

        }

    }
    void RestartGame()
    {
        ResetBall();
        Invoke("PushBall", 2);
    }
}
