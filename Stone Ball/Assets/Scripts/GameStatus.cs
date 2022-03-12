using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class GameStatus : MonoBehaviour
{
    [Range(0.5f, 2.5f)] [SerializeField] float speed = 1.0f;

    float startVelX;
    float startVelY;
    float prevSpeed = 1.0f;
    bool firstClickDone = false;
    //Game Score Parameters
    [SerializeField]int gameScore = 0;
    [SerializeField]int scorePerBlock = 10;
    [SerializeField] bool isAutoPlayOn = false;

    private void Awake()
    {
        int gameStatusCount = FindObjectsOfType<GameStatus>().Length;
        if(gameStatusCount > 1)
        {
            gameObject.SetActive(false);
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }
    void Start()
    {
        GameObject ball = GameObject.Find("Ball");
        Ball ballScript = ball.GetComponent<Ball>();
        startVelX = ballScript.xPush;
        startVelY = ballScript.yPush;
    }

    public void destroyGameStatus()
    {
        Destroy(gameObject);
    }

    public void updateScore()
    {
        gameScore += scorePerBlock; 
    }

    public bool IsAutoPlayOn()
    {
        return isAutoPlayOn;
    }

    void Update()
    {
        if (SceneManager.GetActiveScene().buildIndex != 3 ) {
            GameObject ball = GameObject.Find("Ball");
            Ball ballScript = ball.GetComponent<Ball>();
            if (ballScript.isClickedTheButton && (speed != prevSpeed))
            {
                if (firstClickDone) {
                    ball.GetComponent<Rigidbody2D>().velocity = new Vector2(speed * (ball.GetComponent<Rigidbody2D>().velocity.x / prevSpeed), speed * (ball.GetComponent<Rigidbody2D>().velocity.y / prevSpeed));
                    prevSpeed = speed;
                }
                else
                {
                    ball.GetComponent<Rigidbody2D>().velocity = new Vector2(speed * startVelX, speed * startVelY);
                    prevSpeed = speed;
                    firstClickDone = true;
                }

            }
            Text textComponent = GameObject.Find("Score Text").GetComponent<Text>();
            textComponent.text = "SCORE : " + gameScore;
        }
    }
}
       

