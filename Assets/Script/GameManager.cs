using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public TMP_Text scoreText;
    //public Text highscoreText;
    //int highscore = 0;
    [SerializeField]
    public int score = 0; 
    public const int NB_MAX_LIFE = 6;
    [SerializeField]
    public int nb_life = 6;
    [SerializeField]
    private string gameOver;

    public static GameManager Instance = null;

    private void Awake()
    {
        Instance = this;
    }
    public void ResetScore()
    {
        score = 0;
        nb_life = 6;
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        ResetScore();
        scoreText.text = score.ToString() + " Points";
        //highscoreText.text = "HIGHSCORE" + highscore.ToString() + " Points";
    }

    // Update is called once per frame
    void Update()
    {
        scoreText.text = score.ToString() + " Points";
        switch (GameManager.Instance.nb_life)
        {
            case 6 :
                break;
            case 5:
                break;
            case 4:
                break;
            case 3:
                break;
            case 2:
                break;
            case 1:
                break;
            case 0:
                SceneManager.LoadScene(gameOver);
                break;
            default:
                SceneManager.LoadScene(gameOver);
                break;

        }
    }
}
