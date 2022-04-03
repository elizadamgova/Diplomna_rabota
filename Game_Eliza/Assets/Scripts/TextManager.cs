using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextManager : MonoBehaviour
{
   //Variables
   public GameObject container; //Where on the screen does the text show
   public GameObject prefab; //Prefab of a text that is reusable 

   private List<ApearingText> texts = new  List<ApearingText>(); //List of text that needs to appear

   //Setter for texts
   public void Show(string msg, int fontSize, Color color, Vector3 position, Vector3 motion, float timer)
   {
       ApearingText appeartxt = GetText();
       appeartxt.txt.text = msg;
       appeartxt.txt.fontSize = fontSize;
       appeartxt.txt.color = color;
       appeartxt.go.transform.position = Camera.main.WorldToScreenPoint(position);
       appeartxt.motion = motion;
       appeartxt.timer = timer;

       appeartxt.Show();
    
   } 
   //Checks if there are active texts
   private ApearingText GetText () {

       ApearingText txt = texts.Find(t => !t.active);

       if (txt == null)
       {
           txt = new ApearingText();
           txt.go = Instantiate(prefab);
           txt.go.transform.SetParent(container.transform);
           txt.txt = txt.go.GetComponent<Text>();

           texts.Add(txt);
       }

       return txt;
   }

  
   //Shows texts that need to be shown Each frame 
   private void Update()
   {
       foreach (ApearingText txt in texts)
       {
           txt.UpdateText();
       }
   }
}
