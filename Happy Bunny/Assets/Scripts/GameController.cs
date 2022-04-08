using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    private int numOfHuggies = 2;
    private GameObject[] bundleOfHuggies;
    [SerializeField] private GameObject huggyPrefab;
    private GameObject huggy;
    [SerializeField] UIManager ui; 
    // Start is called before the first frame update
    private void Awake()
    {
        Messenger.AddListener(GameEvent.PLAYER_DEATH, OnPlayerDeath);
       
    }

    private void OnDestroy()
    {
        Messenger.RemoveListener(GameEvent.PLAYER_DEATH, OnPlayerDeath);
    }

    void OnPlayerDeath()
    {
        Debug.Log("died");
        ui.ShowGameOverPopUp();
        PauseGamePlay();
    }
   void PauseGamePlay()
    {
        Time.timeScale = 0;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

    }
    void Start()
    {
        bundleOfHuggies = new GameObject[numOfHuggies];
        for(int i = 0; i < numOfHuggies; i++)
        {
            huggy = Instantiate(huggyPrefab) as GameObject;
            bundleOfHuggies[i] = huggy;
            //float randomAngle = Random.Range(0f, 6.28319f);
            huggy.transform.position = new Vector2(Random.Range(0, 10), Random.Range(0, 10));
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
