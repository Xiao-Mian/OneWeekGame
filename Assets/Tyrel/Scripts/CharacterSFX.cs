using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class CharacterSFX : MonoBehaviour
{
    Movement _movement;

    public AudioClip[] aClips = null;
    AudioSource aSource = null;

    float walkStepLength = 0.2f;
    public float timerMax = 1f;
    public float timer = 0;

    // Start is called before the first frame update
    void Start()
    {
        _movement = GetComponent<Movement>();   
        aSource = GetComponent<AudioSource>();

    }

    void playwalking()
    {
        int aIndex = Random.Range(2, aClips.Length);



        timer -= Time.deltaTime;
        if (timer < 0)
        {

            timer = walkStepLength;
            aSource.clip = aClips[aIndex];

            PlayFootSteps(aClips[aIndex]);
        }



    }

    void Update()
    {

        if (_movement.HorizontalVelocity > 0 && _movement.Grounded)
            playwalking();
        else if (_movement.HorizontalVelocity < 0 && _movement.Grounded)
            playwalking();

        if (_movement.HorizontalVelocity > 50)
            PlayFootSteps(aClips[1]);

        if (_movement.Jumping)
            PlayFootSteps(aClips[0]);


    }

    void PlayFootSteps(AudioClip clip)
    {

        aSource.PlayOneShot(clip);

    }

    
}
