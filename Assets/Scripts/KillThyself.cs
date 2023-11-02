using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillThyself : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D other)
    {
        var player = other.collider.GetComponent<KillYourself>();
        if(player != null)
        {
            player.Damage(10);

        }
    }
}
