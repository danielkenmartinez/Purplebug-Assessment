using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class damagePlayer : MonoBehaviour
{

    public BoxCollider2D box;
    public LayerMask layer;
    public playerController player;
    public int hitPoints;
    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<playerController>();
    }

    // Update is called once per frame
    void Update()
    {
        if(checkPlayerLeft() && player.invulnerable == false|| checkPlayerRight() && player.invulnerable == false)
        {
            player.damagePlayer(hitPoints);
        }
    }

    public bool checkPlayerLeft()
    {
        return Physics2D.BoxCast(box.bounds.center, box.bounds.size, 0f, Vector2.left, .1f, layer);
    }
    public bool checkPlayerRight()
    {
        return Physics2D.BoxCast(box.bounds.center, box.bounds.size, 0f, Vector2.right, .1f, layer);
    }
}
