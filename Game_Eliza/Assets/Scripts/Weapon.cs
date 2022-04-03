using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : Breakable
{ 
  //Variables
  public int dmg = 2; //Damage that the weapondeals
  public float pushmeassure = 3.0f; //Strenght of knockback

  private Animator anima; //Allows an animation to play
  private float cd = 0.5f; //Cooldown of swing
  private float swinged; //Records the time of last swing


  //Sets the animator and collider
  protected override void Start ()
  {
      base.Start();
      anima = GetComponent<Animator>();
  }
  //Checks if the player has swung
  protected override void Update ()
  {
      base.Update();

      if(Input.GetKeyDown(KeyCode.Space))
      {
          if(Time.time - swinged > cd)
          {
              swinged = Time.time;
              Swing();
          }
      }

  }
  //Calls function RecieveDamage if a player is hit
  protected override void OnCollide(Collider2D collided)
  {
      if(collided.tag == "Battle")
      {
        if(collided.name == "Player")
            return;
          
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
  //Plays the animation if the player has swung
  private void Swing ()
  {
      Debug.Log("Swing");
      anima.SetTrigger("Swing");
  }
}
