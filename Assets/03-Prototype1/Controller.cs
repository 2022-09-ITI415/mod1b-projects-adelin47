using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Controller : MonoBehaviour
{
    public GameObject gameOverScreen;
    public void LoadMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void RestartScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void ShowGameOverScreen()
    {
        gameOverScreen.SetActive(true);
    }

    public void TestButton(int index)
    {
        SceneManager.LoadScene(index);
    }
}
