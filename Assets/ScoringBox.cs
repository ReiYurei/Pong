using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoringBox : MonoBehaviour
{
    public GameObject box;
    private SpriteRenderer boxColor;
    public PlayerControl player1;
    public PlayerControl player2;
 
    private void OnTriggerEnter2D(Collider2D collision)
    {
        
            if (collision.gameObject.tag == "BallFromPlayer1")
            {    
                if (boxColor.color == Color.red)
                {
                player1.BoxScore(10);
                Destroy(box.gameObject);
                }
                if (boxColor.color == Color.blue)
                {
                player1.BoxScore(8);
                Destroy(box.gameObject);
                }
                if (boxColor.color == new Color(1, 1, 0, 1))
                {
                player1.BoxScore(3);
                Destroy(box.gameObject);
                }

            }
            if (collision.gameObject.tag == "BallFromPlayer2")
            {
                if (boxColor.color == Color.red)
                {
                    player2.BoxScore(10);
                    Destroy(box.gameObject);
                }
                if (boxColor.color == Color.blue)
                {
                    player2.BoxScore(8);
                    Destroy(box.gameObject);
                }
                if (boxColor.color == new Color(1,1,0,1))
                {
                    player2.BoxScore(3);
                    Destroy(box.gameObject);
                }
        }

    }

    void Start()
    {
        boxColor = box.GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
