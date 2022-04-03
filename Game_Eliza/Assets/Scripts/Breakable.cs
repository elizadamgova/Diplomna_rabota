using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Breakable : MonoBehaviour
{
    //Variables 
    public ContactFilter2D filter; //Filter that selects what gets collided
    private BoxCollider2D BoxCollider; //The Box Collider that we check
    private Collider2D[] hits = new Collider2D [5]; //Array of objects we are currently coliding with 

    protected virtual void Start ()
    {
        BoxCollider = GetComponent<BoxCollider2D>(); //Setting the Box Collider of the current object
    }

    //Collecting data from hit
    protected virtual void Update ()
    {
        BoxCollider.OverlapCollider(filter, hits);
        for (int i = 0; i < hits.Length; i++)
        {
            if (hits[i] == null)
                continue;
            OnCollide(hits[i]);
            hits[i] = null;
        }
    }

    protected virtual void OnCollide (Collider2D collided)
    {
        Debug.Log (collided.name);
    }
}
