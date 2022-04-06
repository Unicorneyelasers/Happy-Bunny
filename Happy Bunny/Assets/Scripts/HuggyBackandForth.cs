using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HuggyBackandForth : MonoBehaviour
{
    // Start is called before the first frame update
    private float topSpeed = 3.0f;
   // [SerializeField] private GameObject huggyPrefab;
   // [SerializeField] Animator anim;
    private bool facingRight = true;
    private float min;
    private float max;
    // Use this for initialization
    void Start()
    {

        min = transform.position.x;
        max = transform.position.x + 15;
        StartCoroutine(HuggyCoroutine());
    }

    // Update is called once per frame
    void Update()
    {

       
        transform.position = new Vector3(Mathf.PingPong(Time.time * 2, max - min) + min, transform.position.y, transform.position.z);
        StartCoroutine(HuggyCoroutine());
    }
    IEnumerator HuggyCoroutine()
    {
        yield return new WaitForSeconds(5);
        
    }

    //transform.Translate(0, 0, topSpeed * Time.deltaTime);


}
