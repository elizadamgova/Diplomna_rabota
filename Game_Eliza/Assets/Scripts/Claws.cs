using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Claws : Breakable
{
   //Variables
   public int dmg;
   public int pushmeassure;

   protected override void OnCollide(Collider2D collided)
   {
       if(collided.tag == "Battle" && collided.name == "Player")
       {
           Damage dealt = new Damage
        {
            dmgamount = dmg,
            target = transform.position,
            push = pushmeassure
        };
        Debug.Log (collided.name);

        collided.SendMessage("RecieveDamage", dealt);
          
       }
   }
}
