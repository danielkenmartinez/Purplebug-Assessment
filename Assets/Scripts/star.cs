using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class star : MonoBehaviour
{
    public Rigidbody2D rb;
    public CapsuleCollider2D col;
    public GameObject parent;
    public pause pause;
    public BoxCollider2D box;
    public float direction = 1;
    public int collectPoint;
    public float moveSpeed;
    public bool activated;
    public bool collectOnce;
    public LayerMask layer;
    // Start is called before the first frame update
    void Start()
    {
        pause = FindObjectOfType<pause>();
        parent = transform.parent.gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        if(activated == false && parent == null)
        {
            activated= true;
            col.enabled = true;
            rb.bodyType = RigidbodyType2D.Dynamic;
        }

        if(activated == true && checkGround())
        {
            direction *= -1;
        }
    }

    public bool checkGround()
    {
        if(direction == 1)
        {
            return Physics2D.BoxCast(box.bounds.center, box.bounds.size, 0f, Vector2.right, .1f, layer);
        }
        else
        {
            return Physics2D.BoxCast(box.bounds.center, box.bounds.size, 0f, Vector2.left, .1f, layer);
        }
        
    }

    public void FixedUpdate()
    {
        rb.velocity = new Vector2(direction * moveSpeed, rb.velocity.y); ;
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.transform.tag == "Player")
        {
            if(collectOnce == false)
            {
                collectOnce = true;
                pause.currentScore += collectPoint;
                collision.transform.GetComponent<playerController>().acquireStar();
                Destroy(gameObject);
            }
            

        }
    }
}
