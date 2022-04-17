using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpHealth : MonoBehaviour
{
  // [SerializeField] AudioSource source;
   [SerializeField] AudioClip clip;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log(this.gameObject + ".TriggerEnter2D() collided with " + collision.gameObject.name);
        if (collision.gameObject.name == "Player")
        {
            PlayerContoller player = collision.gameObject.GetComponent<PlayerContoller>();
           
            if (player.maxLight < 1)
            {
                player.IncreasePlayerLight();
                //source.PlayOneShot(clip);
                // source.Play();
                AudioSource.PlayClipAtPoint(clip, transform.position);
                //Debug.Log("at least we are in the sound thing");
               // Destroy(this.source);
                Destroy(this.gameObject);
                
            }
            
        }

    }
}
