using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Timerfunction : MonoBehaviour
{
    private Text timer;
    private float timerTime = 4f;
    int timedisplay=0;

    private GameObject playerUi;
    private GameObject TimeScript;

    void Start()
    {
        timer = GetComponent<Text>();
        playerUi = GameObject.Find("InputButtons");
        TimeScript = GameObject.Find("Timer");
        TimeScript.SetActive(false);
        playerUi.active = false;
    }

   
    void Update()
    {
        if(timerTime  > 1)
        {
            timerTime -= Time.deltaTime;
            timedisplay = (int)timerTime;
            timer.text= timedisplay.ToString();
        }
        else
        {
            playerUi.SetActive(true);
            timer.text = "GO";
            TimeScript.SetActive(true);
            StartCoroutine(turnoffTimer());
        }
    }
    IEnumerator turnoffTimer()
    {
        yield return new WaitForSeconds(2f);
        this.gameObject.SetActive(false);
    }
}
