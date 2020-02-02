using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PiecesCounter : MonoBehaviour
{
    private Text counter;
    // Start is called before the first frame update
    void Start()
    {
        counter = this.gameObject.GetComponent<UnityEngine.UI.Text>();
    }

    // Update is called once per frame
    void Update()
    {
        counter.text = GameVars.piecesCollected.ToString();
    }
}
