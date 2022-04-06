using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HuggyMovement : MonoBehaviour
{
    private float moveSpeed = 0.3f;
    public Vector3 dir;
    private float turnSpeed = 0.0f;
    float targetAngle;
    Vector3 currentPos;
    bool play = true;
    Vector3 direction;
    void Start()
    {
        dir = Vector3.up;
        InvokeRepeating("Start1", 0f, 5f);
    }
    void Start1()
    {
        play = true;
        direction = new Vector3(Random.Range(-3.0f, 3.0f), Random.Range(-4.0f, 4.0f), 0); //random position in x and y
    }
    void Update()
    {
        currentPos = transform.position;//current position of gameObject
        if (play)
        { //calculating direction
            dir = direction - currentPos;

            dir.z = 0;
            dir.Normalize();
            transform.Rotate(Vector3.up, 180);
            play = false;
        }
        Vector3 target = dir * moveSpeed + currentPos;  //calculating target position
       // Debug.Log("this is x > " + dir.x);
        //Debug.Log("this is y > " + dir.y);
        transform.position = Vector3.Lerp(currentPos, target, Time.deltaTime);//movement from current position to target position
        targetAngle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg - 90; //angle of rotation of gameobject
       // transform.Rotate(Vector3.up, 180); //THIS makes him flip around fast. kinda creepy. Might keep
        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(0, 0, targetAngle), turnSpeed * Time.deltaTime); //rotation from current direction to target direction
    }
   private void OnCollisionEnter2D()
    {

        CancelInvoke();//stop call to start1 method
        direction = new Vector3(Random.Range(-3.0f, 3.0f), Random.Range(-4.0f, 4.0f), 0); //again provide random position in x and y
        play = true;

    }
    private void OnCollisionExit2D()
    {
        InvokeRepeating("Start1", 2f, 5f);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log(this + ".TriggerEnter2D() collided with " + collision.gameObject.name);
       if(collision.gameObject.name == "Player")
        {
            PlayerContoller player = collision.gameObject.GetComponent<PlayerContoller>();
            player.DimPlayerLight();
        }
       
    }
   
  
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("something triggered");
    }

}
