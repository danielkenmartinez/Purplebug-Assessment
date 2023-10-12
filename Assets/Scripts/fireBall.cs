using UnityEngine;
using System.Collections;

public class fireBall : MonoBehaviour
{

    public Rigidbody2D rb;
    public GameObject exploson;
    public Vector2 velocity;
    public float contact;

    // Use this for initialization
    void Start()
    {
        Destroy(this.gameObject, 10);
        rb = GetComponent<Rigidbody2D>();
        velocity = rb.velocity;

    }

    // Update is called once per frame
    void Update()
    {


        if (rb.velocity.y < velocity.y)
        {
            rb.velocity = velocity;
        }
        

    }

    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        
    }
    void OnCollisionStay2D(Collision2D col)
    {

        rb.velocity = new Vector2(velocity.x, -velocity.y);


        float angle = Vector2.Angle(Vector2.right, col.contacts[0].normal);

        contact = angle;
        if (Mathf.Approximately(angle, 180f) || Mathf.Approximately(angle, 0f))
        {
            Explode();
        }

        if(col.transform.tag == "Enemy")
        {
            Explode();
        }

    }

    void Explode()
    {

        Instantiate(exploson, transform.position, Quaternion.identity);

        Destroy(this.gameObject);

    }
}