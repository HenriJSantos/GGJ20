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
            DoorLock doorLock = this.colliding_item.GetComponent<DoorLock>();
            doorLock.ChangeLock();
        }
        else if(this.colliding_item.CompareTag("Switch")) {
            Switch sw = this.colliding_item.GetComponent<Switch>();
            sw.unlockSwitch();
		}
        else if(this.colliding_item.CompareTag("Door")) {
            Door door = this.colliding_item.GetComponent<Door>();
            door.Enter();
        }
    }

    public override void Damage()
    {
        if (damaged)
            return;

        GameVars.player1Health--;

        if (GameVars.player1Health == 0)
        {
            this.damaged = true;
            this.animator.SetTrigger("Dead");

            var playersBehaviour = FindObjectsOfType<Player>();

            foreach (var behaviour in playersBehaviour)
            {
                behaviour.enabled = false;
            }

            return;
        }

        base.Damage();
    }
}
