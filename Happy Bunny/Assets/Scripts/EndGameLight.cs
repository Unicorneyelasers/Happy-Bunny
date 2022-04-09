using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndGameLight : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
       
        if (collision.gameObject.name == "Player")
        {
            //PlayerContoller player = collision.gameObject.GetComponent<PlayerContoller>();
            //player.DimPlayerLight();
            Debug.Log("Bun touched the light");
            Messenger.Broadcast(GameEvent.ENDING_REACHED);
        }

    }
}
