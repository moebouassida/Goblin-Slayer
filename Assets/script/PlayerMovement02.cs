using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerMovement02 : MonoBehaviour
{
    public float moveSpeed;
    public Rigidbody2D rb;
    public Animator animator;
    public SpriteRenderer spriteRenderer;
    public float jumpForce;
    bool isGrounded;
    public LayerMask groundlayer;
    private Vector3 velocity = Vector3.zero;
    public Transform groundCheck;

    public static PlayerMovement02 instance;

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

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.UpArrow))
        {
            if (isGrounded)
            {    
                Jump();  
            }  
        }
        StartCoroutine(instruction());

    }
    void FixedUpdate()
    {
        float horizontalMovement = Input.GetAxis("Horizontal") * moveSpeed * Time.deltaTime;
        MovePlayer(horizontalMovement);
        Flip(rb.velocity.x);
        float characterVelocity = Mathf.Abs(rb.velocity.x);
        isGrounded = Physics2D.OverlapCircle(groundCheck.position,0.25f,groundlayer);
        animator.SetFloat("Speed",characterVelocity);

        
    }
    void MovePlayer(float _horizontalMovement)
    {
        Vector3 targetVelocity = new Vector2(_horizontalMovement,rb.velocity.y);
        rb.velocity = Vector3.SmoothDamp(rb.velocity,targetVelocity,ref velocity, .05f);
    }
    void Jump()
    {
        rb.velocity = Vector2.up * jumpForce;
        StartCoroutine(effet());
    }
    public IEnumerator effet()
    {
        animator.SetBool("Jjump",true);
        yield return new WaitForSeconds(1f);
        animator.SetBool("Jjump",false);
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
        if ((Input.GetKeyDown(KeyCode.UpArrow) || (Input.GetKeyDown(KeyCode.DownArrow)) && c == 0))
        {
            c++;
            yield return new WaitForSeconds(1f);
            instru.enabled = false;
        }
    }

}
