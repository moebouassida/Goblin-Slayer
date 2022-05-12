using System.Collections;
using UnityEngine;

public class PlayerSlide : MonoBehaviour
{
    public PlayerMovement02 PL;
    public bool isSliding = false;
    public Rigidbody2D rigidBody;
    public Animator anim;
    public CapsuleCollider2D regularColl;
    public CapsuleCollider2D SlideColl;
    public float slideSpeed = 5f;
    
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.DownArrow))
        preformSlide();

    }
    private void preformSlide()
    {
        isSliding = true;
        anim.SetBool("isSlide",true);
        regularColl.enabled = false;
        SlideColl.enabled = true;
        if(!PL.spriteRenderer.flipX)
        {
            rigidBody.AddForce(Vector2.right * slideSpeed);  
        }else 
        {
            rigidBody.AddForce(Vector2.left * slideSpeed);    
        }
        StartCoroutine("stopSlide");



    }
    IEnumerator stopSlide()
    {
        yield return new WaitForSeconds(0.8f); 
        anim.Play("Idle");
        anim.SetBool("isSlide",false);
        regularColl.enabled = true;
        SlideColl.enabled = false;
        isSliding = false;

    }

}


