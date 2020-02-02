using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public static bool started = false;
    public GameObject menu;
    public GameObject canvas;

    private void Start()
    {
        if (started && SceneManager.GetActiveScene().name == "Menu")
        {
            Animation anim = canvas.GetComponent<Animation>();
            if(anim != null)
            {
                anim.enabled = false;
            }

            menu.SetActive(true);
        }
        else
        {
            started = true;
        }
    }

    public void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    public void Exit()
    {
        Application.Quit();
    }
}
