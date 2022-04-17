using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;
using UnityEngine.SceneManagement;


public class EndCredits : MonoBehaviour
{
    //Get the end credits to load the title screen once the animation is complete. There has to be a better way. 
    [SerializeField] Animator anim;
    [SerializeField] Light2D globalLight;
    [SerializeField] Light2D bunLight;
    private float duration = 1f;
    

    // Update is called once per frame
    void Update()
    {
        if(anim.GetCurrentAnimatorStateInfo(0).normalizedTime > 1)
        {
            Messenger.Broadcast(GameEvent.CREDITS_OVER);
         
        }
    }
   
}
