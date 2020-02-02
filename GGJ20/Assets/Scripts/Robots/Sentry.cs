using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sentry : Robot
{
    public float roundTripTime = 20f;
    public float distance = 4f;

    // Update is called once per frame
    public override void Update()
    {
        float timeFactor = (Time.timeSinceLevelLoad % roundTripTime) / roundTripTime;

        if(timeFactor > 0.5f){
            this.transform.localScale = new Vector3(-1f,1f,1f);
            this.transform.localPosition = new Vector3((1f - timeFactor) * distance, 0f, 0f);
        }
        else{
            this.transform.localScale = new Vector3(1f,1f,1f);
            this.transform.localPosition = new Vector3(timeFactor * distance, 0f, 0f);
        }
    }
}
