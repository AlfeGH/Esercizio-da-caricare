using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InputRecord : MonoBehaviour
{
    private Text text;

    // Start is called before the first frame update
    void Start()
    {
        text = GetComponent<Text>();
        text.text = "High Score: " + ScoreManager.nameToWrite + ": " + ScoreManager.scoreToWrite;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
