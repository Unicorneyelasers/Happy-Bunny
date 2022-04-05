using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;
public class LightChange : MonoBehaviour
{
    [SerializeField] Light2D bunLight;
    // Start is called before the first frame update
    void Start()
    {
       // bunLight.intensity = 5;
    }
    
    // Update is called once per frame
    void Update()
    {
        //bunLight.intensity = Mathf.PingPong(Time.time, 8);

    }

    void OnCollisionEnter2D(Collision2D other)
    {
       // bunLight.intensity = bunLight.intensity - 1; 
    }

}
