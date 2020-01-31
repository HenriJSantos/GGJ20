using System.Collections;
using System.Collections.Generic;
using UnityEngine;

abstract public class Player : MonoBehaviour
{
    public GameObject player;

    public float hor_val;
    public string hor_key;

    public float ver_val;
    public string ver_key;

    private void Start()
    {
        hor_val = 1;
        ver_val = 1;
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    public void Move()
    {
        if (Input.GetKey(this.hor_key))
        {
            HorizontalMove(this.hor_val);
        }
        else if (Input.GetKeyDown(this.ver_key))
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
        this.player.transform.Translate(new Vector3(0, value, 0));
    }
}
