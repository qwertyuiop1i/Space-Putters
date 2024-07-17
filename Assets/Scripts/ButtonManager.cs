using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class ButtonManager : MonoBehaviour
{
    public bool isPaused = false;
    public bool isSped = false;
    public float speed = 1.0f;
    private void Start()
    {
        isPaused = false;
        isSped = false;
        speed = 1.0f;
    }
    
    public void NextLevel()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex + 1);
    }

    public void ReloadLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void LoadMainMenu()
    {
        SceneManager.LoadScene(0); 
    }


    public void TogglePause()
    {
        isPaused = !isPaused;
        Time.timeScale = isPaused ? 0f : speed;
    }
    public void ToggleSpeed()
    {
        isSped = !isSped;
        speed = isSped ? 3.0f : 1.0f;
        Time.timeScale = speed;
    }

}
