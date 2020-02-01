using System.Collections;
using System.Collections.Generic;
using UnityEngine;

abstract public class Player : MonoBehaviour
{
    private GameObject player;
    Rigidbody2D rig_body;
    private Animator animator;

    public float hor_val;
    protected string hor_key;

    public float ver_val;
    protected string ver_key;

    private bool jumping;
    private bool canGrab;

    private GameObject item;
    private int itemNum;

    protected string grab_key;

    public virtual void Start()
    {
        hor_val = .1f;
        ver_val = 5;

        this.player = this.gameObject;
        this.rig_body = this.gameObject.GetComponent<Rigidbody2D>();
        this.animator = this.gameObject.GetComponent<Animator>();

        this.animator.SetBool("Walking", false);
        this.animator.SetBool("Jumping", false);

        this.jumping = false;
        this.canGrab = false;

        this.item = null;
        this.itemNum = 0;
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        Grab();
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

    private void Grab()
    {
        if (canGrab && Input.GetButton(this.grab_key))
        {
            Destroy(this.item);
            this.item = null;
            this.canGrab = false;
        }
    }


    protected void HorizontalMove(float value)
    {
        this.player.transform.Translate(new Vector3(value, 0, 0));
    }

    protected void VerticalMove(float value)
    {
        this.rig_body.velocity = transform.up*value;
        this.jumping = true;
        this.animator.SetBool("Jumping", true);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Floor"))
        {
            this.jumping = false;
            this.animator.SetBool("Jumping", false);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision) 
    {
        //TODO Change tag name
        if (collision.gameObject.CompareTag("Grab"))
        {
            this.canGrab = true;
            this.item = collision.gameObject;
        }
        else if (collision.gameObject.CompareTag("Item"))
        {
            Destroy(collision.gameObject);
            this.itemNum++;
        }

    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        //TODO Change tag name
        if (collision.gameObject.CompareTag("Grab"))
        {
            this.canGrab = false;
            this.item = null;
        }
    }
}
