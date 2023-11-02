using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstantDeath : MonoBehaviour
{
    // Start is called before the first frame update
    private void OnCollisionEnter2D(Collision2D other)
    {
        var player = other.collider.GetComponent<Movement>();
        if(player != null)
        {
            player.Die();
        }
    }
}
