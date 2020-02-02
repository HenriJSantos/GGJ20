using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthController : MonoBehaviour
{
    private int health;
    public Image[] hearts;
    public int player;

    // Update is called once per frame
    void Update()
    {
        if (player == 1)
        {
            health = GameVars.player1Health;
        }
        else if (player == 2)
        {
            health = GameVars.player2Health;
        }

        for(int i = 0; i < hearts.Length; i++) {
            if(i < health) {
                hearts[i].enabled = true;
            } else {
                hearts[i].enabled = false;
            }
        }
    }
}
