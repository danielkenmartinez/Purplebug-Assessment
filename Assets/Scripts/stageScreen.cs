using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class stageScreen : MonoBehaviour
{
    public float timeBeforePlay;
    private bool timerStarted = false;
    public AudioSource music;
    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (!timerStarted)
        {
            timerStarted = true;
            return;
        }
        if (timeBeforePlay > 0)
        {
            timeBeforePlay -= Time.unscaledDeltaTime;
        }
        else
        {
            Time.timeScale = 1;
            music.enabled = true;
            this.gameObject.active = false;
        }
        
    }
}
