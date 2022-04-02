using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public void StartScene()
    {
        SceneManager.LoadScene("Main Menu");
    }

    public void GameplayScene()
    {
        SceneManager.LoadScene("GamePlay");
    }
    public void Quit()
    {
        Application.Quit();
    }
}
