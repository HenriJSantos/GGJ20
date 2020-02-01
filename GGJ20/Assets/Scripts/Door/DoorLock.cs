using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorLock : MonoBehaviour
{
    public Door door;
    public Sprite isOff, isOn;
    private SpriteRenderer lockSwitch;
    private bool isLocked;


    // Start is called before the first frame update
    void Start()
    {
        this.isLocked = true;
        this.lockSwitch = this.gameObject.GetComponent<SpriteRenderer>();
        this.lockSwitch.sprite = isOn;
    }

    public void ChangeLock(){
        Debug.Log("heh");
        if(isLocked){
            this.door.UnlockDoor();
            this.isLocked = false;
            this.lockSwitch.sprite = isOff;
        }
        else{
            this.door.LockDoor();
            this.isLocked = true;
            this.lockSwitch.sprite = isOn;
        }
    }

}
