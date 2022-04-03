using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Move : Fighter
{
    //Variables 
    private BoxCollider2D Player_hitbox; //Collision
    private Vector3 Player_vector; //Vector for movement
    private RaycastHit2D hit; //Hit Detection

    //Speed of object
    protected float yspeed = 0.5f;
    protected float xspeed = 0.75f;
    
    
    
    protected virtual void Start()
    {
        Player_hitbox = GetComponent<BoxCollider2D>();
    }

    //Function that updates position and detects hits
    protected void UpdatePosition(Vector3 input){

        //Position
        Player_vector = new Vector3 (input.x * xspeed, input.y * yspeed, 0);

        //Making the object flip when it changes direction
        if (Player_vector.x > 0){
            transform.localScale = Vector3.one;
        }
        else if (Player_vector.x < 0){
            transform.localScale = new Vector3(-1, 1, 1);
        }

        //Knockback work
        Player_vector += direction;

        direction = Vector3.Lerp(direction, Vector3.zero, tanacity);

        //Hit detection for y and x
        hit = Physics2D.BoxCast(transform.position, Player_hitbox.size, 0, new Vector3(0, Player_vector.y), Mathf.Abs(Player_vector.y * Time.deltaTime), LayerMask.GetMask("People", "Collision"));

        if (hit.collider == null){
            transform.Translate(0, Player_vector.y * Time.deltaTime, 0);
        }
        

        hit = Physics2D.BoxCast(transform.position, Player_hitbox.size, 0, new Vector3(Player_vector.x, 0), Mathf.Abs(Player_vector.x * Time.deltaTime), LayerMask.GetMask("People", "Collision"));

        if (hit.collider == null){
            transform.Translate(Player_vector.x * Time.deltaTime, 0, 0);
        }
        

        }
}
