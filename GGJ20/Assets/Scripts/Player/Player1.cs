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
    }

    protected override void InteractAction()
    {
        if(this.colliding_item.CompareTag("Door")){
            Door door = this.colliding_item.GetComponent<Door>();
            door.unlockDoor();
        }
    }
}
