using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    [SerializeField]
    private string gameSceneName;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public void StartGame()
    {
        SceneManager.LoadScene(gameSceneName);
        //var newScene = SceneManager.GetSceneByName(gameSceneName);

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
