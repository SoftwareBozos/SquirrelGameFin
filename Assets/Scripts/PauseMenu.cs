using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    //SerializeField makes the object private but still appear in the editor
    [SerializeField] GameObject pauseMenu;

    void Start(){
        pauseMenu.SetActive(false);
    }
    
    void Update(){
        if(Input.GetKey(KeyCode.Escape)){
            Pause();
        }
    }

    public void Pause(){
        //makes the canvas visible
        pauseMenu.SetActive(true);
        //timescale is the multiplier at which time passes(1->realtime and 0->paused)
        Time.timeScale = 0f;
    }

    public void Resume(){
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
    }

    public void Home(int ID){
        Time.timeScale = 1f;
        //loads the input scene
        SceneManager.LoadScene(ID);
    }
}
