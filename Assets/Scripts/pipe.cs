using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pipe : MonoBehaviour
{
    public bool exit;
    public bool crouchToEnter;
    public GameObject entranceLocation;
    public GameObject exitLocation;
    public GameObject elevator;
    public Camera main;
    public pipe exitPipe;
    public playerController player;
    public Vector3 cameraDestination;
    public Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        main = FindObjectOfType<Camera>();
        player = FindObjectOfType<playerController>();
        if (exit == true)
        {
            elevator.transform.position = exitLocation.transform.position;
        }
        else
        {
            elevator.transform.position = entranceLocation.transform.position;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.transform.tag == "Player" && exit == false)
        {
            if(crouchToEnter == true)
            {
                if(player.crouching == true)
                {
                    player.transform.position = elevator.transform.position;
                    player.transform.parent = elevator.transform;
                    player.cantMove = true;
                    Debug.Log("EnteredPipe");
                    anim.SetBool("enter", true);
                }
            }
            else
            {
                player.transform.position = elevator.transform.position;
                player.transform.parent = elevator.transform;
                player.cantMove = true;
                Debug.Log("EnteredPipe");
                anim.SetBool("enter", true);
            }
        }
    }

    public void transport()
    {
        player.transform.parent = null;
        player.transform.position = exitPipe.elevator.transform.position;
        player.transform.parent = exitPipe.elevator.transform;
        main.transform.position = cameraDestination;
        exitPipe.anim.SetBool("exit", true);
    }

    public void release()
    {
        player.transform.parent = null;
        player.cantMove = false;
    }
}
