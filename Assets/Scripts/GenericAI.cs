using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenericAI : MonoBehaviour {
    public float speed = 1;
    int frames;
    // Start is called before the first frame update
    void Start() {
        frames = 0;
    }

    // Update is called once per frame
    void Update()
    {
        frames++;
        if(frames % 120 == 0) speed = -speed;
        if (frames > 720) frames = 0;
        GetComponent<Rigidbody2D>().velocity = new Vector2(speed,0);
    }
}
