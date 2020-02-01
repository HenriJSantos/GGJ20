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
        if(this.colliding_item.CompareTag("DoorLock")){
            Debug.Log("heh");
            DoorLock doorLock = this.colliding_item.GetComponent<DoorLock>();
            doorLock.ChangeLock();
        }
        else if(this.colliding_item.CompareTag("Switch")) {
            Switch sw = this.colliding_item.GetComponent<Switch>();
            sw.unlockSwitch();
		}
    }
}
