using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine.SceneManagement;

public class playerController : MonoBehaviour
{
    public Rigidbody2D rb;
    public float direction;
    public float moveSpeed;
    public float jumpForce;
    public float jumpTime;
    public float jumpDemerit;
    public float height;
    public int hitPoints;
    public Animator anim;
    public BoxCollider2D col;
    public PolygonCollider2D polyCol;
    public LayerMask layer;
    public bool isGrounded;
    public bool blocked;
    public bool grown;
    public bool firePower;
    public bool cantMove;
    public bool dead;
    public bool crouching;
    public bool invulnerable;
    public bool starPower;
    public float invulnerableTime;
    public SpriteRenderer model;
    public Color normalColor;
    public Color fireColor;
    public Color invulnerableFireColor;
    public Color invulnerableNormalColor;
    public Color invulnerableStarColor;
    public Canvas controls;
    public GameObject fireBall;
    public GameObject fireStart;
    public GameObject starProjectile;
    // Start is called before the first frame update
    void Start()
    {
        hitPoints = 1;
    }

    // Update is called once per frame
    void Update()
    {
     
        if(cantMove == false)
        {
            if (checkGround())
            {
                isGrounded = true;
                rb.velocity= Vector3.zero;
                anim.SetBool("jumping", false);

            }
            else
            {
                anim.SetBool("jumping", true);
                isGrounded = false;
            }

            if (jumpTime <= 0)
            {
                jumpTime = 0;
                jumpForce = rb.velocity.y;

            }
            else
            {
                jumpTime -= 1 * Time.deltaTime;
                
            }

            if (grown == false)
            {
                height = 2.5f;
            }
            else
            {
                height = 4;
            }
        }
        
       if(invulnerable == true)
        {

            gameObject.layer = LayerMask.NameToLayer("Invulnerable");
        }
       else
        {
            gameObject.layer = LayerMask.NameToLayer("Player");
        }

       if(invulnerableTime > 0)
        {
            invulnerableTime -= 1 * Time.deltaTime;
            invulnerable = true;
            if(firePower == false)
            {
                if (starPower == false)
                {
                    model.color = invulnerableNormalColor;
                }
                else
                {
                    
                    model.color = invulnerableStarColor;
                }
                
            }
            else
            {
                if(starPower == false)
                {
                    model.color = invulnerableFireColor;
                 
                }
                else
                {
                    model.color = invulnerableStarColor;
                }
                
            }
            
        }
       else
        {
            starPower = false;
            starProjectile.active = false;
            invulnerableTime = 0;
            invulnerable = false;
            if (firePower == false)
            {
                model.color = normalColor;
            }
            else
            {
                model.color = fireColor;
            }
        }

       
    }

    public void moveLeft()
    {

        if(cantMove == false)
        {
            Debug.Log("Holding Left");
            this.transform.localScale = new Vector3(-2.5f, height, 3);
            anim.SetBool("walking", true);
            direction = -1;
        }
        else
        {
            anim.SetBool("walking", false);
        }

    }

    public void moveRight()
    {
        if (cantMove == false)
        {
            Debug.Log("Holding Right");
            direction = 1;
            this.transform.localScale = new Vector3(2.5f, height, 3);
            anim.SetBool("walking", true);
        }
        else
        {
            anim.SetBool("walking", false);
        }
        
    }

    public void stopMove()
    {

        Debug.Log("stoppedMoving");
        direction = 0;
        anim.SetBool("walking", false);
    }
    public void release()
    {
        Debug.Log("Released");
    }
    public void crouch()
    {
            crouching = true;
    }

    public void stand()
    {
        crouching = false;
    }

   public void fire()
    {
        Debug.Log("Fired");
    }

    public void Jump()
    {
        if(isGrounded == true)
        {
            Debug.Log("Jumped");
            jumpTime = 0.42f;
            jumpForce = 5;
        }
    }

    public void stopJump()
    {

        jumpTime = 0;

    }

    public bool checkGround()
    {
        return Physics2D.BoxCast(col.bounds.center, col.bounds.size, 0f, Vector2.down, .1f, layer);
    }

    public void grow()
    {
        if (grown == false)
        {
            grown = true;
            height = 4;
            StartCoroutine("transform1");
            cantMove = true;
        }
    }

