
using UnityEngine;

public class Ball : MonoBehaviour
{
    //configuration parameters
    [SerializeField] Paddle paddle1;
    [SerializeField] public float xPush = 2f;
    [SerializeField] public float yPush = 10f;
    [SerializeField] AudioClip[] audios;
    [SerializeField] float randomFactor = 0.2f;
    
    //state
    Vector2 paddleToBallVector;
    public bool isClickedTheButton = false;
    //cached referance
    AudioSource audio;
    Rigidbody2D rigidBody2D;


    // Start is called before the first frame update
    void Start()
    {
        paddleToBallVector = transform.position - paddle1.transform.position;
        audio = GetComponent<AudioSource>();
        rigidBody2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!isClickedTheButton)
        {
            lockToPaddle();
            launchBollOnMouseClick();
        }
        
    }

    public bool IsClickedTheButton()
    {
        return isClickedTheButton;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        
        if (isClickedTheButton)
        {
            VelocityTweak();
            int randNum = Random.Range(0, audios.Length);
            AudioClip clip = audios[randNum];
            audio.PlayOneShot(clip);
        }
    }

    private void VelocityTweak()
    {
        Vector2 velocityTweak = new Vector2(Random.Range(0, randomFactor), Random.Range(0, randomFactor));
        rigidBody2D.velocity += velocityTweak;
    }

    private void launchBollOnMouseClick()
    {
        if (Input.GetMouseButtonDown(0))
        {
            isClickedTheButton = true;
            rigidBody2D.velocity = new Vector2(xPush, yPush);
        }
    }

    private void lockToPaddle()
    {
        Vector2 paddlePos = new Vector2(paddle1.transform.position.x, paddle1.transform.position.y);
        transform.position = paddlePos + paddleToBallVector;
    }
}
