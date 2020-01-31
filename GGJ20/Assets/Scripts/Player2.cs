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
    }
}
