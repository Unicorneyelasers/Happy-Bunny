using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField] GameOverPopUp gameOverPopUp;
    [SerializeField] ExitGamePopUp exitGamePopUp;
    // Start is called before the first frame update
    void Start()
    {
        
    }
   public void ShowGameOverPopUp()
    {
        gameOverPopUp.Open();
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            exitGamePopUp.Open();
        }
    }
}
