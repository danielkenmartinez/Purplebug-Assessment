using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.IO;
using UnityEngine.SceneManagement;

public class newHighScore : MonoBehaviour
{
    public GameManager gameManager;
    public GameObject gameOver;
    public GameObject newHigh;
    public TextMeshProUGUI score;
    public bool newRecord;
    public GameObject returnToMenu;
    public GameObject inputField;
    public TMP_InputField nameInput;
    public string tempName;
    public int tempScore;
    // Start is called before the first frame update
    void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
        if(gameManager.finalScore > gameManager.score3)
        {
            newRecord = true;
        }
        
        if(newRecord == true)
        {
            newHigh.active = true;
            inputField.active = true;
        }
        else
        {
            
            returnToMenu.active = true;
            gameOver.active = true;

        }

        score.text = "Final Score: " + gameManager.finalScore;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void submit()
    {
        if (gameManager.finalScore > gameManager.score3)
        {
            gameManager.score3 = gameManager.finalScore;
            gameManager.name3 = nameInput.text;
            if(gameManager.finalScore > gameManager.score2)
            {               
                gameManager.name3 = gameManager.name2; 
                gameManager.score3 = gameManager.score2;
                gameManager.name2 = nameInput.text;
                gameManager.score2 = gameManager.finalScore;
                if (gameManager.finalScore > gameManager.score1)
                {
                    gameManager.name2 = gameManager.name1; 
                    gameManager.score2 = gameManager.score1;
                    gameManager.name1 = nameInput.text;
                    gameManager.score1 = gameManager.finalScore;
                    save();

                }
                else
                {
                    save();

                }
            }
            else
            {
                save();
            }
        }
        else
        {
            save();
        }
    }

    public void save()
    {
        save save = new save
        {
            name1 = gameManager.name1,
            name2 = gameManager.name2,
            name3 = gameManager.name3,
            score1 = gameManager.score1,
            score2 = gameManager.score2,
            score3 = gameManager.score3
        };
        string json = JsonUtility.ToJson(save);
        File.WriteAllText(Application.persistentDataPath + "save.txt", json);
     
        SceneManager.LoadScene(0);
    }

    public void backToMenu()
    {
        SceneManager.LoadScene(0);
    }
}
