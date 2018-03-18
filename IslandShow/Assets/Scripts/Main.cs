using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Main : MonoBehaviour
{
    public static Main instance = null;
    public Slider loadBar;

    private void Awake()
    {
        if (instance == null)
            instance = this;
        else if (instance != this)
            Destroy(gameObject);
        DontDestroyOnLoad(gameObject);
    }

    // Use this for initialization
    private void Start() {}

    private void Update() {}

    public void playGame(int levelIndex)
    {
        StartCoroutine(loadLevel(levelIndex));
    }

    IEnumerator loadLevel(int levelIndex)
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(levelIndex);

        while (!operation.isDone)
        {
            loadBar.value = operation.progress;
            yield return null;
        }
    }

    public void quitGame()
    {
        Application.Quit();
    }

}
