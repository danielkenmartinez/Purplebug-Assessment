using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraFollow : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject player;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(this.transform.position.x != player.transform.position.x)
        {
            this.transform.position = Vector2.Lerp(this.transform.position, new Vector2(player.transform.position.x, this.transform.position.y),Time.deltaTime * 1f);
     
        }
        
    }

   
}
