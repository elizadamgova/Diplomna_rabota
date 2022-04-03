using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Move
{
    //Variables
    public float chaserange = 10; //Chase range
    private bool colideplayer; //Coliding with player
    private Transform playerpos; //Player position
    private Vector3 start; //Location

    public ContactFilter2D filter; //Filter that selects what gets collided
    private BoxCollider2D hitbox; //The Box Collider that we check
    private Collider2D[] hits = new Collider2D[5]; //Array of objects we are currently coliding with 

    //Getting data at start
    protected override void Start ()
    {
        base.Start();
        playerpos = GameManager.instance.player.transform;
        start = transform.position;
        hitbox = transform.GetChild(0).GetComponent<BoxCollider2D>();
    }

    //Moving every frame 
    private void Update() 
    {

        if (Vector3.Distance(playerpos.position, start) < chaserange)
        {
            if(!colideplayer)
            {
                UpdatePosition((playerpos.position - transform.position).normalized);
            }
            else
            {
                UpdatePosition(start - transform.position);
            }
            
        }
        else
        {
            UpdatePosition(start - transform.position);
        }

        colideplayer = false;

        hitbox.OverlapCollider(filter, hits);

        for (int i = 0; i < hits.Length; i++)
        {
            if(hits[i] == null)
            {
                continue;
            }

            if(hits[i].tag == "Battle" && hits[i].name == "Player")
            {
                colideplayer = true;
            }
            hits[i] = null;
        }
    }
    //Dying 
    protected override void Death()
    {
        Destroy(gameObject);
    }
    
}
