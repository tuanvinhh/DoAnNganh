using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MainMenu : MonoBehaviour
{
    void Play()
    {
        SceneManager.LoadSceneAsync(1);
    }
    void Update()
    {
        
    }
    public void Exit()
    {
        Application.Quit();
    }
}
