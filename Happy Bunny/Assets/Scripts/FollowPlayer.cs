using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    [SerializeField] Transform target;
    public float speed = 4f;
    [SerializeField] Rigidbody2D rbody;
    private bool facingLeft = false;
    public float attackRangePos = 6f;
    public float attackRangeNeg = -6f;
    private float distanceapart;
    void Start()
    {

    }
    void Flip()
    {
        facingLeft = !facingLeft;
        transform.Rotate(Vector3.up, 180);
    }
    void FixedUpdate()
    {

        distanceapart = target.position.x - rbody.position.x;
      //  Debug.Log(distanceapart);
      
   
            if(distanceapart >= attackRangeNeg)
            {
                Vector2 pos = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
                rbody.MovePosition(pos);
                if (((rbody.position.x < target.position.x) && (!facingLeft)) ||
                     ((rbody.position.x > target.position.x) && (facingLeft)))
                {
                    Flip();
                }
            }
        void OnTriggerEnter2D(Collider2D collision)
        {
            Debug.Log(this.gameObject + ".TriggerEnter2D() collided with " + collision.gameObject.name);
            if (collision.gameObject.name == "Player")
            {
                PlayerContoller player = collision.gameObject.GetComponent<PlayerContoller>();

                player.DimPlayerLight();


            }
        }
            //else if( distanceapart > 0)
            //{
            //    if(distanceapart >= attackRangePos)
            //    {
            //        Vector2 pos = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
            //        rbody.MovePosition(pos);
            //        if (((rbody.position.x < target.position.x) && (!facingLeft)) ||
            //             ((rbody.position.x > target.position.x) && (facingLeft)))
            //        {
            //            Flip();
            //        }
            //    }
            //}
            // Vector2 pos = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
            // rbody.MovePosition(pos);
            //if(((rbody.position.x < target.position.x) && (!facingLeft)) || 
            //     ((rbody.position.x > target.position.x) && (facingLeft)))
            // {
            //     Flip();
            // }
            // Debug.Log("Spider: " + rbody.position);
            //transform.LookAt(target);
            // Debug.Log("Player: " + target.position);
        }
    
}