using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour
{
    Button[] buttons;
    public GameObject LevelButtons;
    private void Awake()
    {
        Time.timeScale = 1f;
        ButtonsToArray();
        int unlokedLeve = PlayerPrefs.GetInt("Unlocklevel", 1);

        for(int i=0;i< buttons.Length;i++)
        {
            buttons[i].interactable = false;
        }
        for(int i=0;i<unlokedLeve;i++)
        {
            buttons[i].interactable=true;
        }
    }
    public void OpenNewLevel(int levelId)
    {
        string levelname = "Level" + levelId;
        SceneManager.LoadScene(levelname);
    }
   
    void ButtonsToArray()
    {
        int childcount=LevelButtons.transform.childCount;
        buttons=new Button[childcount];
        for (int i = 0;i < childcount;i++)
            {
            buttons[i]=LevelButtons.transform.GetChild(i).gameObject.GetComponent<Button>();
        }
    }
    public void Quit()
    {
        Application.Quit();
    }
    public void GaraageScene()
    {
        SceneManager.LoadScene("Garage");
    }
   
}
