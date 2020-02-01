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
    
    // Start is called before the first frame update
    void Start()
    {
        //this.gameObject.GetComponent<SpriteRenderer>().sprite = locked;
        
        player1 = false;
        player2 = false;

        isLocked = true;
    }

    // Update is called once per frame
    void Update()
    {
    
    }

    
}
