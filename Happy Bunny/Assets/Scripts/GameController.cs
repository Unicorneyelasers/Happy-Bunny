using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    private int numOfHuggies = 1;
    private GameObject[] bundleOfHuggies;
    [SerializeField] private GameObject huggyPrefab;
    private GameObject huggy;
    // Start is called before the first frame update
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
