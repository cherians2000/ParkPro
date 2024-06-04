using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerCarSelection : MonoBehaviour
{
    [Header("Buttons")]
    [SerializeField] private Button _previousButton;
    [SerializeField] private Button _nextButton;

    protected int currentcar = 0; // Initialize current car to 0

    private void Start()
    {

        currentcar = PlayerPrefs.GetInt("CarSelected", 0);
        chooseCar(currentcar);

      
    }

    private void chooseCar(int index)
    {
        _nextButton.interactable = (currentcar != 0);
        _previousButton.interactable = (currentcar != transform.childCount-1);
        for (int i = 0; i < transform.childCount; i++)
        {
            transform.GetChild(i).gameObject.SetActive(i == index);
        }
       
    }

    public void switchCar(int switchCars)
    {
        currentcar += switchCars;

        // Ensure currentcar stays within the bounds of the children
        if (currentcar < 0)
        {
            currentcar = 0;
        }
        else if (currentcar >= transform.childCount)
        {
            currentcar = transform.childCount - 1;
        }

        chooseCar(currentcar);
        PlayerPrefs.SetInt("CarSelected", currentcar);
        PlayerPrefs.Save();
    }
   
    public void Back()
    {
        SceneManager.LoadScene("MenuScene");
    }
}

