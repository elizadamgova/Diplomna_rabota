using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    private BoxCollider2D Player_hitbox;
    private Vector3 Player_vector;
    private RaycastHit2D hit;
    
    private void Start()
    {
        Player_hitbox = GetComponent<BoxCollider2D>();
    }

    private void FixedUpdate(){

        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical");

        Player_vector = new Vector3(x, y, 0);

        if (Player_vector.x > 0){
            transform.localScale = Vector3.one;
        }
        else if (Player_vector.x < 0){
            transform.localScale = new Vector3(-1, 1, 1);
        }

        hit = Physics2D.BoxCast(transform.position, Player_hitbox.size, 0, new Vector3(0, Player_vector.y), Mathf.Abs(Player_vector.y * Time.deltaTime), LayerMask.GetMask("People", "Collision"));

        if (hit.collider == null){
            transform.Translate(0, Player_vector.y * Time.deltaTime, 0);
        }
        

        hit = Physics2D.BoxCast(transform.position, Player_hitbox.size, 0, new Vector3(Player_vector.x, 0), Mathf.Abs(Player_vector.x * Time.deltaTime), LayerMask.GetMask("People"));

        if (hit.collider == null){
            transform.Translate(Player_vector.x * Time.deltaTime, 0, 0);
        }
        

        }
        
    }
