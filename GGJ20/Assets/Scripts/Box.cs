using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Box : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Floor"))
        {
            Rigidbody2D rb = this.gameObject.GetComponent<Rigidbody2D>();

            rb.gravityScale = 0;
            rb.Sleep();
            this.gameObject.transform.parent = this.gameObject.transform.parent.transform.parent;
        }
    }
}
