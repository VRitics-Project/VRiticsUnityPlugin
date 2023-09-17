using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OculusSample_MainMenu : MonoBehaviour
{
    public void Play()
    {
        SceneManager.LoadScene("SceneWithEvents");
    }

    public void LoadMenu()
    {
        SceneManager.LoadScene("InitializationScene");
    }

    public void Quit()
    {
        Application.Quit();
    }
}
