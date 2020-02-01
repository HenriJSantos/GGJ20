using System.Collections;
using System.Collections.Generic;
using UnityEngine;

abstract public class Player : MonoBehaviour
{
    private GameObject player;
    Rigidbody2D rig_body;
    protected Animator animator;

    public float hor_val;
    protected string hor_key;

    public float ver_val;
    protected string ver_key;

    private bool jumping;
    protected bool canGrab;

    protected GameObject colliding_item;

    protected GameObject item; //Player 2 box

    private int itemNum;

    protected string grab_key;

    public virtual void Start()
    {
        this.player = this.gameObject;
        transform.position = transform.position + new Vector3(GameVars.positionOffset,0,0);
        this.rig_body = this.gameObject.GetComponent<Rigidbody2D>();
        this.animator = this.gameObject.GetComponent<Animator>();

        this.animator.SetBool("Walking", false);
        this.animator.SetBool("Jumping", false);

        this.jumping = false;
        this.canGrab = false;

        this.colliding_item = null;
        this.itemNum = 0;
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        Interact();
    }

    private void Move()
    {
        if (Input.GetButton(this.hor_key))
        {
            this.animator.SetBool("Walking", true);
            float value = this.hor_val;

            if(Input.GetAxisRaw(this.hor_key) < 0)
            {
                value *= -1;
            }
            HorizontalMove(value);
        }
        else
        {
            this.animator.SetBool("Walking", false);
        }

        if (Input.GetButtonDown(this.ver_key) && !this.jumping)
        {
            VerticalMove(this.ver_val);
        }
    }

    private void Interact()
    {
        if (this.canGrab && Input.GetButtonDown(this.grab_key))
        {
            Debug.Log("CONA");
            InteractAction();
        }
        else if (Input.GetButtonDown(this.grab_key) && this.item != null)
        {
            this.item.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
            this.item = null;
            this.canGrab = false;

            this.animator.SetTrigger("PutDown");
        }
    }

    abstract protected void InteractAction();


    protected void HorizontalMove(float value)
    {
        this.player.transform.Translate(new Vector3(value, 0, 0));

        if(value < 0)
        {
            this.player.GetComponent<SpriteRenderer>().flipX = true;
        }
        else
        {
            this.player.GetComponent<SpriteRenderer>().flipX = false;
        }
    }

    protected void VerticalMove(float value)
    {
        this.rig_body.velocity = transform.up*value;
        this.jumping = true;
        this.animator.SetBool("Jumping", true);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Floor") || collision.gameObject.CompareTag("Box"))
        {
            this.jumping = false;
            this.animator.SetBool("Jumping", false);
        }
        if (!this.canGrab && (collision.gameObject.CompareTag("Grab") || collision.gameObject.CompareTag("Box")))
        {
            this.canGrab = true;
            this.colliding_item = collision.gameObject;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision) 
    {
        if (!this.canGrab && collision.gameObject.CompareTag("Switch"))
        {
            this.canGrab = true;
            this.colliding_item = collision.gameObject;
        }
        else if (collision.gameObject.CompareTag("Acid"))
        {
            Destroy(this.player);
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        //TODO Change tag name
        if (collision.gameObject.CompareTag("Grab") || collision.gameObject.CompareTag("Box"))
        {
            this.canGrab = false;
            this.colliding_item = null;
        }
    }
}
