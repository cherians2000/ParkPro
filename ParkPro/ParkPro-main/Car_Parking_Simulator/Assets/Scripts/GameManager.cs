using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
  static string scene;

    private void Awake()
    {
      
        Screen.orientation = ScreenOrientation.LandscapeLeft;
    }
    public void PlayAgain()
    {
        // Reload the current scene
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1.0f;
    }

    public void Exit()
    {
        Application.Quit();
        Debug.Log("Quitting");
    }
    public void JumpToMainMenu()
    {
        SceneManager.LoadScene("MenuScene");
    }
    public void PouseMenu(float time)
    {

        Time.timeScale = time;
    }
    public void VolumeMenu()
    {
        scene = SceneManager.GetActiveScene().name;
        SceneManager.LoadScene("VolumeScene");
    }
    public void VolumeBack()
    {
        SceneManager.LoadScene(scene);
    }
}
