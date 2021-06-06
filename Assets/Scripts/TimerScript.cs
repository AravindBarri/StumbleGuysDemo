using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimerScript : MonoBehaviour
{
    //public GameObject textdisplay;
    public int seconds = 30;
    public bool takingAway = false;
    Text textdisplay;
    void Start()
    {
        textdisplay = this.GetComponent<Text>();
        textdisplay.text = "TIMER : 00:" + seconds;
    }
    private void Update()
    {
        if (takingAway == false && seconds > 0)
        {
            StartCoroutine(Timertake());
        }
    }
    IEnumerator Timertake()
    {
        takingAway = true;
        yield return new WaitForSeconds(1);
        seconds = seconds - 1;
        if (seconds < 10)
        {
            textdisplay.text = "TIMER : 00:0" + seconds;
        }
        else
        {
            textdisplay.text = "TIMER : 00:" + seconds;
        }
        takingAway = false;
        if (seconds == 0f)
        {
            Debug.Log("Game over");
        }
    }
}
