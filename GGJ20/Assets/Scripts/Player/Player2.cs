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
            if(this.colliding_item.CompareTag("Door")) {
                Door door = this.colliding_item.GetComponent<Door>();
                door.Enter();
                return;
            }
            if(!this.colliding_item.CompareTag("Box")){
                return;
            }
            this.item = this.colliding_item;
            this.item.transform.parent = this.gameObject.transform;
            this.item.transform.position = this.gameObject.transform.position;

            Rigidbody2D rb = this.item.GetComponent<Rigidbody2D>();
            rb.bodyType = RigidbodyType2D.Kinematic;
            rb.constraints = RigidbodyConstraints2D.FreezeRotation;
            
            this.item.tag = "Held";
            this.item.layer = 12; //Held
            
            if(this.GetComponent<SpriteRenderer>().flipX){
                this.item.transform.Translate(new Vector2(-1f, 1f));
            }
            else{
                this.item.transform.Translate(new Vector2(1f, 1f));
            }
            
            this.canGrab = false;
            rb.gravityScale = 1;

            this.animator.SetTrigger("Grab");
        }
    }

    protected override void HorizontalMove(float value)
    {
        if(this.GetComponent<SpriteRenderer>().flipX){
            if(value > 0 && this.item)
                this.item.transform.Translate(new Vector2(2f, 0f));
        }
        else{
            if(value < 0 && this.item)
                this.item.transform.Translate(new Vector2(-2.1f, 0f));
        }

        base.HorizontalMove(value);
    }

    public override void Damage()
    {
        if (damaged)
            return;

        GameVars.player2Health--;

        if (GameVars.player2Health == 0)
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

        if (this.item)
        {
            PutDownItem();
        }

        base.Damage();
    }
}
