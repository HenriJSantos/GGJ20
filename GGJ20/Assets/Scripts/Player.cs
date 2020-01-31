using System.Collections;
using System.Collections.Generic;
using UnityEngine;

abstract public class Player : MonoBehaviour
{
    private GameObject player;

    public float hor_val;
    protected string hor_key;

    public float ver_val;
    protected string ver_key;

    public virtual void Start()
    {
        hor_val = 1;
        ver_val = 1;

        this.player = this.gameObject;
        Debug.Log(this.player);
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
        else if (Input.GetButtonDown(this.ver_key))
        {
            float value = this.ver_val;

            if (Input.GetAxisRaw(this.ver_key) < 0)
            {
                value *= -1;
            }
            VerticalMove(value);
        }
    }

    protected void HorizontalMove(float value)
    {
        this.player.transform.Translate(new Vector3(value, 0, 0));
    }

    protected void VerticalMove(float value)
    {
        this.player.transform.Translate(new Vector3(0, value, 0));
    }
}
