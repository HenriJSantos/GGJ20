using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Story : MonoBehaviour
{
    public GameObject[] images;

    // Start is called before the first frame update
    void Start()
    {
        for(int i = 0; i < images.Length; i++)
        {
            StartCoroutine(ActiveImage(images[i], i * 7.5f));
        }
        Invoke("NextScene", 33);
    }

    IEnumerator ActiveImage(GameObject image, float delay)
    {
        yield return new WaitForSeconds(delay);

        image.SetActive(true);
    }

    private void NextScene()
    {
        SceneManager.LoadScene("Level 0");
    }
}
