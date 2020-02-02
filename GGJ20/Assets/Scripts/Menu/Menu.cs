using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public static bool started = false;
    public GameObject menu;
    public GameObject canvas;

    public GameObject music;
    private GameObject musicClone;

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
        else if(!started)
        {
            if(music != null)
            {
                musicClone = Instantiate(music, new Vector3(0, 0, 0), Quaternion.identity);
                DontDestroyOnLoad(musicClone);
            }

            started = true;
        }
    }

    public void LoadScene(string sceneName)
    {
        if(sceneName == "Story")
        {
            Destroy(musicClone.gameObject);
        }

        SceneManager.LoadScene(sceneName);
    }

    public void Exit()
    {
        Application.Quit();
    }
}
