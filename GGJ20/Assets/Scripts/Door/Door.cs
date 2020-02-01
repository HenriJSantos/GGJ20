using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    public Sprite unlocked;
    public Sprite locked;
    public Sprite open;

    private bool player1;
    private bool player2;

    private bool isLocked;
    private bool isOpen;
    
    // Start is called before the first frame update
    void Start()
    {
        isLocked = true;
        isOpen = false;

        this.gameObject.GetComponent<SpriteRenderer>().sprite = locked;
        
        player1 = false;
        player2 = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(isLocked){
            this.gameObject.GetComponent<SpriteRenderer>().sprite = locked;
        }
        else if(isOpen){
            this.gameObject.GetComponent<SpriteRenderer>().sprite = open;
        }
        else{
            this.gameObject.GetComponent<SpriteRenderer>().sprite = unlocked;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision) 
    {
        
        if (collision.gameObject.CompareTag("Player1"))
        {
            player1 = true;
            isLocked = false;
        }
        if (collision.gameObject.CompareTag("Player2"))
        {
            player2 = true;
        }

        if(player1 && player2 && !isLocked){
            isOpen = true;
        }

    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player1"))
        {
            player1 = false;
        }
        if (collision.gameObject.CompareTag("Player2"))
        {
            player2 = false;
        }
        
        isOpen = false;
        
    }

}
