using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class specialBlock : MonoBehaviour
{
    public Animator anim;
    public Color defaultColor;
    public SpriteRenderer renderer;
    public GameObject text;
    public GameObject item;
    public Sprite newSprite;
    public BoxCollider2D collider;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
            collider.enabled = false;
            Debug.Log("SpecialBlock Activated");
            anim.SetBool("activated", true);
            renderer.sprite = newSprite;
            renderer.color = defaultColor;
            Destroy(text);
            Instantiate(item, transform.position, transform.rotation);
        }
    }
}
