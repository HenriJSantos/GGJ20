using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneProgress : MonoBehaviour
{
    public string scene;
    public int offset;
    private void OnTriggerEnter2D(Collider2D collision) 
    {
        GameVars.positionOffset = offset;
        SceneManager.LoadScene(scene);
    }
}
