using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Movement : MonoBehaviour
{
    //public colorChanger color;
    public Animator anim;

    public SpriteRenderer spriite;

    public float moveSpeed = 5;
    public float stockSpeed = 5;
    public float jumpHeight = 8;
    public float sprintSpeed = 15;
    public bool onGround;

    public int framecount = 0;
    public int count = 0;
    public int movementstuff = 0;
    public int sprintSpeedvar = 0;

    public float friction = 0.5f;

    public int sideattack = 0;

    public int downAttack = 0;
    public int upAttack = 0;
    public bool right = true;
    public bool left = false;
    //public int jumpstuff = 0;

    public GameObject rightslash;
    public GameObject leftslash;
    public GameObject upslash;
    public GameObject downslash;


    

    private Collider2D _collider;

    public int crouch = 0;
    // Start is called before the first frame update


    void Start()
    {
        //clip = soundObject.GetComponent<AudioClip>();


        //color.setColor(1);
        anim = GetComponent<Animator>();
        spriite = GetComponent<SpriteRenderer>();
        _collider = GetComponent<Collider2D>();


        if(HomeMenu.speedVal == 0){
            moveSpeed = 2;
            sprintSpeed = 7;
        }else if(HomeMenu.speedVal == 2){
            moveSpeed = 10;
            sprintSpeed = 18;
        }else{
            moveSpeed = 5;
            sprintSpeed = 15;
        }

        stockSpeed = moveSpeed;
        
    }

    // Update is called once per frame
    void Update(){

        QualitySettings.vSyncCount = 0;  // VSync must be disabled
	    Application.targetFrameRate = 30;

        if(Health.curHealth < 1){
            this.Die();
        }

        //controlstuff:
        if (movementstuff == 0) {
        //stops infinite sliding
        if((GetComponent<Rigidbody2D>().velocity.x < 0.5) && (GetComponent<Rigidbody2D>().velocity.x > -0.5)){
            
            GetComponent<Rigidbody2D>().velocity = new Vector2(0, GetComponent<Rigidbody2D>().velocity.y);
        }

        if(Input.GetKeyDown(KeyCode.Space) && onGround){
		    GetComponent<Rigidbody2D>().velocity = new Vector2(GetComponent<Rigidbody2D>().velocity.x,jumpHeight);
            //anim.Play("Jump");
            //movementstuff = 1;
            //jumpstuff = 1;
        }


        if(Input.GetKey(KeyCode.D)){
            GetComponent<Rigidbody2D>().velocity = new Vector2(moveSpeed,GetComponent<Rigidbody2D>().velocity.y);
            //set to moving right color
            //color.setColor(3);
            //Debug.Log("right");
            if (onGround) {
                anim.Play("Walk");
            }
            else {
                anim.Play("Jump");
            }
            spriite.flipX = true;
            right = true;
            left = false;
            rightslash.gameObject.SetActive(false);
            leftslash.gameObject.SetActive(false);
            downslash.gameObject.SetActive(false);
            upslash.gameObject.SetActive(false);
        }
        if(Input.GetKey(KeyCode.A)){
            GetComponent<Rigidbody2D>().velocity = new Vector2(-moveSpeed,GetComponent<Rigidbody2D>().velocity.y);
            //set to moving left color
            //color.setColor(4);
            //Debug.Log("left");
            if (onGround) {
                anim.Play("Walk");
                moveSpeed = stockSpeed;
            }
            else {
                anim.Play("Jump");
            }
            spriite.flipX = false;
            right = false;
            left = true;
            rightslash.gameObject.SetActive(false);
            leftslash.gameObject.SetActive(false);
            downslash.gameObject.SetActive(false);
            upslash.gameObject.SetActive(false);
        }
        if (!(Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D)) && onGround && (GetComponent<Rigidbody2D>().velocity.x != 0)){
            //set to sliding color
            //color.setColor(5);
            //Debug.Log("slide");
            if(GetComponent<Rigidbody2D>().velocity.x > 0){
                GetComponent<Rigidbody2D>().velocity = new Vector2(GetComponent<Rigidbody2D>().velocity.x - friction, GetComponent<Rigidbody2D>().velocity.y);
            }else{
                GetComponent<Rigidbody2D>().velocity = new Vector2(GetComponent<Rigidbody2D>().velocity.x + friction, GetComponent<Rigidbody2D>().velocity.y);
            }
            anim.Play("Slide");
            //moveSpeed = stockSpeed;
        }

        if(Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.E)){
              movementstuff = 1;
              upAttack = 1;
              anim.Play("UpAttack");
              goto waitingstuff;
            
        }
        if(Input.GetKey(KeyCode.S) && Input.GetKey(KeyCode.E)){
              movementstuff = 1;
              downAttack = 1;
              anim.Play("DownAttack");
              goto waitingstuff;
        }
        if(Input.GetKey(KeyCode.E)){
              movementstuff = 1;
              sideattack = 1;
              anim.Play("SideAttack");
              goto waitingstuff;
        }
        if(onGround && Input.GetKey(KeyCode.LeftControl)){
            movementstuff = 1;
            crouch = 1;
            anim.Play("Crouch");
            goto waitingstuff;
        }

        if (onGround && Input.GetKey(KeyCode.LeftShift) && (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D))) {
            anim.Play("Run");
            moveSpeed = sprintSpeed;
            movementstuff = 1;
            sprintSpeedvar = 1;
            /*
            if (right == true) {
                GetComponent<Rigidbody2D>().velocity = new Vector2(moveSpeed,GetComponent<Rigidbody2D>().velocity.y);
            }
            if (left == true) {
                GetComponent<Rigidbody2D>().velocity = new Vector2(-moveSpeed,GetComponent<Rigidbody2D>().velocity.y);
            }
            */
            goto waitingstuff;
        }

        if(onGround && (GetComponent<Rigidbody2D>().velocity.x == 0)){
            //set idle color
            //color.setColor(1);
            //Debug.Log("idle");
            anim.Play("Idle");
            rightslash.gameObject.SetActive(false);
            leftslash.gameObject.SetActive(false);
            downslash.gameObject.SetActive(false);
            upslash.gameObject.SetActive(false);
            moveSpeed = stockSpeed;
        }

        if(!onGround){
            //set to in air color
            //color.setColor(2);
            //Debug.Log("in air");
            anim.Play("Jump");
            rightslash.gameObject.SetActive(false);
            leftslash.gameObject.SetActive(false);
            downslash.gameObject.SetActive(false);
            upslash.gameObject.SetActive(false);
            //moveSpeed = stockSpeed;
        }

        
        
        }


        waitingstuff:
        if (movementstuff == 0) {
        }

        else if (sideattack == 1) {
            framecount++;
            if(framecount == 8) {
                movementstuff = 0;
                framecount = 0;
                sideattack = 0;
            }
            if (left == true) {
                leftslash.gameObject.SetActive(true);
              }
              if (right == true) {
                rightslash.gameObject.SetActive(true);
            }
        }

        else if (upAttack == 1) {
            framecount++;
            if(framecount == 8) {
                movementstuff = 0;
                framecount = 0;
                upAttack = 0;
            }
            upslash.gameObject.SetActive(true);
        }

        else if (downAttack == 1) {
            framecount++;
            if(framecount == 8) {
                movementstuff = 0;
                framecount = 0;
                downAttack = 0;
            }
            downslash.gameObject.SetActive(true);
        }

        else if (crouch == 1) {
            framecount++;
            if(framecount == 8) {
                movementstuff = 0;
                framecount = 0;
                crouch = 0;
                
            }
        }

        else if (sprintSpeedvar == 1) {
            framecount++;
            if (right == true) {
                GetComponent<Rigidbody2D>().velocity = new Vector2(moveSpeed,GetComponent<Rigidbody2D>().velocity.y);
            }
            if (left == true) {
                GetComponent<Rigidbody2D>().velocity = new Vector2(-moveSpeed,GetComponent<Rigidbody2D>().velocity.y);
            }
            if (framecount == 7) {
                movementstuff = 0;
                sprintSpeedvar = 0;
                framecount = 0;
            }
        }
        

/*
        else if (jumpstuff == 1) {
            framecount++;
            if(framecount == 150) {
                movementstuff = 0;
                framecount = 0;
                jumpstuff = 0; 
            }
        } */




    }

    void OnCollisionEnter2D(Collision2D collision){
        if (collision.gameObject.tag == "ground"){
            onGround = true;
        }
    }

    void OnCollisionExit2D(Collision2D collision){
        if (collision.gameObject.tag == "ground"){
            onGround = false;
        }
    }



    public void Die()
    {
        _collider.enabled = false;
        SceneManager.LoadScene(1); 

    }
    
}
