using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.UIElements;
using TMPro;
using System;

public class pause : MonoBehaviour
{
    public float time;
    public bool levelComplete;
    public TextMeshProUGUI timeText;
    public TextMeshProUGUI points;
    public float currentScore;
    public GameObject panel;
    public playerController player;
    public GameObject playerKiller;
    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<playerController>();
    }

    // Update is called once per frame
    void Update()
    {
        points.text = Convert.ToInt64(currentScore).ToString();
        if (levelComplete == false)
        {
            if (time > 0)
            {
                time -= 1 * Time.deltaTime;
                timeText.text = (Convert.ToInt64(time)).ToString();
            }
            else
            {
                if(player.dead!= true && player.cantMove == false)
                Instantiate(playerKiller, player.transform.position, player.transform.rotation);
                time = 0;
            }
        }
        
    }

    public void pauseGame()
    {
        Time.timeScale = 0;
        panel.active = true;
    }

    public void unpauseGame()
    {
        Time.timeScale = 1;
        panel.active = false;
    }

    public void mainMenu()
    {
        SceneManager.LoadScene(0);
    }
}
