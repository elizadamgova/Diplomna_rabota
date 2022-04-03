using UnityEngine;
using UnityEngine.UI;

public class ApearingText
{
    //Variables
    public bool active; //Is the text active
    public GameObject go; //Referance to self
    public Text txt; //Text
    public Vector3 motion; //Movement
    public float timer; //How should it be on the screen
    public float lastshown; //How long ago was it shown

    //Activates the text
    public void Show()
    {
        active = true;
        lastshown = Time.time;
        go.SetActive(active);
    }

    //Deactivates the text
    public void Hide ()

    {
        active = false;
        go.SetActive(active);
    }

    //Puts text on screen
    public void UpdateText()
    {
        if(!active)
        {
            return;
        }
        if(Time.time - lastshown > timer)
        {
            Hide();
        }
        if(active)
        {
            go.transform.position += motion * Time.deltaTime;
        }
    }
    
}
