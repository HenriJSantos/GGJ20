using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthController : MonoBehaviour
{
    private int health;
    public Image[] hearts;
    public int player;

    private bool gameOver;
    public GameObject panel;
    
    private void Start()
    {
        gameOver = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (gameOver)
            return;

        if (player == 1)
        {
            health = GameVars.player1Health;
        }
        else if (player == 2)
        {
            health = GameVars.player2Health;
        }

        if (health == 0)
        {
            gameOver = true;
            panel.SetActive(true);
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
