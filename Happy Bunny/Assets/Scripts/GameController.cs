using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;
using UnityEngine.SceneManagement;


public class GameController : MonoBehaviour
{
    private int numOfHuggies = 2;
    private GameObject[] bundleOfHuggies;
    [SerializeField] private GameObject huggyPrefab;
    private GameObject huggy;
    [SerializeField] UIManager ui;
    [SerializeField] Light2D globalLight;
    [SerializeField] Light2D bunLight;
    [SerializeField] Light2D tunnelLight;
  
    private float duration = 2f;
    // Start is called before the first frame update
    private void Awake()
    {
        Messenger.AddListener(GameEvent.PLAYER_DEATH, OnPlayerDeath);
        Messenger.AddListener(GameEvent.ENDING_REACHED, OnEndingReached);
       
    }

    private void OnDestroy()
    {
        Messenger.RemoveListener(GameEvent.PLAYER_DEATH, OnPlayerDeath);
        Messenger.RemoveListener(GameEvent.ENDING_REACHED, OnEndingReached);
    }

    void OnEndingReached()
    {
        
        Debug.Log("Heard ending reached");
        StartCoroutine(FadeCoroutine());
    }
    IEnumerator FadeCoroutine()
    {
        float outTime = 0;
        while (outTime < 1)
        {
            globalLight.intensity = Mathf.Lerp(globalLight.intensity, 0, outTime);
            tunnelLight.intensity = Mathf.Lerp(tunnelLight.intensity, 0, outTime);
            bunLight.intensity = Mathf.Lerp(bunLight.intensity, 0, outTime);
            yield return null;
            outTime += Time.deltaTime / duration;
            // print(outTime);
        }
        if (outTime >= 1)
        {
            SceneManager.LoadScene(2);
        }
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
