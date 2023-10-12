using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class kill : MonoBehaviour
{
    // Start is called before the first frame update
    public float lifetime;
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        if(lifetime > 0)
        {
            lifetime -= 1 * Time.deltaTime;
        }
        else
        {
            Destroy(gameObject);
        }
       
    }
}
