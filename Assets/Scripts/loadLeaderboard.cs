using System.Collections;
using System.Collections.Generic;
using System.Xml.Linq;
using System.IO;
using UnityEngine;
using TMPro;

public class loadLeaderboard : MonoBehaviour
{
    public TextMeshProUGUI name1;
    public TextMeshProUGUI name2;
    public TextMeshProUGUI name3;
    public TextMeshProUGUI score1;
    public TextMeshProUGUI score2;
    public TextMeshProUGUI score3;
    // Start is called before the first frame update
    void Start()
    {
        if (File.Exists(Application.persistentDataPath + "save.txt"))
        {
            string saveString = File.ReadAllText(Application.persistentDataPath + "save.txt");
            save save = JsonUtility.FromJson<save>(saveString);
            name1.text = (save.name1);
            name2.text = (save.name2);
            name3.text = (save.name3);
            score1.text = (save.score1).ToString();
            score2.text = (save.score2).ToString();
            score3.text = (save.score3).ToString();
        }
        else
        {
            name1.text = "Name1";
            name2.text = "Name2";
            name3.text = "Name3";
            score1.text = "0";
            score2.text = "0";
            score3.text = "0";
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
