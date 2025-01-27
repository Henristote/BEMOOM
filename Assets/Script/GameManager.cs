using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static GameManager instance = null;
    public static GameManager Instance => instance;

    public int PlayerHP { get; private set; }
    public void DecreasePlayerHP(int hitPoints = 1)
    {
        PlayerHP -= hitPoints;
        if (PlayerHP <= 0)
        {
            GameOver();
        }
    }
    private void GameOver()
    {
        // Séquence de game over
    }
    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(this.gameObject);
            return;
        }
        else
        {
            instance = this;
        }
        DontDestroyOnLoad(this.gameObject);

        // Initialisation du Game Manager...
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
