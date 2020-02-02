using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;

public class Drone : Robot
{
    public float roundTripTime = 20f;
    public float distance = 4f;

    // Update is called once per frame
    public override void Update()
    {
        float timeFactor = (float) Math.Sin(Time.timeSinceLevelLoad);

        this.transform.localPosition = new Vector3(0f, timeFactor * distance, 0f);
    }
}