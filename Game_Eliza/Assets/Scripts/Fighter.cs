using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fighter : MonoBehaviour
{

   //Variables of the Object
   public int hp = 10; //Current health
   public int maxhp = 10; //Maximum health
   public float tanacity = 0.2f; //Length of knockback

   protected float imunity = 0.5f;//Immunity after each hit
   protected float lastimunity;//How long it has been since last immunity
   
   //Direction for knockback
   protected Vector3 direction;
   
   //Function for recieving damage
   protected virtual void RecieveDamage(Damage dealt)
   {
       if(Time.time - lastimunity > imunity)
       {
           lastimunity = Time.time;
           hp -= dealt.dmgamount;
           direction = (transform.position - dealt.target).normalized * dealt.push;

           GameManager.instance.ShowText("-" + dealt.dmgamount.ToString() + " Health", 15, Color.red, transform.position, Vector3.up * 15, 3.0f);

           if (hp <= 0)
           {
               hp = 0;
               Death();
           }
       }
   }
   //Function for healing
   protected virtual void RecieveHealth(int recieve)
   {
       hp += recieve;
       if(hp > maxhp){
           recieve -= hp - maxhp;
           hp = maxhp;
       }
       GameManager.instance.ShowText("+" + recieve.ToString() + " Health", 15, Color.blue, transform.position, Vector3.up * 15, 3.0f);
   }
   
   //Function for death
   protected virtual void Death ()
   {

   }
    
}
