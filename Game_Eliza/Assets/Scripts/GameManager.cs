using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    //Variables
    public static GameManager instance; //Makes it avaliable form anywhere
    public Player player; //The character the player uses
    public int health; //Health of the character
    public TextManager ApearingTextManager; //Text manager

    //Setts things up the the scene starts
    private void Awake()
    {
        instance = this;  
        SceneManager.sceneLoaded += Load;
    }

    //Variables for floating text
    public void ShowText(string msg, int fontSize, Color color, Vector3 position, Vector3 motion, float timer)
    {
        ApearingTextManager.Show(msg, fontSize, color, position, motion, timer);

    }
    
    //Saves game
    public void Save()
    {
        
        string tosavehealth = health.ToString();

        PlayerPrefs.SetString("Savehealth", tosavehealth);

        Debug.Log("Saved state.");
    }

    //Loads game
    public void Load(Scene scene, LoadSceneMode scenemode) 
    {
        string loadhealth = PlayerPrefs.GetString("Savehealth");

        health = int.Parse(loadhealth);

        SceneManager.sceneLoaded -= Load;
        Debug.Log("Loaded state.");
    }
    
}
