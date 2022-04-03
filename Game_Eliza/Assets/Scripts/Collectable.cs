using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectable : Breakable
{
    //Variables
    protected int recieve = 3; //How muck health must be given
    protected bool collected; //Checks if the health has already been collected

    //Calls function RecieveHealth and saves
    protected override void OnCollide(Collider2D collided)
    {
        if (collided.name == "Player"){
            if(!collected){
                OnCollect();
                collided.SendMessage("RecieveHealth", recieve);
                GameManager.instance.Save();
            }
            
        }
    }
    //Sets if the health can be collected
    protected void OnCollect()
    {
        collected = true;
    }
}
