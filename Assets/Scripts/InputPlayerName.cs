using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InputPlayerName : MonoBehaviour
{
    private Text playerNameLocal;

    // Start is called before the first frame update
    void Start()
    {
        playerNameLocal = GetComponent<Text>();
        playerNameLocal.text = "Player:\n" + ScoreManager.instance.playerName;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
