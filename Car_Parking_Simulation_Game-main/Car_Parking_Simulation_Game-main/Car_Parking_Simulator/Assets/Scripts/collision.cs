using System;
using UnityEngine;

public class collision : MonoBehaviour
{
    public Rigidbody rb;
    [SerializeField] GameObject panel;
    [SerializeField] GameObject playerUi;
    public AudioSource audioSourcehigh;
    public AudioSource audioSourcelow;
    private IsParked isparked;
    bool IsGmameover=false;
    private void Start()
    {
        isparked = GameObject.Find("ParkingStation").GetComponent<IsParked>();
   
    }

    private void OnCollisionEnter(Collision collision)
    {
      if (collision.gameObject.CompareTag("obstacle"))
        {
            if (!isparked.IsCarParked)
            {
                GameOverPopUp();
                IsGmameover = true;


            }


         
        }
    }

    public void  GameOverPopUp()
    {
        panel.SetActive(true);
        playerUi.SetActive(false);
        audioSourcehigh.Pause();
        audioSourcelow.Pause();
        Time.timeScale = 0f;
        this.gameObject.SetActive(false);
    }
}
