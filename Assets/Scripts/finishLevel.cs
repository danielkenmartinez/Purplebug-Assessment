using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class finishLevel : MonoBehaviour
{
    public playerController player;
    public GameManager gameManager;
    public pause levelComplete;
    public bool runOnce;
    public bool transferTime;
    public float time;
    public float fullScore;
    
    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<playerController>();
        gameManager = FindObjectOfType<GameManager>();
        levelComplete = FindObjectOfType<pause>();
    }

    // Update is called once per frame
    void Update()
    {
        if(transferTime == true)
        {
            if (levelComplete.time > 0)
            {
                levelComplete.time -= 100 * Time.deltaTime;
                levelComplete.timeText.text = (Convert.ToInt64(levelComplete.time)).ToString();
            }
            else
            {
                levelComplete.time = 0;
                levelComplete.timeText.text = "0";
            }
            
            if(levelComplete.currentScore < fullScore)
            {
                levelComplete.currentScore += 100 * Time.deltaTime;
            }
            else
            {
                levelComplete.currentScore = fullScore;
                transferTime = false;
                StartCoroutine("leaderBoard");
            }
                
        }
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            if(runOnce == false)
            {
                runOnce = true;
                levelComplete.levelComplete = true;
                player.model.enabled = false;
                player.cantMove = true;
                time = levelComplete.time;
                fullScore = levelComplete.currentScore + Convert.ToInt64(time) ;
                StartCoroutine("victory");
            }
        }
    }

    public IEnumerator victory()
    {

        yield return new WaitForSeconds(3);
        transferTime = true;
    }

    public IEnumerator leaderBoard()
    {
        gameManager.finalScore = Convert.ToInt32(fullScore);
        yield return new WaitForSeconds(3);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
