using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class KillYourself : MonoBehaviour
{
    [SerializeField] int myHealth;
    [SerializeField] bool boss;
    [SerializeField] GameObject me;
    // Start is called before the first frame update
    

    public void Damage(int i){
        myHealth -= i;

        if(myHealth < 1){
            me.gameObject.SetActive(false);
            if(boss){
                SceneManager.LoadScene(4);
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        var player = other.collider.GetComponent<Health>();
        if(player != null)
        {
            player.DamagePlayer(20);

        }
    }
}
