using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Win : MonoBehaviour
{

    public GameObject _winCanvas;
    public Timer _timer;

    // Start is called before the first frame update
    void Start()
    {
        _winCanvas.SetActive(false);
        
        Time.timeScale = 1;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            _timer.EndTimer();
            _timer.UpdateTime();
            _winCanvas.SetActive(true);

            
        }
    }


}
