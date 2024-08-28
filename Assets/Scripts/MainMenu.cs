using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class MainMenu : MonoBehaviour
{
    public void PlayGame()
    {
        SceneManager.LoadScene(1);
    }
    public void HowToPlayGame()
    {
        SceneManager.LoadScene(5);
    }
    public void BackTOMain()
    {
        SceneManager.LoadScene(0);
    }
}