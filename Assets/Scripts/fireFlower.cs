using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fireFlower : MonoBehaviour
{
    public Rigidbody2D rb;
    public GameObject parent;
    public pause pause;
    public CapsuleCollider2D col;
    public bool activated;
    public bool collectOnce;
    public int collectPoint;
    // Start is called before the first frame update
    void Start()
    {
        pause = FindObjectOfType<pause>();
        parent = transform.parent.gameObject;

    }

    // Update is called once per frame
    void Update()
    {
        if (activated == false && parent == null)
        {
            activated = true;
            col.enabled = true;
            rb.bodyType = RigidbodyType2D.Kinematic;
        }
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.tag == "Player")
        {
            collision.gameObject.GetComponent<playerController>().fireActivate();
            if (collectOnce == false)
            {
                pause.currentScore += collectPoint;
                collectOnce = true;
                collision.gameObject.GetComponent<playerController>().hitPoints = 2;
                Destroy(gameObject);
            }


        }
    }

}
