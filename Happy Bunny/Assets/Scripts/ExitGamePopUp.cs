using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
}
