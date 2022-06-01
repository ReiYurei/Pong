using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    public KeyCode upButton = KeyCode.W;
    public KeyCode downButton = KeyCode.S;
    public float speed = 10.0f;
    public float yBoundary = 9.0f;
    private Rigidbody2D rb2d;

    private int score;

    public ScoringBox scoringBox;
    //debug info
    private Vector2 trajectoryOrigin;
    private ContactPoint2D lastContactPoint;
    public ContactPoint2D LastContactPoint
    {
        get { return lastContactPoint; }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name.Equals("Ball"))
        {
            lastContactPoint = collision.GetContact(0);
        }

    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        trajectoryOrigin = transform.position;
    }
    public Vector2 TrajectoryOrigin
    {
        get { return trajectoryOrigin; }
    }
    void Start()
    {

        rb2d = GetComponent<Rigidbody2D>();
        trajectoryOrigin = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 velocity = rb2d.velocity;
       
        if (Input.GetKey(upButton))
        {
            velocity.y = speed;
        }
        else if (Input.GetKey(downButton))
        {
            velocity.y = -speed;
        }
        else
        {
            velocity.y = 0.0f;
        }
        rb2d.velocity = velocity;

        Vector3 position = transform.position;

        if (position.y > yBoundary)
        {
            position.y = yBoundary;
        }
   
        else if (position.y < -yBoundary)
        {
            position.y = -yBoundary;
        }
        transform.position = position;
    }
    public void IncrementScore()
    {
        score++;
    }
    public void BoxScore(int x)
    {
        score += x;
    }
    public void ResetScore()
    {
        score = 0;
    }
    public int Score
    {
        get { return score; }
    }
}
