using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class itemBlock : MonoBehaviour
{
    public bool star;
    public GameObject child;
    public GameObject bush;
    public GameObject flower;
    public playerController player;             
    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<playerController>();
        if (star == false)
        {
            if (player.hitPoints < 2)
            {
                bush.active = true;
                child = bush;

            }
            else
            {
                flower.active = true;
                child = flower;
            }
        }
        else
        {
            
        }
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void detach()
    {
        child.transform.parent = null;
        Destroy(gameObject);

    }
}
