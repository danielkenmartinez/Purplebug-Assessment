using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class frogAI : MonoBehaviour
{
    public Rigidbody2D rb;
    public BoxCollider2D box;
    public CapsuleCollider2D capsule;
    public pause pause;
    public float direction = 1;
    public float moveSpeed;
    public int killPoint;
    public bool activated;
    public LayerMask layer;
    public Animator anim;
    public bool bumpedEnemy;
    public bool collectOnce;
    // Start is called before the first frame update
    void Start()
    {
        pause = FindObjectOfType<pause>();
    }

    // Update is called once per frame
    void Update()
    {
      

        if (activated == true && checkGround())
        {
            direction *= -1;
        }
    }

    public bool checkGround()
    {
        if (direction == 1)
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

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.transform.tag == "Player")
        {
            if(collision.GetComponent<playerController>().isGrounded == false)
            {
                moveSpeed = 0;
                transform.localScale = new Vector3(0.8f, 0.2f, 0);
                anim.SetBool("dead", true);
                collision.GetComponent<playerController>().jumpTime = 0.2f;
                collision.GetComponent<playerController>().jumpForce = 1f;
                if (collectOnce == false)
                {
                    pause.currentScore += killPoint;
                    collectOnce = true;
                }
                capsule.enabled = false;
                StartCoroutine("destroy");
            }
           
        }

       
    }

    public IEnumerator destroy()
    {
        yield return new WaitForSeconds(0.5f);
        Destroy(gameObject);
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.transform.tag == "Enemy")
        {
            direction *= -1;
        }

        if (collision.transform.tag == "Projectile")
        {
            if (collectOnce == false)
            {
                pause.currentScore += killPoint;
                collectOnce = true;
            }   
            moveSpeed = 0;
            anim.SetBool("dead", true);
            this.transform.rotation = Quaternion.Euler(180f, this.transform.rotation.y, this.transform.rotation.z);
            capsule.enabled = false;
            box.enabled = false;
        }
    }
}
