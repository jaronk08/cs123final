using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadNextScene : MonoBehaviour
{
    public static LoadNextScene Instance;

    private void Awake()
    {
        Instance = this;
    }

    public enum Scene
    {
        TitleScreen,
        SampleScene,
        GameOver
    }

    public void NextScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1);
    }
}
