using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TimerScript : MonoBehaviour
{
    private float timeduration = 2f * 60f;
    private float timer;
    [SerializeField] private TextMeshProUGUI firstMinute;
    [SerializeField] private TextMeshProUGUI secondMinute;
    [SerializeField] private TextMeshProUGUI firstsecond;
    [SerializeField] private TextMeshProUGUI secondSecond;
    [SerializeField] private TextMeshProUGUI seperator;
    [SerializeField] private Text text;
    private float flashInterval = 0.1f; // Interval for the flashing effect
    private bool isFlashing = false;

    private float highScore = 0.0f;
    private string highScoreKey = "_HighScore"; // The key for PlayerPrefs.
    private collision _collision;
    private bool _IsCarFinished= false;
    void Start()
    {
        ResetTimer();
        _collision = GameObject.FindGameObjectWithTag("Player").GetComponent<collision>();
        // Load the high score from PlayerPrefs.
        if (PlayerPrefs.HasKey(highScoreKey))
        {
            highScore = PlayerPrefs.GetFloat(highScoreKey);
        }
     
    }

    void Update()
    {
        if(!_IsCarFinished)
        {
            CallTimerFuction();
        }
 
    }

    private void CallTimerFuction()
    {
        if (timer > 0)
        {
            timer -= Time.deltaTime;
            Updatediplay(timer);

            if (timer < 6 && !isFlashing)
            {
                firstMinute.color = Color.red;
                secondMinute.color = Color.red;
                seperator.color = Color.red;
                firstsecond.color = Color.red;
                secondSecond.color = Color.red;
                isFlashing = true;
                StartCoroutine(FlashTimer());
            }
        }
        else
        {
            flash();
        }
    }
    
    public void ResetTimer()
    {
        
       timer = timeduration;
    }

    private void Updatediplay(float time)
    {
        float minutes = Mathf.FloorToInt(time / 60);
        float seconds = Mathf.FloorToInt(time % 60);

        string currentTime = string.Format("{00:00}{1:00}", minutes, seconds);
        firstMinute.text = currentTime[0].ToString();
        secondMinute.text = currentTime[1].ToString();
        firstsecond.text = currentTime[2].ToString();
        secondSecond.text = currentTime[3].ToString();
    }

    void flash()
    {
        if (timer != 0)
        {
            timer = 0;
            Updatediplay(timer);
            _collision.GameOverPopUp();
        }
    }

    private void settextDisplay(bool enabled)
    {
        firstMinute.enabled = enabled;
        secondMinute.enabled = enabled;
        secondSecond.enabled = enabled;
        firstsecond.enabled = enabled;
        seperator.enabled = enabled;
    }

    IEnumerator FlashTimer()
    {
        while (isFlashing)
        {
            settextDisplay(false);
            yield return new WaitForSeconds(flashInterval);
            settextDisplay(true);
            yield return new WaitForSeconds(flashInterval);
        }
    }
    public void CarFinshed()
    {
        if (timer > highScore)
        {
            _IsCarFinished = true;
            highScore = timer;
            text.text = "New High Score Achived";

            // Update the high score display.
            Updatediplay(highScore);
         
            PlayerPrefs.SetFloat(highScoreKey, highScore);
            PlayerPrefs.Save();

           
        }
    }
}
