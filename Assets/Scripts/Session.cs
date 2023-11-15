using TMPro;
using UnityEngine;

public class Session : MonoBehaviour
{
    // serialize for debug
    // [SerializeField] int blockToBreak;
    [SerializeField][Range(0.1f, 9.9f)] float gameSpeed = 1f;
    [SerializeField] TextMeshProUGUI scoreText;
    [SerializeField] bool isAutoplay;
    SceneLoader loader;
    int blockToBreak;
    int score = 0;

    private void Awake()
    {
        // singleton pattern
        int gameSessionCount = FindObjectsOfType<Session>().Length;
        if (gameSessionCount > 1)
        {
            gameObject.SetActive(false);
            Destroy(gameObject);
            return;
        }
        DontDestroyOnLoad(gameObject);
    }

    private void Start()
    {
        loader = FindObjectOfType<SceneLoader>();
        scoreText.text = score.ToString();
    }

    private void Update()
    {
        // moved to reset function
        // if (SceneManager.GetActiveScene().buildIndex == 0)
        // {
        //     Destroy(gameObject);
        // }
        Time.timeScale = gameSpeed;
    }

    public void CountBlocks()
    {
        blockToBreak++;
    }

    public void SubtractBlocksCountToBreak()
    {
        blockToBreak--;
        if (blockToBreak <= 0)
        {
            loader.LoadNextScene();
        }
    }

    public void AddScore(int currentscore)
    {
        score += currentscore;
        scoreText.text = score.ToString();
    }

    public void DestroyedBlock(int currentscore)
    {
        AddScore(currentscore);
        SubtractBlocksCountToBreak();
    }

    public void ResetGame()
    {
        Destroy(gameObject);
    }

    public bool GetIsAutoplay()
    {
        return isAutoplay;
    }
}
