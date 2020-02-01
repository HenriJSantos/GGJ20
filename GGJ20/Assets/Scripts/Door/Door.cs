using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    public Sprite unlocked;
    public Sprite locked;
    public Sprite open;
    public Sprite lightOn;
    public Sprite lightOff;
    private SpriteRenderer door;
    private SpriteRenderer player1Light;
    private SpriteRenderer player2Light;
    private bool player1, player2;

    private bool isLocked;
    private bool isOpen;
    
    // Start is called before the first frame update
    void Start()
    {
        isLocked = true;
        isOpen = false;
        this.door = this.gameObject.GetComponent<SpriteRenderer>();
        this.player1Light = this.gameObject.transform.GetChild(0).GetComponent<SpriteRenderer>();
        this.player2Light = this.gameObject.transform.GetChild(1).GetComponent<SpriteRenderer>();
        door.sprite = locked;
        
        
        player1 = false;
        player2 = false;
    }

    private void OnTriggerEnter2D(Collider2D collision) 
    {
        
        if (collision.gameObject.CompareTag("Player1"))
        {
            player1 = true;
            this.player1Light.sprite = lightOn;
            isLocked = false;
            this.door.sprite = unlocked;
        }
        if (collision.gameObject.CompareTag("Player2"))
        {
            this.player2Light.sprite = lightOn;
            player2 = true;
        }

        if(player1 && player2 && !isLocked){
            isOpen = true;
            this.door.sprite = open;
        }

    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player1"))
        {
            this.player1Light.sprite = lightOff;
            player1 = false;
        }
        if (collision.gameObject.CompareTag("Player2"))
        {
            this.player2Light.sprite = lightOff;
            player2 = false;
        }
        
        isOpen = false;
        if(this.isLocked) this.door.sprite = locked;
        else this.door.sprite = unlocked;
    }

}
