using UnityEngine;
using System.Collections;

public class TakeDamage : MonoBehaviour
{
    public Animator anim;

  
    public IEnumerator OnCollisionEnter2D(Collision2D collision) 
    {
        if(collision.transform.CompareTag("Player"))
        {
            PlayerHealth playerHealth = collision.transform.GetComponent<PlayerHealth>();
            playerHealth.TakeDamage(20);  
            anim.SetBool("isHurt",true); 
            yield return new WaitForSeconds(0.5f);
            anim.SetBool("isHurt",false); 

        }
    }
  
    
}
