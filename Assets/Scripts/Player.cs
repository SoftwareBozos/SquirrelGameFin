
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float moveSpeed = 5;
    public float jumpHeight = 8;
    private Collider2D _collider;

    [SerializeField] private bool _active = true; 
    // Start is called before the first frame update
    private void Start()
    {
        _collider = GetComponent<Collider2D>();
    }

    // Update is called once per frame
     private void Update()
    {
        if (!_active)
        {
            return; 
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(GetComponent<Rigidbody2D>().velocity.x, jumpHeight);

        }
        if (Input.GetKey(KeyCode.D))
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(moveSpeed, GetComponent<Rigidbody2D>().velocity.y);

        }
        if (Input.GetKey(KeyCode.A))
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(-moveSpeed, GetComponent<Rigidbody2D>().velocity.y);

        }
    }
    private void MiniJump()
    {
        GetComponent<Rigidbody2D>().velocity = new Vector2(GetComponent<Rigidbody2D>().velocity.x, 3);
    }
    public void Die()
    {
        _active = false;
        _collider.enabled = false;
        MiniJump();
    }


}
