using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;

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

    private bool facingLeft = false;
    private Vector3 respawnPt; 
    [SerializeField] Light2D bunLight;

    public float maxLight = 1f;

    private float lightAmount = 0.3f;
    // Start is called before the first frame update
    void Start()
    {
        float timeToApex = jumpTime / 2.0f;
        float gravity = (-2 * jumpHeight) / Mathf.Pow(timeToApex, 2);
       
        rbody.gravityScale = gravity / Physics2D.gravity.y;
        initialJumpVelocity = Mathf.Sqrt(jumpHeight * -2 * gravity);
        respawnPt = transform.position;
        bunLight.intensity = maxLight;
    }
    void Jump()
    {
        rbody.velocity = new Vector2(rbody.velocity.x, initialJumpVelocity);
        anim.SetTrigger("jump");
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            Jump();
        }
        horizInput = Input.GetAxis("Horizontal"); 
        bool isRunning = horizInput > 0.01 || horizInput < -0.01;
        anim.SetBool("isRunning", isRunning);
        isGrounded = Physics2D.OverlapCircle(groundCheckPoint.position, groundCheckRadius, groundLayerMask) && rbody.velocity.y < 0.01;
        anim.SetBool("isGrounded", isGrounded);

        if ((facingLeft && horizInput < -0.01) ||
          (!facingLeft && horizInput > 0.01))
        {
            Flip();
        }
    }
    public void Respawn()
    {
        transform.position = respawnPt;
    }
   
    public void DimPlayerLight()
    {
        
        bunLight.intensity = bunLight.intensity - lightAmount;
        maxLight = maxLight - lightAmount;
       
    }
   public void IncreasePlayerLight()
    {
        bunLight.intensity = bunLight.intensity + lightAmount;
        maxLight = maxLight + lightAmount;
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
}
