using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class IsParked : MonoBehaviour
{
    [SerializeField]
    private GameObject LevelWin;
  
    private collision _collision;
    public bool IsCarParked= false;
    [SerializeField]
    private GameObject TimerWindow;
    TimerScript _timerScript;
    private void Start()
    {
      
        _timerScript =TimerWindow.GetComponent<TimerScript>();
        IsCarParked = false;

    }
    private void OnTriggerEnter(Collider other)
    {
        _collision = GameObject.FindGameObjectWithTag("Player").GetComponent<collision>();
        if (other.transform.CompareTag("Player"))
        {

            IsCarParked = true;
            _timerScript.CarFinshed();
            UnlockNewLevel();
            LevelWin.SetActive(true);
            StartCoroutine(LoadSceneAfterDelay(3f));
        }
      
    }
    void UnlockNewLevel()
    {
        if (SceneManager.GetActiveScene().buildIndex >= PlayerPrefs.GetInt("ReachedIndex"))
        {
         
            PlayerPrefs.SetInt("ReachedIndex", SceneManager.GetActiveScene().buildIndex + 1);
            PlayerPrefs.SetInt("Unlocklevel", PlayerPrefs.GetInt("Unlocklevel", 1) + 1);
            PlayerPrefs.Save();
        }
    }
    IEnumerator LoadSceneAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