    public IEnumerator transform1()
    {
        invulnerableTime = 0.5f;
        this.transform.localScale = new Vector3(this.transform.localScale.x, 3.25f, this.transform.localScale.z);
        yield return new WaitForSeconds(0.2f);
        this.transform.localScale = new Vector3(this.transform.localScale.x, 3.50f, this.transform.localScale.z);
        StartCoroutine("transform2");
    }
    public IEnumerator transform2()
    {
        this.transform.localScale = new Vector3(this.transform.localScale.x, 3.75f, this.transform.localScale.z);
        yield return new WaitForSeconds(0.2f);
        this.transform.localScale = new Vector3(this.transform.localScale.x, 4, this.transform.localScale.z);
        cantMove = false;
    }

    public void damagePlayer(int damage)
    {
        hitPoints -= damage;
        if(hitPoints <= 0)
        {
            StartCoroutine("death");
        }
        else
        {
            StartCoroutine("transformDown1");
        }
    }

    public IEnumerator death()
    {
        direction = 0;
        this.transform.rotation = Quaternion.Euler(180f, this.transform.rotation.y, this.transform.rotation.z);
        jumpTime = 0.3f;
        jumpForce = 1f;
        polyCol.enabled = false;
        col.enabled = false;
        controls.enabled = false;
        yield return new WaitForSeconds(3f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

    }

    public IEnumerator transformDown1()
    {
        firePower = false;
        invulnerableTime = 2f;
        this.transform.localScale = new Vector3(this.transform.localScale.x, 3.75f, this.transform.localScale.z);
        yield return new WaitForSeconds(0.2f);
        this.transform.localScale = new Vector3(this.transform.localScale.x, 3.50f, this.transform.localScale.z);
        StartCoroutine("transformDown2");
    }
    public IEnumerator transformDown2()
    {
        this.transform.localScale = new Vector3(this.transform.localScale.x, 3.25f, this.transform.localScale.z);
        yield return new WaitForSeconds(0.2f);
        this.transform.localScale = new Vector3(this.transform.localScale.x, 2.5f, this.transform.localScale.z);
        cantMove = false;
        grown = false;
        height = 2.5f;

    }

    public void fireActivate()
    {
         StartCoroutine("fireTransform1");
         firePower = true;
         cantMove = true;
    }

    public IEnumerator fireTransform1()
    {

        invulnerableTime = 0.5f;
        model.color = invulnerableNormalColor;
        if(grown == false)
        {
            this.transform.localScale = new Vector3(this.transform.localScale.x, 3.25f, this.transform.localScale.z);
        }
        yield return new WaitForSeconds(0.2f);
        model.color = invulnerableFireColor;
        if (grown == false)
        {
            this.transform.localScale = new Vector3(this.transform.localScale.x, 3.50f, this.transform.localScale.z);
        }
           
        StartCoroutine("fireTransform2");
    }
    public IEnumerator fireTransform2()
    {
        model.color = invulnerableNormalColor;
        if (grown == false)
        {
            this.transform.localScale = new Vector3(this.transform.localScale.x, 3.75f, this.transform.localScale.z);
        }
        yield return new WaitForSeconds(0.2f);
        if (grown == false)
        {
            grown = true;
            height = 4;
            this.transform.localScale = new Vector3(this.transform.localScale.x, 4, this.transform.localScale.z);
        }
        model.color = invulnerableFireColor;
        cantMove = false;
    }


    public void fireBallCommand()
    {
        if(firePower == true)
        {
            GameObject newFireBall =  Instantiate(fireBall, fireStart.transform.position, transform.rotation);
            if(transform.localScale.x > 0)
            {
                newFireBall.GetComponent<Rigidbody2D>().velocity = new Vector2(8, -3);
            }
            else
            {
                newFireBall.GetComponent<Rigidbody2D>().velocity = new Vector2(-8, -3);
            }    
           
            
        }
    }

    public void acquireStar()
    {
        invulnerableTime = 10;
        starPower = true;
        starProjectile.active = true;
    }

    public void FixedUpdate()
    {
        if (cantMove == false)
        {
            rb.bodyType = RigidbodyType2D.Dynamic;
            rb.velocity = new Vector2(direction * moveSpeed, jumpForce);
        }
        else
        {
            rb.bodyType = RigidbodyType2D.Static;
        }


        if (blocked == true)
        {
            direction = 0;
        }
       
    }
}
