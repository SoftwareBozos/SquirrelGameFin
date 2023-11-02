using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Counter : MonoBehaviour
{
    private int frame;
    // Start is called before the first frame update
    void Start()
    {
        frame = 0;        
    }

    // Update is called once per frame
    void Update()
    {
        frame += 1;
        if(frame > 300){
            SceneManager.LoadScene(0);
        }
    }
}
