using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;
using UnityEngine.SceneManagement;


public class TitleScreen : MonoBehaviour
{
    public void OnStartButton()
    {
         Messenger.Broadcast(GameEvent.START);
       
    }
    public void OnExitButton()
    {
        Application.Quit();
    }
   
 }
