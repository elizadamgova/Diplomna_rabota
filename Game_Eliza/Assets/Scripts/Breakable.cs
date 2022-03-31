using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Breakable : MonoBehaviour
{
    public ContactFilter2D filter;
    private BoxCollider2D BoxCollider;
    private Collider2D[] hits = new Collider2D [10];

    protected virtual void Start ()
    {
        BoxCollider = GetComponent<BoxCollider2D>();
    }

    protected virtual void Update ()
    {
        BoxCollider.OverlapCollider(filter, hits);
        for (int i = 0; i < hits.Length; i++)
        {
            if (hits[i] == null)
                continue;
            Debug.Log(hits[i].name);
            hits[i] = null;
        }
    }
}
