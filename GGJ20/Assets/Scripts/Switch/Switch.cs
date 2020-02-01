using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Switch : MonoBehaviour
{
    public Sprite unlocked;
    public Sprite locked;
    private SpriteRenderer interruptor;

    private bool isLocked;
    
    // Start is called before the first frame update
    void Start()
    {
        this.isLocked = true;
        this.interruptor = this.gameObject.GetComponent<SpriteRenderer>();
        this.interruptor.sprite = this.locked;
    }

    private void OnTriggerEnter2D(Collider2D collision) 
    {
        if (collision.gameObject.CompareTag("Player1") && this.isLocked)
        {
            this.isLocked = false;
            this.interruptor.sprite = this.unlocked;
            GameObject[] acid_waters = GameObject.FindGameObjectsWithTag("Acid");

            for (int i = 0; i < acid_waters.Length; i++) {
                Destroy(acid_waters[i]);     
			}

        }
    }

    public void unlockSwitch(){
        if (this.isLocked)
        {
            this.isLocked = false;
            this.interruptor.sprite = this.unlocked;
            GameObject[] acid_waters = GameObject.FindGameObjectsWithTag("Acid");

            for (int i = 0; i < acid_waters.Length; i++) {
                Destroy(acid_waters[i]);     
			}

        }
	}

}
