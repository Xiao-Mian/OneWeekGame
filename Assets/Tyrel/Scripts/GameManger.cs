using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;
using UnityEngine.UI;

public class GameManger : MonoBehaviour
{

    public GameObject _menu;
    public GameObject _options;

    public AudioClip[] aClips = null;
    AudioSource aSource = null;

    public static float _score;
    public Text _scoreText;

    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1;
        _score = 0;
        _menu.SetActive(false);
        _options.SetActive(false);
        aSource = GetComponent<AudioSource>();
        _scoreText.text = "Score: " + _score;
    }

    private void Update()
    {
        _scoreText.text = "Score: " + _score;
    }

    public void updateScore()
    {
        PlaySound(aClips[2]);
        _score++;
        
    }

    public void PauseGame()   
    {
        PlaySound(aClips[0]);
        OpenMenu();
        Time.timeScale = 0;
        
        
    }

    void OpenMenu()
    {
        _menu.SetActive(true);
    }

    public void ResumeGame()
    {
        Time.timeScale = 1;
        _menu.SetActive(false);
        PlaySound(aClips[1]);
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


    public void PlaySound(AudioClip clip)
    {
        aSource.PlayOneShot(clip);
    }
}
