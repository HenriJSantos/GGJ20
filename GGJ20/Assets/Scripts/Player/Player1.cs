using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player1 : Player
{
    public override void Start()
    {
        base.Start();
        this.hor_key = "Horizontal_1";
        this.ver_key = "Vertical_1";
        this.grab_key = "Grab_1";
        ver_val = 6;
    }

    protected override void InteractAction()
    {
        Debug.Log("ola");
        if(this.colliding_item.CompareTag("Door")){
            Debug.Log("cona");
            Door door = this.colliding_item.GetComponent<Door>();
            door.unlockDoor();
        }
    }
}
