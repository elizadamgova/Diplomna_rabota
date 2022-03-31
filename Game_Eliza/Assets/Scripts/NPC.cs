using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : MonoBehaviour
{
   
    private BoxCollider2D NPC_hitbox;

     private void Start()
    {
        NPC_hitbox = GetComponent<BoxCollider2D>();
    }
    
}
