using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
public class FadeOut : MonoBehaviour
{
    //Fade Out is the class that fades the starting text. There has to be a better way. 
    private float duration = 3f;
    [SerializeField] TextMeshProUGUI text;
    void Start()
    {
        StartCoroutine(FadeCoroutine());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    IEnumerator FadeCoroutine()
    {
        float waitTime = 0;
        while (waitTime < 1)
        {
            text.fontMaterial.SetColor("_FaceColor", Color.Lerp(Color.black, Color.white, waitTime));
            yield return null;
            waitTime += Time.deltaTime / duration;

        }
        float outTime = 0;
        while (outTime < 1)
        {
            text.fontMaterial.SetColor("_FaceColor", Color.Lerp(Color.white, Color.black, outTime));
            yield return null;
            outTime += Time.deltaTime / (duration-1);
           // print(outTime);
        }
        if (outTime >= 1)
        {
            SceneManager.LoadScene(2);
        }

    }
}
