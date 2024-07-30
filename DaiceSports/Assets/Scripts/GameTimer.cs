using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class GameTimer : MonoBehaviour
{
    public float Timer = 60;
    public Text TimerText;
    public GameObject ClearWindow;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Timer -= Time.deltaTime;
        TimerText.text = ((int)Timer).ToString();

        if (Timer <= 0)
        {
            ClearWindow.SetActive(true);
            enabled = false;
        }
    }
}
