using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Robot : MonoBehaviour
{
    public Object Beam;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    public virtual void Update()
    {
        
    }

    public void deactivate(){
        Destroy(Beam);
    }
}
