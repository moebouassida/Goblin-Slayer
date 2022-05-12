using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Playermovement : MonoBehaviour
{
    public float moveSpeed;
    public Rigidbody2D rb;
    public SpriteRenderer spriteRenderer;
    public Animator animator;
    private Vector3 velocity = Vector3.zero;

    public static Playermovement instance;

    public Text instru;

    private int c = 0;

    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("Il ya plus d'une instance de PlayerMovement04 dans la scène");
            return;
        }
        instance = this;

        instru = GameObject.FindGameObjectWithTag("Instru").GetComponent<Text>();
        instru.enabled = true;
    }

    private void Update()
    {
        StartCoroutine(instruction());
    }


    void FixedUpdate()
    {
        float horizontalMovement = Input.GetAxis("Horizontal") * moveSpeed * Time.deltaTime;
        MovePlayer(horizontalMovement);
        Flip(rb.velocity.x);
        float characterVelocity = Mathf.Abs(rb.velocity.x);
        animator.SetFloat("Speed",characterVelocity);

        
    }
    void MovePlayer(float _horizontalMovement)
    {
        Vector3 targetVelocity = new Vector2(_horizontalMovement,rb.velocity.y);
        rb.velocity = Vector3.SmoothDamp(rb.velocity,targetVelocity,ref velocity, .05f);
    }
    void Flip(float _velocity)
    {
        if (_velocity > 0.1f)
        spriteRenderer.flipX = false;
        else if (_velocity < -0.1f)
        spriteRenderer.flipX = true;
    }

    private IEnumerator instruction()
    {
        if ((Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.LeftArrow)) && c == 0)
        {
            c++;
            yield return new WaitForSeconds(1f);
            instru.enabled = false;
        }
    }
    
}
