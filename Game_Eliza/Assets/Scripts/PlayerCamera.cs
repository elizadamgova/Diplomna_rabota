using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCamera : MonoBehaviour
{
   //Variables
   public Transform Player_camera; //What object is being followed
   public float boundX = 0.15f; //Bound for X
   public float boundY = 0.10f; //Bound for y

   //Checks if the object has reached a bound and of he ha has the camera moves
   private void LateUpdate(){
       Vector3 framegap = Vector3.zero;

       float framegapX = Player_camera.position.x - transform.position.x;
       if (framegapX > boundX || framegapX < -boundX){
           if(transform.position.x < Player_camera.position.x){
               framegap.x = framegapX - boundX;
           }
           else {
               framegap.x = framegapX + boundX;
           }
       }
       float framegapY = Player_camera.position.y - transform.position.y;
       if (framegapY > boundY || framegapY < -boundY){
           if(transform.position.y < Player_camera.position.y){
               framegap.y = framegapY - boundY;
           }
           else {
               framegap.y = framegapY + boundY;
           }
       }

       transform.position += new Vector3(framegap.x, framegap.y, 0);
   }
}
