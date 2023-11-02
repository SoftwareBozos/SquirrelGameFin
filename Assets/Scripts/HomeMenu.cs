using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HomeMenu : MonoBehaviour
{
    //SerializeField makes the object private but still appear in the editor
    [SerializeField] GameObject homeMenu;

    public static int speedVal;
    

    void Start()
    {
        //sets the player speed to default      
    }

    public void Play(int ID){
        //loads the input scene
        SceneManager.LoadScene(ID);        
    }

    public void Settings(int ID){
        //loads the input scene
        SceneManager.LoadScene(ID);
    }

    public void Quitter(){
        //Exits Game
        Application.Quit();
    }
}
