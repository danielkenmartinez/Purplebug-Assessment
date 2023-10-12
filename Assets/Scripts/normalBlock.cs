using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class normalBlock : MonoBehaviour
{
    public Animator anim;
    public BoxCollider2D collider;
    public GameObject effect;
    public float cooldown;
    public Renderer self;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(cooldown > 0)
        {
            cooldown -= 1 * Time.deltaTime;
        }
        else
        {
            collider.enabled = true;
            anim.SetBool("jumped", false);
        }
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            if(other.GetComponent<playerController>().grown == false)
            {
                collider.enabled = false;
                anim.SetBool("jumped", true);
                cooldown = 1;
            }   
            else
            {
                Instantiate(effect, this.transform.parent.position, this.transform.parent.rotation);
                self.enabled = false;
                StartCoroutine("destroy");
                
            }
           
        }
    }

    public IEnumerator destroy()
    {
        yield return new WaitForSeconds(0.5f);
        Destroy(gameObject.transform.parent.gameObject);
    }
}
