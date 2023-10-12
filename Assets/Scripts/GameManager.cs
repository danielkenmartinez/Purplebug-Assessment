using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.IO;
using UnityEngine.UI;
using System.Xml.Linq;


public class save
{
    public string name1;
    public string name2; 
    public string name3;
    public int score1;
    public int score2;
    public int score3;
}
public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update
    public string name1;
    public string name2;
    public string name3;
    public int score1;
    public int score2;
    public int score3;
    public int finalScore;

    private void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
        if (File.Exists(Application.persistentDataPath + "save.txt"))
        {
            string saveString = File.ReadAllText(Application.persistentDataPath + "save.txt");
            save save = JsonUtility.FromJson<save>(saveString);
            name1 = (save.name1);
            name2 = (save.name2);
            name3 = (save.name3);
            score1 = (save.score1);
            score2 = (save.score2);
            score3 = (save.score3);

        }
        else
        {
            save save = new save
            {
                name1 = "Name",
                name2 = "Name",
                name3 = "Name",
                score1 = 0,
                score2 = 0,
                score3 = 0
            };
            string json = JsonUtility.ToJson(save);
            File.WriteAllText(Application.persistentDataPath + "save.txt", json);
        }
        

        
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       
    }
}
