using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Paddle : MonoBehaviour

{
    [SerializeField] float ScreenSizeInUnits = 16f;
    [SerializeField] float minX = 0.755f;
    [SerializeField] float maxX = 15.245f;

    //cached
    GameStatus gameStatus;
    Ball ball;
    // Start is called before the first frame update
    void Start()
    {
        gameStatus = FindObjectOfType<GameStatus>();
        ball = FindObjectOfType<Ball>();
    }
    
    private float getPosX()
    {
   
            if (gameStatus.IsAutoPlayOn() && ball.IsClickedTheButton())
            {
                return ball.transform.position.x;
            }
            else
            {
                return Input.mousePosition.x * ScreenSizeInUnits / Screen.width;
            }
        
    }

    // Update is called once per frame
    void Update()
    {
        /*
        float mousePosition = Input.mousePosition.x / Screen.width * ScreenSizeInUnits;
        Vector2 paddlePos = new Vector2(transform.position.x,transform.position.y);
        paddlePos.x = Mathf.Clamp(mousePosition, 1f, 15f);
        transform.position = paddlePos;*/


        Vector2 paddlePos = new Vector2(transform.position.x, transform.position.y);
        paddlePos.x = Mathf.Clamp(getPosX(), minX, maxX);
        transform.position = paddlePos;
    }
}



