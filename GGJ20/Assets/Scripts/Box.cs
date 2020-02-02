using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Box : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Floor") || collision.gameObject.CompareTag("Box"))
        {            
            if(this.gameObject.transform.parent){
                this.gameObject.transform.parent = this.gameObject.transform.parent.transform.parent;
            }
        }
    }
}
