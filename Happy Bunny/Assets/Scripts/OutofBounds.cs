using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OutofBounds : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    IEnumerator RespawnAfterDelay(float respawnTime, PlayerContoller player)
    {
        yield return new WaitForSeconds(respawnTime);
        player.Respawn();
    }
    private void OnTriggerExit2D(Collider2D other)
    {
       // Debug.Log(other.gameObject.name + "fell out");
        if (other.gameObject.name == "Player")
        {
           // Debug.Log("fell out of world");
            PlayerContoller player = other.gameObject.GetComponent<PlayerContoller>();
            StartCoroutine(RespawnAfterDelay(1.5f, player));
            player.DimPlayerLight();
            //player.Respawn();
            //Destroy(other.gameObject);
            //Debug.Log(this + "fell out");
        }
    }
}
