using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player2 : Player
{
    public override void Start()
    {
        base.Start();
        this.hor_key = "Horizontal_2";
        this.ver_key = "Vertical_2";
        this.grab_key = "Grab_2";

        this.item = null;
    }

    protected override void InteractAction()
    {
        if(this.item == null && this.colliding_item != null) {
            this.item = this.colliding_item;
            this.item.transform.parent = this.gameObject.transform;
            this.item.transform.position = this.gameObject.transform.position;

            Rigidbody2D rb = this.item.GetComponent<Rigidbody2D>();
            rb.bodyType = RigidbodyType2D.Kinematic;
            this.item.transform.Translate(new Vector2(0, 2f));
            this.canGrab = false;
            rb.gravityScale = 1;

            this.animator.SetTrigger("Grab");
        }
    }
}
