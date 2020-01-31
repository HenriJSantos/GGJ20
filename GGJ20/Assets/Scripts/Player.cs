using System.Collections;
using System.Collections.Generic;
using UnityEngine;

abstract public class Player : MonoBehaviour
{
    private GameObject player;
    Rigidbody2D rig_body;

    public float hor_val;
    protected string hor_key;

    public float ver_val;
    protected string ver_key;

    private bool jumping;

    public virtual void Start()
    {
        hor_val = .1f;
        ver_val = 5;

        this.player = this.gameObject;
        this.rig_body = this.gameObject.GetComponent<Rigidbody2D>();

        this.jumping = false;
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    public void Move()
    {
        if (Input.GetButton(this.hor_key))
        {
            float value = this.hor_val;

            if(Input.GetAxisRaw(this.hor_key) < 0)
            {
                value *= -1;
            }
            HorizontalMove(value);
        }
        else if (Input.GetButtonDown(this.ver_key) && !this.jumping)
        {
            VerticalMove(this.ver_val);
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
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Floor"))
        {
            this.jumping = false;
        }
    }
}
