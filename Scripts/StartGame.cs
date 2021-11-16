using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartGame : MonoBehaviour
{
    public void GameStandart()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("Standart");
    }
    public void GameArcada()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("Arcada");
    }
    public void GameMenu()
    {
        SceneManager.LoadScene("Menu");
    }
}
