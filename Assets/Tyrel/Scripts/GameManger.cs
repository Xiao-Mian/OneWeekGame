using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManger : MonoBehaviour
{

    public GameObject _menu;
    public GameObject _options;
    

    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1;
        _menu.SetActive(false);
        _options.SetActive(false);
    }

    

    public void PauseGame()
    {
        Time.timeScale = 0;
        _menu.SetActive(true);

    }

    public void ResumeGame()
    {
        Time.timeScale = 1;
        _menu.SetActive(false);
    }

    public void Restart()
    {
        Scene scene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(scene.name);
    }
    
    public void Options()
    {
        _options.SetActive(true);
        _menu.SetActive(false);
    }

    public void Menu()
    {
        _options.SetActive(false);
        _menu.SetActive(true);
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
