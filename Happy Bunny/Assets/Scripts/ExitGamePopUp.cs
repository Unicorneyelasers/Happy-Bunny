using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class ExitGamePopUp : BasePopUp
{
   public void OnExitGameButton()
    {
        Debug.Log("Exit button pressed");

        Application.Quit();
    }

    public void OnReturnToGAme()
    {
        Close();
    }
    public void OnReloadLevel()
    {
        SceneManager.LoadScene(2);
    }
}
