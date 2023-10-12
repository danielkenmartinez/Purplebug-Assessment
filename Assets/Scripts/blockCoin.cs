using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class blockCoin : MonoBehaviour
{
    public pause pause;
    public GameObject effect;
    public int collectPoint;
    public bool collectOnce;
    // Start is called before the first frame update
    void Start()
    {
        pause = FindObjectOfType<pause>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void gain()
    {
        if (collectOnce == false)
        {
            pause.currentScore += collectPoint;
            collectOnce = true;
        }
        Destroy(transform.parent.gameObject);
        Instantiate(effect, transform.position, transform.rotation);
    }
}
