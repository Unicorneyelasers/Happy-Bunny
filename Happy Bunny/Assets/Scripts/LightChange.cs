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
        
    }

    // Update is called once per frame
    void Update()
    {
        bunLight.intensity = Mathf.PingPong(Time.time, 8);
    }
}
