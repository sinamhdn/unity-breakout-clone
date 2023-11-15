using UnityEngine;

public class Ball : MonoBehaviour
{
    [SerializeField] Paddle paddle;
    [SerializeField] float launchVelocityX = 2f;
    [SerializeField] float launchVelocityY = 10f;
    [SerializeField] AudioClip[] bounceAudio;
    [SerializeField] float velocityRandomFactor = 0.2f;
    AudioSource audioSource;
    Rigidbody2D rigidbody2d;
    Vector2 distanceBetweenPaddleAndBall;
    bool hasStarted = false;

    // Start is called before the first frame update
    void Start()
    {
        distanceBetweenPaddleAndBall = transform.position - paddle.transform.position;
        audioSource = GetComponent<AudioSource>();
        rigidbody2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!hasStarted)
        {
            StickToPaddle();
            // if not in if statement we can launch the ball midair
            LaunchOnMouseClick();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Vector2 randomVelocity = new Vector2
            (Random.Range(0f, velocityRandomFactor),
            Random.Range(0f, velocityRandomFactor));

        if (!hasStarted) return;
        AudioClip clip = bounceAudio[Random.Range(0, bounceAudio.Length)];
        // GetComponent<AudioSource>().Play();
        // play one shot plays audio to the end than plays the other one and doesnt interrupt the playing
        audioSource.PlayOneShot(clip);
        rigidbody2d.velocity += randomVelocity;
    }

    private void StickToPaddle()
    {
        Vector2 paddlepos = new Vector2(paddle.transform.position.x, paddle.transform.position.y);
        transform.position = paddlepos + distanceBetweenPaddleAndBall;
    }
    private void LaunchOnMouseClick()
    {
        if (Input.GetMouseButtonDown(0))
        {
            hasStarted = true;
            rigidbody2d.velocity = new Vector2(launchVelocityX, launchVelocityY);
        }
    }

    public void AutoLaunch()
    {
        if (!hasStarted) rigidbody2d.velocity = new Vector2(launchVelocityX, launchVelocityY);
        hasStarted = true;
    }
}
