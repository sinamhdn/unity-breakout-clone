using UnityEngine;

public class Paddle : MonoBehaviour
{
    [SerializeField] float screenWidthunits = 16f;
    [SerializeField] float minX = 1f;
    [SerializeField] float maxX = 15f;
    Session session;
    Ball ball;

    // Start is called before the first frame update
    void Start()
    {
        session = FindObjectOfType<Session>();
        ball = FindObjectOfType<Ball>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 paddlepos = new Vector2(GetXPosition(), transform.position.y);
        // to limit movement inside play area
        paddlepos.x = Mathf.Clamp(paddlepos.x, minX, maxX);
        transform.position = paddlepos;
    }

    private float GetXPosition()
    {
        // devide to screen width so x position ranges between 0 and 1
        // because how we setup camera we have 16 camera units in width and 12 in height
        float mousepos = Input.mousePosition.x / Screen.width * screenWidthunits;
        if (session.GetIsAutoplay())
        {
            ball.AutoLaunch();
            return ball.transform.position.x;
        }
        return mousepos;
    }
}
