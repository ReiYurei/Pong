using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public PlayerControl player1;
    private Rigidbody2D player1Rigidbody;
    public PlayerControl player2; 
    private Rigidbody2D player2Rigidbody;
    public Ball ball; 
    private Rigidbody2D ballRigidbody;
    private bool isDebugWindowShown = false;
    private CircleCollider2D ballCollider;
    public int maxScore;



    //ScoringBox
    public GameObject scoringBoxRed,scoringBoxBlue,scoringBoxYellow;
    public int maxGenerate;
    //public int boxCounter;
    void Start()
    {
        BoxLoop();
        player2Rigidbody = player2.GetComponent<Rigidbody2D>();
        ballRigidbody = ball.GetComponent<Rigidbody2D>();
        ballCollider = ball.GetComponent<CircleCollider2D>();
    }


    void BoxLoop()
    {
        for (int i = 0; i < maxGenerate; i++)
        {
            var redBox = Instantiate(scoringBoxRed, new Vector3(Random.Range(-10.0f, 10.0f), Random.Range(-10.0f, 10.0f), 0), Quaternion.identity);
            var blueBox = Instantiate(scoringBoxBlue, new Vector3(Random.Range(-10.0f, 10.0f), Random.Range(-10.0f, 10.0f), 0), Quaternion.identity);
            var yellowBox = Instantiate(scoringBoxYellow, new Vector3(Random.Range(-10.0f, 10.0f), Random.Range(-10.0f, 10.0f), 0), Quaternion.identity);
            redBox.tag = "Clone";
            blueBox.tag = "Clone";
            yellowBox.tag = "Clone";

        }
    }
    void DestroyAll(string tag)
    {
        GameObject[] boxes = GameObject.FindGameObjectsWithTag(tag);
        for (int i = 0; i < boxes.Length; i++)
        {
            Destroy(boxes[i]);
        }

    }
    // Update is called once per frame
    void Update()
    {
        
    }
    void OnGUI()
    {
        GUI.Label(new Rect(Screen.width / 2 - 150 - 12, 20, 100, 100), "" +player1.Score);
        GUI.Label(new Rect(Screen.width / 2 + 150 + 12, 20, 100, 100), "" +player2.Score);
        if (GUI.Button(new Rect(Screen.width / 2 - 60, 35, 120, 53),"RESTART"))
        {
            player1.ResetScore();
            player2.ResetScore();
            DestroyAll("Clone");
            BoxLoop();
            ball.SendMessage("RestartGame", 0.5f,SendMessageOptions.RequireReceiver);
        }
        if (player1.Score >= maxScore)
        {
            GUI.Label(new Rect(Screen.width / 2 - 150, Screen.height / 2 -10, 2000, 1000), "PLAYER ONE WINS");
            ball.SendMessage("ResetBall", null,SendMessageOptions.RequireReceiver);

        }

        else if (player2.Score >= maxScore)
        {
            GUI.Label(new Rect(Screen.width / 2 + 30, Screen.height / 2 -10, 2000, 1000), "PLAYER TWO WINS");
            ball.SendMessage("ResetBall", null,SendMessageOptions.RequireReceiver);
        }

        //DEBUG INFO
        if (GUI.Button(new Rect(Screen.width / 2 - 60, Screen.height - 73, 120,
53), "TOGGLE\nDEBUG INFO"))
        {
            isDebugWindowShown = !isDebugWindowShown;
        }
        if (isDebugWindowShown)
        {
            Color oldColor = GUI.backgroundColor;
            GUI.backgroundColor = Color.red;

            float ballMass = ballRigidbody.mass;
            Vector2 ballVelocity = ballRigidbody.velocity;
            float ballSpeed = ballRigidbody.velocity.magnitude;
            Vector2 ballMomentum = ballMass * ballVelocity;
            float ballFriction = ballCollider.friction;
            float impulsePlayer1X = player1.LastContactPoint.normalImpulse;
            float impulsePlayer1Y =
            player1.LastContactPoint.tangentImpulse;
            float impulsePlayer2X = player2.LastContactPoint.normalImpulse;
            float impulsePlayer2Y =
            player2.LastContactPoint.tangentImpulse;

            // Tentukan debug text-nya
            string debugText =
            "Ball mass = " + ballMass + "\n" +
            "Ball velocity = " + ballVelocity + "\n" +
            "Ball speed = " + ballSpeed + "\n" +
            "Ball momentum = " + ballMomentum + "\n" +
            "Ball friction = " + ballFriction + "\n" +
            "Last impulse from player 1 = (" + impulsePlayer1X + ", " +
            impulsePlayer1Y + ")\n" +
            "Last impulse from player 2 = (" + impulsePlayer2X + ", "
            + impulsePlayer2Y + ")\n";

            GUIStyle guiStyle = new GUIStyle(GUI.skin.textArea);
            guiStyle.alignment = TextAnchor.UpperCenter;
            GUI.TextArea(new Rect(Screen.width / 2 - 200, Screen.height -
            200, 400, 110), debugText, guiStyle);

            GUI.backgroundColor = oldColor;
     
        }
    }
}
