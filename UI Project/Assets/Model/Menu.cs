using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public abstract class Menu : MonoBehaviour, IMenu
{
    public void SwitchMenu(GameObject next)
    {
        gameObject.SetActive(false);
        next.SetActive(true);
    }
    public void PlayGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    public void QuitGame()
    {

        Debug.Log("QUIT!");
#if UNITY_EDITOR
        if (EditorApplication.isPlaying)
        {
            EditorApplication.isPlaying = false;
        }
#else
        Application.Quit();
#endif
    }
    public void Resume()
    {
        gameObject.SetActive(false);
        Time.timeScale = 1.0f;
    }
    public void PauseGame()
    {
        gameObject.SetActive(true);
        Time.timeScale = 0f;
    }

}
