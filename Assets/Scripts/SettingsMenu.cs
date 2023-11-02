using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SettingsMenu : MonoBehaviour
{
    //SerializeField makes the object private but still appear in the editor
    [SerializeField] GameObject settingsMenu;
    [SerializeField] Slider slider;
    
    void Awake(){
        slider.value = HomeMenu.speedVal;
    }

    public void Return(int ID){
        //loads the input scene
        SceneManager.LoadScene(ID);
    }

    public void Speed(){
        HomeMenu.speedVal = (int)slider.value;
    }
}
