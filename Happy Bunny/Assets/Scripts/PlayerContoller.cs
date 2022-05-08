using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;
using UnityEngine.UI;

public class PlayerContoller : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rbody;
    [SerializeField] Animator anim;
    private float horizInput;
    private float moveSpeed = 200.0f;
    private float jumpHeight = 1f;
    private float jumpTime = 0.75f;
    private float initialJumpVelocity;
    private bool isGrounded = false;
    [SerializeField] private Transform groundCheckPoint;
    [SerializeField] private LayerMask groundLayerMask;
    private float groundCheckRadius = 0.03f;
    [SerializeField] private Canvas gameOver;
    private bool isAlive = true;
    private bool facingLeft = false;
    private Vector3 respawnPt; 
    [SerializeField] Light2D bunLight;

    public float maxLight = 1f;

    private float lightAmount = 0.25f;
    // Start is called before the first frame update
    void Start()
    {
        float timeToApex = jumpTime / 2.0f;
        float gravity = (-2 * jumpHeight) / Mathf.Pow(timeToApex, 2);
       
        rbody.gravityScale = gravity / Physics2D.gravity.y;
        initialJumpVelocity = Mathf.Sqrt(jumpHeight * -2 * gravity);
        respawnPt = transform.position;
        bunLight.intensity = maxLight;
        isGrounded = true;
    }
    void Jump()
    {
        rbody.velocity = new Vector2(rbody.velocity.x, initialJumpVelocity);
        anim.SetTrigger("jump");
    }
    void Die()
    {
        if (anim.GetCurrentAnimatorStateInfo(0).IsName("player_death") && anim.GetCurrentAnimatorStateInfo(0).normalizedTime > 1)// && anim.IsInTransition(0))
        {
            isAlive = false;
            Debug.Log("death animation should be comeplete");
            Messenger.Broadcast(GameEvent.PLAYER_DEATH);
        }
       
    }
    // Update is called once per frame
    void Update()
    {
        if (isAlive)
        {
            //Debug.Log("bun is alive");
            isGrounded = Physics2D.OverlapCircle(groundCheckPoint.position, groundCheckRadius, groundLayerMask) && rbody.velocity.y < 0.01;
            if (Input.GetButtonDown("Jump") && isGrounded)
            {
                Debug.Log("jump");
                Jump();
            }

            bool hasLight = (maxLight > 0);
            anim.SetBool("hasLight", hasLight);
            //isGrounded = Physics2D.OverlapCircle(groundCheckPoint.position, groundCheckRadius, groundLayerMask) && rbody.velocity.y < 0.01;
            horizInput = Input.GetAxis("Horizontal");
            bool isRunning = horizInput > 0.01 || horizInput < -0.01;
            anim.SetBool("isRunning", isRunning);
           // isGrounded = Physics2D.OverlapCircle(groundCheckPoint.position, groundCheckRadius, groundLayerMask) && rbody.velocity.y < 0.01;
            anim.SetBool("isGrounded", isGrounded);
            if ((!hasLight) && isGrounded && isAlive)
            {


                Die();

            }

            if ((facingLeft && horizInput < -0.01) ||
              (!facingLeft && horizInput > 0.01))
            {
                Flip();
            }
        }
    }
    public void Respawn()
    {
        transform.position = respawnPt;
    }
   private void UpdateMaxHealth()
    {
        maxLight = bunLight.intensity;
    }
    public void DimPlayerLight()
    {
        Debug.Log(maxLight);
        Debug.Log(bunLight.intensity);
        bunLight.intensity = bunLight.intensity - lightAmount;
        UpdateMaxHealth();
       
    }
   public void IncreasePlayerLight()
    {
        bunLight.intensity = bunLight.intensity + lightAmount;
        UpdateMaxHealth();
    }
    void Flip()
    {
        // flip the direction the player is facing
        facingLeft = !facingLeft;
        transform.Rotate(Vector3.up, 180);
    }
    private void FixedUpdate()
    {
        float xVel = horizInput * moveSpeed * Time.deltaTime;
        rbody.velocity = new Vector2(xVel, rbody.velocity.y);
    }
    private void OnDrawGizmos()
    {
        Gizmos.DrawSphere(groundCheckPoint.position, groundCheckRadius);
    }
    private void OnParticleCollision(GameObject other)
    {
        // Debug.Log("this is other > "  + other + " and this is gameobject this >" + this);
        DimPlayerLight();

    }
    IEnumerator waitForAnimation(float seconds, Canvas gameOver)
    {
        Debug.Log("wait for animation");
        yield return new WaitForSeconds(seconds);
        gameOver.gameObject.SetActive(true);
    }
}
